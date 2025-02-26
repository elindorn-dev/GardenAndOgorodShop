using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GardenAndOgorodShop
{
    public partial class Main : Form
    {
        // переменная для обработки перемещения панели настроек
        bool moving;
        // переменная-флаг активации по нажатию кнопки
        bool setting_active_status = false;

        string[] categories_strings;

        private string save_search_text = "";

        private DataTable products_table;
        public Main()
        {
            InitializeComponent();
        }
        #region Handle panel menu
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
            button5.Visible = true;
            button5.BackgroundImage = GardenAndOgorodShop.Properties.Resources.closed_menu;
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
            button5.Visible = true;
            button5.BackgroundImage = GardenAndOgorodShop.Properties.Resources.burger_menu;
        }
        #endregion
        #region Loading table's data to dataGridView
        private void LoadProductDataGridView()
        {
            foreach (DataRow row in products_table.Rows)
            {
                Image productImage = Properties.Resources.none_image;
                string productTitle = "none";
                string productPrice = "none";
                string productCategory = "none";
                try
                {
                    productTitle = $"{row[1]}";
                    productPrice = $"{row[3]} ₽";
                    productCategory = $"{categories_strings[Convert.ToInt32(row[4])-1]}";
                    if (row[7] != DBNull.Value) 
                    {
                        byte[] imageData = (byte[])row[7]; 

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            productImage = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    productImage = Properties.Resources.none_image;
                }
                dataGridViewProducts.Rows.Add(productImage, productTitle, productPrice, productCategory);
            }
        }
        private void LoadCategoriesDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("categories").Rows)
            {
                string titleCategory = "none";
                string descCategory = "none";
                try
                {
                    titleCategory = $"{row[1]}";
                    descCategory = $"{row[2]}";
                }
                catch
                {
                    titleCategory = "none";
                    descCategory = "none";
                }
                dataGridViewCategories.Rows.Add(titleCategory, descCategory);
            }
        }
        private void LoadUsersDataGridView()
        {
            string[] roles = { "Администратор", "Продавец" };
            foreach (DataRow row in DBHandler.LoadData("users").Rows)
            {
                string loginUser = "none";
                string roleUser = "none";
                string lastLoginUser = "none";
                try
                {
                    loginUser = $"{row[1]}";
                    roleUser = $"{roles[Convert.ToInt32(row[3])-1]}";
                    lastLoginUser = $"{row[4]}";
                }
                catch
                {
                    loginUser = "none";
                    roleUser = "none";
                    lastLoginUser = "none";
                }
                dataGridViewUsers.Rows.Add(loginUser, roleUser, lastLoginUser);
            }
        }
        private void LoadOrdersDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("orders").Rows)
            {
                string orderId = "none";
                string orderDate = "none";
                string orderStatus = "none";
                string orderCost = "none";
                try
                {
                    orderId = $"{row[0]}";
                    orderDate = $"{row[2]}";
                    orderStatus = $"{row[3]}";
                    orderCost = $"{row[5]}";
                }
                catch
                {
                    orderId = "none";
                    orderDate = "none";
                    orderStatus = "none";
                    orderCost = "none";
                }
                dataGridViewOrders.Rows.Add(orderId, orderDate, orderStatus, orderCost);
            }
        }
        private void LoadBrandsDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("brands").Rows)
            {
                string brandName = "none";
                string brandEmail = "none";
                string brandPhone = "none";
                try
                {
                    brandName = $"{row[1]}";
                    brandEmail = $"{row[3]}";
                    brandPhone = $"{row[4]}";
                }
                catch
                {
                    brandName = "none";
                    brandEmail = "none";
                    brandPhone = "none";
                }
                dataGridViewBrands.Rows.Add(brandName, brandEmail, brandPhone);
            }
        }
        private void LoadSuppliersDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("suppliers").Rows)
            {
                string suppliersName = "none";
                string suppliersEmail = "none";
                string suppliersPhone = "none";
                try
                {
                    suppliersName = $"{row[1]}";
                    suppliersEmail = $"{row[3]}";
                    suppliersPhone = $"{row[4]}";
                }
                catch
                {
                    suppliersName = "none";
                    suppliersEmail = "none";
                    suppliersPhone = "none";
                }
                dataGridViewSuppliers.Rows.Add(suppliersName, suppliersEmail, suppliersPhone);
            }
        }
        private void LoadEmployeesDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("employees").Rows)
            {
                Image employeePhoto = Properties.Resources.none_image;
                string employeeName = "none";
                string employeePhone = "none";
                string employeePosition = "none";
                try
                {
                    employeeName = $"{row[2]}" + " " + $"{row[1]}".Substring(0, 1) + "." + $"{row[3]}".Substring(0, 1) + ".";
                    employeePhone = $"{row[6]}";
                    employeePosition = $"{row[9]}";
                    if (row[14] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row[14];

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            employeePhoto = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    employeeName = "none";
                    employeeName = "none";
                    employeeName = "none";
                    employeePhoto = Properties.Resources.none_employee;
                }
                dataGridViewEmployees.Rows.Add(employeePhoto, employeeName, employeePhone, employeePosition);
            }
        }
        #endregion
        private void getCategories()
        {
            DataTable categories_table = DBHandler.LoadData("categories");
            categories_strings = new string[categories_table.Rows.Count];
            for(int i = 0; i < categories_table.Rows.Count; i++)
            {
                DataRow row = categories_table.Rows[i];
                categories_strings[i] = $"{row[1]}";
            }
        }
        private void FormViewProduct_Load(object sender, EventArgs e)
        {
            getCategories();
            products_table = DBHandler.LoadData("products");
            comboBoxCategories.Items.Add("без фильтрации");
            for (int i = 0; i< categories_strings.Length;i++)
            {
                comboBoxCategories.Items.Add(categories_strings[i]);
            }
            #region EmployeeDataLoad
            try
            {
                (string firstName, string lastName, string fathersName, Image photo) employeeData = DBHandler.LoadEmployeeData();
                labelEmployeeName.Text = employeeData.lastName + " " + employeeData.firstName.Substring(0, 1) + "." + employeeData.fathersName.Substring(0, 1) + ".";
                pictureBoxUser.BackgroundImage = employeeData.photo;
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки пользователя");
            }
            #endregion
            LoadProductDataGridView();
            LoadCategoriesDataGridView();
            LoadEmployeesDataGridView();
            LoadUsersDataGridView();
            LoadOrdersDataGridView();
            LoadBrandsDataGridView();
            LoadSuppliersDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comboBoxCategories.DroppedDown = true;
        }

        private void button5_Click(object sender, EventArgs e)
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
        #region Transitions between forms
        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            AuthForm form = new AuthForm();
            form.Show();
            this.Hide();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm();
            form.Show();
            this.Hide();
        }
        #endregion
        #region ClosedMenuPanel
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }

        private void ViewEmployeesPage_Click(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }

        private void ViewCategories_Click(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }

        private void ViewProductPage_Click(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (setting_active_status == true) { DisactiveSetting(); }
        }
        #endregion
        #region SwitchingTables
        private void buttonToProductForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void buttonToCategoryForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonToEmployeeForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void buttonToUserForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void buttonToOrderForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        private void buttonToBrandForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void buttonToSupplierForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }
        #endregion
        #region Handle placeholder of search_button
        private void placeholderTextBox_Enter(TextBox textBox)
        {
            textBox.ForeColor = Color.Black;
            if (save_search_text != "")
            {
                textBox.Text = save_search_text;
            }
            else
            {
                textBox.Text = "";
            }
        }
        private void placeholderTextBox_Leave(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                textBox.Text = "Введите для поиска...";
                textBox.ForeColor = Color.Gray;
                save_search_text = "";
                products_table = DBHandler.LoadData("products");
                LoadProductDataGridView();
            }
            else
            {
                save_search_text = textBox.Text;
            }
        }
        private void textBoxSearchProduct_Enter(object sender, EventArgs e)
        {
            placeholderTextBox_Enter(textBoxSearchProduct);
        }

        private void textBoxSearchProduct_Leave(object sender, EventArgs e)
        {
            placeholderTextBox_Leave(textBoxSearchProduct);
        }
        #endregion
        #region Live searching
        private void searchHandleTextBox(TextBox textBox, string table_name, string table_property)
        {
            dataGridViewProducts.Rows.Clear();
            string method = $"{table_name} WHERE {table_property} LIKE '%{textBox.Text}%';";
            products_table = DBHandler.LoadData(method);
            LoadProductDataGridView();
        }
        
        #endregion
        #region Processing of search buttons
        
        private void textBoxSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'ё' || c == 'Ё' || char.IsControl(c)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void textBoxSearchProduct_TextChanged(object sender, EventArgs e)
        {
            searchHandleTextBox(textBoxSearchProduct, "products", "products_name");
        }
        #endregion
        bool flag_sort_product_price = true;
        bool flag_sort_product_name = true;
        bool flag_using_filter = false;

        private string method_sort_price_product = "ASC";
        private string method_sort_name_product = "ASC";
        private string method_filter = "";
        private string method;

        private (string, bool, string) definitionSorting(bool flag_sorting, string textAttributeBySort)
        {
            // проверяем что за сортировка: при true - DESC, false - ASC
            if (flag_sorting)
            {
                // переопределяем флаг
                flag_sorting = false;
                // символ сортировки (можно обыграть по-другому)
                textAttributeBySort += " ↓";
                // вертаем: метод сортировки, обратный полеченному флаг, символ метода
                return ("DESC", flag_sorting, textAttributeBySort);
            }
            else
            {
                flag_sorting = true;
                textAttributeBySort += " ↑";
                return ("ASC", flag_sorting, textAttributeBySort);
            }
        }

        private void buttonSortProductByPrice_Click(object sender, EventArgs e)
        {
            try
            {
                // принимаем метод сортировки, обратный полеченному флаг, символ метода
                (string method_sorting, bool flag_sorting, string textAttributeBySort) = definitionSorting(flag_sort_product_price, "цене");
                // приравниваем к глобальным переменным
                method_sort_price_product = method_sorting;
                flag_sort_product_price = flag_sorting;
                buttonSortProductByPrice.Text = textAttributeBySort;
                reloadProductData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }
        private void reloadProductData()
        {
            // определяем метод
            method = $"products {method_filter} ORDER BY price {method_sort_price_product}, products_name {method_sort_name_product}";
            // Загружаем новые данные таблицы
            products_table = DBHandler.LoadData(method);
            dataGridViewProducts.Rows.Clear();
            LoadProductDataGridView();
        }
        private void buttonSortProductByName_Click(object sender, EventArgs e)
        {
            try
            {
                // принимаем метод сортировки, обратный полеченному флаг, символ метода
                (string method_sorting, bool flag_sorting, string textAttributeBySort) = definitionSorting(flag_sort_product_name, "наименованию");
                // приравниваем к глобальным переменным
                method_sort_name_product = method_sorting;
                flag_sort_product_name = flag_sorting;
                buttonSortProductByName.Text = textAttributeBySort;
                reloadProductData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // определяем выбрана ли категория
            if (comboBoxCategories.SelectedIndex != 0)
            {
                // меняем отображение картинки
                buttonFilterProduct.BackgroundImage = Properties.Resources.active_filter_icon;
                // делаем запрос с условием по id категории
                method_filter = $"WHERE categories_id = {comboBoxCategories.SelectedIndex}";
            }
            else
            {
                buttonFilterProduct.BackgroundImage = Properties.Resources.disactive_filter_icon;
                method_filter = "";
            }
            reloadProductData();
        }

    }
}
