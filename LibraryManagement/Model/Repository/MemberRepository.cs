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
    public class MemberRepository
    {
        private SQLiteConnection _conn;

        public MemberRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Member member)
        {
            int result = 0;

            string sql = @"insert into member (name, gender, no_telp, email, address, created_by, creation_date)
                           values (@name, @gender, @no_telp, @email, @address, @created_by, datetime('now', 'localtime'))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", member.name);
                cmd.Parameters.AddWithValue("@gender", member.gender);
                cmd.Parameters.AddWithValue("@no_telp", member.no_telp);
                cmd.Parameters.AddWithValue("@email", member.email);
                cmd.Parameters.AddWithValue("@address", member.address);
                cmd.Parameters.AddWithValue("@created_by", member.created_by);

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

        public int Update(Member member)
        {
            int result = 0;

            string sql = @"update member set
                            name = @name,
                            gender = @gender,
                            no_telp = @no_telp,
                            email = @email,
                            address = @address,
                            last_update_date = datetime('now', 'localtime'),
                            last_update_by = @last_update_by
                        where
                            id_member = @id_member";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", member.name);
                cmd.Parameters.AddWithValue("@gender", member.gender);
                cmd.Parameters.AddWithValue("@no_telp", member.no_telp);
                cmd.Parameters.AddWithValue("@email", member.email);
                cmd.Parameters.AddWithValue("@address", member.address);
                cmd.Parameters.AddWithValue("@last_update_by", member.last_update_by);
                cmd.Parameters.AddWithValue("@id_member", member.id_member);

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

        public int Delete(int id_member)
        {
            int result = 0;

            string sql = @"delete from member where id_member = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id_member);

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

        public List<Member> GetAllMember()
        {
            List<Member> result = new List<Member>();

            try
            {
                string sql = @"select m.*, a.name as created_by_name, b.name as last_update_by_name from member m left join admin a on a.id_admin = m.created_by left join admin b on b.id_admin = m.last_update_by";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Member member = new Member();

                            member.id_member = Convert.ToInt32(dtr["id_member"]);

                            member.name = dtr["name"].ToString();
                            member.gender = dtr["gender"].ToString();
                            member.no_telp = dtr["no_telp"] == DBNull.Value ? null : dtr["no_telp"].ToString();
                            member.email = dtr["email"] == DBNull.Value ? null : dtr["email"].ToString();
                            member.address = dtr["address"] == DBNull.Value ? null : dtr["address"].ToString();
                            member.creation_date = dtr["creation_date"] == DBNull.Value ? null : dtr["creation_date"].ToString();
                            member.created_by = dtr["created_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["created_by"]);
                            member.created_by_name = dtr["created_by_name"] == DBNull.Value ? null : dtr["created_by_name"].ToString();
                            member.last_update_date = dtr["last_update_date"] == DBNull.Value ? null : dtr["last_update_date"].ToString();
                            member.last_update_by = dtr["last_update_by"] == DBNull.Value ? 0 : Convert.ToInt32(dtr["last_update_by"]);
                            member.last_update_by_name = dtr["last_update_by_name"] == DBNull.Value ? null : dtr["last_update_by_name"].ToString();

                            result.Add(member);
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
