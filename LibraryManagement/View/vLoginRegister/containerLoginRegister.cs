using System;
using System.Drawing;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;
using LibraryManagement.Controller;
using Guna.UI2.WinForms;

namespace LibraryManagement.View.vLoginRegister
{
    public partial class containerLoginRegister : UserControl
    {
        public event EventHandler<Admin> loggedIn;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        private LoginRegisterController controller = new LoginRegisterController();

        public containerLoginRegister()
        {
            InitializeComponent();

            toLogin();

            Image originalImage = Properties.Resources.rack_bg;

            double aspectRatio = (double)originalImage.Width / originalImage.Height;

            int newHeight = panel2.Height;
            int newWidth = (int)(newHeight * aspectRatio);

            Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);

            panel2.BackgroundImage = resizedImage;

            logoLoginRegister.Image = Properties.Resources.rack_white;

            logoLoginRegister.Location = new Point(
                (panel2.Width - logoLoginRegister.Width) / 2,
                (panel2.Height - logoLoginRegister.Height) / 2
            );

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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Image originalImage = Properties.Resources.rack_bg;

            double aspectRatio = (double)originalImage.Width / originalImage.Height;

            int newHeight = panel2.Height;
            int newWidth = (int)(newHeight * aspectRatio);

            Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);

            panel2.BackgroundImage = resizedImage;

            logoLoginRegister.Location = new Point(
                (panel2.Width - logoLoginRegister.Width) / 2,
                (panel2.Height - logoLoginRegister.Height) / 2
            );

        }

        private void toRegisterEvent(object sender, EventArgs e)
        {
            toRegister();
        }

        private void toRegister()
        {
            contentLoginRegister.Controls.Clear();

            UC_Register register = new UC_Register();

            register.Dock = DockStyle.Fill;
            contentLoginRegister.Controls.Add(register);

            register.BackToLogin += toLoginEvent;
            register.SubmitForm += Register;
        }

        private void toLoginEvent(object sender, EventArgs e)
        {
            toLogin();
        }

        private void toLogin()
        {
            contentLoginRegister.Controls.Clear();

            UC_Login login = new UC_Login();

            login.Dock = DockStyle.Fill;
            contentLoginRegister.Controls.Add(login);

            login.GotoRegister += toRegisterEvent;
            login.SubmitForm += Login;
        }

        private void Register(object sender, Admin admin)
        {
            int result = controller.Create(admin);

            if (result > 0) {
                toLogin();
            }
        }

        private void Login(object sender, Admin admin)
        {
            int result = controller.Login(admin);

            if (result > 0) {
                OnLogged(controller.getAdminLogged());
            }
        }

        private void OnLogged(Admin admin)
        {
            loggedIn?.Invoke(this, admin);
        }
    }
}
