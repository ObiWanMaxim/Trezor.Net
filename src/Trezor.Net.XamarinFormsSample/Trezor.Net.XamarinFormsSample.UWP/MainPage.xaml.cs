using Hid.Net;
using Hid.Net.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app = Trezor.Net.XamarinFormsSample.App;
using wde = Windows.Devices.Enumeration;

namespace Trezor.Net.XamarinFormsSample.UWP
{
    public sealed partial class MainPage
    {
        private UWPHidDevicePoller poller;

        public MainPage()
        {
            InitializeComponent();

            NewMethod();
        }

        private async Task NewMethod()
        {

            var asdasd = await GetDevicesByProductAndVendorAsync(1, 2);
            var trezorHidDevice = new UWPHidDevice(asdasd[1].Id);
            trezorHidDevice.DataHasExtraByte = false;
            await trezorHidDevice.InitializeAsync();

            LoadApplication(new app(trezorHidDevice));
        }

   
        public static async Task<List<wde.DeviceInformation>> GetDevicesByProductAndVendorAsync(int vendorId, int productId)
        {
            var asdasd =  ((IEnumerable<wde.DeviceInformation>)await wde.DeviceInformation.FindAllAsync().AsTask()).ToList();
            return asdasd.Where(d => d.Id.Contains("1209")).ToList();
        }
    }
}
