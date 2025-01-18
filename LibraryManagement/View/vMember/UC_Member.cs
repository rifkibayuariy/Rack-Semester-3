using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace LibraryManagement.View.vMember
{
    public partial class UC_Member : UserControl
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();

        private MemberController controller = new MemberController();

        public UC_Member()
        {
            InitializeComponent();

            List<Member> listMember = controller.GetAllMember();

            dataGridViewMember.AutoGenerateColumns = false;
            dataGridViewMember.MultiSelect = true;

            dataGridViewMember.DataSource = listMember;

            dataGridViewMember.Columns.Add("id_member", "No");
            dataGridViewMember.Columns.Add("name", "Name");
            dataGridViewMember.Columns.Add("gender", "Gender");
            dataGridViewMember.Columns.Add("email", "E-mail");

            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "editButton",
                Text = "Edit"
            };

            dataGridViewMember.Columns.Add(buttonEdit);

            dataGridViewMember.Columns["id_member"].DataPropertyName = "id_member";
            dataGridViewMember.Columns["name"].DataPropertyName = "name";
            dataGridViewMember.Columns["gender"].DataPropertyName = "gender";
            dataGridViewMember.Columns["email"].DataPropertyName = "email";

            dataGridViewMember.Columns["id_member"].Width = 50;
            dataGridViewMember.Columns["editButton"].Width = 80;
            dataGridViewMember.Columns["gender"].Width = 100;

            dataGridViewMember.CellClick += DataGridViewMember_CellClick;

            dataGridViewMember.ReadOnly = true;

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

        private void Reset_Click(object sender, EventArgs e)
        {
            memberName.Text = "";
            rbFemale.Checked = false;
            rbMale.Checked = false;
            memberTelephoneNumber.Text = "";
            memberEmail.Text = "";
            memberAddress.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Member member = new Member();

            member.name = memberName.Text.Trim();
            member.gender = rbMale.Checked == true ? "male" : (rbFemale.Checked == true) ? "female" : "";
            member.no_telp = memberTelephoneNumber.Text.Trim();
            member.email = memberEmail.Text.Trim();
            member.address = memberAddress.Text.Trim();
            member.created_by = adminInfromation.id_admin;

            int result = controller.Create(member);

            if (result > 0)
            {
                memberName.Text = "";
                rbFemale.Checked = false;
                rbMale.Checked = false;
                memberTelephoneNumber.Text = "";
                memberEmail.Text = "";
                memberAddress.Text = "";

                refreshTable();
            }
        }

        private void refreshTable()
        {
            List<Member> list = controller.GetAllMember();

            dataGridViewMember.DataSource = list;
        }

        private void deleteMember_Click(object sender, EventArgs e)
        {
            if (dataGridViewMember.SelectedRows.Count > 0)
            {
                int result = 1;
                var confirmation = MessageDialog("Confirmation", "Do you want to delete member ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewMember.SelectedRows)
                    {
                        int rslt = controller.Delete(Convert.ToInt32(row.Cells["id_member"].Value));
                        if (rslt == 0) result = 0;
                    }

                    if (result > 0)
                        MessageDialog("Successfull", "Members deleted successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
                    else
                        MessageDialog("Failed", "Failed to delete member!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

                    refreshTable();
                }
            }
            else
            {
                MessageDialog("Warning", "Please select member you want to delete !!!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            }
        }

        private void DataGridViewMember_CellClick(object sender , DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewMember.Columns[e.ColumnIndex].Name == "editButton")
            {
                Member member = (Member)dataGridViewMember.Rows[e.RowIndex].DataBoundItem;

                UC_UpdateMember updateMember = new UC_UpdateMember(member);
                updateMember.adminInfromation = adminInfromation;

                PopUpForm popUpForm = new PopUpForm(updateMember, "Update Member");
                if (popUpForm.ShowDialog() == DialogResult.Yes) refreshTable();
            }
        }
    }
}
