namespace UsbLibrary
{
    public class SpecifiedInputReport : InputReport
    {
        private byte[] arrData;

        public SpecifiedInputReport(HIDDevice oDev) : base(oDev)
        {
        }

        public byte[] Data
        {
            get { return arrData; }
        }

        public override void ProcessData()
        {
            arrData = Buffer;
        }
    }
}