using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hid.Net
{
    public class LibUsbDevice : IDevice
    {
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsConnectedAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
