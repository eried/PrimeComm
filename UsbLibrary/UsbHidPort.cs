using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UsbLibrary
{
    /// <summary>
    ///     This class provides an usb component. This can be placed ont to your form.
    /// </summary>
    [ToolboxBitmap(typeof (UsbHidPort), "UsbHidBmp.bmp")]
    public partial class UsbHidPort : Component
    {
        //private memebers
        private readonly Guid device_class;
        private IntPtr handle;
        private int product_id;
        private SpecifiedDevice specified_device;
        private IntPtr usb_event_handle;
        private int vendor_id;
        //events

        public UsbHidPort()
        {
            //initializing in initial state
            product_id = 0;
            vendor_id = 0;
            specified_device = null;
            device_class = Win32Usb.HIDGuid;

            InitializeComponent();
        }

        public UsbHidPort(IContainer container)
        {
            //initializing in initial state
            product_id = 0;
            vendor_id = 0;
            specified_device = null;
            device_class = Win32Usb.HIDGuid;
            
            container.Add(this);
            InitializeComponent();
        }

        [Description("The product id from the USB device you want to use")]
        [DefaultValue("(none)")]
        [Category("Embedded Details")]
        public int ProductId
        {
            get { return product_id; }
            set { product_id = value; }
        }

        [Description("The vendor id from the USB device you want to use")]
        [DefaultValue("(none)")]
        [Category("Embedded Details")]
        public int VendorId
        {
            get { return vendor_id; }
            set { vendor_id = value; }
        }

        [Description("The Device Class the USB device belongs to")]
        [DefaultValue("(none)")]
        [Category("Embedded Details")]
        public Guid DeviceClass
        {
            get { return device_class; }
        }

        [Description("The Device witch applies to the specifications you set")]
        [DefaultValue("(none)")]
        [Category("Embedded Details")]
        public SpecifiedDevice SpecifiedDevice
        {
            get { return specified_device; }
        }

        /// <summary>
        ///     This event will be triggered when the device you specified is pluged into your usb port on
        ///     the computer. And it is completly enumerated by windows and ready for use.
        /// </summary>
        [Description(
            "The event that occurs when a usb hid device with the specified vendor id and product id is found on the bus"
            )]
        [Category("Embedded Event")]
        [DisplayName("OnSpecifiedDeviceArrived")]
        public event EventHandler OnSpecifiedDeviceArrived;

        /// <summary>
        ///     This event will be triggered when the device you specified is removed from your computer.
        /// </summary>
        [Description(
            "The event that occurs when a usb hid device with the specified vendor id and product id is removed from the bus"
            )]
        [Category("Embedded Event")]
        [DisplayName("OnSpecifiedDeviceRemoved")]
        public event EventHandler OnSpecifiedDeviceRemoved;

        /// <summary>
        ///     This event will be triggered when a device is pluged into your usb port on
        ///     the computer. And it is completly enumerated by windows and ready for use.
        /// </summary>
        [Description("The event that occurs when a usb hid device is found on the bus")]
        [Category("Embedded Event")]
        [DisplayName("OnDeviceArrived")]
        public event EventHandler OnDeviceArrived;

        /// <summary>
        ///     This event will be triggered when a device is removed from your computer.
        /// </summary>
        [Description("The event that occurs when a usb hid device is removed from the bus")]
        [Category("Embedded Event")]
        [DisplayName("OnDeviceRemoved")]
        public event EventHandler OnDeviceRemoved;

        /// <summary>
        ///     This event will be triggered when data is received from the device specified by you.
        /// </summary>
        [Description("The event that occurs when data is received from the embedded system")]
        [Category("Embedded Event")]
        [DisplayName("OnDataReceived")]
        public event DataReceivedEventHandler OnDataReceived;

        /// <summary>
        ///     This event will be triggered when data is send to the device.
        ///     It will only occure when this action wass succesfull.
        /// </summary>
        [Description("The event that occurs when data is send from the host to the embedded system")]
        [Category("Embedded Event")]
        [DisplayName("OnDataSend")]
        public event EventHandler OnDataSend;

        /// <summary>
        ///     Registers this application, so it will be notified for usb events.
        /// </summary>
        /// <param name="Handle">a IntPtr, that is a handle to the application.</param>
        /// <example>
        ///     This sample shows how to implement this method in your form.
        ///     <code> 
        /// protected override void OnHandleCreated(EventArgs e)
        /// {
        ///     base.OnHandleCreated(e);
        ///     usb.RegisterHandle(Handle);
        /// }
        /// </code>
        /// </example>
        public void RegisterHandle(IntPtr Handle)
        {
            usb_event_handle = Win32Usb.RegisterForUsbEvents(Handle, device_class);
            handle = Handle;
            //Check if the device is already present.
            CheckDevicePresent();
        }

        /// <summary>
        ///     Unregisters this application, so it won't be notified for usb events.
        /// </summary>
        /// <returns>Returns if it wass succesfull to unregister.</returns>
        public bool UnregisterHandle()
        {
            return Win32Usb.UnregisterForUsbEvents(handle);
        }

        /// <summary>
        ///     This method will filter the messages that are passed for usb device change messages only.
        ///     And parse them and take the appropriate action
        /// </summary>
        /// <param name="m">a ref to Messages, The messages that are thrown by windows to the application.</param>
        /// <example>
        ///     This sample shows how to implement this method in your form.
        ///     <code> 
        /// protected override void WndProc(ref Message m)
        /// {
        ///     usb.ParseMessages(ref m);
        ///     base.WndProc(ref m);	    // pass message on to base form
        /// }
        /// </code>
        /// </example>
        public void ParseMessages(ref Message m)
        {
            if (m.Msg == Win32Usb.WM_DEVICECHANGE)
                // we got a device change message! A USB device was inserted or removed
            {
                switch (m.WParam.ToInt32()) // Check the W parameter to see if a device was inserted or removed
                {
                    case Win32Usb.DEVICE_ARRIVAL: // inserted
                        if (OnDeviceArrived != null || OnSpecifiedDeviceArrived != null)
                        {
                            if(OnDeviceArrived != null)
                                OnDeviceArrived(this, new EventArgs());
                            CheckDevicePresent();
                        }
                        break;
                    case Win32Usb.DEVICE_REMOVECOMPLETE: // removed
                        if (OnDeviceRemoved != null || OnSpecifiedDeviceArrived != null)
                        {
                            if (OnDeviceArrived != null)
                                OnDeviceRemoved(this, new EventArgs());
                            CheckDevicePresent();
                        }
                        break;
                }
            }
        }

        /// <summary>
        ///     Checks the devices that are present at the moment and checks if one of those
        ///     is the device you defined by filling in the product id and vendor id.
        /// </summary>
        public void CheckDevicePresent()
        {
            try
            {
                //Mind if the specified device existed before.
                bool history = false;
                if (specified_device != null)
                {
                    history = true;
                }

                specified_device = SpecifiedDevice.FindSpecifiedDevice(vendor_id, product_id);
                    // look for the device on the USB bus
                if (specified_device != null) // did we find it?
                {
                    if (OnSpecifiedDeviceArrived != null)
                    {
                        OnSpecifiedDeviceArrived(this, new EventArgs());
                        specified_device.DataReceived += OnDataReceived;
                        specified_device.DataSend += new DataSendEventHandler(OnDataSend);
                    }
                }
                else
                {
                    if (OnSpecifiedDeviceRemoved != null && history)
                    {
                        OnSpecifiedDeviceRemoved(this, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DataReceived(object sender, DataReceivedEventArgs args)
        {
            if (OnDataReceived != null)
            {
                OnDataReceived(sender, args);
            }
        }

        private void DataSend(object sender, DataSendEventArgs args)
        {
            if (OnDataSend != null)
            {
                OnDataSend(sender, args);
            }
        }
    }
}