using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Model.Entity;
using LibraryManagement.Model.Repository;
using LibraryManagement.Model.Context;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static Guna.UI2.Native.WinApi;

namespace LibraryManagement.Controller
{
    public class ReturnBookController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private ReturnBookRepository returnBookRepository;

        private int FormValidation(ReturnBook returnBook)
        {

            if (string.IsNullOrEmpty(returnBook.condition))
            {
                SendWarning("Please input Book Condition !!!!");
                return 0;
            }

            return 1;
        }

        public int Create(ReturnBook returnBook)
        {
            int result = 0;

            if (FormValidation(returnBook) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to return book ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    returnBookRepository = new ReturnBookRepository(context);
                    result = returnBookRepository.Create(returnBook);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Book returned successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to return book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Update(ReturnBook returnBook)
        {
            int result = 0;

            if (FormValidation(returnBook) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to update return book data ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    returnBookRepository = new ReturnBookRepository(context);
                    result = returnBookRepository.Update(returnBook);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Return Book Data updated successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update return bookdata!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Delete(int id_return)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                returnBookRepository = new ReturnBookRepository(context);
                result = returnBookRepository.Delete(id_return);
            }

            if (result > 0) { }
            else
                MessageDialog("Failed", "Failed to delete return book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public List<ReturnBook> GetAllReturnBooks()
        {
            List<ReturnBook> result = new List<ReturnBook>();

            using (DbContext context = new DbContext())
            {
                returnBookRepository = new ReturnBookRepository(context);
                result = returnBookRepository.GetAllReturnBooks();

                foreach (ReturnBook item in result)
                {
                    item.borrowBook = new BorrowBookController().GetBorrowBook(item.id_borrow);
                }
            }

            return result;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}
