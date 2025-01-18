using Guna.UI2.WinForms;
using LibraryManagement.Model.Context;
using LibraryManagement.Model.Entity;
using LibraryManagement.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Controller
{
    public class ProfileController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private AdminRepository adminRepository;

        public int Update(Admin admin, string old_username)
        {
            int result = 0;

            if (string.IsNullOrEmpty(admin.name))
            {
                SendWarning("Please input name !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(admin.gender))
            {
                SendWarning("Please choose gender !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(admin.no_telp))
            {
                SendWarning("Please input telephone number !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(admin.email))
            {
                SendWarning("Please input e-mail!!!");
                return 0;
            }

            if (string.IsNullOrEmpty(admin.username))
            {
                SendWarning("Please input username !!!");
                return 0;
            }

            bool password = false;
            if (!string.IsNullOrEmpty(admin.password))
            {
                if (admin.password != admin.confirm_password)
                {
                    SendWarning("Confirm Password not match !!!");
                    return 0;
                }
                else if (admin.password == admin.confirm_password) password = true;
            }

            using (DbContext context = new DbContext())
            {
                adminRepository = new AdminRepository(context);
                Admin adminFiltered = adminRepository.FindAdminByUsername(admin.username);

                if (old_username != admin.username && adminFiltered.username == admin.username)
                {
                    SendWarning("Username has been registered, please use another !!!");
                    return 0;
                }
            }

            if (MessageDialog("Confirmation", "Do you want to update profile ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    adminRepository = new AdminRepository(context);
                    result = adminRepository.Update(admin, password);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Profile updated successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update profile!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}