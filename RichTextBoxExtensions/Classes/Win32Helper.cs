using System;
using System.Runtime.InteropServices;

namespace RichTextBoxExtensions.Classes
{
    internal static class Win32Helper
    {
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
