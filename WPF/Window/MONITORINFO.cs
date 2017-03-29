using System.Runtime.InteropServices;

namespace WPF.Window
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public Rectangle rcMonitor = new Rectangle();
        public Rectangle rcWork = new Rectangle();
        public int dwFlags = 0;
    }
}