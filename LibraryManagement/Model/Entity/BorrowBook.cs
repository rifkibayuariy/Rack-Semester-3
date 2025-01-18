using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model.Entity
{
    public class BorrowBook
    {
        public int id_borrow {  get; set; }
        public int id_member {  get; set; }
        public string date {  get; set; }
        public string name {  get; set; }
        public int id_book { get; set; }
        public string title { get; set; }
        public string due_date { get; set; }
        public string creation_date { get; set; }
        public int created_by { get; set; }
        public string created_by_name { get; set; }
        public string last_update_date { get; set; }
        public int last_update_by { get; set; }
        public string last_update_by_name { get; set; }
        public int returned {  get; set; }
        public string text
        {
            get
            {
                return id_borrow + " | " + title + " | " + name + " | " + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " - " + Convert.ToDateTime(due_date).ToString("yyyy/MM/dd");
            }
        }
    }
}
