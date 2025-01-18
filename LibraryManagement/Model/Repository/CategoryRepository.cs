using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.Model.Repository
{
    public class CategoryRepository
    {
        private SQLiteConnection _conn;

        public CategoryRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Category category)
        {
            int result = 0;

            string sql = @"insert into category (category, description, created_by, creation_date)
                           values (@category, @description, @created_by, datetime('now', 'localtime'))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@category", category.category);
                cmd.Parameters.AddWithValue("@description", category.description);
                cmd.Parameters.AddWithValue("@created_by", category.created_by);

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

        public int Update(Category category)
        {
            int result = 0;

            string sql = @"update category set category = @category, description = @description, last_update_by = @last_update_by, last_update_date = datetime('now', 'localtime') where id_category = @id_category";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@category", category.category);
                cmd.Parameters.AddWithValue("@description", category.description);
                cmd.Parameters.AddWithValue("@last_update_by", category.last_update_by);
                cmd.Parameters.AddWithValue("@id_category", category.id_category);

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

        public int Delete(int idCategory)
        {
            int result = 0;

            string sql = @"delete from category where id_category = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", idCategory);

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

        public List<Category> GetAllCategory()
        {
            List<Category> result = new List<Category>();

            try
            {
                string sql = @"select c.*, a.name as 'created_by_name', b.name as 'last_update_by_name'
                                from category c left join admin a on a.id_admin = c.created_by
                                left join admin b on b.id_admin = c.last_update_by";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Category category = new Category();

                            category.id_category = Convert.ToInt32(dtr["id_category"]);

                            category.category = dtr["category"].ToString();
                            category.description = dtr["description"] == DBNull.Value ? null : (dtr["description"].ToString() == "" ? "-" : dtr["description"].ToString());
                            category.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            category.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            category.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            category.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            category.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            category.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();

                            result.Add(category);
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
