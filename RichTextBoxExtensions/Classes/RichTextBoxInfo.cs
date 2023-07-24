using RichTextBoxExtensions.Enums;

namespace ControlExtensions.Classes
{
    public  class RichTextBoxInfo
    {
        public bool IsListingEnabled { get; set; }
        public RichEditNumberingOption NumberingOption { get; set; }
        public RichEditNumberingStyle NumberingStyle { get; set; }
        public int IntendInTwips { get; set; }
    }
}
