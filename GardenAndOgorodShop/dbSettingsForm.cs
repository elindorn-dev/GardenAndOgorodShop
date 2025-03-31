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

namespace GardenAndOgorodShop
{
    public partial class dbSettingsForm : Form
    {
        public dbSettingsForm()
        {
            InitializeComponent();
        }

        private void dbSettingsForm_Load(object sender, EventArgs e)
        {
            if (!DBHandler.checkConnection())
            {
                buttonRecovery.Enabled = false;
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

        private void buttonRecovery_Click(object sender, EventArgs e)
        {
            if (DBHandler.RecoveryStructure())
            {
                MessageBox.Show("Структура восстановлена без данных", "Восстановление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Структура не была восстановлена", "Восстановление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {

        }
    }
}
