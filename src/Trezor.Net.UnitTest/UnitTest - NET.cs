﻿using Hid.Net;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Trezor.Net
{
    public partial class UnitTest
    {
        private async Task<IDevice> Connect()
        {
            DeviceInformation trezorDeviceInformation = null;

            Console.Write("Waiting for Trezor .");

            while (trezorDeviceInformation == null)
            {
                var devices = WindowsDeviceBase.GetConnectedDeviceInformations(WindowsDeviceConstants.GUID_DEVINTERFACE_USB_DEVICE);

                //1.6.x Device By Id
                trezorDeviceInformation = devices.FirstOrDefault(d => d.DevicePath.Contains("534c"));

                //1.7.x Device By Vid
                //var enumerable = devices.Where(d => d.DevicePath.Contains("1209")).ToList();
                //trezorDeviceInformation = enumerable.FirstOrDefault();

                if (trezorDeviceInformation != null)
                {
                    break;
                }

                await Task.Delay(1000);
                Console.Write(".");
            }

            var retVal = new WindowsUsbDevice(trezorDeviceInformation.DevicePath, 65, 65);

            await retVal.InitializeAsync();

            Console.WriteLine("Connected");

            return retVal;
        }

        private async Task<string> GetPin()
        {
            var passwordExePath = Path.Combine(GetExecutingAssemblyDirectoryPath(), "Misc", "GetPassword.exe");
            if (!File.Exists(passwordExePath))
            {
                throw new Exception($"The pin exe doesn't exist at passwordExePath {passwordExePath}");
            }

            var process = Process.Start(passwordExePath);
            process.WaitForExit();
            await Task.Delay(100);
            var pin = File.ReadAllText(Path.Combine(GetExecutingAssemblyDirectoryPath(), "pin.txt"));
            return pin;
        }

        private static string GetExecutingAssemblyDirectoryPath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var executingAssemblyDirectoryPath = Path.GetDirectoryName(uri.Path);
            return executingAssemblyDirectoryPath;
        }
    }
}
