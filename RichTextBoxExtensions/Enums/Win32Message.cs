namespace RichTextBoxExtensions.Enums
{
    internal enum Win32Message
    {
        WM_USER = 0x400,
        EM_SETPARAFORMAT = WM_USER + 71,
        EM_GETPARAFORMAT = WM_USER + 61
    }
}
