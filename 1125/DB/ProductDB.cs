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

        static ProductDB db;
        public static ProductDB GetDb()
        {
            if (db == null)
                db = new ProductDB(DBConnection.GetDbConnection());
            return db;
        }
    }
}