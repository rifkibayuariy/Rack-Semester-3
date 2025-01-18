using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;

using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.View.vBook
{
    public partial class UC_UpdateBook : UserControl
    {
        public event EventHandler<DialogResult> ClosePopUp;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();
        private BookController controller = new BookController();
        private Book book = new Book();

        private List<Category> category = new CategoryController().GetAllCategory();

        public UC_UpdateBook(Book book)
        {
            InitializeComponent();
            loadBookCategory();

            this.book = book;

            bookCategory.SelectedValue = book.id_category;
            bookTitle.Text = book.title;
            bookAuthor.Text = book.author;
            bookPublisher.Text = book.publisher;
            bookDate.Value = DateTime.Parse(book.publication_date);
            bookISBN.Text = book.ISBN;
            bookLanguage.Text = book.language;

            created.Text = book.creation_date + " " + book.created_by_name;
            lastUpdateDate.Text = book.last_update_date + " " + book.last_update_by_name;

            controller.MessageDialog = (
                string caption,
                string text,
                MessageDialogButtons buttons,
                MessageDialogStyle style,
                MessageDialogIcon icon) =>
            {
                return MessageDialog(caption, text, buttons, style, icon);
            };
        }

        private void loadBookCategory()
        {
            bookCategory.DataSource = category;

            bookCategory.DisplayMember = "category";
            bookCategory.ValueMember = "id_category";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            book.id_category = Convert.ToInt32(bookCategory.SelectedValue);
            book.title = bookTitle.Text;
            book.author = bookAuthor.Text;
            book.publisher = bookPublisher.Text;
            book.publication_date = bookDate.Value.ToString("yyyy-MM-dd");
            book.ISBN = bookISBN.Text;
            book.language = bookLanguage.Text;
            book.last_update_by = adminInfromation.id_admin;

            int result = controller.Update(book);

            if (result > 0) ClosePopUp?.Invoke(this, DialogResult.Yes);
        }
    }
}
