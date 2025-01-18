using Guna.UI2.WinForms;
using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;
using System;
using System.Windows.Forms;

namespace LibraryManagement.View.vReturnBook
{
    public partial class UC_UpdateReturnBook : UserControl
    {
        public event EventHandler<DialogResult> ClosePopUp;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();
        private ReturnBookController controller = new ReturnBookController();
        private ReturnBook returnBook = new ReturnBook();

        public UC_UpdateReturnBook(ReturnBook returnBook)
        {
            InitializeComponent();

            this.returnBook = returnBook;

            idBorrow.Text = returnBook.id_borrow.ToString();
            member.Text = returnBook.borrowBook.name;
            book.Text = returnBook.borrowBook.title;
            date.Text = returnBook.borrowBook.date;
            dueDate.Text = returnBook.borrowBook.due_date;
            bookCondition.Text = returnBook.condition;
            returnFine.Text = returnBook.charge;

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

        private void Submit_Click(object sender, EventArgs e)
        {
            returnBook.condition = bookCondition.Text.Trim();
            returnBook.charge = returnFine.Text.Trim();
            returnBook.last_update_by = adminInfromation.id_admin;

            int result = controller.Update(returnBook);

            if (result > 0) ClosePopUp?.Invoke(this, DialogResult.Yes);
        }
    }
}
