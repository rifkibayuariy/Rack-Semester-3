using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model.Entity
{
    public class ReturnBook
    {
        public int id_return {  get; set; }
        public int id_borrow {  get; set; }
        public string date { get; set; }
        public string condition { get; set; }
        public string charge { get; set; }
        public string creation_date { get; set; }
        public int created_by { get; set; }
        public string created_by_name { get; set; }
        public string last_update_date { get; set; }
        public int last_update_by { get; set; }
        public string last_update_by_name { get; set; }
        public BorrowBook borrowBook { get; set; }
        public string book
        {
            get
            {
                return borrowBook.title;
            }
        }
        public string member
        {
            get
            {
                return borrowBook.name;
            }
        }
    }
}
