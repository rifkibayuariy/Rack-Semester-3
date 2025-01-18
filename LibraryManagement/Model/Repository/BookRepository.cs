using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;
using LibraryManagement.View.vBook;

namespace LibraryManagement.Model.Repository
{
    public class BookRepository
    {
        private SQLiteConnection _conn;

        public BookRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Book book)
        {
            int result = 0;

            string sql = @"insert into book (id_category, title, author, publisher, publication_date, ISBN, language, created_by, creation_date)
                           values (@id_category, @title, @author, @publisher, @publication_date, @ISBN, @language, @created_by, datetime('now', 'localtime'))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_category", book.id_category);
                cmd.Parameters.AddWithValue("@title", book.title);
                cmd.Parameters.AddWithValue("@author", book.author);
                cmd.Parameters.AddWithValue("@publisher", book.publisher);
                cmd.Parameters.AddWithValue("@publication_date", book.publication_date);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@language", book.language);
                cmd.Parameters.AddWithValue("@created_by", book.created_by);

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

        public int Update(Book book)
        {
            int result = 0;

            string sql = @"update book set
                            id_category = @id_category,
                            title = @title,
                            author = @author,
                            publisher = @publisher,
                            publication_date = @publication_date,
                            ISBN = @ISBN,
                            language = @language,
                            last_update_date = datetime('now', 'localtime'),
                            last_update_by = @last_update_by
                           where
                            id_book = @id_book";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_category", book.id_category);
                cmd.Parameters.AddWithValue("@title", book.title);
                cmd.Parameters.AddWithValue("@author", book.author);
                cmd.Parameters.AddWithValue("@publisher", book.publisher);
                cmd.Parameters.AddWithValue("@publication_date", book.publication_date);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
                cmd.Parameters.AddWithValue("@language", book.language);
                cmd.Parameters.AddWithValue("@last_update_by", book.last_update_by);
                cmd.Parameters.AddWithValue("@id_book", book.id_book);

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

        public int Delete(int id_book)
        {
            int result = 0;

            string sql = @"delete from book where id_book = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id_book);

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

        public List<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>();

            try
            {
                string sql = @"select b.*, c.category as 'category_name', a.name as 'created_by_name', d.name as 'last_update_by_name'
                                from book b left join category c on c.id_category = b.id_category
                                left join admin a on a.id_admin = b.created_by
                                left join admin d on d.id_admin = b.last_update_by";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Book book = new Book();

                            book.id_book = Convert.ToInt32(dtr["id_book"]);
                            book.id_category = Convert.ToInt32(dtr["id_category"]);
                            book.category_name = dtr["category_name"] == DBNull.Value ? null : dtr["category_name"].ToString();
                            book.title = dtr["title"].ToString();
                            book.author = dtr["author"] == DBNull.Value ? null : dtr["author"].ToString();
                            book.publisher = dtr["publisher"] == DBNull.Value ? null : dtr["publisher"].ToString();
                            book.publication_date = dtr["publication_date"] == DBNull.Value ? null : dtr["publication_date"].ToString();
                            book.ISBN = dtr["ISBN"] == DBNull.Value ? null : dtr["ISBN"].ToString();
                            book.language = dtr["language"] == DBNull.Value ? null : dtr["language"].ToString();
                            book.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            book.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            book.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            book.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            book.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            book.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();

                            result.Add(book);
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

        public int CountBooks()
        {
            int result = 0;

            string sql = @"select count(*) as total from book";

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
