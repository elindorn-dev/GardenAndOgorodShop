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
    public partial class HandleRecordForm : Form
    {
        private int selected_page = 0;
        public HandleRecordForm(int page)
        {
            InitializeComponent();
            this.selected_page = page;
        }
        private void HandleRecordForm_Load(object sender, EventArgs e)
        {
            tabControlRecords.SelectedIndex = selected_page;
        }
        private void buttonToMianForm_Click(object sender, EventArgs e)
        {

        }
    }
}
