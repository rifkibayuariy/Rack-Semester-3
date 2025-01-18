using System;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;

namespace LibraryManagement.View.vLoginRegister
{
    public partial class UC_Register : UserControl
    {
        public event EventHandler BackToLogin;
        public event EventHandler<Admin> SubmitForm;

        public UC_Register()
        {
            InitializeComponent();
        }

        private void OnBackToLogin()
        {
            BackToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OnBackToLogin();
        }

        private void RaiseSubmitForm()
        {
            var data = new Admin
            {
                name = name.Text.Trim(),
                gender = rbMale.Checked == true ? "male" : (rbFemale.Checked == true) ? "female" : "",
                no_telp = telephone.Text.Trim(),
                email = email.Text.Trim(),
                username = username.Text.Trim(),
                password = password.Text.Trim(),
                confirm_password = confirmPassword.Text.Trim(),
            };

            SubmitForm?.Invoke(this, data);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RaiseSubmitForm();
        }
    }
}
