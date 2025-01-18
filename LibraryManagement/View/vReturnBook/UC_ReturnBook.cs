using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;
using LibraryManagement.Controller;
using Guna.UI2.WinForms;

namespace LibraryManagement.View.vReturnBook
{
    public partial class UC_ReturnBook : UserControl
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        public Admin adminInfromation = new Admin();

        private List<BorrowBook> listBorrow = new BorrowBookController().GetAllBorrowBooks(true);

        private ReturnBookController controller = new ReturnBookController();

        public UC_ReturnBook()
        {
            InitializeComponent();
            loadBorrow();

            List<ReturnBook> listReturnBook = controller.GetAllReturnBooks();

            dataGridViewReturnBook.AutoGenerateColumns = false;
            dataGridViewReturnBook.MultiSelect = true;

            dataGridViewReturnBook.DataSource = listReturnBook;

            dataGridViewReturnBook.Columns.Add("id_return", "ID");
            dataGridViewReturnBook.Columns.Add("date", "Date");
            dataGridViewReturnBook.Columns.Add("book", "Book");
            dataGridViewReturnBook.Columns.Add("member", "Member");

            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "editButton",
                Text = "Edit"
            };

            dataGridViewReturnBook.Columns.Add(buttonEdit);

            dataGridViewReturnBook.Columns["id_return"].DataPropertyName = "id_return";
            dataGridViewReturnBook.Columns["date"].DataPropertyName = "date";
            dataGridViewReturnBook.Columns["book"].DataPropertyName = "book";
            dataGridViewReturnBook.Columns["member"].DataPropertyName = "member";

            dataGridViewReturnBook.Columns["id_return"].Width = 50;
            dataGridViewReturnBook.Columns["editButton"].Width = 80;

            dataGridViewReturnBook.CellClick += dataGridViewReturnBook_CellClick;

            dataGridViewReturnBook.ReadOnly = true;

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

        private void loadBorrow()
        {
            idBorrow.DataSource = listBorrow;

            idBorrow.DisplayMember = "text";
            idBorrow.ValueMember = "id_borrow";
        }

        public void RefreshOption()
        {
            listBorrow = new BorrowBookController().GetAllBorrowBooks(true);

            loadBorrow();
        }

        private void idBorrow_SelectedValueChanged(object sender, EventArgs e)
        {
            if (idBorrow.SelectedItem is BorrowBook borrowBook) {
                member.Text = borrowBook.name;
                book.Text = borrowBook.title;
                date.Text = borrowBook.date;
                dueDate.Text = borrowBook.due_date;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            bookCondition.Text = "";
            returnFine.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();

            returnBook.id_borrow = Convert.ToInt32(idBorrow.SelectedValue);
            returnBook.condition = bookCondition.Text.Trim();
            returnBook.charge = returnFine.Text.Trim();
            returnBook.created_by = adminInfromation.id_admin;

            int result = controller.Create(returnBook);

            if (result > 0)
            {
                bookCondition.Text = "";
                returnFine.Text = "";
                member.Text = "";
                book.Text = "";
                date.Text = "";
                dueDate.Text = "";

                RefreshOption();
                refreshTable();
            }
        }

        public void refreshTable()
        {
            List<ReturnBook> list = controller.GetAllReturnBooks();

            dataGridViewReturnBook.DataSource = list;
        }

        private void dataGridViewReturnBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewReturnBook.Columns[e.ColumnIndex].Name == "editButton")
            {
                ReturnBook returnBook = (ReturnBook)dataGridViewReturnBook.Rows[e.RowIndex].DataBoundItem;

                UC_UpdateReturnBook updateReturnBook = new UC_UpdateReturnBook(returnBook);
                updateReturnBook.adminInfromation = adminInfromation;

                PopUpForm popUpForm = new PopUpForm(updateReturnBook, "Update Return Book Data");
                if (popUpForm.ShowDialog() == DialogResult.Yes) refreshTable();
            }
        }

        private void deleteReturnBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewReturnBook.SelectedRows.Count > 0)
            {
                int result = 1;
                var confirmation = MessageDialog("Confirmation", "Do you want to delete this data ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewReturnBook.SelectedRows)
                    {
                        int rslt = controller.Delete(Convert.ToInt32(row.Cells["id_return"].Value));
                        if (rslt == 0) result = 0;
                    }

                    if (result > 0)
                        MessageDialog("Successfull", "Return Book deleted successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
                    else
                        MessageDialog("Failed", "Failed to delete Return Book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

                    RefreshOption();
                    refreshTable();
                }
            }
            else
            {
                MessageDialog("Warning", "Please select data you want to delete !!!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            }
        }
    }
}
