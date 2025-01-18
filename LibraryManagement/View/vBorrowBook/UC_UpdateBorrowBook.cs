using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;

using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.View.vBorrowBook
{
    public partial class UC_UpdateBorrowBook : UserControl
    {
        public event EventHandler<DialogResult> ClosePopUp;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();
        private BorrowBookController controller = new BorrowBookController();
        private BorrowBook borrowBook = new BorrowBook();

        private List<Member> listMember = new MemberController().GetAllMember();
        private List<Book> listBook = new BookController().GetAllBooks();

        public UC_UpdateBorrowBook(BorrowBook borrowBook)
        {
            InitializeComponent();
            loadMember();
            loadBook();

            this.borrowBook = borrowBook;

            cbMember.SelectedValue = borrowBook.id_member;
            cbBook.SelectedValue = borrowBook.id_book;
            dueDate.Value = DateTime.Parse(borrowBook.due_date);

            created.Text = borrowBook.creation_date + " " + borrowBook.created_by_name;
            lastUpdateDate.Text = borrowBook.last_update_date + " " + borrowBook.last_update_by_name;
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

        private void loadMember()
        {
            cbMember.DataSource = listMember;

            cbMember.DisplayMember = "name";
            cbMember.ValueMember = "id_member";
        }

        private void loadBook()
        {
            cbBook.DataSource = listBook;

            cbBook.DisplayMember = "title";
            cbBook.ValueMember = "id_book";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            borrowBook.id_member = Convert.ToInt32(cbMember.SelectedValue);
            borrowBook.id_book = Convert.ToInt32(cbBook.SelectedValue);
            borrowBook.due_date = dueDate.Value.ToString("yyyy-MM-dd");
            borrowBook.last_update_by = adminInfromation.id_admin;

            int result = controller.Update(borrowBook);

            if (result > 0) ClosePopUp?.Invoke(this, DialogResult.Yes);
        }
    }
}
