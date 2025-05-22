using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public partial class CustomSlider : UserControl
    {
        public CustomSlider()
        {
            InitializeComponent();
        }
        private int pages_count;
        public int CountPages
        {
            get { return pages_count; }
            set
            {
                pages_count = value;
                labelCounter.Text = pages_count.ToString();
                textBoxCounter.MaxLength = pages_count.ToString().Length;
            }
        }
        public int Count
        {
            get { return int.Parse(textBoxCounter.Text); }
            set
            {
                textBoxCounter.Text = value.ToString();
            }
        }

        private void textBoxCounter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (char)Keys.Back == e.KeyChar))
            {
                e.Handled = true;
            }
            if (pages_count.ToString().Length == 1 && e.KeyChar == '0')
            {
                e.Handled = true;
            }
        }
        private int current_page = 1;
        public int CurrentPage
        {
            get { return current_page; }
            set { current_page = value; }
        }
        public event EventHandler RefreshProducts;
        private void textBoxCounter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCounter.Text == "")
            {
                return;
            }
            if (Convert.ToInt32(textBoxCounter.Text) > pages_count)
            {
                textBoxCounter.Text = textBoxCounter.Text.Substring(0, textBoxCounter.Text.Length - 1);
            }
            current_page = textBoxCounter.Text != "" ? Convert.ToInt32(textBoxCounter.Text) : current_page;
            RefreshProducts?.Invoke(this, EventArgs.Empty);
        }

        private void textBoxCounter_Leave(object sender, EventArgs e)
        {
            textBoxCounter.Text = current_page.ToString();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCounter.Text) != CountPages)
            {
                current_page++;
                textBoxCounter.Text = current_page.ToString();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCounter.Text) != 1)
            {
                current_page--;
                textBoxCounter.Text = current_page.ToString();
            }
        }
    }
}
