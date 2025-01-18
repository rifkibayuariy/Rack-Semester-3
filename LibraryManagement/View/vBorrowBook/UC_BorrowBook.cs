using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;
using LibraryManagement.Controller;
using Guna.UI2.WinForms;

namespace LibraryManagement.View.vBorrowBook
{
    public partial class UC_BorrowBook : UserControl
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        public Admin adminInfromation = new Admin();

        private List<Member> listMember = new MemberController().GetAllMember();
        private List<Book> listBook = new BookController().GetAllBooks();

        private BorrowBookController controller = new BorrowBookController();

        public UC_BorrowBook()
        {
            InitializeComponent();
            loadMember();
            loadBook();

            dueDate.Value = DateTime.Now.AddDays(7);

            List<BorrowBook> listBorrowBook = controller.GetAllBorrowBooks();

            dataGridViewBorrowBook.AutoGenerateColumns = false;
            dataGridViewBorrowBook.MultiSelect = true;

            dataGridViewBorrowBook.DataSource = listBorrowBook;

            dataGridViewBorrowBook.Columns.Add("id_borrow", "No");
            dataGridViewBorrowBook.Columns.Add("title", "Book");
            dataGridViewBorrowBook.Columns.Add("date", "Date");
            dataGridViewBorrowBook.Columns.Add("name", "Member");
            dataGridViewBorrowBook.Columns.Add("due_date", "Due Date");

            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "editButton",
                Text = "Edit"
            };

            dataGridViewBorrowBook.Columns.Add(buttonEdit);

            dataGridViewBorrowBook.Columns["id_borrow"].DataPropertyName = "id_borrow";
            dataGridViewBorrowBook.Columns["title"].DataPropertyName = "title";
            dataGridViewBorrowBook.Columns["date"].DataPropertyName = "date";
            dataGridViewBorrowBook.Columns["name"].DataPropertyName = "name";
            dataGridViewBorrowBook.Columns["due_date"].DataPropertyName = "due_date";

            dataGridViewBorrowBook.Columns["id_borrow"].Width = 50;
            dataGridViewBorrowBook.Columns["editButton"].Width = 80;

            dataGridViewBorrowBook.CellClick += dataGridViewBorrowBook_CellClick;

            dataGridViewBorrowBook.ReadOnly = true;

            dataGridViewBorrowBook.MultiSelect = false;

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
            BorrowBook borrowBook = new BorrowBook();

            borrowBook.id_member = Convert.ToInt32(cbMember.SelectedValue);
            borrowBook.id_book = Convert.ToInt32(cbBook.SelectedValue);
            borrowBook.due_date = dueDate.Value.ToString("yyyy-MM-dd");
            borrowBook.created_by = adminInfromation.id_admin;

            int result = controller.Create(borrowBook);

            if (result > 0)
            {
                refreshTable();
            }
        }

        public void refreshTable()
        {
            List<BorrowBook> list = controller.GetAllBorrowBooks();

            dataGridViewBorrowBook.DataSource = list;
        }

        public void RefreshOption()
        {
            listMember = new MemberController().GetAllMember();
            listBook = new BookController().GetAllBooks();
            loadMember();
            loadBook();
        }

        private void deleteBorrowBook_Click(object sender, EventArgs e)
        {
            BorrowBook borrowBook = (BorrowBook)dataGridViewBorrowBook.Rows[dataGridViewBorrowBook.SelectedRows[0].Index].DataBoundItem;

            if (borrowBook.returned > 0)
            {
                MessageDialog("Warning", "The book has been returned !!!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            }
            else
            {
                if (dataGridViewBorrowBook.SelectedRows.Count > 0)
                {
                    int result = 1;
                    var confirmation = MessageDialog("Confirmation", "Do you want to delete this data ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridViewBorrowBook.SelectedRows)
                        {
                            int rslt = controller.Delete(Convert.ToInt32(row.Cells["id_borrow"].Value));
                            if (rslt == 0) result = 0;
                        }

                        if (result > 0)
                            MessageDialog("Successfull", "Borrow Book deleted successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
                        else
                            MessageDialog("Failed", "Failed to delete Borrow Book!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);


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

        private void dataGridViewBorrowBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewBorrowBook.Columns[e.ColumnIndex].Name == "editButton")
            {
                BorrowBook borrowBook = (BorrowBook)dataGridViewBorrowBook.Rows[e.RowIndex].DataBoundItem;

                UC_UpdateBorrowBook updateBorrowBook = new UC_UpdateBorrowBook(borrowBook);
                updateBorrowBook.adminInfromation = adminInfromation;

                PopUpForm popUpForm = new PopUpForm(updateBorrowBook, "Update Borrow Book Data", 400);
                if (popUpForm.ShowDialog() == DialogResult.Yes) refreshTable();
            }
        }

        private void dataGridViewBorrowBook_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBorrowBook.Rows)
            {
                BorrowBook borrowBook = row.DataBoundItem as BorrowBook;

                if (borrowBook != null)
                {
                    if (borrowBook.returned > 0)
                    {
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.FromArgb(243, 149, 13);
                    }
                }
            }
        }
    }
}
