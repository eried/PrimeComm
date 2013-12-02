using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using HidLibrary;

namespace PrimeLib
{
    /// <summary>
    /// Represents an HP Prime
    /// </summary>
    public class PrimeCalculator
    {
        private HidDevice _calculator;
        private bool _isConnected,_continue;
        public event EventHandler<EventArgs> Connected, Disconnected;
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Checks the Hid Devices looking for the first calculator
        /// </summary>
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

        /// <summary>
        /// There is at least one compatible device connected
        /// </summary>
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

        /// <summary>
        /// First compatible device was found and it is connected
        /// </summary>
        protected virtual void OnConnected()
        {
            EventHandler<EventArgs> handler = Connected;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// The last connected device was removed
        /// </summary>
        protected virtual void OnDisconnected()
        {
            EventHandler<EventArgs> handler = Disconnected;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sends data to the calculator
        /// </summary>
        /// <param name="file">Data to send</param>
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

        /// <summary>
        /// Some data arrived (Device has to be Receiving data)
        /// </summary>
        /// <param name="e">Data received</param>
        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            EventHandler<DataReceivedEventArgs> handler = DataReceived;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Size of the output chunk (Output Report lenght)
        /// </summary>
        public int OutputChunkSize
        {
            get { return _calculator.Capabilities.OutputReportByteLength; }
        }

        /// <summary>
        /// Enabled the data reception for this device, flushing any pending data in the buffer
        /// </summary>
        public void StartReceiving()
        {
            // Flush contents
            _calculator.CloseDevice();

            _continue = true;
            _calculator.ReadReport(OnReport);
        }

        /// <summary>
        /// Disables the data reception
        /// </summary>
        public void StopReceiving()
        {
            _continue = false;
            _calculator.CloseDevice();
        }

        private void OnReport(HidReport report)
        {
            if(_continue)
                _calculator.ReadReport(OnReport); // Expect more reports

            if (IsNotReady()) return;

            OnDataReceived(new DataReceivedEventArgs(report.Data));
        }
    }

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
