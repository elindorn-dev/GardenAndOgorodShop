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
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;

namespace GardenAndOgorodShop
{
    public static class DBHandler
    {
        public static string host = "localhost";
        public static string username = "root";
        public static string pwd = "";
        public static string database = "garden_and_ogorod_shop";
        public static string connect_string = $"host={host};uid={username};pwd={pwd};database={database}";

        public static async Task<System.Data.DataTable> getProductsOrder_forBill()
        {
            System.Data.DataTable products = new System.Data.DataTable();
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
                System.Data.DataTable korzina = new System.Data.DataTable();
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
        public static bool checkChangedHash(string hash)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connect_string);
                connect.Open();
                string query = $@"SELECT 1 FROM garden_and_ogorod_shop.users WHERE password_hash = '{hash}';";
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
                int id_role = reader.GetInt32(4);
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
            string firstName = "";
            string lastName = "";
            string fathersName = "";
            Image photo = Properties.Resources.none_employee;

            try
            {
                using (MySqlConnection connect = new MySqlConnection(connect_string))
                {
                    connect.Open();
                    string query = "SELECT first_name, last_name, fathers_name, photo FROM employees INNER JOIN users ON employees.employees_id = users.employees_id WHERE users.users_id = @userId;";
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
        public static System.Data.DataTable LoadDataSync(string table)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {table};", con);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                 da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt;
        }
        public static async Task<System.Data.DataTable> LoadData(string table)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
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
        #region Add records
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="descript"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="is_avaible"></param>
        /// <param name="image"></param>
        /// <param name="supplier"></param>
        /// <param name="discount"></param>
        /// <returns></returns>
        public static bool InsertProduct(string title, string descript, decimal price, int category, int brand, int is_avaible, Image image, int supplier, decimal discount)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();
                byte[] blobData;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    blobData = ms.ToArray();
                }

                string query = "INSERT INTO `garden_and_ogorod_shop`.`products` " +
                               "(`products_name`, `descript`, `price`, `categories_id`, `brands_id`, `is_available`, `image`, `suppliers_id`, `seasonal_discount`) " +
                               "VALUES " +
                               "(@title, @descript, @price, @category, @brand, @is_available, @image, @supplier, @discount)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@descript", descript);
                    cmd.Parameters.AddWithValue("@price", price);
                    category = category == 0 ? 1 : category;
                    cmd.Parameters.AddWithValue("@category", category);
                    brand = brand == 0 ? 1 : brand;
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@is_available", is_avaible);
                    cmd.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = blobData;
                    supplier = supplier == 0 ? 1 : supplier;
                    cmd.Parameters.AddWithValue("@supplier", supplier);
                    cmd.Parameters.AddWithValue("@discount", discount);


                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления продукта (db):\n"+e.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="descript"></param>
        /// <returns></returns>
        public static bool InsertCategory(string title, string descript)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                string query = "INSERT INTO `garden_and_ogorod_shop`.`categories` (`category_name`, `descript`) VALUES ('@title', '@description');";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@descript", descript);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления категории (db):\n" + e.Message);
                return false;
            }
        }
        public static bool InsertEmployee(string lastName, string firstName, string fathersName, string birth_date, string gender, string phone, string email, string address, string posotion, string salary, string descript, Image image)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                byte[] blobData;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    blobData = ms.ToArray();
                }

                string query = "INSERT INTO `garden_and_ogorod_shop`.`employees` (`first_name`, `last_name`, `fathers_name`, `birth_day`, `gender`, `phone_number`, `email`, `address`, `position`, `hire_date`, `salary`, `notes`, `photo`) " +
                "VALUES (@firstName, @lastName, @fathersName, @birth_day, @gender, @phone_number, @email, @address, @position, NOW(), @salary, @notes, @photo);";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@fathersName", fathersName);
                    cmd.Parameters.AddWithValue("@birth_day", birth_date);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone_number", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@position", posotion);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@notes", descript);
                    cmd.Parameters.Add("@photo", MySqlDbType.MediumBlob).Value = blobData;

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления сотрудника (db):\n" + e.Message);
                return false;
            }
        }
        public static bool InsertUser(string username, string hash, int employee_id, int role_id, string descript)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                string query = "INSERT INTO `garden_and_ogorod_shop`.`users` (`username`, `password_hash`, `employees_id`, `role_id`, `last_login_date`, `notes`) " +
               "VALUES (@username, @hash, @employee_id, @role_id, NOW(), @notes);";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("@employee_id", employee_id); 
                    cmd.Parameters.AddWithValue("@role_id", role_id);       
                    cmd.Parameters.AddWithValue("@notes", descript);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления пользователя (db):\n" + e.Message);
                return false;
            }
        }
        public static bool InsertBrand(string title, string email, string phone, string addr, string desc)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                string query = "INSERT INTO `garden_and_ogorod_shop`.`brands` (`brand_name`, `descript`, `email`, `phone_number`, `legal_address`) VALUES (@title, @email, @phone, @addr, @desc);";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@addr", addr);
                    cmd.Parameters.AddWithValue("@desc", desc);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления пользователя (db):\n" + e.Message);
                return false;
            }
        }
        #endregion
        #region Edit records
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="descript"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="is_avaible"></param>
        /// <param name="image"></param>
        /// <param name="supplier"></param>
        /// <param name="discount"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool EditProduct(string title, string descript, double price, int category, int brand, int is_avaible, Image image, int supplier, double discount, int id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();
                byte[] blobData;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    blobData = ms.ToArray();
                }
                string query = $"UPDATE `garden_and_ogorod_shop`.`products` SET " +
                    "`products_name` = @title, " +
                    "`descript` = @descript, " +
                    "`price` = @price, " +
                    "`categories_id` = @category, " +
                    "`brands_id` = @brand, " +
                    "`is_available` = @is_available, " +
                    "`image` = @image, " +
                    "`suppliers_id` = @supplier, " +
                    "`seasonal_discount` = @discount " +
                    $"WHERE (`products_id` = '{id}');";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", $"{title}");
                    cmd.Parameters.AddWithValue("@descript", $"{descript}");
                    cmd.Parameters.AddWithValue("@price", price);
                    category = category == 0 ? 1 : category;
                    cmd.Parameters.AddWithValue("@category", category);
                    brand = brand == 0 ? 1 : brand;
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@is_available", is_avaible);
                    cmd.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = blobData;
                    supplier = supplier == 0 ? 1 : supplier;
                    cmd.Parameters.AddWithValue("@supplier", supplier);
                    cmd.Parameters.AddWithValue("@discount", discount);


                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения продукта (db):\n" + e.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="descript"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool EditCategory(string title, string descript, int id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();
                string query = $"UPDATE `garden_and_ogorod_shop`.`categories` SET `category_name` = @title, `descript` = @descript WHERE (`categories_id` = '{id}');";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@descript", descript);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка изменения категории (db):\n" + e.Message);
                return false;
            }
        }
        public static bool EditEmployee(string lastName, string firstName, string fathersName, string birth_date, string gender, string phone, string email, string address, string posotion, string salary, string descript, byte[] blobData, int id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                string query = "UPDATE `garden_and_ogorod_shop`.`employees` SET " +
                "`first_name` = @firstName, " +
                "`last_name` = @lastName, " +
                "`fathers_name` = @fathersName, " +
                "`birth_day` = @birth_day, " +
                "`gender` = @gender, " +
                "`phone_number` = @phone_number, " +
                "`email` = @email, " +
                "`address` = @address, " +
                "`position` = @position, " +
                "`salary` = @salary, " +
                "`notes` = @notes, " +
                "`photo` = @photo " +
                "WHERE (`employees_id` = @id);";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@fathersName", fathersName);
                    cmd.Parameters.AddWithValue("@birth_day", birth_date);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone_number", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@position", posotion);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@notes", descript);
                    cmd.Parameters.Add("@photo", MySqlDbType.MediumBlob).Value = blobData;

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления категории (db):\n" + e.Message);
                return false;
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
        public static bool EditUser(string username, string hash, int employee_id, int role_id, string descript, int id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                con.Open();

                string query = $"UPDATE `garden_and_ogorod_shop`.`users` SET `username` = @username, `password_hash` = @hash, `employees_id` = @employee_id, `role_id` = @role_id, `notes` = @notes WHERE (`users_id` = '{id}');";
                hash = checkChangedHash(hash) ? hash : ComputeSha256Hash(hash);
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", hash);
                    cmd.Parameters.AddWithValue("@employee_id", employee_id);
                    cmd.Parameters.AddWithValue("@role_id", role_id);
                    cmd.Parameters.AddWithValue("@notes", descript);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка добавления пользователя (db):\n" + e.Message);
                return false;
            }
        }
        #endregion
        public static async Task<System.Data.DataTable> LoadDataReportOrders(string date_from, string date_to)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                MySqlConnection con = new MySqlConnection(connect_string);
                await con.OpenAsync();
                MySqlCommand cmd = new MySqlCommand($"SELECT orders.*, last_name, first_name, fathers_name FROM garden_and_ogorod_shop.orders INNER JOIN employees ON orders.employees_id = employees.employees_id WHERE order_date BETWEEN '{date_from}' AND '{date_to}';", con);
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
