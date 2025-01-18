using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.View.vProfile
{
    public partial class UC_Profile : UserControl
    {
        public event EventHandler<Admin> UpdateProfile;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        private ProfileController controller = new ProfileController();

        private Admin admin = new Admin();
        private string old_username;

        public UC_Profile(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            old_username = admin.username;

            name.Text = admin.name;
            if (admin.gender == "male") rbMale.Checked = true;
            else if (admin.gender == "female") rbFemale.Checked = true;
            telephoneNumber.Text = admin.no_telp;
            email.Text = admin.email;
            username.Text = admin.username;

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
            admin.name = name.Text.Trim();
            admin.gender = rbMale.Checked == true ? "male" : (rbFemale.Checked == true) ? "female" : "";
            admin.no_telp = telephoneNumber.Text.Trim();
            admin.email = email.Text.Trim();
            admin.username = username.Text.Trim();
            admin.password = password.Text.Trim();
            admin.confirm_password = confirmPassword.Text.Trim();

            int result = controller.Update(admin, old_username);

            if (result > 0)
            {
                password.Text = "";
                confirmPassword.Text = "";
                UpdateProfile?.Invoke(this, admin);
                old_username = admin.username;
            }
        }
    }
}
