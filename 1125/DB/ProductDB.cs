using _1125.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            List<Product> product = new List<Product>();
            if (connection == null)
                return product;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select `id`, `name`, `description`, `availability`, `price` from `product` ");
                try
                {

                    MySqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string name = string.Empty;
                        if (!dr.IsDBNull(1))
                            name = dr.GetString("name");
                        string description = string.Empty;
                        if (!dr.IsDBNull(2))
                            description = dr.GetString("description");
                        int availability = 0;
                        if (!dr.IsDBNull(3))
                            availability = dr.GetInt32("availability");
                        int price = 0;
                        if (!dr.IsDBNull(4))
                            price = dr.GetInt32("Price");

                        product.Add(new Product
                        {
                            Id = id,
                            Name = name,
                            Description = description,
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
            return product;
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