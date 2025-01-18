using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;

using LibraryManagement.View.vDashboard;
using LibraryManagement.View.vCategory;
using LibraryManagement.View.vMember;
using LibraryManagement.View.vBook;
using LibraryManagement.View.vBorrowBook;
using LibraryManagement.View.vReturnBook;
using LibraryManagement.View.vLoginRegister;
using LibraryManagement.View.vProfile;
using System.Linq;

namespace LibraryManagement.View
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int maxWidthSidemenu = 300;
        private int minWidthSidemenu = 106;
        private bool sidemenuExpand = true;
        private string menuActive = "";

        private Dictionary<string, Image> iconMenuLight = new Dictionary<string, Image>();
        private Dictionary<string, Image> iconMenuDark = new Dictionary<string, Image>();

        private bool is_logged = false;

        UC_Dashboard dashboard = null;
        UC_Category category = null;
        UC_Member member = null;
        UC_Book book = null;
        UC_BorrowBook borrowBook = null;
        UC_ReturnBook returnBook = null;
        UC_Profile profile = null;

        public Admin adminInformation = new Admin();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                const int resizeArea = 10;
                Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        public Main()
        {
            InitializeComponent();
            iconMenuLight.Add("btnSidemenuDashboard", Properties.Resources.home_light);
            iconMenuLight.Add("btnSidemenuBorrow", Properties.Resources.borrow_light);
            iconMenuLight.Add("btnSidemenuReturn", Properties.Resources.return_light);
            iconMenuLight.Add("btnSidemenuBook", Properties.Resources.book_light);
            iconMenuLight.Add("btnSidemenuCategory", Properties.Resources.stack_light);
            iconMenuLight.Add("btnSidemenuMember", Properties.Resources.user_group_light);

            iconMenuDark.Add("btnSidemenuDashboard", Properties.Resources.home_dark);
            iconMenuDark.Add("btnSidemenuBorrow", Properties.Resources.borrow_dark);
            iconMenuDark.Add("btnSidemenuReturn", Properties.Resources.return_dark);
            iconMenuDark.Add("btnSidemenuBook", Properties.Resources.book_dark);
            iconMenuDark.Add("btnSidemenuCategory", Properties.Resources.stack_dark);
            iconMenuDark.Add("btnSidemenuMember", Properties.Resources.user_group_dark);

            checkLoggedIn();
            
        }

        private void checkLoggedIn()
        {
            Guna2Panel menuDashboard = sidemenuList.Controls[sidemenuList.Controls.Count - 1] as Guna2Panel;

            if (is_logged)
            {
                if (contentContainer.Controls.Find("cntrLoginRegister", false).Count() > 0) contentContainer.Controls.Remove(contentContainer.Controls.Find("cntrLoginRegister", false)[0]);
                sidemenu.Visible = true;
                contentContainer.Controls.Clear();

                itemSidemenu_Click(menuDashboard, EventArgs.Empty);

                sidemenuProfile_Name.Text = adminInformation.name;
            }
            else
            {
                sidemenu.Visible = false;

                dashboard = null;
                category = null;
                member = null;
                book = null;
                borrowBook = null;
                returnBook = null;

                adminInformation = new Admin();

                login();
            }
        }

        private void login()
        {
            contentContainer.Controls.Clear();
            containerLoginRegister loginRegister = new containerLoginRegister
            {
                Name = "cntrLoginRegister"
            };
            loginRegister.Dock = DockStyle.Fill;

            contentContainer.Controls.Add(loginRegister);

            loginRegister.loggedIn += loggedInEvent;
            loginRegister.MessageDialog = ShowMessageDialog;
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnMenuBar_Click(object sender, EventArgs e)
        {
            if (!sidemenuExpand)
            {
                sidemenu.Width = maxWidthSidemenu;
                sidemenuProfile.Visible = true;
            }
            else {
                sidemenu.Width = minWidthSidemenu;
                sidemenuProfile.Visible = false;
            }

            sidemenuExpand = !sidemenuExpand;
        }

        private void itemSidemenu_Click(object sender, EventArgs e)
        {
            Guna2Panel menu = null;
            if (sender is Guna2Panel)
            {
                menu = sender as Guna2Panel;
            } 
            else if (sender is Control control)
            {
                menu = control.Parent as Guna2Panel;
            }

            if (menu != null && menuActive != menu.Name)
            {
                if (menuActive != "")
                {
                    Guna2Panel menuBefore = sidemenuList.Controls.Find(menuActive, false)[0] as Guna2Panel;

                    menuBefore.FillColor = Color.Transparent;
                    Label textBefore = menuBefore.Controls.Find($"{menuBefore.Name}_Text", false)[0] as Label;
                    textBefore.ForeColor = System.Drawing.Color.FromArgb(63, 63, 63);
                    PictureBox pictureBoxBefore = menuBefore.Controls.Find($"{menuBefore.Name}_Icon", false)[0] as PictureBox;
                    pictureBoxBefore.Image = iconMenuDark[menuBefore.Name];
                }

                // active menu
                menu.FillColor = System.Drawing.Color.FromArgb(243, 149, 13);
                Label text = menu.Controls.Find($"{menu.Name}_Text", false)[0] as Label;
                text.ForeColor = Color.White;
                PictureBox pictureBox = menu.Controls.Find($"{menu.Name}_Icon", false)[0] as PictureBox;
                pictureBox.Image = iconMenuLight[menu.Name];

                menuActive = menu.Name;

                contentContainer.Controls.Clear();
                if (menuActive == "btnSidemenuDashboard") menuDashboard();
                else if (menuActive == "btnSidemenuCategory") menuCategory();
                else if (menuActive == "btnSidemenuMember") menuMember();
                else if (menuActive == "btnSidemenuBook") menuBook();
                else if (menuActive == "btnSidemenuBorrow") menuBorrowBook();
                else if (menuActive == "btnSidemenuReturn") menuReturnBook();
            }
        }

        private void menuDashboard()
        {
            if (dashboard == null)
            {
                dashboard = new UC_Dashboard();
            }
            else
            {
                dashboard.RefreshData();
            }

            dashboard.Dock = DockStyle.Fill;

            contentContainer.Controls.Add(dashboard);
        }

        private void menuCategory()
        {
            if (category == null)
            {
                category = new UC_Category();
            }

            category.Dock = DockStyle.Fill;
            category.MessageDialog = ShowMessageDialog;

            contentContainer.Controls.Add(category);

            category.adminInfromation = adminInformation;
        }

        private void menuMember()
        {
            if (member == null)
            {
                member = new UC_Member();
            }

            member.Dock = DockStyle.Fill;
            member.MessageDialog = ShowMessageDialog;

            contentContainer.Controls.Add(member);

            member.adminInfromation = adminInformation;
        }

        private void menuBook()
        {
            if (book == null)
            {
                book = new UC_Book();
            } else
            {
                book.RefreshOption();
            }

            book.Dock = DockStyle.Fill;
            book.MessageDialog = ShowMessageDialog;

            contentContainer.Controls.Add(book);

            book.adminInfromation = adminInformation;
        }

        private void menuBorrowBook()
        {
            if (borrowBook == null)
            {
                borrowBook = new UC_BorrowBook();
            }
            else
            {
                borrowBook.refreshTable();
                borrowBook.RefreshOption();
            }

            borrowBook.Dock = DockStyle.Fill;
            borrowBook.MessageDialog = ShowMessageDialog;

            contentContainer.Controls.Add(borrowBook);

            borrowBook.adminInfromation = adminInformation;
        }

        private void menuReturnBook()
        {
            if (returnBook == null)
            {
                returnBook = new UC_ReturnBook();
            }
            else
            {
                returnBook.refreshTable();
                returnBook.RefreshOption();
            }

            returnBook.Dock = DockStyle.Fill;
            returnBook.MessageDialog = ShowMessageDialog;

            contentContainer.Controls.Add(returnBook);

            returnBook.adminInfromation = adminInformation;
        }

        private void Profile(object sender, EventArgs e)
        {
            profile = new UC_Profile(adminInformation);

            profile.MessageDialog = ShowMessageDialog;
            profile.UpdateProfile += UpdateProfileEvent;

            PopUpForm popUpForm = new PopUpForm(profile, "Profile - " + adminInformation.name);
            popUpForm.ShowDialog();
        }

        private void UpdateProfileEvent(object sender, Admin admin)
        {
            admin.password = "";
            admin.confirm_password = "";
            adminInformation = admin;

            sidemenuProfile_Name.Text = adminInformation.name;
        }

        private void loggedInEvent(object sender, Admin admin)
        {
            admin.password = "";
            adminInformation = admin;
            is_logged = true;

            checkLoggedIn();
        }

        private void cbClose_Click(object sender, EventArgs e)
        {
            mdMain.Icon = MessageDialogIcon.Warning;
            mdMain.Caption = "Exit?";
            mdMain.Text = "Close this application?";
            mdMain.Buttons = MessageDialogButtons.OKCancel;

            DialogResult result = mdMain.Show();

            if (result == DialogResult.Yes) this.Close();
        }

        private void logout(object sender, EventArgs e)
        {
            mdMain.Icon = MessageDialogIcon.Question;
            mdMain.Caption = "Logout?";
            mdMain.Text = "Logout from this account?";
            mdMain.Buttons = MessageDialogButtons.OKCancel;

            DialogResult result = mdMain.Show();

            if (result == DialogResult.Yes)
            {
                is_logged = false;
                checkLoggedIn();
            }
        }

        public DialogResult ShowMessageDialog(
            string caption,
            string text,
            MessageDialogButtons buttons,
            MessageDialogStyle style,
            MessageDialogIcon icon)
        {
            mdMain.Caption = caption;
            mdMain.Text = text;
            mdMain.Buttons = buttons;
            mdMain.Style = style;
            mdMain.Icon = icon;

            return mdMain.Show();
        }
    }
}
