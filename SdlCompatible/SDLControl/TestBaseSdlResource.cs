using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdlCompatible.SDLControl
{
    public abstract class TestBaseSdlResource : IDisposable
    {
        private bool disposed;

        private IntPtr handle;

        public IntPtr Handle
        {
            get
            {
                return handle;
            }
            set
            {
                handle = value;
                GC.KeepAlive(this);
            }
        }

        //
        // 요약:
        //     Creates class using a handle.
        //
        // 매개 변수:
        //   handle:
        //     Pointer to unmanaged Sdl resource
        //
        // 설명:
        //     Often used by internal classes.
        protected TestBaseSdlResource(IntPtr handle)
        {
            this.handle = handle;
        }

        //
        // 요약:
        //     Default constructor.
        //
        // 설명:
        //     Used by outside classes.
        protected TestBaseSdlResource()
        {
        }

        //
        // 요약:
        //     Allows an Object to attempt to free resources and perform other cleanup operations
        //     before the Object is reclaimed by garbage collection.
        //
        // 설명:
        //     Frees managed resources
        ~TestBaseSdlResource()
        {
            Dispose(disposing: false);
        }

        //
        // 요약:
        //     Dispose objects
        //
        // 매개 변수:
        //   disposing:
        //     If true, it will dispose close the handle
        //
        // 설명:
        //     Will dispose managed and unmanaged resources.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                CloseHandle();
            }

            disposed = true;
        }

        //
        // 요약:
        //     Close the handle.
        //
        // 설명:
        //     Used to close handle to unmanaged SDL resources
        protected abstract void CloseHandle();

        //
        // 요약:
        //     Closes and destroys this object
        //
        // 설명:
        //     Destroys managed and unmanaged objects
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        //
        // 요약:
        //     Closes and destroys this object
        //
        // 설명:
        //     Same as Dispose(true)
        public void Close()
        {
            Dispose();
        }
    }
}
