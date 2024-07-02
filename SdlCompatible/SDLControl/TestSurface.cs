using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdlCompatible.SDLControl
{
    public class TestSurface : TestBaseSdlResource, ICloneable
    {

        private bool isVideoMode;

        public object Clone()
        {
            return Clone(doDeepCopy: false);
        }

        public object Clone(bool doDeepCopy)
        {
            /*if (doDeepCopy)
            {
                Surface surface = new Surface(SdlGfx.zoomSurface(base.Handle, 1.0, 1.0, 0));
                CloneFields(this, surface);
                return surface;
            }

            Surface surface2 = new Surface(SdlGfx.zoomSurface(base.Handle, 1.0, 1.0, 0));
            CloneFields(this, surface2);
            return surface2;*/
            return null;
        }

        protected override void CloseHandle()
        {
            try
            {
                if (base.Handle != IntPtr.Zero && !isVideoMode)
                {
                    SDL.SDL_FreeSurface(base.Handle);
                    base.Handle = IntPtr.Zero;
                }
            }
            catch (NullReferenceException ex)
            {
                ex.ToString();
            }
            catch (AccessViolationException ex2)
            {
                Console.WriteLine(ex2.StackTrace);
                ex2.ToString();
            }
            finally
            {
                base.Handle = IntPtr.Zero;
            }
        }
    }
}
