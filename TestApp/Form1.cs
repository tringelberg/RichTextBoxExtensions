using RichTextBoxExtensions;
using RichTextBoxExtensions.Enums;
using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            numberingStyles.Items.AddRange(new object[]
            {
                RichEditNumberingStyle.ParanthesesRight,
                RichEditNumberingStyle.ParanthesesLeftRight,
                RichEditNumberingStyle.Period,
                RichEditNumberingStyle.Plain,
                RichEditNumberingStyle.NoNumber,
            });

            numberingStyles.SelectedIndex = 0;

            numberingOptions.Items.AddRange(new object[]
            {
                RichEditNumberingOption.Arabic,
                RichEditNumberingOption.Bullet,
                RichEditNumberingOption.LowercaseLetters,
                RichEditNumberingOption.UppercaseLetters,
                RichEditNumberingOption.LowercaseRoman,
                RichEditNumberingOption.UppercaseRoman,
            });
            
            numberingOptions.SelectedIndex = 0;

            numberingOptions.SelectedIndexChanged += (o, e) => ApplyNumbering();
            numberingStyles.SelectedIndexChanged += (o, e) => ApplyNumbering();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyNumbering();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = !richTextBox1.SelectionBullet;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            richTextBox1.DisableListing();
        }

        private void ApplyNumbering()
        {
            richTextBox1.Focus();
            richTextBox1.EnableListing(option: (RichEditNumberingOption)numberingOptions.SelectedItem, style: (RichEditNumberingStyle)numberingStyles.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();

            var info = richTextBox1.GetListingInfo();

            infoBox.Text = $"ListingEnabled: {info.IsListingEnabled}\r\n";
            
            if (info.IsListingEnabled)
            {
                infoBox.Text += $"NumberingOption: {info.NumberingOption}\r\n" +
                                $"NumberingStyle: {info.NumberingStyle}\r\n" + 
                                $"IntendInTwips: {info.IntendInTwips}\r\n";
            }
        }
    }
}
