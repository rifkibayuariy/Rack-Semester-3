using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model.Entity
{
    public class Book
    {
        public int id_book {  get; set; }
        public int id_category {  get; set; }
        public string category_name {  get; set; }
        public string title {  get; set; }
        public string author {  get; set; }
        public string publisher {  get; set; }
        public string publication_date {  get; set; }
        public string ISBN {  get; set; }
        public string language {  get; set; }
        public string creation_date {  get; set; }
        public int created_by {  get; set; }
        public string created_by_name {  get; set; }
        public string last_update_date {  get; set; }
        public int last_update_by {  get; set; }
        public string last_update_by_name {  get; set; }
    }
}
