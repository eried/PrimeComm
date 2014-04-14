using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Searching;

namespace ScintillaNet
{
	/// <summary>
	/// Used to invoke AutoComplete and UserList windows. Also manages AutoComplete
	/// settings.
	/// </summary>
	/// <remarks>
	/// Autocomplete is typically used in IDEs to automatically complete some kind
	/// of identifier or keyword based on a partial name. 
	/// </remarks>
	[TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
	public class AutoComplete : TopLevelHelper
    {
		
        #region BuiltInImages
        /// <summary>
        /// If the location of the DefaultImages class gets changed, 
        /// this needs to be changed as well, to point to the new location. (FQN)
        /// </summary>
        internal const string DefaultImagesClassLocation = "ScintillaNet.AutoComplete.DefaultImages";
        public class DefaultImages
        {
            public static readonly Bitmap Keyword = new Bitmap(global::ScintillaNet.Properties.Resources.Keyword);
            public static readonly Bitmap Snippet = new Bitmap(global::ScintillaNet.Properties.Resources.CodeSnippet);
            
            public static readonly Bitmap PrivateClass = new Bitmap(global::ScintillaNet.Properties.Resources.PrivClass);
            public static readonly Bitmap PrivateDelegate = new Bitmap(global::ScintillaNet.Properties.Resources.PrivDelegate);
            public static readonly Bitmap PrivateEnum = new Bitmap(global::ScintillaNet.Properties.Resources.PrivEnum);
            public static readonly Bitmap PrivateEvent = new Bitmap(global::ScintillaNet.Properties.Resources.privevent);
            public static readonly Bitmap PrivateExtension = new Bitmap(global::ScintillaNet.Properties.Resources.privextension);
            public static readonly Bitmap PrivateField = new Bitmap(global::ScintillaNet.Properties.Resources.privfield);
            public static readonly Bitmap PrivateInterface = new Bitmap(global::ScintillaNet.Properties.Resources.privinterface);
            public static readonly Bitmap PrivateMethod = new Bitmap(global::ScintillaNet.Properties.Resources.privmethod);
            public static readonly Bitmap PrivateProperty = new Bitmap(global::ScintillaNet.Properties.Resources.privproperty);
            public static readonly Bitmap PrivateStructure = new Bitmap(global::ScintillaNet.Properties.Resources.privstructure);

            public static readonly Bitmap ProtectedClass = new Bitmap(global::ScintillaNet.Properties.Resources.protclass);
            public static readonly Bitmap ProtectedDelegate = new Bitmap(global::ScintillaNet.Properties.Resources.protdelegate);
            public static readonly Bitmap ProtectedEnum = new Bitmap(global::ScintillaNet.Properties.Resources.protenum);
            public static readonly Bitmap ProtectedEvent = new Bitmap(global::ScintillaNet.Properties.Resources.protevent);
            public static readonly Bitmap ProtectedExtension = new Bitmap(global::ScintillaNet.Properties.Resources.protextension);
            public static readonly Bitmap ProtectedField = new Bitmap(global::ScintillaNet.Properties.Resources.protfield);
            public static readonly Bitmap ProtectedInterface = new Bitmap(global::ScintillaNet.Properties.Resources.protinterface);
            public static readonly Bitmap ProtectedMethod = new Bitmap(global::ScintillaNet.Properties.Resources.protmethod);
            public static readonly Bitmap ProtectedOperator = new Bitmap(global::ScintillaNet.Properties.Resources.protoperator);
            public static readonly Bitmap ProtectedProperty = new Bitmap(global::ScintillaNet.Properties.Resources.protproperty);
            public static readonly Bitmap ProtectedStructure = new Bitmap(global::ScintillaNet.Properties.Resources.protstructure);

            public static readonly Bitmap PublicClass = new Bitmap(global::ScintillaNet.Properties.Resources.pubclass);
            public static readonly Bitmap PublicDelegate = new Bitmap(global::ScintillaNet.Properties.Resources.pubdelegate);
            public static readonly Bitmap PublicEnum = new Bitmap(global::ScintillaNet.Properties.Resources.pubenum);
            public static readonly Bitmap PublicEvent = new Bitmap(global::ScintillaNet.Properties.Resources.pubevent);
            public static readonly Bitmap PublicExtension = new Bitmap(global::ScintillaNet.Properties.Resources.pubextension);
            public static readonly Bitmap PublicField = new Bitmap(global::ScintillaNet.Properties.Resources.pubfield);
            public static readonly Bitmap PublicInterface = new Bitmap(global::ScintillaNet.Properties.Resources.pubinterface);
            public static readonly Bitmap PublicMethod = new Bitmap(global::ScintillaNet.Properties.Resources.pubmethod);
            public static readonly Bitmap PublicOperator = new Bitmap(global::ScintillaNet.Properties.Resources.puboperator);
            public static readonly Bitmap PublicProperty = new Bitmap(global::ScintillaNet.Properties.Resources.pubproperty);
            public static readonly Bitmap PublicStructure = new Bitmap(global::ScintillaNet.Properties.Resources.pubstructure);
        }
        #endregion

        internal AutoComplete(Scintilla scintilla) : base(scintilla)
		{
            scintilla.CharAdded += new EventHandler<CharAddedEventArgs>(scintilla_CharAdded);
            scintilla.KeyDown += new KeyEventHandler(scintilla_KeyDown);
            scintilla.AutoCompleteAccepted += new EventHandler<AutoCompleteAcceptedEventArgs>(scintilla_AutoCompleteAccepted);
        	RegisterImage(1, DefaultImages.PrivateClass);
        	RegisterImage(2, DefaultImages.PrivateEnum);
        	RegisterImage(3, DefaultImages.PrivateEvent);
        	RegisterImage(4, DefaultImages.PrivateExtension);
        	RegisterImage(5, DefaultImages.PrivateField);
        	RegisterImage(6, DefaultImages.PrivateInterface);
        	RegisterImage(7, DefaultImages.PrivateMethod);
        	RegisterImage(9, DefaultImages.PrivateProperty);
        	RegisterImage(10, DefaultImages.PrivateStructure);
        	RegisterImage(11, DefaultImages.ProtectedClass);
        	RegisterImage(12, DefaultImages.ProtectedDelegate);
        	RegisterImage(13, DefaultImages.ProtectedEnum);
        	RegisterImage(14, DefaultImages.ProtectedEvent);
        	RegisterImage(15, DefaultImages.ProtectedExtension);
        	RegisterImage(16, DefaultImages.ProtectedField);
        	RegisterImage(17, DefaultImages.ProtectedInterface);
        	RegisterImage(18, DefaultImages.ProtectedMethod);
        	RegisterImage(19, DefaultImages.ProtectedOperator);
        	RegisterImage(20, DefaultImages.ProtectedProperty);
        	RegisterImage(21, DefaultImages.ProtectedStructure);
        	RegisterImage(22, DefaultImages.PublicClass);
        	RegisterImage(23, DefaultImages.PublicDelegate);
        	RegisterImage(24, DefaultImages.PublicEnum);
        	RegisterImage(25, DefaultImages.PublicEvent);
        	RegisterImage(26, DefaultImages.PublicExtension);
        	RegisterImage(27, DefaultImages.PublicField);
        	RegisterImage(28, DefaultImages.PublicInterface);
        	RegisterImage(29, DefaultImages.PublicMethod);
        	RegisterImage(30, DefaultImages.PublicOperator);
        	RegisterImage(31, DefaultImages.PublicProperty);
            RegisterImage(32, DefaultImages.PublicStructure);
            RegisterImage(33, DefaultImages.Keyword);
            RegisterImage(34, DefaultImages.Snippet);
		}
        /// <summary>
        /// If the index for the snippet image is changed,
        /// please change this as well, otherwise the wrong
        /// image will display for a snippet.
        /// </summary>
        internal const int SnippetImageIndex = 34;

        /// <summary>
        /// This method is used to deal with what occurs when a user 
        /// selects a snippet in the auto-complete box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scintilla_AutoCompleteAccepted(object sender, AutoCompleteAcceptedEventArgs e)
        {
            if (Scintilla.Snippets.List.Contains(this.SelectedText))
            {
                // Trigger the snippet insertion.
                Scintilla.Snippets.InsertSnippet(this.SelectedText);
            }
        }

        #region EventHandlers
        void scintilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.IsActive)
            {
                if (e.KeyData == Keys.Back)
                {
                    int le = getLengthEntered();

                    if (le > 0)
                    {
                        // We need to make sure we aren't affecting the main list later on.
                        // and so we create a new SkipList from the one we're given.
                        SkipList usableList = new SkipList(_list.GetList());
                        StringBuilder strb = new StringBuilder();
                        int cop = 1;
                        while (le > (cop - 1))
                        {
                            strb.Append(NativeScintilla.GetCharAt(NativeScintilla.GetCurrentPos() - (cop + 1)));
                            cop++;
                        }
                        char[] arr = strb.ToString().ToCharArray();
                        Array.Reverse(arr);
                        String tmp = new string(arr);
                        SkipList srList = usableList.RemoveNonMatchingStartString(tmp.Substring(1));
                        String rList = getListString(srList);
                        NativeScintilla.AutoCSetCurList(rList);
                    }
                }
            }
        }

        void scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (this.IsActive)
            {
                int le = getLengthEntered();

                // We need to make sure we aren't affecting the main list later on.
                // and so we create a new SkipList from the one we're given.
                SkipList usableList = new SkipList(_list.GetList());
                StringBuilder strb = new StringBuilder();
                int cop = 1;
                while (le > (cop - 1))
                {
                    strb.Append(NativeScintilla.GetCharAt(NativeScintilla.GetCurrentPos() - cop));
                    cop++;
                }
                char[] arr = strb.ToString().ToCharArray();
                Array.Reverse(arr);
                String tmp = new string(arr);
                SkipList srList = usableList.RemoveNonMatchingStartString(tmp);
                String rList = getListString(srList);
                NativeScintilla.AutoCSetCurList(rList);
            }
            else
            {
                if (this.List[0] != "")
                {
                    if (ShouldTrigger(e.Ch))
                    {
                        this.Show();
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// This is the function that is used to determine if the 
        /// AutoComplete box should be automatically shown.
        /// </summary>
        /// <returns></returns>
        internal bool ShouldTrigger(Char newestChar)
        {
            String e = newestChar.ToString();
            int len = MaxTriggerCharLength;
            if (base.Scintilla.Text.Length >= len)
            {
                String baseString = base.Scintilla.Text.Substring(base.Scintilla.Selection.Start - len, len);
                foreach (String s in TriggerChars)
                {
                    if (s.Length <= baseString.Length)
                    {
                        if (s == baseString.Substring(0, s.Length))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal bool ShouldSerialize()
		{
			return ShouldSerializeAutoHide() ||
				ShouldSerializeCancelAtShowPoint() ||
				ShouldSerializeDropRestOfWord() ||
				ShouldSerializeFillUpCharacters() ||
				ShouldSerializeImageSeparator() ||
				ShouldSerializeIsCaseSensitive() ||
				ShouldSerializeListSeparator() ||
				ShouldSerializeMaxHeight() ||
				ShouldSerializeMaxWidth() ||
				ShouldSerializeSingleLineAccept() ||
				ShouldSerializeStopCharacters();
		}

        #region TriggerChars
        private int MaxTriggerCharLength = 0;
        private List<String> triggerChars = new List<String>();
        /// <summary>
        /// A list of the strings that will cause the AutoComplete window to show.
        /// </summary>
        public List<String> TriggerChars
        {
            get
            {
                foreach (String s in triggerChars)
                {
                    if (s.Length > MaxTriggerCharLength)
                    {
                        MaxTriggerCharLength = s.Length;
                    }
                }
                return triggerChars;
            }
            set
            {
                triggerChars = value;
                foreach (String s in triggerChars)
                {
                    if (s.Length > MaxTriggerCharLength)
                    {
                        MaxTriggerCharLength = s.Length;
                    }
                }
            }
        }
        #endregion

        #region List
        private SkipList _list = new SkipList();
		/// <summary>
		/// List of words to display in the AutoComplete window when invoked.
		/// </summary>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SkipList List
		{
           
			get
			{
				return _list;
			}
			set
            {
				if (value == null)
                    value = new SkipList();

            	_list = value;
            }
		}

		/// <summary>
		/// List of words to display in the AutoComplete window.
		/// </summary>
		/// <remarks>
		///  The list of words separated by <see cref="ListSeparator"/> which
		/// is " " by default.
		/// </remarks>
		public string ListString
		{
			get
			{
				return getListString(_list);
			}
			set
            {
                _list = new SkipList(value.Split(ListSeparator));
            }
		}

        private string getListString(SkipList list)
        {
            StringBuilder listString = new StringBuilder();
            foreach (string s in list)
            {
                listString.Append(s).Append(" ");
            }
            if (listString.Length > 1)
                listString.Remove(listString.Length - 1, 1);

            return listString.ToString().Trim();
        }
        #endregion

        #region Show
        /// <summary>
		/// Shows the autocomplete window.
		/// </summary>
		/// <param name="lengthEntered">Number of characters of the current word already entered in the editor </param>
		/// <param name="list">Sets the <see cref="ListString"/> property. </param>
		public void Show(int lengthEntered, string list)
		{
			if (list == string.Empty)
                _list = new SkipList();
			else
                _list = new SkipList(list.Split(ListSeparator));
			Show(lengthEntered, list, true);
		}

        internal void Show(int lengthEntered, SkipList list, bool dontSplit)
        {
            //	We may have the auto-detect of lengthEntered. In which case
            //	look for the last word character as the start
            int le = lengthEntered;
            if (le < 0)
                le = getLengthEntered();

			// We need to make sure we aren't affecting the main list later on.
			// and so we create a new SkipList from the one we're given.
			SkipList usableList = new SkipList(list.GetList());
            StringBuilder strb = new StringBuilder();
            int cop = 1;
            while(le > (cop - 1))
            {
                strb.Append(NativeScintilla.GetCharAt(NativeScintilla.GetCurrentPos() - cop));
                cop++;
            }
            SkipList srList = usableList.RemoveNonMatchingStartString(strb.ToString());
            String rList = getListString(srList);
            NativeScintilla.AutoCShow(le, rList);

            //	Now it may have been that the auto-detect lengthEntered
            //	caused to AutoCShow call to fail becuase no words matched
            //	the letters we autodetected. In this case just show the
            //	list with a 0 lengthEntered to make sure it will show
            if (!IsActive && lengthEntered < 0)
                NativeScintilla.AutoCShow(0, rList);
        }

        internal void Show(int lengthEntered, string list, bool dontSplit)
        {
            SkipList submittableList = new SkipList(list.Split(ListSeparator));
            Show(lengthEntered, submittableList, dontSplit);
        }

		/// <summary>
		/// Shows the autocomplete window.
		/// </summary>
		/// <remarks>
		/// This overload assumes that the <see cref="List"/> property has been
		/// set. The lengthEntered is automatically detected by the editor.
		/// </remarks>
		public void Show()
		{
			Show(-1, getListString(_list), false);
		}

		/// <summary>
		/// Shows the autocomplete window.
		/// </summary>
		/// <param name="list">Sets the <see cref="ListString"/> property. </param>
		/// <remarks>
		/// In this overload the lengthEntered is automatically detected by the editor.
		/// </remarks>
		public void Show(string list)
		{
			Show(-1, list);
		}

		private int getLengthEntered()
		{
			if (!_automaticLengthEntered)
				return 0;

			int pos = NativeScintilla.GetCurrentPos();
			return pos - NativeScintilla.WordStartPosition(pos, true);
		}

		/// <summary>
		/// Shows the autocomplete window
		/// </summary>
		/// <param name="lengthEntered">Number of characters of the current word already entered in the editor </param>
		/// <param name="list">Sets the <see cref="List"/> property. </param>
		public void Show(int lengthEntered, IEnumerable<string> list)
		{
            _list = new SkipList(list);
			Show(-1);
		}

		/// <summary>
		/// Shows the autocomplete window
		/// </summary>
		/// <param name="list">Sets the <see cref="List"/> property. </param>
		/// In this overload the lengthEntered is automatically detected by the editor.
		public void Show(IEnumerable<string> list)
		{
            _list = new SkipList(list);
			Show(-1);
		}

		/// <summary>
		/// Shows the autocomplete window
		/// </summary>
		/// <param name="lengthEntered">Number of characters of the current word already entered in the editor </param>
		/// <remarks>
		/// This overload assumes that the <see cref="List"/> property has been set.
		/// </remarks>
		public void Show(int lengthEntered)
		{
			Show(lengthEntered, getListString(_list), false);
        }


		#endregion

		#region ShowUserList
		/// <summary>
		/// Shows a UserList window
		/// </summary>
		/// <param name="listType">Index of the userlist to show. Can be any integer</param>
		/// <param name="list">List of words to show separated by " "</param>
		/// <remarks>
		/// UserLists are not as powerful as autocomplete but can be assigned to a user defined index.
		/// </remarks>
		public void ShowUserList(int listType, string list)
		{
			NativeScintilla.UserListShow(listType, list);
		}

		/// <summary>
		/// Shows a UserList window
		/// </summary>
		/// <param name="listType">Index of the userlist to show. Can be any integer</param>
		/// <param name="list">List of words to show.</param>
		/// <remarks>
		/// UserLists are not as powerful as autocomplete but can be assigned to a user defined index.
		/// </remarks>
		public void ShowUserList(int listType, IEnumerable<string> list)
		{
            string lst = getListString(new SkipList(list));
			Show(listType, lst, true);
		}
		#endregion

        #region Control
        /// <summary>
		/// Cancels the autocomplete window
		/// </summary>
		/// <remarks>
		/// If the AutoComplete window is displayed calling Cancel() will close the window. 
		/// </remarks>
		public void Cancel()
		{
			NativeScintilla.AutoCCancel();
		}

        /// <summary>
        /// Accepts the current AutoComplete window entry
        /// </summary>
        /// <remarks>
        /// If the AutoComplete window is open Accept() will close it. This also causes the
        /// <see cref="Scintilla.AutoCompleteAccepted" /> event to fire
        /// </remarks>
        public void Accept()
        {
            NativeScintilla.AutoCComplete();
        }

		/// <summary>
		/// Returns wether or not the AutoComplete window is currently displayed
		/// </summary>
		[Browsable(false)]
		public bool IsActive
		{
			get
			{
				return NativeScintilla.AutoCActive();
			}
		}

		/// <summary>
		/// Gets the document position when the AutoComplete window was last invoked
		/// </summary>
		[Browsable(false)]
		public int LastStartPosition
		{
			get
			{
				return NativeScintilla.AutoCPosStart();
			}
		}
        #endregion

        #region StopCharacters
        private string _stopCharacters = string.Empty;
		/// <summary>
		/// List of characters (no separator) that causes the AutoComplete window to cancel.
		/// </summary>
		public string StopCharacters
		{
			get
			{
				return _stopCharacters;
			}
			set
			{
				_stopCharacters = value;
				NativeScintilla.AutoCStops(value);
			}
		}

		private bool ShouldSerializeStopCharacters()
		{
			return _stopCharacters != string.Empty;
		}

		private void ResetStopCharacters()
		{
			_stopCharacters = string.Empty;
		} 
		#endregion

		#region ListSeparator
		/// <summary>
		/// Character used to split <see cref="ListString"/> to convert to a List.
		/// </summary>
		[TypeConverter(typeof(ScintillaNet.WhitespaceStringConverter))]
		public char ListSeparator
		{
			get
			{
				return NativeScintilla.AutoCGetSeparator();
			}
			set
			{
				NativeScintilla.AutoCSetSeparator(value);
			}
		}

		private bool ShouldSerializeListSeparator()
		{
			return ListSeparator != ' ';
		}

		private void ResetListSeparator()
		{
			ListSeparator = ' ';
		} 
		#endregion

        #region Selected
        /// <summary>
		/// Gets or Sets the Text of the currently selected AutoComplete item.
		/// </summary>
		/// <remarks>
		/// When setting this property it does not change the text of the currently
		/// selected item. Instead it searches the list for the given value and selects
		/// that item if it matches.
		/// </remarks>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedText
		{
			get
			{
				return (string) _list[NativeScintilla.AutoCGetCurrent()];
			}
			set
            {
            	NativeScintilla.AutoCSelect(value);
            }
		}

		/// <summary>
		/// Gets or Sets the index of the currently selected item in the AutoComplete <see cref="List"/>
		/// </summary>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectedIndex
		{
			get
			{
				return NativeScintilla.AutoCGetCurrent();
			}
			set
			{
				SelectedText = (string) _list[value];
			}
		}
        #endregion

        #region CancelAtShowPoint
        /// <summary>
		/// The default behavior is for the list to be cancelled if the caret moves before the location it was at when the list was displayed. 
		/// By setting this property to false, the list is not cancelled until the caret moves before the first character of the word being completed.
		/// </summary>
		public bool CancelAtShowPoint
		{
			get
			{
				return NativeScintilla.AutoCGetCancelAtShowPoint();
			}
			set
			{
				NativeScintilla.AutoCSetCancelAtShowPoint(value);
			}
		}

		private bool ShouldSerializeCancelAtShowPoint()
		{
			return !CancelAtShowPoint;
		}

		private void ResetCancelAtShowPoint()
		{
			CancelAtShowPoint = false;
		} 
		#endregion

		#region FillUpCharacters
		private string _fillUpCharacters = string.Empty;
		/// <summary>
		/// List of characters (no separated) that causes the AutoComplete window to accept the current
		/// selection.
		/// </summary>
		public string FillUpCharacters
		{
			get
			{
				return _fillUpCharacters;
			}
			set
			{
				_fillUpCharacters = value;
				NativeScintilla.AutoCSetFillUps(value);
			}
		}

		private bool ShouldSerializeFillUpCharacters()
		{
			return _fillUpCharacters != string.Empty;
		}

		private void ResetFillUpCharacters()
		{
			_fillUpCharacters = string.Empty;
		}

		#endregion

		#region SingleLineAccept
		/// <summary>
		/// If you set this value to true and a list has only one item, it is automatically added and no list is displayed. The default is to display the list even if there is only a single item.
		/// </summary>
		public bool SingleLineAccept
		{
			get
			{
				return NativeScintilla.AutoCGetChooseSingle();
			}
			set
			{
				NativeScintilla.AutoCSetChooseSingle(value);
			}
		}

		private bool ShouldSerializeSingleLineAccept()
		{
			return SingleLineAccept;
		}

		private void ResetSingleLineAccept()
		{
			SingleLineAccept = false;
		} 
		#endregion

		#region IsCaseSensitive
		/// <summary>
		/// Gets or Sets if the comparison of words to the AutoComplete <see cref="List"/> are case sensitive.
		/// </summary>
		/// <remarks>Defaults to true</remarks>
		public bool IsCaseSensitive
		{
			get
			{
				return !NativeScintilla.AutoCGetIgnoreCase();
			}
			set
			{
				NativeScintilla.AutoCSetIgnoreCase(!value);
			}
		}

		private bool ShouldSerializeIsCaseSensitive()
		{
			return !IsCaseSensitive;
		}

		private void ResetIsCaseSensitive()
		{
			IsCaseSensitive = true;
		} 
		#endregion

		#region AutoHide
		/// <summary>
		/// By default, the list is cancelled if there are no viable matches (the user has typed characters that no longer match a list entry). 
		/// If you want to keep displaying the original list, set AutoHide to false. 
		/// </summary>
		public bool AutoHide
		{
			get
			{
				return NativeScintilla.AutoCGetAutoHide();
			}
			set
			{
				NativeScintilla.AutoCSetAutoHide(value);
			}
		}

		private bool ShouldSerializeAutoHide()
		{
			return !AutoHide;
		}

		private void ResetAutoHide()
		{
			AutoHide = true;
		} 
		#endregion

		#region DropRestOfWord
		/// <summary>
		/// When an item is selected, any word characters following the caret are first erased if dropRestOfWord is set to true.
		/// </summary>
		/// <remarks>Defaults to false</remarks>
		public bool DropRestOfWord
		{
			get
			{
				return NativeScintilla.AutoCGetDropRestOfWord();
			}
			set
			{
				NativeScintilla.AutoCSetDropRestOfWord(value);
			}
		}

		private bool ShouldSerializeDropRestOfWord()
		{
			return DropRestOfWord;
		}

		private void ResetDropRestOfWord()
		{
			DropRestOfWord = false;
		} 
		#endregion

        #region Images
        #region RegisterImage
        /// <summary>
		/// Registers an image with index to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="type">Index of the image to register to</param>
		/// <param name="xpmImage">Image in the XPM image format</param>
		public void RegisterImage(int type, string xpmImage)
		{
			NativeScintilla.RegisterImage(type, xpmImage);
		}

		/// <summary>
		/// Registers an image with index to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="type">Index of the image to register to</param>
		/// <param name="xpmImage">Image to display in the XPM image format</param>
		/// <param name="transparentColor">Color to mask the image as transparent</param>
		private void RegisterImage(int type, Bitmap image, Color transparentColor)
		{
			NativeScintilla.RegisterImage(type, XpmConverter.ConvertToXPM(image, Utilities.ColorToHtml(transparentColor)));
		}

		/// <summary>
		/// Registers an image with index to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="type">Index of the image to register to</param>
		/// <param name="image">Image to display in Bitmap format</param>
		private void RegisterImage(int type, Bitmap image)
		{
			NativeScintilla.RegisterImage(type, XpmConverter.ConvertToXPM(image));
		}

		#endregion

		#region RegisterImages
		/// <summary>
		/// Registers a list of images to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="xpmImages">List of images in the XPM image format</param>
		/// <remarks>Indecis are assigned sequentially starting at 0</remarks>
		public void RegisterImages(IList<string> xpmImages)
		{
            for (int i = 0; i < xpmImages.Count; i++)
            {
                NativeScintilla.RegisterImage(i, xpmImages[i]);
            }
		}

		/// <summary>
		/// Registers a list of images to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="images">List of images in the Bitmap image format</param>
		/// <remarks>Indecis are assigned sequentially starting at 0</remarks>
		public void RegisterImages(IList<Bitmap> images)
		{
			for (int i = 0; i < images.Count; i++)
				RegisterImage(i, images[i]);
		}

		/// <summary>
		/// Registers a list of images to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="images">List of images in the Bitmap image format</param>
		/// <param name="transparentColor">Color to mask the image as transparent</param>
		/// <remarks>Indecis are assigned sequentially starting at 0</remarks>
		public void RegisterImages(IList<Bitmap> images, Color transparentColor)
		{
			for (int i = 0; i < images.Count; i++)
				RegisterImage(i, images[i], transparentColor);
		}

		/// <summary>
		/// Registers a list of images to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="images">List of images contained in an ImageList</param>
		/// <remarks>Indecis are assigned sequentially starting at 0</remarks>
		public void RegisterImages(ImageList images)
		{
			RegisterImages(XpmConverter.ConvertToXPM(images));
		}

		/// <summary>
		/// Registers a list of images to be displayed in the AutoComplete window.
		/// </summary>
		/// <param name="images">List of images contained in an ImageList</param>
		/// <param name="transparentColor">Color to mask the image as transparent</param>
		/// <remarks>Indecis are assigned sequentially starting at 0</remarks>
		public void RegisterImages(ImageList images, Color transparentColor)
		{
			RegisterImages(XpmConverter.ConvertToXPM(images, Utilities.ColorToHtml(transparentColor)));
		} 
		#endregion

		/// <summary>
		/// Deletes all registered images.
		/// </summary>
		public void ClearRegisteredImages()
		{
			NativeScintilla.ClearRegisteredImages();
		}
        #endregion

        #region ImageSeparator
        /// <summary>
		/// Autocompletion list items may display an image as well as text. Each image is first registered with an integer type. 
		/// Then this integer is included in the text of the list separated by a '?' from the text. For example, "fclose?2 fopen" 
		/// displays image 2 before the string "fclose" and no image before "fopen". 
		/// </summary>
		public char ImageSeparator
		{
			get
			{
				return NativeScintilla.AutoCGetTypeSeparator();
			}
			set
			{
				NativeScintilla.AutoCSetTypeSeparator(value);
			}
		}

		private bool ShouldSerializeImageSeparator()
		{
			return ImageSeparator != '?';
		}

		private void ResetImageSeparator()
		{
			ImageSeparator = '?';
		} 
		#endregion

		#region MaxHeight
		/// <summary>
		/// Get or set the maximum number of rows that will be visible in an autocompletion list. If there are more rows in the list, then a vertical scrollbar is shown
		/// </summary>
		/// <remarks>Defaults to 5</remarks>
		public int MaxHeight
		{
			get
			{
				return NativeScintilla.AutoCGetMaxHeight();
			}
			set
			{
				NativeScintilla.AutoCSetMaxHeight(value);
			}
		}

		private bool ShouldSerializeMaxHeight()
		{
			return MaxHeight != 5;
		}

		private void ResetMaxHeight()
		{
			MaxHeight = 5;
		} 
		#endregion

		#region MaxWidth
		/// <summary>
		/// Get or set the maximum width of an autocompletion list expressed as the number of characters in the longest item that will be totally visible. 
		/// </summary>
		/// <remarks>
		/// If zero (the default) then the list's width is calculated to fit the item with the most characters. Any items that cannot be fully displayed 
		/// within the available width are indicated by the presence of ellipsis.
		/// </remarks>
		public int MaxWidth
		{
			get
			{
				return NativeScintilla.AutoCGetMaxWidth();
			}
			set
			{
				NativeScintilla.AutoCSetMaxWidth(value);
			}
		}

		private bool ShouldSerializeMaxWidth()
		{
			return MaxWidth != 0;
		}

		private void ResetMaxWidth()
		{
			MaxWidth = 0;
		} 
		#endregion

		#region AutomaticLengthEntered
		private bool _automaticLengthEntered = true;
		/// <summary>
		/// Gets or Sets the last automatically calculated LengthEntered used whith <see cref="Show" />.
		/// </summary>
		public bool AutomaticLengthEntered
		{
			get
			{
				return _automaticLengthEntered;
			}
			set
			{
				_automaticLengthEntered = value;
			}
		}

		private bool ShouldSerializeAutomaticLengthEntered()
		{
			return !AutomaticLengthEntered;
		}

		private void ResetAutomaticLengthEntered()
		{
			AutomaticLengthEntered = true;
		} 
		#endregion

	}
}


