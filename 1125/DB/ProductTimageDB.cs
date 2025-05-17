using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;
using _1125.Model;

namespace _1125.DB
{
    internal class ProductTimageDB
    {
        DBConnection connection;

    private ProductTimageDB(DBConnection db)
    {
        connection = db;
    }
    internal List<ProductTimage> SelectAll()
    {
        List<ProductTimage> producttimage = new List<ProductTimage>();
        if (connection == null)
            return producttimage;

        if (connection.OpenConnection())
        {
            var command = connection.CreateCommand("select `id`, `name`, `data`,  from `productimage` ");
            try
            {
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);

                    string name = string.Empty;
                    if (!dr.IsDBNull(1))
                        name = dr.GetString("name");

                    byte[] data = null;
                    if (!dr.IsDBNull(2))
                    {
                        long size = dr.GetBytes(5, 0, null, 0, 0);
                            data = new byte[size];
                        dr.GetBytes(5, 0, data, 0, (int)size);
                    }

                        producttimage.Add(new ProductTimage
                    {
                        Id = id,
                        Name = name,
                        Data = data,

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        connection.CloseConnection();

        return producttimage;
    }

    static ProductTimageDB db;
    public static ProductTimageDB GetDb()
    {
        if (db == null)
            db = new ProductTimageDB(DBConnection.GetDbConnection());
        return db;
    }
}
}
