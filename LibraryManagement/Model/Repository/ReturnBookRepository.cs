using System;
using System.Collections.Generic;
using System.Data.SQLite;

using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.Model.Repository
{
    public class ReturnBookRepository
    {
        private SQLiteConnection _conn;

        public ReturnBookRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(ReturnBook returnBook)
        {
            int result = 0;

            string sql = @"insert into return_book (id_borrow, condition, charge, created_by, creation_date)
                           values (@id_borrow, @condition, @charge, @created_by, datetime('now', 'localtime'))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_borrow", returnBook.id_borrow);
                cmd.Parameters.AddWithValue("@condition", returnBook.condition);
                cmd.Parameters.AddWithValue("@charge", returnBook.charge);
                cmd.Parameters.AddWithValue("@created_by", returnBook.created_by);

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

        public int Update(ReturnBook returnBook)
        {
            int result = 0;

            string sql = @"update return_book set
                            condition = @condition,
                            charge = @charge,
                            last_update_date = datetime('now', 'localtime'),
                            last_update_by = @last_update_by
                           where
                            id_return = @id_return";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@condition", returnBook.condition);
                cmd.Parameters.AddWithValue("@charge", returnBook.charge);
                cmd.Parameters.AddWithValue("@last_update_by", returnBook.last_update_by);
                cmd.Parameters.AddWithValue("@id_return", returnBook.id_return);

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

        public int Delete(int id_return)
        {
            int result = 0;

            string sql = @"delete from return_book where id_return = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id_return);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<ReturnBook> GetAllReturnBooks()
        {
            List<ReturnBook> result = new List<ReturnBook>();

            try
            {
                string sql = @"SELECT
	                                rb.*,
	                                m.name,
	                                bk.title,
	                                a.name as 'created_by_name',
	                                d.name as 'last_update_by_name'
                                FROM
	                                return_book rb
	                                LEFT JOIN borrow b ON b.id_borrow = rb.id_borrow
	                                LEFT JOIN book bk ON bk.id_book = b.id_book
	                                LEFT JOIN member m ON m.id_member = b.id_member
	                                LEFT JOIN admin a ON a.id_admin = rb.created_by
	                                LEFT JOIN admin d ON d.id_admin = rb.last_update_by";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            ReturnBook returnBook = new ReturnBook();

                            returnBook.id_return = Convert.ToInt32(dtr["id_return"]);
                            returnBook.id_borrow = Convert.ToInt32(dtr["id_borrow"]);
                            returnBook.date = dtr["date"] == DBNull.Value ? null : Convert.ToDateTime(dtr["date"]).ToString("yyyy-MM-dd");
                            returnBook.condition = dtr["condition"] == DBNull.Value ? null : dtr["condition"].ToString();
                            returnBook.charge = dtr["charge"] == DBNull.Value ? null : dtr["charge"].ToString();
                            returnBook.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            returnBook.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            returnBook.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            returnBook.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            returnBook.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            returnBook.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();

                            result.Add(returnBook);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return result;
        }
    }
}
