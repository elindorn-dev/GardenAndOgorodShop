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
using MySql.Data.MySqlClient;

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

                string path = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Files|*.csv";
                openFileDialog.Title = "Выберите файл для импорта данных";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    int[] result = DBHandler.ImportFromCsv(path, comboBoxTables.Text);
                    MessageBox.Show($"Успешно: {result[0]}\nПровал: {result[1]}", "Результат импорта", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        DBHandler.ExportToCsv(comboBoxTables.Text, filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine("Сохранение отменено пользователем.");
                }
            }
        }
    }
}
