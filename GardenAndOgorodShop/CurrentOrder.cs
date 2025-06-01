using Microsoft.Office.Interop.Excel;
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
        System.Data.DataTable products_table;
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
                    double cost = Convert.ToDouble(row[6]);
                    productPrice = $"{cost - cost * (Convert.ToDouble(row[12]) / 100)} ₽";
                    productAmount = $"{row[2]}";
                    if (row[10] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row[10];

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            productImage = Image.FromStream(ms);
                        }
                    }
                    totalCost += Convert.ToDouble(cost - cost * (Convert.ToDouble(row[12]) / 100)) * Convert.ToDouble(row[2]);
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
            save_cost = LoadProductDataGridView();
            labelTotalCost.Text = $"{save_cost}";
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
                    int amount_avaible = DBHandler.GetAmount(product_id);
                    if (amount_avaible != 0 || edit_backet == "-")
                    {
                        DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = `is_available` {edit_product} 1 WHERE (`products_id` = '{product_id}');");
                    }
                    double cost = Convert.ToDouble(save_cost);
                    double cost_ = Convert.ToDouble(selected_row[6]);
                    if (new_amount == 1)
                    {
                        if (edit_backet == "-")
                        {
                            dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount - 1}";
                            cost -= cost_ - cost_ * (Convert.ToDouble(selected_row[12]) / 100);
                            DBHandler.randomSQLCommand($"DELETE FROM `garden_and_ogorod_shop`.`products_orders` WHERE (`products_id` = '{product_id}') and (`orders_id` = '{UserConfiguration.Current_order_id}');");
                            await reloadBacket();
                            buttonAddProduct.Enabled = true;
                        }
                        else
                        {
                            if (amount_avaible > 0)
                            {
                                dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount + 1}";
                                cost += cost_ - cost_ * (Convert.ToDouble(selected_row[12]) / 100);
                            }
                            else
                            {
                                buttonAddProduct.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (edit_backet == "+")
                        {
                            if (amount_avaible > 0)
                            {
                                dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount + 1}";
                                cost += cost_ - cost_ * (Convert.ToDouble(selected_row[12]) / 100);
                            }
                            else
                            {
                                buttonAddProduct.Enabled = false;
                            }
                        }
                        else
                        {
                            dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount - 1}";
                            cost -= cost_ - cost_ * (Convert.ToDouble(selected_row[12]) / 100);
                            buttonAddProduct.Enabled = true;
                        }
                    }
                    save_cost = cost;
                    labelTotalCost.Text = Convert.ToString(cost);
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
            numericUpDown1.Value = 1;
            labelTotalCost.Text = $"{save_cost}";
            numericUpDown1.Maximum = Convert.ToInt32(save_cost) - 1;
        }

        private async void buttonMinus_Click(object sender, EventArgs e)
        {
            await PlusMinusAmountProduct_inOrder("-", "+");
            numericUpDown1.Value = 1;
            labelTotalCost.Text = $"{save_cost}";
            numericUpDown1.Maximum = Convert.ToInt32(save_cost) - 1;
        }
        private int _points = 0;
        private async void buttonDoneOrder_Click(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value > 0 && checkBox1.Checked)
            //{
            //    int points = Convert.ToInt32(labelPoints.Text) - Convert.ToInt32(numericUpDown1.Value);
            //    DBHandler.UpdateBonus(Convert.ToInt32(textBoxClient.Text), points);
            //}
            if (checkBox1.Checked)
            {
                _points = Convert.ToInt32(numericUpDown1.Value);
            }
            if (comboBoxPayMethod.Text != "") {
                try
                {
                    if (dataGridViewProducts.Rows.Count != 0)
                    {
                        DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`orders` SET" +
                            $" `employees_id` = '{UserConfiguration.UserID}'," +
                            $" `order_date` = NOW()," +
                            $" `order_status` = 'Успешно'," +
                            $" `payment_method` = '{comboBoxPayMethod.Text}'," +
                            $" `total_cost` = '{labelTotalCost.Text.Replace(',', '.')}'," +
                            $" `tax_amount` = '{Convert.ToString(Convert.ToDouble(labelTotalCost.Text) / 13.0).Replace(',', '.')}'," +
                            $" `notes` = '{textBoxOrderNotes.Text}'," +
                            $" `clients_id` = '{textBoxClient.Text}' " +
                            $"WHERE (`orders_id` = '{UserConfiguration.Current_order_id}');");
                        dataGridViewProducts.Rows.Clear();
                        MessageBox.Show(
                           $"Продажа проведена успешно",
                           "Статус продажи",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                        
                        buttonWarning.Visible = true;
                        int points = 0;
                        if (numericUpDown1.Value > 0 && checkBox1.Checked)
                        {
                            points = Convert.ToInt32(labelPoints.Text) - Convert.ToInt32(numericUpDown1.Value);
                            DBHandler.UpdateBonus(Convert.ToInt32(textBoxClient.Text), points);
                        }
                        
                        //
                        await PaymentAgreement.createExcelAgreement(_points);
                        //
                        UserConfiguration.Current_order_id = 0;
                        comboBoxPayMethod.SelectedIndex = -1;
                        textBoxClient.Text = "";
                        labelPoints.Text = "0";
                        buttonDoneOrder.Enabled = false;
                        labelTotalCost.Text = "0.0";
                        comboBoxPayMethod.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Корзина пуста", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show($"Ошибка\n{err}");
                }
            }
            else
            {
                MessageBox.Show(
                    $"Проверьте заполнения способа оплаты!",
                    "Проверка заполнения полей",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonWarning.Visible = comboBoxPayMethod.Text != "" ? false : true;
        }

        private void textBoxClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c)) && !char.IsControl(c);
        }

        private void textBoxClient_TextChanged(object sender, EventArgs e)
        {
            if (textBoxClient.Text != "")
            {
                int clients_id = Convert.ToInt32(textBoxClient.Text);
                int points = DBHandler.isExistClient_returnPoints(clients_id);
                if (points == -1)
                {
                    buttonDoneOrder.Enabled = false;
                    labelExistClient.Visible = true;
                    panelCheckExistClient.Visible = true;

                    labelPoints.Text = $"0";
                    checkBox1.Visible = false;
                }
                else
                {
                    buttonDoneOrder.Enabled = true;
                    labelExistClient.Visible = false;
                    panelCheckExistClient.Visible = false;

                    labelPoints.Text = $"{points}";
                    if (points == 0)
                    {
                        checkBox1.Visible = false;
                        numericUpDown1.Visible = false;
                    }
                    else
                    {
                        checkBox1.Visible = true;
                        if (dataGridViewProducts.Rows.Count <= 0)
                        {
                            checkBox1.Enabled = false;
                        }
                        else
                        {
                            checkBox1.Enabled = true;
                        }
                        if (save_cost < Convert.ToDouble(points))
                        {
                            numericUpDown1.Maximum = Convert.ToInt32(save_cost) -1;
                        }
                        else
                        {
                            numericUpDown1.Maximum = points;
                        }
                    }
                }
            }
            else
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                numericUpDown1.Visible = false;
                numericUpDown1.Value = 0;
            }

            checkBox1.Checked = false;
            numericUpDown1.Value = 1;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Visible = true;
                double cost = Convert.ToDouble(labelTotalCost.Text);
                labelTotalCost.Text = $"{cost - Convert.ToDouble(numericUpDown1.Value)}";
                
            }
            else
            {
                numericUpDown1.Visible = false;
                labelTotalCost.Text = $"{save_cost}";
            }
        }
        private double save_cost;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            labelTotalCost.Text = $"{save_cost}";
            if (numericUpDown1.Value > numericUpDown1.Maximum)
            {
                numericUpDown1.Value = numericUpDown1.Maximum;
            }
            double cost = Convert.ToDouble(labelTotalCost.Text);
            double cost_ = cost - Convert.ToDouble(numericUpDown1.Value);
            if (cost_ < 1) 
            {
                labelTotalCost.Text = $"1";
            }
            else
            {
                if (numericUpDown1.Visible)
                {
                    labelTotalCost.Text = $"{cost - Convert.ToDouble(numericUpDown1.Value)}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ширина: {this.Width}\nВысота:{this.Height}");
        }
    }
}
