using LibraryManagement.Model.Entity;
using System;
using System.Windows.Forms;

namespace LibraryManagement.View.vLoginRegister
{
    public partial class UC_Login : UserControl
    {
        public event EventHandler GotoRegister;
        public event EventHandler<Admin> SubmitForm;

        public UC_Login()
        {
            InitializeComponent();
        }

        private void OnGotoRegister()
        {
            GotoRegister?.Invoke(this, EventArgs.Empty);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnGotoRegister();
        }

        private void RaiseSubmitForm()
        {
            var data = new Admin
            {
                username = username.Text.Trim(),
                password = password.Text.Trim(),
            };

            SubmitForm?.Invoke(this, data);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RaiseSubmitForm();
        }
    }
}
