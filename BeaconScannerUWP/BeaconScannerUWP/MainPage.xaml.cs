using System;
using System.ComponentModel;
using Xamarin.Forms;


namespace BeaconScannerUWP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void BtnScan_Clicked(object sender, EventArgs e)
        {
            ConnectInterfaceUWP connectInterfaceUWP = new ConnectInterfaceUWP();
            LblDisplayUUID.Text = connectInterfaceUWP.UUID();
        }


    public class ConnectInterfaceUWP
    {
        GetBeaconInformationInterface getBeaconInformationInterface = DependencyService.Get<GetBeaconInformationInterface>();
        public string UUID()
        {
           return getBeaconInformationInterface.GetIBeaconInformation();
        }
    }

    }


}
