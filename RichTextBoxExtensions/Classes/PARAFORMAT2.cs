using System.Runtime.InteropServices;

namespace RichTextBoxExtensions.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal class PARAFORMAT2
    { 
        public uint cbSize;
        public uint dwMask;
        public ushort wNumbering;
        public ushort wReserved;
        public int dxStartIndent;
        public int dxRightIndent;
        public int dxOffset;
        public ushort wAlignment;
        public short cTabCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public int[] rgxTabs;

        public int dySpaceBefore;
        public int dySpaceAfter;
        public int dyLineSpacing;
        public short sStyle;
        public byte bLineSpacingRule;
        public byte bOutlineLevel;
        public ushort wShadingWeight;
        public ushort wShadingStyle;
        public ushort wNumberingStart;
        public ushort wNumberingStyle;
        public ushort wNumberingTab;
        public ushort wBorderSpace;
        public ushort wBorderWidth;
        public ushort wBorders;
    };
}
