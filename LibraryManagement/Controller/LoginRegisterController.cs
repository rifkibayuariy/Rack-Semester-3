using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Model.Entity;
using LibraryManagement.Model.Repository;
using LibraryManagement.Model.Context;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Net.Mime.MediaTypeNames;

namespace LibraryManagement.Controller
{
    public class LoginRegisterController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        private Admin adminInformation = new Admin();
        private AdminRepository adminRepository;

        public int Create(Admin admin)
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

            if (string.IsNullOrEmpty(admin.password))
            {
                SendWarning("Please input password !!!");
                return 0;
            }

            if (admin.password != admin.confirm_password)
            {
                SendWarning("Confirm Password not match !!!");
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                adminRepository = new AdminRepository(context);
                Admin adminFiltered = adminRepository.FindAdminByUsername(admin.username);

                if (adminFiltered.username == admin.username)
                {
                    SendWarning("Username has been registered, please use another !!!");
                    return 0;
                }
            }

            using (DbContext context = new DbContext())
            {
                adminRepository = new AdminRepository(context);
                result = adminRepository.Create(admin);
            }

            if (result > 0)
                MessageDialog("Successfull", "Admin Registered!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to register account!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Login(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.username))
            {
                SendWarning("Please input username !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(admin.password))
            {
                SendWarning("Please input password !!!");
                return 0;
            }

            Admin adminFiltered = new Admin();
            using (DbContext context = new DbContext())
            {
                adminRepository = new AdminRepository(context);
                adminFiltered = adminRepository.FindAdminByUsername(admin.username);
            }

            if (adminFiltered.username != admin.username)
            {
                SendWarning("Username not found !!!");
                return 0;
            }

            if (adminFiltered.username == admin.username && adminFiltered.password != admin.password)
            {
                SendWarning("Password not match !!!");
                return 0;
            } else if (adminFiltered.username == admin.username && adminFiltered.password == admin.password)
            {
                adminInformation = adminFiltered;
                return 1;
            }

            return 1;
        }

        public Admin getAdminLogged()
        {
            return adminInformation;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}
