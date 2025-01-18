using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model.Entity
{
    public class Admin
    {
        public int id_admin { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string no_telp { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
    }
}
