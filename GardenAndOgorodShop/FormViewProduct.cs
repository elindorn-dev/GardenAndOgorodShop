using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GardenAndOgorodShop
{
    public partial class FormViewProduct : Form
    {
        public FormViewProduct()
        {
            InitializeComponent();
        }

        private void FormViewProduct_Load(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.Visible = true;
            comboBox1.DroppedDown = true;
        }
    }
}
