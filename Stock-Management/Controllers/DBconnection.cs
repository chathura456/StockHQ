using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using TutorHQ.Models;

namespace TutorHQ.Controllers
{
    public class DBconnection
    {
        //create sql server connection
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=stockhq;";


            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("MySQL Connection! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static bool Login(string email, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT Password FROM Users WHERE Email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();
                 
                        if (storedPassword == password)  
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool AddNewItem(string itemName, int quantity)
        {
            using (MySqlConnection conn = DBconnection.GetConnection())
            {
                string query = "INSERT INTO Items (ItemName, Quantity, Transaction) VALUES (@ItemName, @Quantity, @Transaction)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Transaction", "Item Added");

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("MySQL Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static List<Item> GetAllItems()
        {
            List<Item> itemsList = new List<Item>();

            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Items";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Item item = new Item
                        {
                            StockID = reader.GetInt32("StockID"),
                            ItemName = reader.GetString("ItemName"),
                            Quantity = reader.GetInt32("Quantity"),
                            DateAdded = reader.GetDateTime("DateAdded"),
                            Transaction = reader.GetString("Transaction")
                        };

                        itemsList.Add(item);
                    }
                }
            }

            return itemsList;
        }



    }
}
