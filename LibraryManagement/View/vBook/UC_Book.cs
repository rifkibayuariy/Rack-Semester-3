using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;
using LibraryManagement.Controller;
using Guna.UI2.WinForms;

namespace LibraryManagement.View.vBook
{
    public partial class UC_Book : UserControl
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();

        private List<Category> category = new CategoryController().GetAllCategory();

        private BookController controller = new BookController();

        public UC_Book()
        {
            InitializeComponent();
            bookDate.Value = DateTime.Now;
            loadBookCategory();

            List<Book> listBook = controller.GetAllBooks();

            dataGridViewBook.AutoGenerateColumns = false;
            dataGridViewBook.MultiSelect = true;

            dataGridViewBook.DataSource = listBook;

            dataGridViewBook.Columns.Add("id_book", "No");
            dataGridViewBook.Columns.Add("title", "Title");
            dataGridViewBook.Columns.Add("category_name", "Category");
            dataGridViewBook.Columns.Add("author", "Author");
            dataGridViewBook.Columns.Add("publisher", "Publisher");

            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "editButton",
                Text = "Edit"
            };

            dataGridViewBook.Columns.Add(buttonEdit);

            dataGridViewBook.Columns["id_book"].DataPropertyName = "id_book";
            dataGridViewBook.Columns["title"].DataPropertyName = "title";
            dataGridViewBook.Columns["category_name"].DataPropertyName = "category_name";
            dataGridViewBook.Columns["author"].DataPropertyName = "author";
            dataGridViewBook.Columns["publisher"].DataPropertyName = "publisher";

            dataGridViewBook.Columns["id_book"].Width = 50;
            dataGridViewBook.Columns["editButton"].Width = 80;

            dataGridViewBook.CellClick += dataGridViewBook_CellClick;

            dataGridViewBook.ReadOnly = true;

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

        private void Reset_Click(object sender, EventArgs e)
        {
            bookTitle.Text = "";
            bookAuthor.Text = "";
            bookPublisher.Text = "";
            bookISBN.Text = "";
            bookLanguage.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.id_category = Convert.ToInt32(bookCategory.SelectedValue);
            book.title = bookTitle.Text;
            book.author = bookAuthor.Text;
            book.publisher = bookPublisher.Text;
            book.publication_date = bookDate.Value.ToString("yyyy-MM-dd");
            book.ISBN = bookISBN.Text;
            book.language = bookLanguage.Text;
            book.created_by = adminInfromation.id_admin;

            int result = controller.Create(book);

            if (result > 0)
            {
                bookTitle.Text = "";
                bookAuthor.Text = "";
                bookPublisher.Text = "";
                bookISBN.Text = "";
                bookLanguage.Text = "";

                refreshTable();
            }
        }

        private void refreshTable()
        {
            List<Book> list = controller.GetAllBooks();

            dataGridViewBook.DataSource = list;
        }

        private void deleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count > 0)
            {
                int result = 1;
                var confirmation = MessageDialog("Confirmation", "Do you want to delete book ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewBook.SelectedRows)
                    {
                        int rslt = controller.Delete(Convert.ToInt32(row.Cells["id_book"].Value));
                        if (rslt == 0) result = 0;
                    }

                    if (result > 0)
                        MessageDialog("Successfull", "Book deleted successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
                    else
                        MessageDialog("Failed", "Failed to delete book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

                    refreshTable();
                }
            }
            else
            {
                MessageDialog("Warning", "Please select book you want to delete !!!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            }
        }

        public void RefreshOption()
        {
            category = new CategoryController().GetAllCategory();
            bookCategory.DataSource = null;
            loadBookCategory();
        }

        private void dataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewBook.Columns[e.ColumnIndex].Name == "editButton")
            {
                Book book = (Book)dataGridViewBook.Rows[e.RowIndex].DataBoundItem;

                UC_UpdateBook updateBook = new UC_UpdateBook(book);
                updateBook.adminInfromation = adminInfromation;

                PopUpForm popUpForm = new PopUpForm(updateBook, "Update Book");
                if (popUpForm.ShowDialog() == DialogResult.Yes) refreshTable();
            }
        }
    }
}
