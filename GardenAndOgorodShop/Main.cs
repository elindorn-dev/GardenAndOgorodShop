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
        public Main()
        {
            InitializeComponent();
        }
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
        private void LoadProductDataGridView()
        {
            foreach (DataRow row in DBHandler.LoadData("products").Rows)
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
                    if (row[15] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row[15];

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
            
            comboBoxCategories.DataSource = categories_strings;
            #region EmployeeDataLoad
            (string firstName, string lastName, string fathersName, Image photo) employeeData = DBHandler.LoadEmployeeData();
            labelEmployeeName.Text = employeeData.lastName + " " + employeeData.firstName.Substring(0, 1) + "." + employeeData.fathersName.Substring(0, 1) + ".";
            pictureBoxUser.BackgroundImage = employeeData.photo;
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
        private void buttonToStockForm_Click(object sender, EventArgs e)
        {

        }
    }
}
