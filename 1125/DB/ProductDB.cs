using _1125.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1125.DB
{
    internal class ProductDB
    {
        DBConnection connection;

        private ProductDB(DBConnection db)
        {
            connection = db;
        }

        public bool Insert(Product product)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand("insert into `product` Values (0, @name, @description, @availability, @price);select LAST_INSERT_ID();");


                cmd.Parameters.Add(new MySqlParameter("name", product.Name));
                cmd.Parameters.Add(new MySqlParameter("description", product.Description));
                cmd.Parameters.Add(new MySqlParameter("availability", product.Availability));
                cmd.Parameters.Add(new MySqlParameter("price", product.Price));
                try
                {

                    int id = (int)(ulong)cmd.ExecuteScalar();
                    if (id > 0)
                    {
                        MessageBox.Show(id.ToString());

                        product.Id = id;
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show("Запись не добавлена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }

        internal List<Product> SelectAll()
        {
            List<Product> clients = new List<Product>();
            if (connection == null)
                return clients;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select `id`, `name`, `description`, `availability`, `price` from `product` ");
                try
                {

                    MySqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string description = string.Empty;

                        if (!dr.IsDBNull("description"))
                            description = dr.GetString("description");
                        string name = dr.GetString("name");
                        int availability = dr.GetInt32("availability");
                        decimal price = dr.GetDecimal("price");
                        clients.Add(new Product
                        {
                            Id = id,
                            Description = description,
                            Name = name,
                            Availability = availability,
                            Price = price
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return clients;
        }

        internal bool Update(Product edit)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"update `product` set `name`=@name, `description`=@description, `availability`=@availability, `price`=@price where `id` = {edit.Id}");
                mc.Parameters.Add(new MySqlParameter("name", edit.Name));
                mc.Parameters.Add(new MySqlParameter("description", edit.Description));
                mc.Parameters.Add(new MySqlParameter("availability", edit.Availability));
                mc.Parameters.Add(new MySqlParameter("price", edit.Price));
                try
                {
                    mc.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }


        internal bool Remove(Product remove)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"delete from `product` where `id` = {remove.Id}");
                try
                {
                    mc.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }

        static ProductDB db;
        public static ProductDB GetDb()
        {
            if (db == null)
                db = new ProductDB(DBConnection.GetDbConnection());
            return db;
        }
    }
}