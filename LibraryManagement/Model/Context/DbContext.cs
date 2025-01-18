using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagement.Model.Context
{
    public class DbContext : IDisposable
    {
        private SQLiteConnection _conn;

        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;

            string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Rack");
            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }

            try
            {
                string dbPath = Path.Combine(documentsPath, "LibraryManagement.db");

                string defaultDbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LibraryManagement.db");
                if (!File.Exists(dbPath) && File.Exists(defaultDbPath))
                {
                    File.Copy(defaultDbPath, dbPath);
                }

                string connectionString = string.Format("Data Source={0};FailIfMissing=True", dbPath);
                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
                File.WriteAllText(Path.Combine(documentsPath, "error_log.txt"), ex.ToString());
            }

            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
