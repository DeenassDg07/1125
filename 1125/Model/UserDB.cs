using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;

namespace _1125.Model
{
    internal class UserDB
    {
        DbConnection connection;

        private UserDB(DbConnection db)
        {
            this.connection = db;
        }

        public bool Insert(User user)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand("insert into `user` Values (0, @login, @password);select LAST_INSERT_ID();");
                cmd.Parameters.Add(new MySqlParameter("login", user.login));

                MySqlParameter password = new MySqlParameter("password", user.password);
                cmd.Parameters.Add(password);
                try
                {

                    int id = (int)(ulong)cmd.ExecuteScalar();
                    if (id > 0)
                    {
                        MessageBox.Show(id.ToString());
                        user.id = id;
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

        internal List<User> SelectAll()
        {
            List<User> users = new List<User>();
            if (connection == null)
                return users;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select `id`, `login`, `password` from `user` ");
                try
                {
                    MySqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string login = string.Empty;
                        if (!dr.IsDBNull(1))
                            login = dr.GetString("login");
                        string password = dr.GetString("password");
                        users.Add(new User
                        {
                            id = id,
                            login = login,
                            password = password
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return users;
        }

        internal bool Update(User edit)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"update `Clients` set `Fname`=@fname, `Lname`=@lname where `id` = {edit.ID}");
                mc.Parameters.Add(new MySqlParameter("fname", edit.FirstName));
                mc.Parameters.Add(new MySqlParameter("lname", edit.LastName));

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


        internal bool Remove(Client remove)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"delete from `Clients` where `id` = {remove.ID}");
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

        static ClientsDB db;
        public static ClientsDB GetDb()
        {
            if (db == null)
                db = new ClientsDB(DbConnection.GetDbConnection());
            return db;
        }
    }
}