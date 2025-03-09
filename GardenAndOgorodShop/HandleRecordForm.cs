using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private async void LoadComboBoxSource(ComboBox comboBox, string table_name, string display_member, string value_member)
        {
            try
            {
                System.Data.DataTable dataTable = await DBHandler.LoadData(table_name);
                // Устанавливаем DataSource для ComboBox
                comboBox.DataSource = dataTable;

                // Указываем, какое поле отображать
                comboBox.DisplayMember = display_member;

                // Указываем, какое поле использовать для значения
                comboBox.ValueMember = value_member;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке {table_name}: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HandleRecordForm_Load(object sender, EventArgs e)
        {
            tabControlRecords.SelectedIndex = selected_page;
            LoadComboBoxSource(comboBoxBrands, "brands", "brand_name", "brands_id");
            LoadComboBoxSource(comboBoxCategories, "categories", "category_name", "categories_id");
            LoadComboBoxSource(comboBoxSuppliers, "suppliers", "supplier_name", "suppliers_id");
        }
        private void buttonToMianForm_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void RestrictToDigitsAndBackspace(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void textBoxProductCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }

        private void textBoxProductSeasonalDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }

        private void textBoxProductIsAvaible_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }

        private void textBoxAmountInStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigitsAndBackspace(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pictureBox"></param>
        private void OpenImageDialogAndSetImage(PictureBox pictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Устанавливаем фильтр файлов (только JPG и PNG)
            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Выберите изображение";

            // Если пользователь выбрал файл и нажал "OK"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBoxProduct_Click(object sender, EventArgs e)
        {
            OpenImageDialogAndSetImage(pictureBoxProduct);
        }

        private void pictureBoxEmployee_Click(object sender, EventArgs e)
        {
            OpenImageDialogAndSetImage(pictureBoxEmployee);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabPage"></param>
        /// <returns></returns>
        private bool ValidateTabPage(TabPage tabPage)
        {
            bool isValid = true;
            Color _errorColor = Color.FromArgb(255, 192, 192);
            foreach (Control control in tabPage.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BackColor = _errorColor;
                        isValid = false;
                    }
                    else
                    {
                        textBox.BackColor = Color.White;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedItem == null || string.IsNullOrWhiteSpace(comboBox.Text))
                    {
                        comboBox.BackColor = _errorColor;
                        isValid = false;
                    }
                    else
                    {
                        comboBox.BackColor = Color.White;
                    }
                }
            }

            if (!isValid)
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void buttonAddEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTabPage(tabControlRecords.SelectedTab))
                {
                    string[] result = DBHandler.InsertProduct(
                            textBoxProductName.Text,
                            textBoxProductDesc.Text,
                            Convert.ToDouble(textBoxProductCost.Text),
                            comboBoxCategories.SelectedIndex,
                            comboBoxBrands.SelectedIndex,
                            Convert.ToInt32(textBoxProductIsAvaible.Text),
                            pictureBoxProduct.BackgroundImage,
                            comboBoxSuppliers.SelectedIndex,
                            Convert.ToInt32(textBoxProductSeasonalDiscount.Text)
                    ) ? new string[] {"Товар добавлен.", "Успех"} : new string[] { "Товар НЕ добавлен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка добавления продукта (form):\n" + err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
