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
    public class BorrowBookController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private BorrowBookRepository borrowBookRepository;

        public int Create(BorrowBook borrowBook)
        {
            int result = 0;

            if (MessageDialog("Confirmation", "Do you want to borrow book ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    borrowBookRepository = new BorrowBookRepository(context);
                    result = borrowBookRepository.Create(borrowBook);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Book loan submitted!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to borrow book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Update(BorrowBook borrowBook)
        {
            int result = 0;

            if (MessageDialog("Confirmation", "Do you want to update borrow book data?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    borrowBookRepository = new BorrowBookRepository(context);
                    result = borrowBookRepository.Update(borrowBook);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Borrow Book Data updated!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update borrow book data!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Delete(int id_borrowBook)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                borrowBookRepository = new BorrowBookRepository(context);
                result = borrowBookRepository.Delete(id_borrowBook);
            }

            if (result > 0) { }
            else
                MessageDialog("Failed", "Failed to delete borrow book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public List<BorrowBook> GetAllBorrowBooks(bool returned = false)
        {
            List<BorrowBook> result = new List<BorrowBook>();

            using (DbContext context = new DbContext())
            {
                borrowBookRepository = new BorrowBookRepository(context);
                result = borrowBookRepository.GetAllBorrowBooks(returned);
            }

            return result;
        }

        public BorrowBook GetBorrowBook(int id) {
            BorrowBook borrowBook = null;

            using (DbContext context = new DbContext())
            {
                borrowBookRepository = new BorrowBookRepository(context);
                borrowBook = borrowBookRepository.GetBorrowBookById(id);
            }

            return borrowBook;
        }

        public int GetTotalBorrowBooks()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                borrowBookRepository = new BorrowBookRepository(context);
                result = borrowBookRepository.CountBorrowBooks();
            }

            return result;
        }

        public int GetTotalBorrowBooksToday()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                borrowBookRepository = new BorrowBookRepository(context);
                result = borrowBookRepository.CountBorrowBooksToday();
            }

            return result;
        }
    }
}
