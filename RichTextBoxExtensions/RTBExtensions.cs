using ControlExtensions.Classes;
using RichTextBoxExtensions.Classes;
using RichTextBoxExtensions.Enums;
using RichTextBoxExtensions.Structures;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RichTextBoxExtensions
{
    public static class RTBExtensions
    {

        /// <summary>
        /// Enables numbering listing mode.
        /// </summary>
        /// <param name="rtb">The affected RichTextBox.</param>
        /// <param name="option">The kind of numbering (Arabic, Bullet, etc...)</param>
        /// <param name="style">The style for the numbering (Parantheses, Period, etc...)\</param>
        /// <param name="intendInTwips">The intendation in twips.</param>
        public static void EnableListing(this RichTextBox rtb, RichEditNumberingOption option = RichEditNumberingOption.Arabic, RichEditNumberingStyle style = RichEditNumberingStyle.Period, int intendInTwips = 300)
        {
            PARAFORMAT2 pfm = new PARAFORMAT2()
            {
                dwMask = RichEdit.PFM_STARTINDENT | RichEdit.PFM_NUMBERINGSTYLE | RichEdit.PFM_NUMBERINGSTART | RichEdit.PFM_NUMBERING | RichEdit.PFM_OFFSET,
                wNumberingStart = 1,
                wNumbering = (ushort)option,
                wNumberingStyle = (ushort)style,
                dxStartIndent = intendInTwips
            };

            SendParagraphFormatMessage(rtb, Win32Message.EM_SETPARAFORMAT, pfm, out _);
        }

        /// <summary>
        /// Disables numbering listing mode.
        /// </summary>
        /// <param name="rtb">The affected RichTextBox.</param>
        public static void DisableListing(this RichTextBox rtb)
        {
            PARAFORMAT2 pfm = new PARAFORMAT2()
            {
                dwMask = RichEdit.PFM_STARTINDENT | RichEdit.PFM_NUMBERINGSTYLE | RichEdit.PFM_NUMBERINGSTART | RichEdit.PFM_NUMBERING | RichEdit.PFM_OFFSET,
                wNumberingStart = 1,
                wNumbering = 0,
                wNumberingStyle = 0,
                dxStartIndent = 0
            };

            SendParagraphFormatMessage(rtb, Win32Message.EM_SETPARAFORMAT, pfm, out _);
        }

        /// <summary>
        /// Retrieves listing information about the current selection.
        /// </summary>
        /// <param name="rtb">The affected RichTextBox.</param>
        /// <returns>A RichTextBoxInfo-Instance</returns>
        public static RichTextBoxInfo GetListingInfo(this RichTextBox rtb)
        {
            PARAFORMAT2 pfm = new PARAFORMAT2();

            pfm.cbSize = (uint)Marshal.SizeOf(typeof(PARAFORMAT2));
            SendParagraphFormatMessage(rtb, Win32Message.EM_GETPARAFORMAT, pfm, out PARAFORMAT2 outPfm);

            return new RichTextBoxInfo
            {
                // For some reason, dwMask always contains a very huge number
                // and I haven't figured out yet why it does that. Because of that I cannot use
                // the following line of code, although it is (probably) correct:
                // IsListingEnabled = (outPfm.dwMask & RichEdit.PFM_NUMBERINGSTART) != 0,
                // Instead, let's use the following hack:
                IsListingEnabled = outPfm.dxStartIndent > 0, // This is a hack and must be fixed.
                NumberingOption = (RichEditNumberingOption)outPfm.wNumbering,
                NumberingStyle = (RichEditNumberingStyle)outPfm.wNumberingStyle,
                IntendInTwips = outPfm.dxStartIndent
            };
        }

        private static void SendParagraphFormatMessage(Control control, Win32Message msg, PARAFORMAT2 inPfm, out PARAFORMAT2 outPfm)
        {
            int structSize = Marshal.SizeOf(inPfm);
            IntPtr structPtr = Marshal.AllocCoTaskMem(structSize);

            inPfm.cbSize = (uint)structSize;

            Marshal.StructureToPtr(inPfm, structPtr, false);
            Win32Helper.SendMessage(control.Handle, (uint)msg, IntPtr.Zero, structPtr);

            outPfm = msg == Win32Message.EM_GETPARAFORMAT ? Marshal.PtrToStructure<PARAFORMAT2>(structPtr) : default;

            Debug.WriteLine(outPfm?.dwMask);
            Marshal.FreeCoTaskMem(structPtr);
        }
    }
}
