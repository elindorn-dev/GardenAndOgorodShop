using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using MySqlX.XDevAPI.Relational;

namespace GardenAndOgorodShop
{
    public static class DBHandler
    {
        public static string host = "localhost";
        public static string username = "root";
        public static string pwd = "";
        public static string database = "garden_and_ogorod_shop";
        public static string connect_string = $"host={host};uid={username};pwd={pwd};database={database}";

        public static async Task<DataTable> getProductsOrder_forBill()
        {
            DataTable products = new DataTable();
            try
            {
                string query = $"SELECT products.products_name, products_orders.product_amount, products.price FROM garden_and_ogorod_shop.products_orders INNER JOIN products ON products_orders.products_id = products.products_id WHERE orders_id  = '{UserConfiguration.Current_order_id}';";
                MySqlConnection con = new MySqlConnection(connect_string);
                await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(products);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            
            return products;
        }
        public static void returnProduct()
        {
            try
            {
                string query_current_order = "`products_orders` WHERE `products_orders`.orders_id = (SELECT MAX(orders.orders_id) FROM orders);";
                DataTable korzina = new DataTable();
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {query_current_order};", con);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(korzina);
                con.Close();
                foreach (DataRow row in korzina.Rows)
                {
                    string query_return = $"UPDATE `garden_and_ogorod_shop`.`products` SET `is_available` = `is_available` + '{row[2]}' WHERE (`products_id` = '{row[1]}');";
                    randomSQLCommand(query_return);
                }
                
                string query_cancel_order = $"UPDATE `garden_and_ogorod_shop`.`orders` SET `order_status` = 'Отменено' WHERE (`orders_id` = '{UserConfiguration.Current_order_id}');";
                randomSQLCommand(query_cancel_order);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public static bool randomSQLCommand(string query_body)
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
        public static bool checkExistProduct_inOrder(int product_id)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connect_string);
                connect.Open();
                string query = $@"SELECT 1 FROM products_orders WHERE products_id = {product_id} AND orders_id = {UserConfiguration.Current_order_id}";
                MySqlCommand command_sql = new MySqlCommand(query, connect);
                int exist = Convert.ToInt32(command_sql.ExecuteScalar());
                connect.Close();
                return exist == 1 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public static int getNewIdOrder()
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connect_string);
                connect.Open();
                string query = $@"INSERT INTO `garden_and_ogorod_shop`.`orders` (`employees_id`, `order_date`, `order_status`, `payment_method`, `total_cost`, `tax_amount`, `notes`)  VALUES ('{UserConfiguration.UserID}', NOW(), 'Обработка', 'Наличными', '0.00', '0.00', 'Продажа создана'); SELECT MAX(orders_id) FROM orders;";
                MySqlCommand command_sql = new MySqlCommand(query, connect);
                int newOrderId = Convert.ToInt32(command_sql.ExecuteScalar());
                connect.Close();
                return newOrderId;
            }
            catch
            {
                return 0;
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
                //UserConfiguration.UserFIO = reader.GetString(1) + " " + reader.GetString(2) + "." + reader.GetString(3) + ".";
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
        public static (string firstName, string lastName, string fathersName, Image photo) LoadEmployeeData()
        {
            string firstName = null;
            string lastName = null;
            string fathersName = null;
            Image photo = null;

            try
            {
                using (MySqlConnection connect = new MySqlConnection(connect_string))
                {
                    connect.Open();
                    string query = "SELECT first_name, last_name, fathers_name, photo FROM employees WHERE users_id = @userId;";
                    using (MySqlCommand command_sql = new MySqlCommand(query, connect))
                    {
                        command_sql.Parameters.AddWithValue("@userId", UserConfiguration.UserID);

                        using (MySqlDataReader reader = command_sql.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                firstName = reader.GetString("first_name");
                                lastName = reader.GetString("last_name");
                                fathersName = reader.GetString("fathers_name");

                                if (!reader.IsDBNull(3)) 
                                {
                                    byte[] imageData = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        photo = Image.FromStream(ms);
                                    }
                                }
                            }
                        }
                    }
                }
                return (firstName, lastName, fathersName, photo); 
            }
            catch (Exception err)
            {
                return (null, null, null, null);  
            }
        }
        public static async Task<DataTable> LoadData(string table)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {table};", con);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                await Task.Run(() => da.Fill(dt));
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //MessageBox.Show(connect_string);
            }
            return dt;
        }
    }
}
