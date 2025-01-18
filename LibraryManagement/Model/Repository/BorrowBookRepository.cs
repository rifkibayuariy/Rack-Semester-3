using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.Model.Repository
{
    public class BorrowBookRepository
    {
        private SQLiteConnection _conn;

        public BorrowBookRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(BorrowBook borrowBook)
        {
            int result = 0;

            string sql = @"insert into borrow (
                                id_member,
                                id_book,
                                due_date,
                                created_by,
                                creation_date
                           ) values (
                                @id_member,
                                @id_book,
                                @due_date,
                                @created_by,
                                datetime('now', 'localtime')
                           )";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_member", borrowBook.id_member);
                cmd.Parameters.AddWithValue("@id_book", borrowBook.id_book);
                cmd.Parameters.AddWithValue("@due_date", borrowBook.due_date);
                cmd.Parameters.AddWithValue("@created_by", borrowBook.created_by);

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

        public int Update(BorrowBook borrowBook)
        {
            int result = 0;

            string sql = @"update borrow set
                                id_member = @id_member,
                                id_book = @id_book,
                                due_date = @due_date,
                                last_update_by = @last_update_by,
                                last_update_date = datetime('now', 'localtime')
                           where
                                id_borrow = @id_borrow";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_member", borrowBook.id_member);
                cmd.Parameters.AddWithValue("@id_book", borrowBook.id_book);
                cmd.Parameters.AddWithValue("@due_date", borrowBook.due_date);
                cmd.Parameters.AddWithValue("@last_update_by", borrowBook.last_update_by);
                cmd.Parameters.AddWithValue("@id_borrow", borrowBook.id_borrow);

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

        public int Delete(int id_borrowBook)
        {
            int result = 0;

            string sql = @"delete from borrow where id_borrow = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id_borrowBook);

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

        public List<BorrowBook> GetAllBorrowBooks(bool returned = false)
        {
            List<BorrowBook> result = new List<BorrowBook>();

            try
            {
                string sql = "";

                if (returned)
                {
                    sql = @"select
                                b.*,
                                m.name,
                                bk.title,
                                a.name as 'created_by_name',
                                d.name as 'last_update_by_name',
                                0 as 'returned'
                            from borrow b
                                left join member m on m.id_member = b.id_member
                                left join book bk on bk.id_book = b.id_book
                                left join admin a on a.id_admin = b.created_by
                                left join admin d on d.id_admin = b.last_update_by
                            where
                                b.id_borrow not in (select rb.id_borrow from return_book rb)";
                }
                else
                {
                    sql = @"select
                                b.*,
                                m.name,
                                bk.title,
                                a.name as 'created_by_name',
                                d.name as 'last_update_by_name',
                                (select count(*) from return_book rb where rb.id_borrow = b.id_borrow) as 'returned'
                            from borrow b
                                left join member m on m.id_member = b.id_member
                                left join book bk on bk.id_book = b.id_book
                                left join admin a on a.id_admin = b.created_by
                                left join admin d on d.id_admin = b.last_update_by";
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            BorrowBook borrowBook = new BorrowBook();

                            borrowBook.id_borrow = Convert.ToInt32(dtr["id_borrow"]);
                            borrowBook.id_member = Convert.ToInt32(dtr["id_member"]);
                            borrowBook.name = dtr["name"] == DBNull.Value ? null : dtr["name"].ToString();
                            borrowBook.id_book = Convert.ToInt32(dtr["id_book"]);
                            borrowBook.title = dtr["title"].ToString();
                            borrowBook.date = dtr["date"] == DBNull.Value ? null : Convert.ToDateTime(dtr["date"]).ToString("yyyy-MM-dd");
                            borrowBook.due_date = dtr["due_date"] == DBNull.Value ? null : Convert.ToDateTime(dtr["due_date"]).ToString("yyyy-MM-dd");
                            borrowBook.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            borrowBook.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            borrowBook.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            borrowBook.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            borrowBook.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            borrowBook.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();
                            borrowBook.returned = Convert.ToInt32(dtr["returned"]);

                            result.Add(borrowBook);
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

        public BorrowBook GetBorrowBookById(int id)
        {
            BorrowBook borrowBook = new BorrowBook();

            try
            {
                string sql = @"select
                                    b.*,
                                    m.name,
                                    bk.title,
                                    a.name as 'created_by_name',
                                    d.name as 'last_update_by_name',
                                    (select count(*) from return_book rb where rb.id_borrow = b.id_borrow) as 'returned'
                               from
                                    borrow b
                                    left join member m on m.id_member = b.id_member
                                    left join book bk on bk.id_book = b.id_book
                                    left join admin a on a.id_admin = b.created_by
                                    left join admin d on d.id_admin = b.last_update_by
                               where
                                    b.id_borrow = @id_borrow";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    cmd.Parameters.AddWithValue("@id_borrow", id);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            borrowBook.id_borrow = Convert.ToInt32(dtr["id_borrow"]);
                            borrowBook.id_member = Convert.ToInt32(dtr["id_member"]);
                            borrowBook.name = dtr["name"] == DBNull.Value ? null : dtr["name"].ToString();
                            borrowBook.id_book = Convert.ToInt32(dtr["id_book"]);
                            borrowBook.title = dtr["title"].ToString();
                            borrowBook.date = dtr["date"] == DBNull.Value ? null : Convert.ToDateTime(dtr["date"]).ToString("yyyy-MM-dd");
                            borrowBook.due_date = dtr["due_date"] == DBNull.Value ? null : Convert.ToDateTime(dtr["due_date"]).ToString("yyyy-MM-dd");
                            borrowBook.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            borrowBook.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            borrowBook.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            borrowBook.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            borrowBook.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            borrowBook.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();
                            borrowBook.returned = Convert.ToInt32(dtr["returned"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return borrowBook;
        }

        public int CountBorrowBooks()
        {
            int result = 0;

            string sql = @"select count(*) as total from borrow";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int CountBorrowBooksToday()
        {
            int result = 0;

            string sql = @"select count(*) as total from borrow where date = date('now')";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }
    }
}
