using System;

namespace PrimeLib
{
    /// <summary>
    /// Happens when data is received
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Received data
        /// </summary>
        public readonly byte[] Data;

        public DataReceivedEventArgs(byte[] data)
        {
            Data = data;
        }
    }
}