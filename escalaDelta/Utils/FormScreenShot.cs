/*
   referência de criação https://www.codeproject.com/Articles/20651/Capturing-Minimized-Window-A-Kid-s-Trick 
 */

using System.Runtime.InteropServices;

namespace escalaDelta.Utils {
    internal static class FormScreenShot {
        [DllImport("user32")]
        private static extern int PrintWindow(IntPtr hWnd, IntPtr dc, uint flags);

        public static Bitmap CaptureScreenFullForm(this Form form) {
            try {
                IntPtr hWnd = form.Handle;
                Size size = form.Size;

                if (size.IsEmpty || size.Height < 0 || size.Width < 0) return null;

                Bitmap bmp = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage(bmp);
                IntPtr dc = g.GetHdc();

                PrintWindow(hWnd, dc, 0);

                g.ReleaseHdc();
                g.Dispose();

                return bmp;
            } catch { return null; }
        }
    }
}
