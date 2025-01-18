using System;
using System.Drawing;
using System.Windows.Forms;

using LibraryManagement.Controller;

namespace LibraryManagement.View.vDashboard
{
    public partial class UC_Dashboard : UserControl
    {
        private int totalBooks = new BookController().GetTotalBooks();
        private int totalBorrowBooks = new BorrowBookController().GetTotalBorrowBooks();
        private int totalBorrowBooksToday = new BorrowBookController().GetTotalBorrowBooksToday();

        public UC_Dashboard()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            totalBook.Text = totalBooks.ToString();
            totalBorrow.Text = totalBorrowBooks.ToString();
            totalBorrowToday.Text = totalBorrowBooksToday.ToString();
        }

        public void RefreshData()
        {
            totalBooks = new BookController().GetTotalBooks();
            totalBorrowBooks = new BorrowBookController().GetTotalBorrowBooks();
            totalBorrowBooksToday = new BorrowBookController().GetTotalBorrowBooksToday();

            loadData();
        }
    }
}
