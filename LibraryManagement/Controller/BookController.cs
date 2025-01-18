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
    public class BookController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private BookRepository bookRepository;

        private int FormValidation(Book book)
        {
            if (string.IsNullOrEmpty(book.title))
            {
                SendWarning("Please input Book Title !!!!");
                return 0;
            }

            if (string.IsNullOrEmpty(book.author))
            {
                SendWarning("Please input Author !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(book.publisher))
            {
                SendWarning("Please input Publisher !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(book.publication_date))
            {
                SendWarning("Please input publication date of Book !!!"); 
                return 0;
            }

            if (string.IsNullOrEmpty(book.ISBN))
            {
                SendWarning("Please input ISBN !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(book.language))
            {
                SendWarning("Please input Language !!!");
                return 0;
            }

            return 1;
        }

        public int Create(Book book)
        {
            int result = 0;

            if (FormValidation(book) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to add book ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    bookRepository = new BookRepository(context);
                    result = bookRepository.Create(book);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Book added successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to add book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Update(Book book)
        {
            int result = 0;

            if (FormValidation(book) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to update book ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    bookRepository = new BookRepository(context);
                    result = bookRepository.Update(book);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Book update successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Delete(int id_book)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                bookRepository = new BookRepository(context);
                result = bookRepository.Delete(id_book);
            }

            if (result > 0) { }
            else
                MessageDialog("Failed", "Failed to delete book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>();

            using (DbContext context = new DbContext())
            {
                bookRepository = new BookRepository(context);
                result = bookRepository.GetAllBooks();
            }

            return result;
        }

        public int GetTotalBooks()
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                bookRepository = new BookRepository(context);
                result = bookRepository.CountBooks();
            }

            return result;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}
