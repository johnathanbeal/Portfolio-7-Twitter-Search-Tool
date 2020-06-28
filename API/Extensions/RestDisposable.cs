using RestSharp;
using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace API.Extensions
{
    public class RestDisposable : RestClient, IDisposable
    {
       public RestDisposable(Uri baseUri) 
       {
            this.BaseUrl = baseUri;
       }
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
