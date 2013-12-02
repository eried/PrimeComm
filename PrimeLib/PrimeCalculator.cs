using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using HidLibrary;

namespace PrimeLib
{
    public class PrimeCalculator
    {
        private HidDevice _calculator;
        private bool _isConnected;
        public event EventHandler<EventArgs> Connected, Disconnected;
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        public void CheckForChanges()
        {
            foreach (var d in HidDevices.Enumerate(1008, new[] { 1089 }))
            {
                _calculator = d;
                IsConnected = true;
                return;
            }

            IsConnected = false;
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            private set {
                if (_isConnected != value)
                {
                    // Update event
                    _isConnected = value;

                    if (_isConnected) OnConnected();
                    else OnDisconnected();
                }
            }
        }

        protected virtual void OnConnected()
        {
            EventHandler<EventArgs> handler = Connected;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnDisconnected()
        {
            EventHandler<EventArgs> handler = Disconnected;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void Send(PrimeUsbFile file)
        {
            if (_isConnected && _calculator != null)
                foreach(var c in file.Chunks)
                    _calculator.Write(c);
                /*
                _calculator.WriteReport(new HidReport(file.Data.Length,
                    new HidDeviceData(file.Data, HidDeviceData.ReadStatus.NoDataRead)));*/
        }

        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = DataReceived;
            if (handler != null) handler(this, e);
        }

        public int OutputChunkSize
        {
            get { return _calculator.Capabilities.OutputReportByteLength; }
        }
    }
}
