using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public partial class blockRecord : UserControl
    {
        public blockRecord()
        {
            InitializeComponent();
        }
        public string Header
        {
            get { return labelHeader.Text; }
            set
            {
                if (value.Length > 45)
                {
                    labelHeader.Text = value.Substring(0, 45) + "...";
                    toolTip.SetToolTip(labelHeader, value);
                }
                else
                {
                    labelHeader.Text = value;
                }
            }
        }
        public Color BackgColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public string Description
        {
            get { return labelDescription.Text; }
            set
            {
                string[] words = value.Split(' ');
                string[] strings = { "", "", "" };
                int complete_string = 0;
                foreach (string word in words)
                {
                    if ($"{strings[complete_string]} {word}".Length <= 60)
                    {
                        strings[complete_string] += word + " ";
                    }
                    else
                    {
                        complete_string++;
                        if (complete_string == 3)
                        {
                            break;
                        }
                    }
                }
                if (complete_string == 3)
                {
                    labelDescription.Text = strings[2].Substring(0, strings[2].Length-1) + "...";
                    toolTip.SetToolTip(labelDescription, value);
                }
                labelDescription.Text = $"{strings[0]}\n{strings[1]}\n{strings[2]}";
                
            }
        }
        public int Amount
        {
            get { return int.Parse(labelAmount.Text); }
            set { labelAmount.Text = value.ToString(); }
        }

        private double _defaultPrice;
        private int _discount;
        private double _priceWithDiscount;

        public int Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                UpdatePriceWithDiscount();
                if (_discount != 0)
                {
                    labelDiscount.Text = value.ToString() + "%";
                    labelDiscount.ForeColor = Color.YellowGreen;
                }
                else
                {
                    labelDiscount.Text = "";
                }
            }
        }

        public double PriceWithDiscount
        {
            get { return _priceWithDiscount; }
            private set 
            {
                _priceWithDiscount = value;
                labelPrice1.Text = value.ToString("N2");
                labelPrice1.ForeColor = _discount != 0 ? Color.Red : Color.Black;
            }
        }
        public double DefaultPrice
        {
            get { return _defaultPrice; }
            set
            {
                _defaultPrice = value;
                UpdatePriceWithDiscount();
                labelPrice2.Text = _discount != 0 ? value.ToString() : "";
            }
        }
        private void UpdatePriceWithDiscount()
        {
            if (_defaultPrice > 0 && _discount > 0)
            {
                PriceWithDiscount = _defaultPrice * (1 - (double)_discount / 100);
            }
            else
            {
                PriceWithDiscount = DefaultPrice;
            }
        }

        public Image ProductImage
        {
            get { return pictureBoxProduct.Image; }
            set 
            { 
                pictureBoxProduct.BackgroundImage = value;
            }
        }
        public bool VisibleButtons
        {
            set
            {
                buttonEdit.Visible = value;
                buttonDelete.Visible = value;
                buttonAddProductToBacket.Visible = !value;
            }
        }
        public bool EnabledButtons
        {
            set
            {
                buttonEdit.Enabled = value;
                buttonDelete.Enabled = value;
                buttonAddProductToBacket.Enabled = value;
            }
        }
        public int IDrecord
        {
            get { return int.Parse(labelID.Text); }
            set
            {
                labelID.Text = value.ToString();
            }
        }
        public event EventHandler FormClose;
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormClose?.Invoke(this, EventArgs.Empty);
            HandleRecordForm form = new HandleRecordForm(0, "edit", Convert.ToInt32(labelID.Text));
            form.Show();
        }
        public event EventHandler ProductDeleted;
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Вы уверены что хотите удалить продукт '{labelHeader.Text}'?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (dr == DialogResult.Yes)
            {
                if (DBHandler.DeleteHandler("products", "products_id", Convert.ToInt32(labelID.Text)))
                {
                    MessageBox.Show($"Продукт удалён",
                    "Результат",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                    ProductDeleted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show($"Продукт не был удалён!",
                    "Результат",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
            }
        }
        public event EventHandler ProductAddToBacket;
        private void buttonAddProductToBacket_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserConfiguration.Current_order_id == 0)
                {
                    UserConfiguration.Current_order_id = DBHandler.getNewIdOrder();
                    if (UserConfiguration.Current_order_id != 0)
                    {
                        resultAdd_inOrder(IDrecord);
                    }
                    else
                    {
                        //badResultView();
                    }
                }
                else
                {
                    resultAdd_inOrder(IDrecord);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
            //resultAdd_inOrder(productToDelete.IDrecord, productToDelete);
            ProductAddToBacket?.Invoke(this, EventArgs.Empty);
        }
        private async void resultAdd_inOrder(int product_id)
        {
            try
            {
                if (AddEditProduct_inOrder(product_id))
                {
                    //customSlider1.Enabled = false;
                    //labelReadyOrNot.ForeColor = Color.Green;
                    //labelReadyOrNot.Text = "Товар добавлен.";
                    //pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.ready;
                    //panelResult.Visible = true;
                    //await Task.Delay(1000);
                    //panelResult.Visible = false;
                    //customSlider1.Enabled = true;

                    //int new_amount = Convert.ToInt32(Convert.ToString(dataGridViewProducts.Rows[index_row].Cells[3].Value).Replace(" шт.", ""));
                    int new_amount = Amount;
                    DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = '{new_amount - 1}' WHERE (`products_id` = '{product_id}');");
                    //if (new_amount == 1)
                    //{
                    //    await reloadProductData();
                    //}
                    //dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount - 1} шт.";
                    Amount -= 1;
                }
                else
                {
                    //badResultView();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }
        //private async void badResultView()
        //{
        //    buttonAddProductToBacket.Enabled = false;
        //    labelReadyOrNot.ForeColor = Color.Red;
        //    labelReadyOrNot.Text = "Товар НЕ добавлен!";
        //    pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.cancel;
        //    panelResult.Visible = true;
        //    await Task.Delay(1000);
        //    panelResult.Visible = false;
        //    buttonAddProductToBacket.Enabled = true;
        //}
        private bool AddEditProduct_inOrder(int product_id)
        {
            try
            {
                if (DBHandler.checkExistProduct_inOrder(product_id))
                {
                    return DBHandler.randomSQLCommand($@"
                    UPDATE `products_orders` 
                    SET `product_amount` = `product_amount` + 1 
                    WHERE products_id = {product_id} AND orders_id = {UserConfiguration.Current_order_id};");
                }
                else
                {
                    return DBHandler.randomSQLCommand($@"
                    INSERT INTO `garden_and_ogorod_shop`.`products_orders` 
                    (`products_id`, `orders_id`, `product_amount`) 
                    VALUES ('{product_id}', '{UserConfiguration.Current_order_id}', '1');");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
                return false;
            }
        }
        //private async void resultAdd_inOrder(int product_id)
        //{
        //    try
        //    {
        //        if (AddEditProduct_inOrder(product_id))
        //        {
        //            buttonBacket.Enabled = false;
        //            labelReadyOrNot.ForeColor = Color.Green;
        //            labelReadyOrNot.Text = "Товар добавлен.";
        //            pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.ready;
        //            panelResult.Visible = true;
        //            await Task.Delay(1000);
        //            panelResult.Visible = false;
        //            buttonBacket.Enabled = true;
        //            int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
        //            int new_amount = Convert.ToInt32(Convert.ToString(dataGridViewProducts.Rows[index_row].Cells[3].Value).Replace(" шт.", ""));
        //            DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = '{new_amount - 1}' WHERE (`products_id` = '{product_id}');");
        //            if (new_amount == 1)
        //            {
        //                await reloadProductData();
        //            }
        //            else
        //            {
        //                dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount - 1} шт.";
        //            }
        //        }
        //        else
        //        {
        //            badResultView();
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show($"Ошибка\n{err}");
        //    }
        //}
        //private async void badResultView()
        //{
        //    buttonBacket.Enabled = false;
        //    labelReadyOrNot.ForeColor = Color.Red;
        //    labelReadyOrNot.Text = "Товар НЕ добавлен!";
        //    pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.cancel;
        //    panelResult.Visible = true;
        //    await Task.Delay(1000);
        //    panelResult.Visible = false;
        //    buttonBacket.Enabled = true;
        //}
    }
}
