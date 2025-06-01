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
    public partial class ChangeProduct : Form
    {
        private int id = 0;
        public ChangeProduct(int _id)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int is_avaible = 0;
        private int supplier_id = 0;
        private string supplier = "";
        private void ChangeProduct_Load(object sender, EventArgs e)
        {
            DataTable product_dt = DBHandler.LoadDataSync($"products INNER JOIN suppliers ON suppliers.suppliers_id = products.suppliers_id WHERE products_id = {id}");
            DataRow product = product_dt.Rows[0];

            labelName.Text = product["products_name"].ToString();
            is_avaible = Convert.ToInt32(product["is_available"]);
            labelHandle.Text = is_avaible.ToString();
            supplier = product["supplier_name"].ToString();
            supplier_id = Convert.ToInt32(product["suppliers_id"]);
            numericUpDown1.Maximum = is_avaible;

            comboBoxChange.SelectedIndex = 0;
            
        }

        private void comboBoxChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChange.SelectedIndex == 1)
            {
                labelHandle.Text = supplier;
                label3.Text = "Поставщик:";
                buttonWrite.Text = "Создать накладную";
                numericUpDown1.Maximum = 10000;
            }
            else
            {
                labelHandle.Text = is_avaible.ToString();
                label3.Text = "Доступно:";
                numericUpDown1.Maximum = is_avaible;
                buttonWrite.Text = "Списать товар";
            }
        }

        private void ChangeProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main form = new Main();
            form.Show();
        }

        private async void buttonWrite_Click(object sender, EventArgs e)
        {
            switch (comboBoxChange.SelectedIndex)
            {
                case 0:
                    await Reports.ReportWroteProduct(labelName.Text, Convert.ToInt32(numericUpDown1.Value), textBoxPr.Text);
                    ;break;
                case 1:
                    
                    ;break;
            }
        }
    }
}
