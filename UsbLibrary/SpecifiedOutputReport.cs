namespace UsbLibrary
{
    public class SpecifiedOutputReport : OutputReport
    {
        public SpecifiedOutputReport(HIDDevice oDev) : base(oDev)
        {
        }

        public bool SendData(byte[] data)
        {
            var arrBuff = Buffer; //new byte[Buffer.Length];
            int dataSize = data.Length, bufferSize = arrBuff.Length;

            for (var i = 1; i < bufferSize; i++)
                arrBuff[i] = data[i % dataSize];

            //returns false if the data does not fit in the buffer. else true
            return bufferSize >= dataSize;
        }
    }
}