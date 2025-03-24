using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public partial class HandleRecordForm : Form
    {
        private int selected_page = 0;
        private int id_record = 0;
        private string selected_mode = "add";
        public HandleRecordForm(int page, string mode, int id)
        {
            InitializeComponent();
            this.selected_page = page;
            this.id_record = id;
            this.selected_mode = mode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="table_name"></param>
        /// <param name="display_member"></param>
        /// <param name="value_member"></param>
        private void LoadComboBoxSource(ComboBox comboBox, string table_name, string display_member, string value_member)
        {
            try
            {
                System.Data.DataTable dataTable = DBHandler.LoadDataSync(table_name);
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
        System.Data.DataTable employees;
        private void LoadComboBoxSourceEmployee()
        {
            try
            {
                DataTable employees_ = DBHandler.LoadEmployeesComboBox();
                comboBoxEmployeeUser.DataSource = employees_;
                comboBoxEmployeeUser.DisplayMember = "names";
                comboBoxEmployeeUser.ValueMember = "ids";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка сотрудников: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        byte[] imageData;
        private void loadEditDataProduct()
        {
            DataTable table = DBHandler.LoadDataSync($"products WHERE products_id = {id_record}");
            DataRow selected_product = table.Rows[0];
            if (selected_product != null)
            {
                textBoxProductName.Text = Convert.ToString(selected_product[1]);
                textBoxProductDesc.Text = Convert.ToString(selected_product[2]);
                textBoxProductCost.Text = Convert.ToString(selected_product[3]);
                int count = comboBoxCategories.Items.Count;
                comboBoxCategories.SelectedIndex = Convert.ToInt32(selected_product[4]);
                comboBoxBrands.SelectedIndex = Convert.ToInt32(selected_product[5]);
                textBoxProductIsAvaible.Text = Convert.ToString(selected_product[6]);
                imageData = (byte[])selected_product[7];
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBoxProduct.BackgroundImage = Image.FromStream(ms);
                }
                comboBoxSuppliers.SelectedIndex = Convert.ToInt32(selected_product[8]);
                textBoxProductSeasonalDiscount.Text = Convert.ToString(selected_product[9]);
                buttonAddEditProduct.Text = "Изменить";
            }
        }
        private void loadEditDataCategory()
        {
            DataTable table = DBHandler.LoadDataSync($"categories WHERE categories_id = {id_record}");
            DataRow selected_row = table.Rows[0];
            if (selected_row != null)
            {
                textBoxCategoryTitle.Text = Convert.ToString(selected_row[1]);
                textBoxCategoryDesc.Text = Convert.ToString(selected_row[2]);
                buttonAddEditCategory.Text = "Изменить";
            }
        }
        private void loadEditData_employee()
        {
            DataTable table = DBHandler.LoadDataSync($"employees WHERE employees_id = {id_record}");
            DataRow selected_row = table.Rows[0];
            if (selected_row != null)
            {
                textBoxLastName.Text = $"{selected_row[2]}";
                textBoxFirstName.Text = $"{selected_row[1]}";
                textBoxFathersName.Text = $"{selected_row[3]}";
                dateTimePickerAge.Value = DateTime.Parse($"{selected_row[4]}");
                int years = DateTime.Now.Year - dateTimePickerAge.Value.Year;
                if (dateTimePickerAge.Value.AddYears(years) > DateTime.Now) years--;
                labelAge.Text = years.ToString();
                comboBoxGender.SelectedIndex = $"{selected_row[5]}" == "мужской" ? 0 : 1;
                maskedTextBoxEmployeePhone.Text = $"{selected_row[6]}";
                textBoxEmployeeEmail.Text = $"{selected_row[7]}";
                textBoxEmployeeAddress.Text = $"{selected_row[8]}";
                textBoxPosition.Text = $"{selected_row[9]}";
                textBoxEmployeePrice.Text = $"{selected_row[11]}";
                textBoxEmployeeDesc.Text = $"{selected_row[12]}";
                if (DBNull.Value != selected_row[13])
                {
                    blobData_employee = (byte[])selected_row[13];
                    using (MemoryStream ms = new MemoryStream(blobData_employee))
                    {
                        pictureBoxEmployee.BackgroundImage = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBoxEmployee.BackgroundImage = Properties.Resources.none_employee;
                }
                buttonAddEditEmployee.Text = "Изменить";
            }
        }
        private void loadEditData_user()
        {
            DataTable table = DBHandler.LoadDataSync($"users WHERE users_id = {id_record}");
            DataRow selected_row = table.Rows[0];
            if (selected_row != null)
            {
                textBoxLogin.Text = $"{selected_row[1]}";
                textBoxPwd.Text = $"{selected_row[2]}";
                comboBoxEmployeeUser.SelectedValue = Convert.ToInt32(selected_row[3]);
                comboBoxRole.SelectedIndex = Convert.ToInt32(selected_row[4])-1;
                textBoxUserDesc.Text = $"{selected_row[6]}";
                buttonAddEditUser.Text = "Изменить";
            }
        }
        private void loadEditData_brand()
        {
            DataTable table = DBHandler.LoadDataSync($"brands WHERE brands_id = {id_record}");
            DataRow selected_row = table.Rows[0];
            if (selected_row != null)
            {
                textBoxManName.Text = $"{selected_row[1]}";
                textBoxManEmail.Text = $"{selected_row[3]}";
                maskedTextBoxManPhone.Text = $"{selected_row[4]}";
                textBoxManAddress.Text = $"{selected_row[5]}";
                textBoxManDesc.Text = $"{selected_row[2]}";
                button9.Text = "Изменить";
            }
        }
        private void loadEditData_supplier()
        {
            DataTable table = DBHandler.LoadDataSync($"suppliers WHERE suppliers_id = {id_record}");
            DataRow selected_row = table.Rows[0];
            if (selected_row != null)
            {
                textBoxSupName.Text = $"{selected_row[1]}";
                textBoxSupEmail.Text = $"{selected_row[3]}";
                maskedTextBoxSupPhone.Text = $"{selected_row[4]}";
                textBoxSupAddress.Text = $"{selected_row[5]}";
                textBoxSupDesc.Text = $"{selected_row[2]}";
                textBoxSupINN.Text = $"{selected_row[6]}";
                button9.Text = "Изменить";
            }
        }
        private void loadEditData_order()
        {
            DataTable table = DBHandler.LoadDataSync($"garden_and_ogorod_shop.orders INNER JOIN employees ON employees.employees_id = orders.employees_id WHERE orders_id = {id_record};");
            DataRow row = table.Rows[0];
            if (row != null)
            {
                try
                {
                    comboBoxEmployeeOrder.SelectedValue = Convert.ToInt32(row[1]);

                    dateTimePickerOrder.Value = DateTime.Parse($"{row[2]}");

                    comboBoxStatus.Text = $"{row[3]}";
                    comboBoxPayMethod.Text = $"{row[4]}";
                    textBoxTotalCost.Text = $"{row[5]}";
                    textBoxOrderDesc.Text = $"{row[7]}";
                }
                catch (Exception er)
                {
                    MessageBox.Show("Ошибка загрузки данных о продаже", "Заполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                button13.Text = "Изменить";
            }
        }
        private void loadEditData()
        {
            switch (tabControlRecords.SelectedIndex)
            {
                case 0: loadEditDataProduct(); break;
                case 1: loadEditDataCategory(); break;
                case 2: loadEditData_employee(); break;
                case 3: loadEditData_user(); break;
                case 4: loadEditData_brand(); break;
                case 5: loadEditData_supplier(); break;
                case 6: loadEditData_order(); break;
                default: MessageBox.Show("Не найдена нужная таблица\n(selected index -> table)"); Main form = new Main(); form.Show(); this.Hide(); break;
            }
        }
        private void HandleRecordForm_Load(object sender, EventArgs e)
        {
            dateTimePickerOrder.MaxDate = DateTime.Today;
            #region EmployeeDataLoad
            try
            {
                (string firstName, string lastName, string fathersName, Image photo) employeeData = DBHandler.LoadEmployeeData();
                labelEmployeeName.Text = employeeData.lastName + " " + employeeData.firstName.Substring(0, 1) + "." + employeeData.fathersName.Substring(0, 1) + ".";
                pictureBoxUser.BackgroundImage = employeeData.photo;
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка загрузки пользователя");
            }
            #endregion
            tabControlRecords.SelectedIndex = selected_page;
            LoadComboBoxSource(comboBoxBrands, "brands", "brand_name", "brands_id");
            LoadComboBoxSource(comboBoxCategories, "categories", "category_name", "categories_id");
            LoadComboBoxSource(comboBoxSuppliers, "suppliers", "supplier_name", "suppliers_id");
            //LoadComboBoxSource(comboBoxEmployeeUser, "employees", "last_name", "employees_id");
            LoadComboBoxSourceEmployee();
            if (this.selected_mode == "edit")
            {
                try
                {
                    employees = DBHandler.LoadEmployeesComboBox();
                    comboBoxEmployeeOrder.DataSource = employees;
                    comboBoxEmployeeOrder.DisplayMember = "names";
                    comboBoxEmployeeOrder.ValueMember = "ids";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке сотрудника: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadEditData();
            }
            else
            {
                comboBoxEmployeeUser.SelectedIndex = -1;
            }
            
        }
        private void buttonToMianForm_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
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
            switch (tabPage.Name)
            {
                case "tabPageEmployee":
                    if (!maskedTextBoxEmployeePhone.MaskCompleted)
                    {
                        MessageBox.Show("Пожалуйста, введите полный номер телефона.");
                        isValid = false;
                    }
                    if (labelAge.Text == "00")
                    {
                        MessageBox.Show("Пожалуйста, укажите возраст.");
                        isValid = false;
                    }
                    ; break;
                case "tabPageBrand":
                    if (!maskedTextBoxManPhone.MaskCompleted)
                    {
                        MessageBox.Show("Пожалуйста, введите полный номер телефона.");
                        isValid = false;
                    }
                    ; break;
                case "tabPageSupplier":
                    if (!maskedTextBoxSupPhone.MaskCompleted)
                    {
                        MessageBox.Show("Пожалуйста, введите полный номер телефона.");
                        isValid = false;
                    }
                    ; break;
            }
           
            return isValid;
        }
        private void ClearFieldsOnForm_product()
        {
            textBoxProductName.Text = "";
            textBoxProductDesc.Text = "";
            textBoxProductCost.Text = "";
            comboBoxCategories.SelectedIndex = -1;
            comboBoxBrands.SelectedIndex = -1;
            textBoxProductIsAvaible.Text = "";
            pictureBoxProduct.BackgroundImage = Properties.Resources.none_image;
            comboBoxSuppliers.SelectedIndex = -1;
            textBoxProductSeasonalDiscount.Text = "";
        }
        private void ClearFieldsOnForm_category()
        {
            textBoxCategoryTitle.Text = "";
            textBoxCategoryDesc.Text = "";
        }
        private void ClearFieldsOnForm_employee()
        {
            textBoxLastName.Text = "";
            textBoxFirstName.Text = "";
            textBoxFathersName.Text = "";
            dateTimePickerAge.Value = new DateTime(2000, 1, 1);
            comboBoxGender.SelectedIndex = -1;
            maskedTextBoxEmployeePhone.Text = "";
            textBoxEmployeeEmail.Text = "";
            textBoxEmployeeAddress.Text = "";
            textBoxPosition.Text = "";
            textBoxEmployeePrice.Text = "";
            textBoxEmployeeDesc.Text = "";
        }
        private void ClearFieldsOnForm_user()
        {
            textBoxLogin.Text = "";
            textBoxPwd.Text = "";
            comboBoxRole.SelectedIndex = -1;
            comboBoxEmployeeUser.SelectedIndex = -1;
            textBoxUserDesc.Text = "";
        }
        private void ClearFieldsOnForm_brand()
        {
            textBoxManName.Text = "";
            textBoxManEmail.Text = "";
            maskedTextBoxManPhone.Text = "";
            textBoxManAddress.Text = "";
            textBoxManDesc.Text = "";
        }
        private void ClearFieldsOnForm_supplier()
        {
            textBoxSupName.Text = "";
            textBoxSupEmail.Text = "";
            maskedTextBoxSupPhone.Text = "";
            textBoxSupAddress.Text = "";
            textBoxSupINN.Text = "";
            textBoxSupDesc.Text = "";
        }
        private string[] SuccessAddRecordResult(string elem, string form)
        {
            switch (form)
            {
                case "product": ClearFieldsOnForm_product(); break;
                case "category": ClearFieldsOnForm_category(); break;
                case "employee": ClearFieldsOnForm_employee(); break;
                case "user": ClearFieldsOnForm_user(); break;
                case "brand": ClearFieldsOnForm_brand(); break;
                case "supplier": ClearFieldsOnForm_supplier(); break;
                default:;break;
            }
            return new string[] { $"{elem} добавлен.", "Успех" };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTabPage(tabControlRecords.SelectedTab))
                {
                    if (selected_mode == "add")
                    {
                        string[] result = DBHandler.InsertProduct(
                            textBoxProductName.Text,
                            textBoxProductDesc.Text,
                            Convert.ToDecimal(textBoxProductCost.Text),
                            comboBoxCategories.SelectedIndex,
                            comboBoxBrands.SelectedIndex,
                            Convert.ToInt32(textBoxProductIsAvaible.Text),
                            pictureBoxProduct.BackgroundImage,
                            comboBoxSuppliers.SelectedIndex,
                            Convert.ToDecimal(textBoxProductSeasonalDiscount.Text)
                    ) ? SuccessAddRecordResult("Товар", "product") : new string[] { "Товар НЕ добавлен!", "Провал" };
                        MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        double cost = Convert.ToDouble(textBoxProductCost.Text);
                        int amount = Convert.ToInt32(textBoxProductIsAvaible.Text);
                        double discount = Convert.ToDouble(textBoxProductSeasonalDiscount.Text);

                        string title = Convert.ToString(textBoxProductName.Text);

                        string[] result = DBHandler.EditProduct(
                            title,
                            textBoxProductDesc.Text,
                            cost,
                            comboBoxCategories.SelectedIndex,
                            comboBoxBrands.SelectedIndex,
                            amount,
                            pictureBoxProduct.BackgroundImage,
                            comboBoxSuppliers.SelectedIndex,
                            discount,
                            id_record
                    ) ? new string[] { "Товар изменен.", "Успех" } : new string[] { "Товар НЕ был изменен!", "Провал" };
                        MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка обработки продукта (form):\n" + err.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                string elem_table = "Категория";
                if (selected_mode == "add")
                {
                    string[] result = DBHandler.InsertCategory(
                        textBoxCategoryTitle.Text,
                        textBoxCategoryDesc.Text
                )
                ? SuccessAddRecordResult(elem_table, "category") : new string[] { $"{elem_table} НЕ добавлена!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] result = DBHandler.EditCategory(
                       textBoxCategoryTitle.Text,
                       textBoxCategoryDesc.Text,
                       id_record
               )
               ? new string[] { $"{elem_table} изменена.", "Успех" } : new string[] { $"{elem_table} НЕ была изменена!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                string elem_table = "Сотрудник";
                if (selected_mode == "add")
                {
                    string[] result = DBHandler.InsertEmployee(
                        textBoxLastName.Text,
                        textBoxFirstName.Text,
                        textBoxFathersName.Text,
                        dateTimePickerAge.Value.ToString("yyyy-MM-dd"),
                        comboBoxGender.Text,
                        maskedTextBoxEmployeePhone.Text,
                        textBoxEmployeeEmail.Text,
                        textBoxEmployeeAddress.Text,
                        textBoxPosition.Text,
                        textBoxEmployeePrice.Text,
                        textBoxEmployeeDesc.Text,
                        pictureBoxEmployee.BackgroundImage
                )
                ? SuccessAddRecordResult(elem_table, "employee") : new string[] { $"{elem_table} НЕ добавлен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] result = DBHandler.EditEmployee(
                        textBoxLastName.Text,
                        textBoxFirstName.Text,
                        textBoxFathersName.Text,
                        dateTimePickerAge.Value.ToString("yyyy-MM-dd"),
                        comboBoxGender.Text,
                        maskedTextBoxEmployeePhone.Text,
                        textBoxEmployeeEmail.Text,
                        textBoxEmployeeAddress.Text,
                        textBoxPosition.Text,
                        textBoxEmployeePrice.Text,
                        textBoxEmployeeDesc.Text,
                        blobData_employee,
                        id_record
               )
               ? new string[] { $"{elem_table} изменен.", "Успех" } : new string[] { $"{elem_table} НЕ был изменен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Создаем новый экземпляр SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Вычисляем хэш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Преобразуем байты в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Преобразуем в шестнадцатеричный формат
                }
                return builder.ToString();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                string elem_table = "Пользователь";
                if (selected_mode == "add")
                {
                    DataRow row = employees.Rows[comboBoxEmployeeUser.SelectedIndex];

                    string[] result = DBHandler.InsertUser(
                        textBoxLogin.Text,
                        ComputeSha256Hash(textBoxPwd.Text),
                        Convert.ToInt32(row[0]),
                        comboBoxRole.SelectedIndex+1,
                        textBoxUserDesc.Text
                )
                ? SuccessAddRecordResult(elem_table, "user") : new string[] { $"{elem_table} НЕ добавлен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] result = DBHandler.EditUser(
                         textBoxLogin.Text,
                         textBoxPwd.Text,
                         comboBoxEmployeeUser.SelectedIndex + 1,
                         comboBoxRole.SelectedIndex + 1,
                         textBoxUserDesc.Text,
                         id_record
                 )
                ? new string[] { $"{elem_table} изменен.", "Успех" } : new string[] { $"{elem_table} НЕ был изменен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                string elem_table = "Производитель";
                if (selected_mode == "add")
                {
                    string[] result = DBHandler.InsertBrand(
                        textBoxManName.Text,
                        textBoxManEmail.Text,
                        maskedTextBoxManPhone.Text,
                        textBoxManAddress.Text,
                        textBoxManDesc.Text
                )
                ? SuccessAddRecordResult(elem_table, "brand") : new string[] { $"{elem_table} НЕ добавлен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] result = DBHandler.EditBrand(
                        textBoxManName.Text,
                        textBoxManEmail.Text,
                        maskedTextBoxManPhone.Text,
                        textBoxManAddress.Text,
                        textBoxManDesc.Text,
                        id_record
                 )
                ? new string[] { $"{elem_table} изменен.", "Успех" } : new string[] { $"{elem_table} НЕ был изменен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                string elem_table = "Поставщик";
                if (selected_mode == "add")
                {
                    string[] result = DBHandler.InsertSup(
                        textBoxSupName.Text,
                        textBoxSupEmail.Text,
                        maskedTextBoxSupPhone.Text,
                        textBoxSupAddress.Text,
                        textBoxSupINN.Text,
                        textBoxSupDesc.Text
                )
                ? SuccessAddRecordResult(elem_table, "supplier") : new string[] { $"{elem_table} НЕ добавлен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] result = DBHandler.EditSup(
                        textBoxSupName.Text,
                        textBoxSupEmail.Text,
                        maskedTextBoxSupPhone.Text,
                        textBoxSupAddress.Text,
                        textBoxSupINN.Text,
                        textBoxSupDesc.Text,
                        id_record
                 )
                ? new string[] { $"{elem_table} изменен.", "Успех" } : new string[] { $"{elem_table} НЕ был изменен!", "Провал" };
                    MessageBox.Show(result[0], result[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ValidateTabPage(tabControlRecords.SelectedTab))
            {
                MessageBox.Show("Все поля заполнены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region Handle panel menu
        bool setting_active_status = false;
        bool moving;
        // ФУНКЦИЯ ВИДИМОСТИ ЭЛЕМЕНТОВ ПАНЕЛИ НАВИГАЦИИ
        private void VisibleItemsNavigation(bool visible)
        {
            foreach (Control control in panelNavigation.Controls)
            {
                control.Visible = visible;
            }
        }
        // ФУНКЦИЯ ПОЯВЛЕНИЯ ПАНЕЛИ НАВИГАЦИИ
        private async void ActiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelNavigation.Width + 160;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelNavigation.Width < future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelNavigation.Width += 20;
                moving = false;
            }
            setting_active_status = true;
            VisibleItemsNavigation(true);
            pictureBoxUser.Visible = true;
            panelEmployeeData.Visible = true;
            buttonMenu.Visible = true;
            buttonMenu.BackgroundImage = GardenAndOgorodShop.Properties.Resources.closed_menu;

        }
        // ФУНКЦИЯ СКРЫТИЯ ПАНЕЛИ НАВИГАЦИИ
        private async void DisactiveSetting()
        {
            // задаём будущее положение панели настроек
            int future_location_pannelSettings = panelNavigation.Width - 160;
            // цикл по пиксельного перемещения с итерационным созданием точки локации на форме
            while (!moving && panelNavigation.Width > future_location_pannelSettings)
            {
                moving = true;
                await Task.Delay(1);
                panelNavigation.Width -= 20;
                moving = false;
            }
            setting_active_status = false;
            VisibleItemsNavigation(false);
            pictureBoxUser.Visible = true;
            panelEmployeeData.Visible = true;
            buttonMenu.Visible = true;
            buttonMenu.BackgroundImage = GardenAndOgorodShop.Properties.Resources.burger_menu;
        }
        #endregion
        
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (!setting_active_status)
            {
                ActiveSetting();
            }
            else
            {
                DisactiveSetting();
            }
        }

        private void dateTimePickerAge_ValueChanged(object sender, EventArgs e)
        {
            int years = DateTime.Now.Year - dateTimePickerAge.Value.Year;
            if (dateTimePickerAge.Value.AddYears(years) > DateTime.Now) years--;
            labelAge.Text = years.ToString();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {

        }
        byte[] blobData_employee;
        private void pictureBoxEmployee_BackgroundImageChanged(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxEmployee.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                blobData_employee = ms.ToArray();
            }
        }
    }
}
