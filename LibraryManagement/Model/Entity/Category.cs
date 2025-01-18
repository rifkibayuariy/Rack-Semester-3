using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model.Entity
{
    public class Category
    {
        public int id_category { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string creation_date { get; set; }
        public int created_by { get; set; }
        public string created_by_name { get; set; }
        public string last_update_date { get; set; }
        public int last_update_by { get; set; }
        public string last_update_by_name { get; set; }

    }
}
