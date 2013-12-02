using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using HidLibrary;

namespace PrimeLib
{
    public class PrimeCalculator
    {
        private HidDevice _calculator;
        private bool _isConnected,_continue;
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
            if (IsNotReady()) return;

            foreach(var c in file.Chunks)
                _calculator.Write(c);
        }

        private bool IsNotReady()
        {
            return !(_isConnected && _calculator != null);
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

        public void StartReceiving()
        {
            // Flush contents
            _calculator.CloseDevice();

            _continue = true;
            _calculator.ReadReport(OnReport);
        }

        public void StopReceiving()
        {
            _continue = false;
            _calculator.CloseDevice();
        }

        private void OnReport(HidReport report)
        {
            if(_continue)
                _calculator.ReadReport(OnReport);

            if (IsNotReady()) return;

            OnDataReceived(new DataReceivedEventArgs(report.Data));
        }
    }

    public class DataReceivedEventArgs : EventArgs
    {
        public readonly byte[] data;

        public DataReceivedEventArgs(byte[] data)
        {
            this.data = data;
        }
    }
}
