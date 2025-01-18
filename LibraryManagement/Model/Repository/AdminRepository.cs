using System;
using System.Collections.Generic;
using System.Data.SQLite;

using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.Model.Repository
{
    public class AdminRepository
    {
        private SQLiteConnection _conn;

        public AdminRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Admin admin)
        {
            int result = 0;

            string sql = @"insert into admin (name, gender, no_telp, email, username, password, creation_date)
                           values (@name, @gender, @no_telp, @email, @username, @password, datetime('now', 'localtime'))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", admin.name);
                cmd.Parameters.AddWithValue("@gender", admin.gender);
                cmd.Parameters.AddWithValue("@no_telp", admin.no_telp);
                cmd.Parameters.AddWithValue("@email", admin.email);
                cmd.Parameters.AddWithValue("@username", admin.username);
                cmd.Parameters.AddWithValue("@password", admin.password);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Admin admin, bool password = false)
        {
            int result = 0;

            string sql = "";

            if (password)
            {

                sql = @"update admin set
                            name = @name,
                            gender = @gender,
                            no_telp = @no_telp,
                            email = @email,
                            username = @username,
                            password = @password
                        where
                            id_admin = @id_admin";
            }
            else
            {
                sql = @"update admin set
                            name = @name,
                            gender = @gender,
                            no_telp = @no_telp,
                            email = @email,
                            username = @username
                        where
                            id_admin = @id_admin";
            }

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", admin.name);
                cmd.Parameters.AddWithValue("@gender", admin.gender);
                cmd.Parameters.AddWithValue("@no_telp", admin.no_telp);
                cmd.Parameters.AddWithValue("@email", admin.email);
                cmd.Parameters.AddWithValue("@username", admin.username);
                cmd.Parameters.AddWithValue("@id_admin", admin.id_admin);
                if (password) cmd.Parameters.AddWithValue("@password", admin.password);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public Admin FindAdminByUsername(string username)
        {
            Admin admin = new Admin();

            try
            {
                string sql = @"select * from admin where username = @username";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    cmd.Parameters.AddWithValue("@username", username);
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            admin.id_admin = Convert.ToInt32(dtr["id_admin"]);
                            admin.name = dtr["name"].ToString();
                            admin.gender = dtr["gender"].ToString();
                            admin.no_telp = dtr["no_telp"].ToString();
                            admin.email = dtr["email"].ToString();
                            admin.username = dtr["username"].ToString();
                            admin.password = dtr["password"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return admin;
        }
    }
}
