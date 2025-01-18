using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;

namespace LibraryManagement.View.vMember
{
    public partial class UC_UpdateMember : UserControl
    {
        public event EventHandler<DialogResult> ClosePopUp;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();
        private MemberController controller = new MemberController();
        private Member member = new Member();

        public UC_UpdateMember(Member member)
        {
            InitializeComponent();

            this.member = member;

            memberName.Text = member.name;
            if (member.gender == "male") rbMale.Checked = true;
            else if (member.gender == "female") rbFemale.Checked = true;
            memberTelephoneNumber.Text = member.no_telp;
            memberEmail.Text = member.email;
            memberAddress.Text = member.address;

            created.Text = member.creation_date + " " + member.created_by_name;
            lastUpdateDate.Text = member.last_update_date + " " + member.last_update_by_name;

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
            member.name = memberName.Text.Trim();
            member.gender = rbMale.Checked == true ? "male" : (rbFemale.Checked == true) ? "female" : "";
            member.no_telp = memberTelephoneNumber.Text.Trim();
            member.email = memberEmail.Text.Trim();
            member.address = memberAddress.Text.Trim();
            member.last_update_by = adminInfromation.id_admin;

            int result = controller.Update(member);

            if (result > 0) ClosePopUp?.Invoke(this, DialogResult.Yes);
        }
    }
}
