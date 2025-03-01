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
    public partial class CurrentOrder : Form
    {
        Task<DataTable> products_table;
        public CurrentOrder()
        {
            InitializeComponent();
        }

        private async void CurrentOrder_Load(object sender, EventArgs e)
        {
            products_table = DBHandler.LoadData("orders ORDER BY orders_id DESC LIMIT 1");
        }
    }
}
