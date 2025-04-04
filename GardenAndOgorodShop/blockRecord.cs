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
            }
        }
        public double DefaultPrice
        {
            get { return _defaultPrice; }
            set
            {
                _defaultPrice = value;
                UpdatePriceWithDiscount();
                labelPrice2.Text = value.ToString("N2"); 
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(0, "edit", Convert.ToInt32(labelID.Text));
            form.Show();
            this.Hide();
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
