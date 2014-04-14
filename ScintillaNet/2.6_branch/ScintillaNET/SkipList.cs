// The original code came from http://igoro.com/archive/skip-lists-are-fascinating/,
// However, it barely resembles it anymore.
// I retrieved and made the intial version of this March 17, 2011.
// Last modified: March 18, 2011.
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Searching
{
    public class SkipList
    {

        #region Properties
        protected Node _head = new Node(new byte[] { }, 33);
        /// <summary>
        /// The main node that the rest of the list is based on.
        /// </summary>
        public Node Head
        {
            get
            {
                return _head;
            }
        }
        protected Random _rand = new Random();
        public Random Random
        {
            get
            {
                return _rand;
            }
        }
        protected int _levels = 1;
        /// <summary>
        /// An Int32 representing how deep the list is.
        /// </summary>
        public int Levels
        {
            get
            {
                return _levels;
            }
        }

#if !RELEASE
        public List<string> Items = new List<string>();
#endif
        #endregion

        #region Constructors

        public SkipList()
        {
            _head = new Node(new byte[] { }, 33);
            _rand = new Random();
            _levels = 1;
        }

        public SkipList(IEnumerable<String> list)
        {
            foreach (string s in list)
            {
                this.Add(s);
            }
        }

        #endregion

        #region Conversions

        static public explicit operator object[](SkipList list)
        {
            List<string> lst = list;
            return ((object[])lst.ToArray());
        }

        static public implicit operator string[](SkipList list)
        {
            List<string> lst = list;
            return lst.ToArray();
        }

        static public implicit operator List<String>(SkipList list)
        {
            List<String> lst = new List<String>();
            Node cur = list._head.Next[0];
            while (cur != null)
            {
                lst.Add(ASCIIEncoding.Unicode.GetString(cur.Value));
                cur = cur.Next[0];
            }
            return lst;
        }

        public string this[int index]
        {
            get
            {
                Int32 currentLoc = 0;
                Node SelectedItem = _head.Next[0];
                while (currentLoc < index)
                {
                    SelectedItem = SelectedItem.Next[0];
                    currentLoc++;
                }
                if (SelectedItem == null)
                {
                    return "";
                }
                try
                {
                    return ASCIIEncoding.Unicode.GetString(SelectedItem.Value);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                Int32 currentLoc = 0;
                Node SelectedItem = _head.Next[0];
                while (currentLoc < index)
                {
                    SelectedItem = SelectedItem.Next[0];
                    currentLoc++;
                }
                SelectedItem.Value = ASCIIEncoding.Unicode.GetBytes(value);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds a value to the skip list.
        /// </summary>
        public void Add(string value)
        {
            this.Insert(value);
        }

        /// <summary>
        /// Adds a range of values to the skip list
        /// </summary>
        /// <param name="collection">The collection of values to add</param>
        public void AddRange(IEnumerable<string> collection)
        {
            foreach (string s in collection)
            {
                this.Insert(s);
            }
        }

        /// <summary>
        /// Inserts a value into the skip list.
        /// </summary>
        public void Insert(string value)
        {
            Items.Add(value);
            byte[] value2 = ASCIIEncoding.Unicode.GetBytes(value);
            int level = 0;
            for (int R = _rand.Next(); (R & 1) == 1; R >>= 1)
            {
                level++;
                if (level == _levels)
                {
                    _levels++;
                    break;
                }
            }
            Node newNode = new Node(value2, level + 1);
            Node cur = _head;
            for (int i = _levels - 1; i >= 0; i--)
            {
                for (; cur.Next[i] != null; cur = cur.Next[i])
                {
                    if (ArrayGreaterThan(cur.Next[i].Value, value2))
                    {
                        break;
                    }
                }

                if (i <= level)
                {
                    newNode.Next[i] = cur.Next[i];
                    cur.Next[i] = newNode;
                }
            }
        }

        public void Clear()
        {
            _head = new Node(new byte[] { }, 33);
            _rand = new Random();
            _levels = 1;
        }

        /// <summary>
        /// Returns whether a particular value already exists in the skip list
        /// </summary>
        public bool Contains(string value)
        {
            byte[] value2 = ASCIIEncoding.Unicode.GetBytes(value);
            for (int i = _levels - 1; i >= 0; i--)
            {
                for (Node cur = _head; cur.Next[i] != null; cur = cur.Next[i])
                {
                    if (ArraysEqual(cur.Next[i].Value, value2))
                    {
                        return true;
                    }

                    if (ArrayGreaterThan(cur.Next[i].Value, value2))
                    {
                        break;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Removes all strings not starting with the specified string.
        /// </summary>
        public SkipList RemoveNonMatchingStartString(string startString)
        {
            foreach (string item in this)
            {
                // If the item is shorter than the specified string, remove it
                if (item.Length < startString.Length)
                {
                    this.Remove(item);
                }
                else
                {
                    int len = startString.Length;
                    string thistr = item.Substring(0, len);
                    if (thistr != startString)
                    {
                        this.Remove(item);
                    }
                }
            }

            return this;
        }

        public List<String> GetList()
        {
            List<String> lst = new List<string>();
            foreach (String item in this)
            {
                lst.Add(item);
            }
            return lst;
        }

        /// <summary>
        /// Removes all strings past a specified length.
        /// </summary
        /// <returns>Returns the number of items removed.</returns>
        public int TruncateLargerThan(int length)
        {
            int NumberOfItemsRemoved = 0;
            foreach (string item in this)
            {
                if (item.Length > length)
                {
                    this.Remove(item);
                    NumberOfItemsRemoved++;
                }
            }
            return NumberOfItemsRemoved;
        }

        /// <summary>
        /// Attempts to remove one occurrence of a particular value from the skip list. Returns
        /// whether the value was found in the skip list.
        /// </summary>
        public bool Remove(string value)
        {
            byte[] value2 = ASCIIEncoding.Unicode.GetBytes(value);

            bool found = false;
            for (int i = _levels - 1; i >= 0; i--)
            {
                for (Node cur = _head; cur.Next[i] != null; cur = cur.Next[i])
                {
                    if (ArraysEqual(cur.Next[i].Value, value2))
                    {
                        found = true;
                        cur.Next[i] = cur.Next[i].Next[i];
                        break;
                    }

                    if (ArrayGreaterThan(cur.Next[i].Value, value2))
                    {
                        break;
                    }
                }
            }

            return found;
        }

        #endregion

        #region IEnumerators

        public IEnumerator<String> GetEnumerator()
        {
            Node cur = _head.Next[0];
            while (cur != null)
            {
                yield return ASCIIEncoding.Unicode.GetString(cur.Value);
                cur = cur.Next[0];
            }
        }

        #endregion

        #region ByteArrayComparers

        protected bool ArraysEqual(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }
            Int32 curlen = 0;
            foreach (byte b in firstArray)
            {
                if (b != secondArray[curlen])
                {
                    return false;
                }
                curlen++;
            }
            return true;
        }

        protected int ArraysEqualSpecial(byte[] firstArray, byte[] secondArray)
        {
            int comp = 0;
            if (firstArray.Length > secondArray.Length)
            {
                comp = 2;
            }
            if (secondArray.Length > firstArray.Length)
            {
                comp = 1;
            }
            Int32 curlen = 0;

            if (comp == 1)
            {
                curlen = 0;
                foreach (byte b in firstArray)
                {
                    if (b != secondArray[curlen])
                    {
                        return 3;
                    }
                    curlen++;
                }
                return 1;
            }
            if (comp == 2)
            {
                curlen = 0;
                foreach (byte b in secondArray)
                {
                    if (b != firstArray[curlen])
                    {
                        return 3;
                    }
                    curlen++;
                }
                return 2;
            }
            if (comp == 0)
            {
                curlen = 0;
                foreach (byte b in firstArray)
                {
                    if (b != secondArray[curlen])
                    {
                        return 3;
                    }
                    curlen++;
                }
                return 0;
            }
            return 0;
        }

        protected bool ArrayGreaterThan(byte[] firstArray, byte[] secondArray)
        {
            bool greaterThan = true;
            Int32 currentLoc = 0;

            if (ArraysEqualSpecial(firstArray, secondArray) == 1)
            {
                // This means that the second array is longer than the first one
                // However, up to the length of the first array they are equal
                // Since nothing comes before something, this means that
                // The array should be counted as less than
                return false;
            }
            else if (ArraysEqualSpecial(firstArray, secondArray) == 2)
            {
                // This means that the first array is longer than the second one
                // However, up to the length of the second array they are equal
                // Since nothing comes before something, this means that
                // The array should be counted as greater than
                return true;
            }

            foreach (byte b in firstArray)
            {
                try
                {
                    if (b != secondArray[currentLoc])
                    {
                        if (b > secondArray[currentLoc])
                        {
                            greaterThan = true;
                            break;
                        }
                        else if (b < secondArray[currentLoc])
                        {
                            greaterThan = false;
                            break;
                        }
                    }
                    else
                    {
                        currentLoc++;
                    }
                }
                catch
                {
                    greaterThan = false;
                    break;
                }
            }

            return greaterThan;
        }
        #endregion

        #region SupportClasses
        public class Node
        {
            private Node[] next;
            public Node[] Next
            {
                get
                {
                    return this.next;
                }
                private set
                {
                    this.next = value;
                }
            }
            private byte[] value;
            public byte[] Value
            {
                get
                {
                    return value;
                }
                set
                {
                    this.value = value;
                }
            }

            public Node(byte[] value, int level)
            {
                this.value = value;
                this.next = new Node[level];
            }
        }
        #endregion
    }
}