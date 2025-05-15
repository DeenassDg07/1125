using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;
using _1125.Model;

namespace _1125.DB
{
    internal class UserDB
    {
        DBConnection connection;

        private UserDB(DBConnection db)
        {
            connection = db;
        }

        public bool Insert(User user)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand("insert into `user` Values (0, @login, @password);select LAST_INSERT_ID();");
                cmd.Parameters.Add(new MySqlParameter("login", user.Login));
                cmd.Parameters.Add(new MySqlParameter("password", user.Password));

                try
                {

                    int id = (int)(ulong)cmd.ExecuteScalar();
                    if (id > 0)
                    {
                        MessageBox.Show(id.ToString());
                        user.Id = id;
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
                            Id = id,
                            Login = login,
                            Password = password
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
                var mc = connection.CreateCommand($"update `user` set `login`=@login, `password`=@password where `id` = {edit.Id}");
                mc.Parameters.Add(new MySqlParameter("login", edit.Login));
                mc.Parameters.Add(new MySqlParameter("password", edit.Password));

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


        internal bool Remove(User remove)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"delete from `user` where `id` = {remove.Id}");
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

        static UserDB db;
        public static UserDB GetDb()
        {
            if (db == null)
                db = new UserDB(DBConnection.GetDbConnection());
            return db;
        }
    }
}