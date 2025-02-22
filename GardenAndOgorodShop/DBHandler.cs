using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GardenAndOgorodShop
{
    public static class DBHandler
    {
        public static string host = "localhost";
        public static string username = "root";
        public static string pwd = "";
        public static string database = "garden_and_ogorod_shop";
        public static string connect_string = $"host={host};uid={username};pwd={pwd};database={database}";

        private static bool randomSQLCommand(string query_body)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connect_string);
                connect.Open();
                string query = $"{query_body}";
                MySqlCommand command_sql = new MySqlCommand(query, connect);
                command_sql.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool checkAutorization(string login, string pwd)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connect_string);
                connect.Open();
                string query = $"SELECT * FROM users WHERE username = @login AND password_hash = @pwd;";
                MySqlCommand command_sql = new MySqlCommand(query, connect);
                command_sql.Parameters.AddWithValue("@login", login);
                command_sql.Parameters.AddWithValue("@pwd", pwd);
                var reader = command_sql.ExecuteReader();
                reader.Read();
                UserConfiguration.UserID = reader.GetInt32(0);
                int id_role = reader.GetInt32(3);
                UserConfiguration.UserRole = id_role == 1 ? "admin" : "seller";
                //UserRole.UserFio = reader.GetString(1) + " " + reader.GetString(2) + "." + reader.GetString(3) + ".";
                connect.Close();
                return true;
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show(
                    $"Проверьте вводимый логин и пароль",
                    "Ошибка авторизации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show(
                    $"Проверьте вводимый логин и пароль",
                    "Ошибка авторизации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
        }
        public static void updateLastLogInUser()
        {
            string query = $"UPDATE users SET last_login_date = NOW() WHERE users_id = '{UserConfiguration.UserID}';";
            randomSQLCommand(query);
        }
    }
}
