using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;

namespace GardenAndOgorodShop
{
    public partial class dbSettingsForm : Form
    {
        private string save_login_textbox;
        private string save_password_textbox;
        public dbSettingsForm()
        {
            InitializeComponent();
        }

        private void dbSettingsForm_Load(object sender, EventArgs e)
        {
            if (!DBHandler.checkConnectionDB())
            {
                buttonImport.Enabled = false;
            }
            serverTextBox.Text = ConfigurationManager.AppSettings["host"];
            dbTextBox.Text = ConfigurationManager.AppSettings["db"];
            usernameTextBox.Text = ConfigurationManager.AppSettings["uid"];
            userpasswordTextBox.Text = ConfigurationManager.AppSettings["pwd"];
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

                string host = serverTextBox.Text;
                string database = dbTextBox.Text;
                string username = usernameTextBox.Text;
                string pwd = userpasswordTextBox.Text;

                config.AppSettings.Settings["host"].Value = host;
                config.AppSettings.Settings["db"].Value = database;
                config.AppSettings.Settings["uid"].Value = username;
                config.AppSettings.Settings["pwd"].Value = pwd;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show($"Настройки изменены", "Изменение настроек", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);

            }
            catch (Exception err)
            {
                MessageBox.Show($"Настройки не изменены\n{err.Message}", "Изменение настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void dbSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthForm form = new AuthForm();
            form.Show();
            this.Hide();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedIndex != -1)
            {
                string query_brands= "INSERT INTO `garden_and_ogorod_shop`.`brands` (`brands_id`, `brand_name`, `descript`, `email`, `phone_number`, `legal_address`) VALUES (";
                string query_categories= "INSERT INTO `garden_and_ogorod_shop`.`categories` (`categories_id`, `category_name`, `descript`) VALUES (";
                string query_employees= "INSERT INTO `garden_and_ogorod_shop`.`employees` (`employees_id`, `first_name`, `last_name`, `fathers_name`, `birth_day`, `gender`, `phone_number`, `email`, `address`, `position`, `hire_date`, `salary`, `notes`, `photo`) VALUES (";
                string query_orders= "INSERT INTO `garden_and_ogorod_shop`.`orders` (`orders_id`, `employees_id`, `order_date`, `order_status`, `payment_method`, `total_cost`, `tax_amount`, `notes`) VALUES (";
                string query_products= "INSERT INTO `garden_and_ogorod_shop`.`products` (`products_id`, `products_name`, `descript`, `price`, `categories_id`, `brands_id`, `is_available`, `image`, `suppliers_id`, `seasonal_discount`) VALUES (";
                string query_products_orders= "INSERT INTO `garden_and_ogorod_shop`.`products_orders` (`orders_id`, `products_id`, `product_amount`) VALUES (";
                string query_roles= "INSERT INTO `garden_and_ogorod_shop`.`roles` (`role_id`, `role_name`, `descript`) VALUES (";
                string query_suppliers= "INSERT INTO `garden_and_ogorod_shop`.`suppliers` (`suppliers_id`, `supplier_name`, `descript`, `email`, `phone_number`, `legal_address`, `registration_number_inn`) VALUES (";
                string query_users= "INSERT INTO `garden_and_ogorod_shop`.`users` (`users_id`, `username`, `password_hash`, `employees_id`, `role_id`, `last_login_date`, `notes`) VALUES (";

                string path = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Files|*.csv";
                openFileDialog.Title = "Выберите файл для импорта данных";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }

                string query = "";
                int count_properties = 0;

                switch (comboBoxTables.Text)
                {
                    case "brands": query = query_brands; count_properties = 6; break;
                    case "categories": query = query_categories; count_properties = 3; break;
                    case "employees": query = query_employees; count_properties = 14; break;
                    case "orders": query = query_orders; count_properties = 8; break;
                    case "products": query = query_products; count_properties = 10; break;
                    case "products_orders": query = query_products_orders; count_properties = 3; break;
                    case "roles": query = query_roles; count_properties = 3; break;
                    case "suppliers": query = query_suppliers; count_properties = 7; break;
                    case "users": query = query_users; count_properties = 7; break;
                }

                int[] inserts = DBHandler.ImportCsv(comboBoxTables.Text, query, path, count_properties);
                MessageBox.Show($"Успешно: {inserts[0]- inserts[1]}\nПровал: {inserts[1]}");
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
        private void buttonAuth_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pwd = textBoxPassword.Text;
            if (DBHandler.checkAutorizationAdmin(login, ComputeSha256Hash(pwd)) || (login == ConfigurationManager.AppSettings["username"] && pwd == ConfigurationManager.AppSettings["password"]))
            {
                panelBlock.Visible = false;
                this.Width = 1000;
                this.Height = 420;
            }
            else
            {
                MessageBox.Show("Проверьте ваш вводимый логин или пароль", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            textBoxLogin.ForeColor = Color.Black;
            if (save_login_textbox != "")
            {
                textBoxLogin.Text = save_login_textbox;
            }
            else
            {
                textBoxLogin.Text = "";
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.ForeColor = Color.Black;

            if (save_password_textbox != "")
            {
                textBoxPassword.Text = save_password_textbox;
            }
            else
            {
                textBoxPassword.Text = "";
            }
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логин";
                textBoxLogin.ForeColor = Color.Gray;
                save_login_textbox = "";
            }
            else
            {
                save_login_textbox = textBoxLogin.Text;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Пароль";
                textBoxPassword.ForeColor = Color.Gray;
                save_password_textbox = "";
            }
            else
            {
                save_password_textbox = textBoxPassword.Text;
            }
        }
        bool show_password = false;
        private void hideshowpwd_Click(object sender, EventArgs e)
        {
            if (show_password)
            {
                hideshowpwd.BackgroundImage = GardenAndOgorodShop.Properties.Resources.show_password;
                textBoxPassword.PasswordChar = '\0';
                show_password = false;
            }
            else
            {
                hideshowpwd.BackgroundImage = GardenAndOgorodShop.Properties.Resources.hide_password;
                textBoxPassword.PasswordChar = '●';
                show_password = true;
            }
        }

        private void buttonHandleBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Выберите папку:";
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (!DBHandler.Backup(folderBrowserDialog.SelectedPath))
                    {
                        MessageBox.Show("Ошибка резервного копирования при старте программы.", "Резервное копирование бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Резервное копирование в ручном режиме успешно завершено.", "Резервное копирование бд", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Действие отменено или папка не выбрана.");
                }
            }
            
        }

        private void buttonRestoreBackup_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Files|*.sql";
            openFileDialog.Title = "Выберите файл для восстановления БД";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            if (DBHandler.RecoveryBackup(path))
            {
                MessageBox.Show("Восстановление БД успешно.", "Восстановление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonImport.Enabled = true;
            }
            else
            {
                MessageBox.Show("БД не была восстановлена", "Восстановление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
