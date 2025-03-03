using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public partial class CurrentOrder : Form
    {
        DataTable products_table;
        public CurrentOrder()
        {
            InitializeComponent();
        }
        private double LoadProductDataGridView()
        {
            double totalCost = 0.0;
            foreach (DataRow row in products_table.Rows)
            {
                Image productImage = Properties.Resources.none_image;
                string productTitle = "none";
                string productPrice = "none";
                string productAmount = "none";
                try
                {
                    productTitle = $"{row[4]}";
                    productPrice = $"{row[6]} ₽";
                    productAmount = $"{row[2]}";
                    if (row[10] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row[10];

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            productImage = Image.FromStream(ms);
                        }
                    }
                    totalCost += Convert.ToDouble(row[6]) * Convert.ToDouble(row[2]);
                }
                catch
                {
                    productImage = Properties.Resources.none_image;
                }
                dataGridViewProducts.Rows.Add(productImage, productTitle, productPrice, productAmount);
            }
            return totalCost;
        }
        private async Task reloadBacket()
        {
            products_table = await DBHandler.LoadData($"products_orders INNER JOIN products ON products_orders.products_id = products.products_id WHERE orders_id = {UserConfiguration.Current_order_id};");
            dataGridViewProducts.Rows.Clear();
            labelTotalCost.Text = $"{LoadProductDataGridView()}";
        } 
        private async void CurrentOrder_Load(object sender, EventArgs e)
        {
            await reloadBacket();
            buttonDoneOrder.Enabled = dataGridViewProducts.Rows.Count == 0 ? false : true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private void CurrentOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        }

        private async void buttonDeleteProduct_Click(object sender, EventArgs e)
        { 
            try
            {
                if (dataGridViewProducts.Rows.Count > 0)
                {
                    int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
                    DataRow selected_row = products_table.Rows[index_row];
                    int product_id = Convert.ToInt32(selected_row[1]);
                    DBHandler.returnProduct();
                    DBHandler.randomSQLCommand($"DELETE FROM `garden_and_ogorod_shop`.`products_orders` WHERE `orders_id` = '{UserConfiguration.Current_order_id}';");
                    await reloadBacket();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }
        private async Task PlusMinusAmountProduct_inOrder(string edit_backet, string edit_product)
        {
            try
            {
                if (dataGridViewProducts.Rows.Count > 0)
                {
                    int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
                    DataRow selected_row = products_table.Rows[index_row];
                    int product_id = Convert.ToInt32(selected_row[1]);
                    DBHandler.randomSQLCommand($@"
                    UPDATE `products_orders` 
                    SET `product_amount` = `product_amount` {edit_backet} 1 
                    WHERE products_id = {product_id} AND orders_id = {UserConfiguration.Current_order_id};");
                    int new_amount = Convert.ToInt32(dataGridViewProducts.Rows[index_row].Cells[3].Value);
                    DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = `is_available` {edit_product} 1 WHERE (`products_id` = '{product_id}');");
                    if (new_amount == 1)
                    {
                        if (edit_backet == "-")
                        {
                            DBHandler.randomSQLCommand($"DELETE FROM `garden_and_ogorod_shop`.`products_orders` WHERE (`products_id` = '{product_id}') and (`orders_id` = '{UserConfiguration.Current_order_id}');");
                            await reloadBacket();
                        }
                        else
                        {
                            dataGridViewProducts.Rows[index_row].Cells[3].Value = edit_backet == "+" ? $"{new_amount + 1}" : $"{new_amount - 1}";
                        }
                    }
                    else
                    {
                        dataGridViewProducts.Rows[index_row].Cells[3].Value = edit_backet == "+" ? $"{new_amount + 1}" : $"{new_amount - 1}";
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }
        private async void buttonAddProduct_Click(object sender, EventArgs e)
        {
            await PlusMinusAmountProduct_inOrder("+", "-");
        }

        private async void buttonMinus_Click(object sender, EventArgs e)
        {
            await PlusMinusAmountProduct_inOrder("-", "+");
        }

        private async void buttonDoneOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxPayMethod.Text == "") {
                MessageBox.Show(
                    $"Проверьте заполнения способа оплаты!",
                    "Проверка заполнения полей",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            try
            {
                if (dataGridViewProducts.Rows.Count != 0 && comboBoxPayMethod.Text != "")
                {
                    DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`orders` SET" +
                        $" `employees_id` = '{UserConfiguration.UserID}'," +
                        $" `order_date` = NOW()," +
                        $" `order_status` = 'Успешно'," +
                        $" `payment_method` = '{comboBoxPayMethod.Text}'," +
                        $" `total_cost` = '{labelTotalCost.Text.Replace(',', '.')}'," +
                        $" `tax_amount` = '{Convert.ToString(Convert.ToDouble(labelTotalCost.Text) / 13.0).Replace(',', '.')}'," +
                        $" `notes` = '{textBoxOrderNotes.Text}' " +
                        $"WHERE (`orders_id` = '{UserConfiguration.Current_order_id}');");
                    dataGridViewProducts.Rows.Clear();
                    MessageBox.Show(
                       $"Продажа проведена успешно",
                       "Статус продажи",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    buttonDoneOrder.Enabled = false;
                    labelTotalCost.Text = "0.0";
                    comboBoxPayMethod.Text = "";
                    buttonWarning.Visible = true;
                    //
                    await PaymentAgreement.createExcelAgreement();
                    //
                    UserConfiguration.Current_order_id = 0;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonWarning.Visible = comboBoxPayMethod.Text != "" ? false : true;
        }
    }
}
