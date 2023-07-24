namespace RichTextBoxExtensions.Classes
{
    internal class RichEdit
    {
        // Masks.
        public const int PFM_STARTINDENT = 0x00000001;
        public const int PFM_OFFSET = 0x00000004;
        public const int PFM_ALIGNMENT = 0x00000008;
        public const int PFM_NUMBERING = 0x00000020;
        public const int PFM_NUMBERINGSTYLE = 0x00002000;
        public const int PFM_NUMBERINGSTART = 0x00008000;

        // Alignment.
        public const int PFA_CENTER = 3;

        // Numbering options.
        public const int PFN_ARABIC = 2;

        // Numbering styles.
        
        public const int PFNS_PERIOD = 0x200;
        
        // Styles.
        public const int PFNS_NEWNUMBER = 0x00008000;
    }
}
