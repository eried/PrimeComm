using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using PrimeLib;

namespace PrimeLib
{
    /// <summary>
    /// Class that represents a data ready to be sent to the calculator thru the USB
    /// </summary>
    public class PrimeUsbFile
    {
        private readonly byte[] _header = {0x00, 0x00, 0xf7, 0x01};
        private bool _isComplete;

        public string Name { get; set; }
        public byte[] Data { get; private set; }

        public PrimeUsbFile(string name, byte[] data, int chunkSize)
        {
            Name = name;
            Data = data;
            IsValid = true;
            IsComplete = true;

            Chunks = new List<byte[]>();

            // Prepare the header
            var fullData = new List<byte>(_header);

            // Name
            var nameBytes = Encoding.Unicode.GetBytes(name);

            // Size
            var size = BitConverter.GetBytes(data.Length + nameBytes.Length +5);

            // Combining all fields
            fullData.AddRange(size.Reverse());
            fullData.Add(0x06);
            fullData.Add((byte) nameBytes.Length);
            fullData.AddRange(new byte[] {0x94, 0xdd}); // CRC
            fullData.AddRange(nameBytes);
            fullData.AddRange(data);

            var allBytes = fullData.ToArray();
            int position = 0, chunk = 0;

            if(chunkSize>0)
                do
                {
                    IEnumerable<byte> tmp = new[] { (byte)0x00, (byte)(chunk++ % byte.MaxValue) };
                    Chunks.Add(tmp.Concat(allBytes.SubArray(position==0?2:position, Math.Min(chunkSize-2, allBytes.Length - position))).ToArray());
                    position += chunkSize-(position==0?0:2);

                } while (position < allBytes.Length);
        }

        public bool IsValid { get; private set; }

        public bool IsComplete
        {
            get 
            {
                CheckForValidity();
                return _isComplete; 
            }

            private set { _isComplete = value; }
        }

        public PrimeUsbFile(byte[] data)
        {
            Name = null;
            Chunks = new List<byte[]>(new[] {data});
            CheckForValidity();
        }

        private void CheckForValidity(bool force = false)
        {
            if (_isComplete && !force)
                return;

            IsValid = false;
            IsComplete = false;
            if (Chunks.Count <= 0) return;

            var tmp = Chunks.Aggregate<byte[], IEnumerable<byte>>(null, (current, b) => current == null ? b : current.Concat(b)).ToArray();

            if (tmp.Length < 12) // Can't fit the header in here
                return;

            // Check the header
            if (_header.Where((t, i) => tmp[i] != t).Any())
                return;

            // Another checking
            if (tmp[8] != 0x06)
                return;

            // Get the size and name
            var size = BitConverter.ToInt32(tmp.SubArray(4, 4).Reverse().ToArray(), 0);

            IsValid = true;

            // Get the name length
            const int nameOffset = 12;
            int nameLength = tmp[9];

            if (tmp.Length > nameOffset + tmp[9])
            {
                Name = Encoding.Unicode.GetString(tmp.SubArray(nameOffset, nameLength));
                _isComplete = tmp.Length >= size + nameOffset + nameLength;
                Debug.WriteLine(tmp.Length);
                if (_isComplete)
                    Data = tmp.SubArray(nameOffset + nameLength, size - nameLength-4).Concat(new byte[]{0x00, 0x00}).ToArray();
            }
        }

        public List<byte[]> Chunks { get; set; }

        /*public void Send(SpecifiedDevice hidDevice)
        {
            foreach (var chunk in Chunks)
                hidDevice.SendData(chunk);
        }*/

        public void Save(string destinationFilename)
        {
            switch (Path.GetExtension(destinationFilename))
            {
                case ".txt":
                    File.WriteAllBytes(destinationFilename, Encoding.Convert(Encoding.Unicode, Encoding.Default, Data.SubArray(0,Data.Length-2)));
                    break;

                default:
                    // Convert to hpprgm file
                    IEnumerable<byte> f = new byte[]
                    {0x0c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
                    File.WriteAllBytes(destinationFilename,
                        f.Concat(BitConverter.GetBytes(Data.Length)).Concat(Data).ToArray());
                    break;
            }
        }
    }
}
