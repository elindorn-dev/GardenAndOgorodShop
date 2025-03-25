using MySqlX.XDevAPI.Relational;
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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GardenAndOgorodShop
{
    public partial class Main : Form
    {
        // переменная для обработки перемещения панели настроек
        bool moving;
        // переменная-флаг активации по нажатию кнопки
        bool setting_active_status = false;

        string[] categories_strings;

        private DataTable products_table;
        private DataTable employees_table;
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
            if (UserConfiguration.UserRole == "seller") { HideForCommonUser(); } else buttonCurrentOrder.Visible = false;

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
                string productAmount = "none";
                try
                {
                    productTitle = $"{row[1]}";
                    double cost = Convert.ToDouble(row[3]);
                    productPrice = $"{cost - cost * (Convert.ToDouble(row[9])/100)} ₽";
                    productCategory = $"{categories_strings[Convert.ToInt32(row[4])-1]}";
                    productAmount = $"{row[6]} шт.";
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
                dataGridViewProducts.Rows.Add(productImage, productTitle, productPrice, productAmount, productCategory);
            }
        }
        private async void LoadCategoriesDataGridView()
        {
            DataTable table = await DBHandler.LoadData("categories");
            foreach (DataRow row in table.Rows)
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
        private async void LoadUsersDataGridView()
        {
            string[] roles = { "Администратор", "Продавец" };
            DataTable table = await DBHandler.LoadData("users");
            foreach (DataRow row in table.Rows)
            {
                string loginUser = "none";
                string roleUser = "none";
                string lastLoginUser = "none";
                try
                {
                    loginUser = $"{row[1]}";
                    roleUser = $"{roles[Convert.ToInt32(row[4])-1]}";
                    lastLoginUser = $"{row[5]}";
                }
                catch
                {
                }
                dataGridViewUsers.Rows.Add(loginUser, roleUser, lastLoginUser);
            }
        }
        private async void LoadOrdersDataGridView(string method)
        {
            dataGridViewOrders.Rows.Clear();
            DataTable table = await DBHandler.LoadData(method);
            foreach (DataRow row in table.Rows)
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
        private async void LoadBrandsDataGridView()
        {
            DataTable table = await DBHandler.LoadData("brands");
            foreach (DataRow row in table.Rows)
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
        private async void LoadSuppliersDataGridView()
        {
            DataTable table = await DBHandler.LoadData("suppliers");
            foreach (DataRow row in table.Rows)
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
        private async void LoadEmployeesDataGridView()
        {
            //employees_table = await DBHandler.LoadData("employees INNER JOIN users ON employees.users_id = users.users_id");
            foreach (DataRow row in employees_table.Rows)
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
                    if (row[13] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row[13];

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            employeePhoto = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                }
                dataGridViewEmployees.Rows.Add(employeePhoto, employeeName, employeePhone, employeePosition);
            }
        }
        #endregion
        private async void getCategories()
        {
            DataTable categories_table = await DBHandler.LoadData("categories");
            categories_strings = new string[categories_table.Rows.Count];
            for(int i = 0; i < categories_table.Rows.Count; i++)
            {
                DataRow row = categories_table.Rows[i];
                categories_strings[i] = $"{row[1]}";
            }
        }
        private void HideForCommonUser()
        {
            buttonToCategoryForm.Visible = false;
            buttonToUserForm.Visible = false;
            buttonToEmployeeForm.Visible = false;
            buttonToBrandForm.Visible = false;
            buttonToSupplierForm.Visible = false;
            buttonToStockForm.Visible = false;
            buttonAddProduct.Visible = false;
        }
        private async void FormViewProduct_Load(object sender, EventArgs e)
        {
            //MessageBox.Show($"{UserConfiguration.UserRole}");
            dateTimePickerFrom.MaxDate = DateTime.Now;
            dateTimePickerTo.MaxDate = DateTime.Now;


            getCategories();
            products_table = await DBHandler.LoadData("products WHERE is_available > 0");
            employees_table = await DBHandler.LoadData("employees;");
            //employees_table = await DBHandler.LoadData("employees INNER JOIN users ON employees.employees_id = users.employees_id");

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
            catch (Exception err)
            {
                MessageBox.Show("Ошибка загрузки пользователя");
            }
            #endregion
            LoadProductDataGridView();
            LoadCategoriesDataGridView();
            LoadEmployeesDataGridView();
            LoadUsersDataGridView();
            LoadOrdersDataGridView("orders ORDER BY order_date ASC");
            LoadBrandsDataGridView();
            LoadSuppliersDataGridView();
            if (UserConfiguration.UserRole == "seller") { HideForCommonUser(); } else { buttonCurrentOrder.Visible = false; buttonBacket.Visible = false; }
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
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DBHandler.returnProduct();
                Application.ExitThread();
            }            
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DBHandler.returnProduct();
                AuthForm form = new AuthForm();
                form.Show();
                this.Hide();
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(0, "add", 0);
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
              
        
        private void textBoxSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'ё' || c == 'Ё' || char.IsControl(c)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        

        #region Seaching, Sorting and Filtering
        // флаги для атрибутов сортировки по цене и наиманованию продуктов
        bool flag_sort_product_price = true;
        bool flag_sort_product_name = true;

        bool flag_sort_employee_name = true;
        // переменные для определения методов
        private string method_sort_product = "products_name ASC";
        private string method_filter_product = "1=1";
        private string method_search_product = "";
        private string method_product;

        private string method_sort_name_employee = "last_name ASC";
        private string method_filter_employee = "1=1";
        private string method_search_employee = "";
        private string method_employee;
        /// <summary>
        /// Определяет параметры сортировки.
        /// </summary>
        /// <returns>Кортеж, содержащий:
        ///   - string: Направление сортировки ("ASC" или "DESC").
        ///   - bool:  Инвертированный флаг сортировки.  
        ///   Предназначен для переключения направления сортировки при следующем вызове.
        ///   - string: Текст атрибута с добавленным индикатором направления сортировки (↑ для ASC, ↓ для DESC).
        /// </returns>
        private (string, bool, string) definitionSorting(bool flag_sorting)
        {
            // проверяем что за сортировка: при true - DESC, false - ASC
            if (flag_sorting)
            {
                // переопределяем флаг
                flag_sorting = false;
                // вертаем: метод сортировки, обратный полеченному флаг, символ метода
                return ("DESC", flag_sorting, " ↓");
            }
            else
            {
                flag_sorting = true;
                return ("ASC", flag_sorting, " ↑");
            }
        }

        private void EnabledUsingHandleProducts(bool enabled)
        {
            textBoxSearchProduct.Enabled = enabled;
            buttonSortProductByPrice.Enabled = enabled;
            buttonSortProductByName.Enabled = enabled;
            comboBoxCategories.Enabled = enabled;
            dataGridViewProducts.Enabled = enabled;
        }
        private void EnabledUsingHandleEmployees(bool enabled)
        {
            textBoxSearchEmployee.Enabled = enabled;
            buttonSortEmployeeByName.Enabled = enabled;
            comboBoxRoles.Enabled = enabled;
            dataGridViewEmployees.Enabled = enabled;
        }
        private async Task reloadProductData()
        {
            EnabledUsingHandleProducts(false);
            // определяем метод
            method_product = $"products WHERE {method_filter_product} AND (products_name LIKE '%{method_search_product}%') AND is_available > 0 ORDER BY {method_sort_product}";
            // Загружаем новые данные таблицы
            products_table = await DBHandler.LoadData(method_product);
            dataGridViewProducts.Rows.Clear();
            LoadProductDataGridView();
            EnabledUsingHandleProducts(true);
        }
        private async Task reloadEmployeeData()
        {
            EnabledUsingHandleEmployees(false);
            // определяем метод
            method_employee = comboBoxRoles.SelectedIndex != 0 ? $"employees INNER JOIN users ON employees.employees_id = users.employees_id WHERE {method_filter_employee} AND (last_name LIKE '%{method_search_employee}%') ORDER BY {method_sort_name_employee}" : $"employees WHERE" +
                $" last_name LIKE '%{method_search_employee}%' ORDER BY {method_sort_name_employee}";
            // Загружаем новые данные таблицы
            employees_table = await DBHandler.LoadData(method_employee);
            dataGridViewEmployees.Rows.Clear();
            LoadEmployeesDataGridView();
            EnabledUsingHandleEmployees(true);
        }

        private async void buttonSortProductByPrice_Click(object sender, EventArgs e)
        {
            try
            {
                //flag_sort_product_name = !(flag_sort_product_price);
                // принимаем метод сортировки, обратный полеченному флаг, символ метода
                (string method_sorting, bool flag_sorting, string textAttributeBySort) = definitionSorting(flag_sort_product_price);
                // приравниваем к глобальным переменным
                method_sort_product = $"price {method_sorting}";
                flag_sort_product_price = flag_sorting;
                buttonSortProductByPrice.Text = "цене"+textAttributeBySort;
                buttonSortProductByName.Text = "наименованию ↑";
                flag_sort_product_name = true;
                await reloadProductData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }
        
        private async void buttonSortProductByName_Click(object sender, EventArgs e)
        {
            try
            {
                // принимаем метод сортировки, обратный полеченному флаг, символ метода
                (string method_sorting, bool flag_sorting, string textAttributeBySort) = definitionSorting(flag_sort_product_name);
                // приравниваем к глобальным переменным
                method_sort_product = $"products_name {method_sorting}";
                flag_sort_product_name = flag_sorting;
                buttonSortProductByName.Text = "наименованию" + textAttributeBySort;
                buttonSortProductByPrice.Text = "цене ↑";
                flag_sort_product_price = true;

                await reloadProductData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxCategories.DroppedDown = true;
        }

        private async void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // определяем выбрана ли категория
                if (comboBoxCategories.SelectedIndex != 0)
                {
                    // меняем отображение картинки
                    buttonFilterProduct.BackgroundImage = Properties.Resources.active_filter_icon;
                    // делаем запрос с условием по id категории
                    method_filter_product = $"categories_id = {comboBoxCategories.SelectedIndex}";
                }
                else
                {
                    buttonFilterProduct.BackgroundImage = Properties.Resources.disactive_filter_icon;
                    method_filter_product = "1=1";
                }
                await reloadProductData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }
        private async void textBoxSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                method_search_product = textBoxSearchProduct.Text;
                await reloadProductData();
                textBoxSearchProduct.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private async void buttonSortEmployeeByName_Click(object sender, EventArgs e)
        {
            try
            {
                // принимаем метод сортировки, обратный полеченному флаг, символ метода
                (string method_sorting, bool flag_sorting, string textAttributeBySort) = definitionSorting(flag_sort_employee_name);
                // приравниваем к глобальным переменным
                method_sort_name_employee = $"last_name {method_sorting}";
                flag_sort_employee_name = flag_sorting;
                buttonSortEmployeeByName.Text = $"фамилии{textAttributeBySort}";

                await reloadEmployeeData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private void buttonFilterEmployee_Click(object sender, EventArgs e)
        {
            comboBoxRoles.DroppedDown = true;
        }

        private async void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // определяем выбрана ли категория
                if (comboBoxRoles.SelectedIndex != 0)
                {
                    // меняем отображение картинки
                    buttonFilterEmployee.BackgroundImage = Properties.Resources.active_filter_icon;
                    // делаем запрос с условием по id категории
                    method_filter_employee = $"role_id = {comboBoxRoles.SelectedIndex}";
                }
                else
                {
                    buttonFilterEmployee.BackgroundImage = Properties.Resources.disactive_filter_icon;
                    method_filter_employee = "1=1";
                }
                await reloadEmployeeData();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private async void textBoxSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                method_search_employee = textBoxSearchEmployee.Text;
                await reloadEmployeeData();
                textBoxSearchEmployee.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private void buttonCurrentOrder_Click(object sender, EventArgs e)
        {
            CurrentOrder form = new CurrentOrder();
            form.Show();
            this.Hide();
        }
        private async void badResultView()
        {
            buttonBacket.Enabled = false;
            labelReadyOrNot.ForeColor = Color.Red;
            labelReadyOrNot.Text = "Товар НЕ добавлен!";
            pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.cancel;
            panelResult.Visible = true;
            await Task.Delay(1000);
            panelResult.Visible = false;
            buttonBacket.Enabled = true;
        }
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
        private async void resultAdd_inOrder(int product_id)
        {
            try
            {
                if (AddEditProduct_inOrder(product_id))
                {
                    buttonBacket.Enabled = false;
                    labelReadyOrNot.ForeColor = Color.Green;
                    labelReadyOrNot.Text = "Товар добавлен.";
                    pictureBoxReadyOrNot.BackgroundImage = Properties.Resources.ready;
                    panelResult.Visible = true;
                    await Task.Delay(1000);
                    panelResult.Visible = false;
                    buttonBacket.Enabled = true;
                    int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
                    int new_amount = Convert.ToInt32(Convert.ToString(dataGridViewProducts.Rows[index_row].Cells[3].Value).Replace(" шт.", ""));
                    DBHandler.randomSQLCommand($"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = '{new_amount - 1}' WHERE (`products_id` = '{product_id}');");
                    if (new_amount == 1)
                    {
                        await reloadProductData();
                    }
                    else
                    {
                        dataGridViewProducts.Rows[index_row].Cells[3].Value = $"{new_amount - 1} шт.";
                    }
                }
                else
                {
                    badResultView();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }
        private void buttonBacket_Click(object sender, EventArgs e)
        {
            try
            {
                int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
                DataRow selected_row = products_table.Rows[index_row];
                int product_id = Convert.ToInt32(selected_row[0]);
                if (UserConfiguration.Current_order_id == 0)
                {
                    UserConfiguration.Current_order_id = DBHandler.getNewIdOrder();
                    if (UserConfiguration.Current_order_id != 0)
                    {
                        resultAdd_inOrder(product_id);
                    }
                    else
                    {
                        badResultView();
                    }
                }
                else
                {
                    resultAdd_inOrder(product_id);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Ошибка\n{err}");
            }
        }
        private void saveProducts_delOrder()
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DBHandler.returnProduct();
                AuthForm form = new AuthForm();
                form.Show();
                this.Hide();
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveProducts_delOrder();
        }
        #endregion

        private void buttonInfoProduct_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewProducts.SelectedCells[0].RowIndex;
            DataRow selected_row = products_table.Rows[index_row];
            int product_id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(0, "edit", product_id);
            form.Show();
            this.Hide();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(1, "add", 0);
            form.Show();
            this.Hide();
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewCategories.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("categories").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(1, "edit", _id);
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(2, "add", 0);
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewEmployees.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("employees").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(2, "edit", _id);
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(3, "add", 0);
            form.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewUsers.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("users").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(3, "edit", _id);
            form.Show();
            this.Hide();
        }

        private async void buttonProductsControl_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Продолжить создание отчёта \"Контроль остатков\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await Reports.ReportBalanceСontrol();
            }
        }

        private async void buttonReportOrders_Click(object sender, EventArgs e)
        {
            string date_from = dateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string date_to = dateTimePickerTo.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DialogResult result = MessageBox.Show("Продолжить создание отчёта \"Анализ продаж\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await Reports.ReportAnalyzOrders(date_from, date_to);
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(4, "add", 0);
            form.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewBrands.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("brands").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(4, "edit", _id);
            form.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            HandleRecordForm form = new HandleRecordForm(5, "add", 0);
            form.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewSuppliers.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("suppliers").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(5, "edit", _id);
            form.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int index_row = dataGridViewOrders.SelectedCells[0].RowIndex;
            DataRow selected_row = DBHandler.LoadDataSync("orders").Rows[index_row];
            int _id = Convert.ToInt32(selected_row[0]);
            HandleRecordForm form = new HandleRecordForm(6, "edit", _id);
            form.Show();
            this.Hide();
        }

        private void buttonToStockForm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 7;
        }
        bool flag_order_sort = true;
        private void button18_Click(object sender, EventArgs e)
        {
            if (flag_order_sort)
            {
                LoadOrdersDataGridView("orders ORDER BY order_date DESC");
                button18.Text = "дате ↓";
                flag_order_sort = false;
            }
            else
            {
                LoadOrdersDataGridView("orders ORDER BY order_date ASC");
                button18.Text = "дате ↑";
                flag_order_sort = true;
            }
        }
    }
}
