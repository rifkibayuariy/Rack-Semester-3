using Guna.UI2.WinForms;
using LibraryManagement.View.vCategory;
using LibraryManagement.View.vMember;
using LibraryManagement.View.vBook;
using LibraryManagement.View.vBorrowBook;
using LibraryManagement.View.vReturnBook;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LibraryManagement.View.vProfile;

namespace LibraryManagement.View
{
    public partial class PopUpForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public PopUpForm(UserControl control, string title, int height = 0)
        {
            InitializeComponent();

            control.Dock = DockStyle.Top;

            if (height > 0) this.Height = height;

            PopUpFormContainer.Controls.Add(control);
            this.title.Text = title;

            if (control is UC_UpdateMember updateMember)
            {
                updateMember.MessageDialog = ShowMessageDialog;
                updateMember.ClosePopUp += ClosePopUp;
            }
            else if (control is UC_UpdateCategory updateCategory)
            {
                updateCategory.MessageDialog = ShowMessageDialog;
                updateCategory.ClosePopUp += ClosePopUp;
            }
            else if (control is UC_UpdateBook updateBook)
            {
                updateBook.MessageDialog = ShowMessageDialog;
                updateBook.ClosePopUp += ClosePopUp;
            }
            else if (control is UC_UpdateBorrowBook updateBorrowBook)
            {
                updateBorrowBook.MessageDialog = ShowMessageDialog;
                updateBorrowBook.ClosePopUp += ClosePopUp;
            }
            else if (control is UC_UpdateReturnBook updateReturnBook)
            {
                updateReturnBook.MessageDialog = ShowMessageDialog;
                updateReturnBook.ClosePopUp += ClosePopUp;
            }
            else if (control is UC_Profile profile)
            {
                profile.MessageDialog = ShowMessageDialog;
            }
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        public DialogResult ShowMessageDialog(
            string caption,
            string text,
            MessageDialogButtons buttons,
            MessageDialogStyle style,
            MessageDialogIcon icon)
        {
            mdPopUp.Caption = caption;
            mdPopUp.Text = text;
            mdPopUp.Buttons = buttons;
            mdPopUp.Style = style;
            mdPopUp.Icon = icon;

            return mdPopUp.Show();
        }

        private void ClosePopUp(object sender, DialogResult result) {
            DialogResult = result;
            Close();
        }
    }
}
