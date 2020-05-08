using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Storage.Streams;
using BeaconScannerUWP;



namespace BeaconScannerUWP.UWP
{
    public sealed partial class MainPage 
    {

        public BluetoothLEAdvertisementWatcher watcher;

        public string Name { get; set; }
        public string UUID { get; set; }


        public MainPage()
        {
            this.InitializeComponent();


            LoadApplication(new BeaconScannerUWP.App());

            //UUID = "";
        }


    }
}
