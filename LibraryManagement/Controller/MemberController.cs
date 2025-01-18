using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagement.Model.Entity;
using LibraryManagement.Model.Repository;
using LibraryManagement.Model.Context;
using System.Windows.Forms;
using LibraryManagement.View;
using Guna.UI2.WinForms;

namespace LibraryManagement.Controller
{
    public class MemberController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private MemberRepository memberRepository;

        private int FormValidation(Member member)
        {
            if (string.IsNullOrEmpty(member.name))
            {
                SendWarning("Please input member name !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(member.gender))
            {
                SendWarning("Please choose gender !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(member.no_telp))
            {
                SendWarning("Please input telephone number !!!");
                return 0;
            }

            if (string.IsNullOrEmpty(member.email))
            {
                SendWarning("Please input e-mail!!!");
                return 0;
            }

            if (string.IsNullOrEmpty(member.address))
            {
                SendWarning("Please input address !!!");
                return 0;
            }

            return 1;
        }

        public int Create(Member member)
        {
            int result = 0;

            if (FormValidation(member) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to add member ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes) {
                using (DbContext context = new DbContext())
                {
                    memberRepository = new MemberRepository(context);
                    result = memberRepository.Create(member);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Member added successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to add member!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Update(Member member)
        {
            int result = 0;

            if (FormValidation(member) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to update member ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    memberRepository = new MemberRepository(context);
                    result = memberRepository.Update(member);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Member updated!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update member!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Delete(int id_member)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                memberRepository = new MemberRepository(context);
                result = memberRepository.Delete(id_member);
            }

            if (result > 0) { }
            else
                MessageDialog("Failed", "Failed to delete member!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public List<Member> GetAllMember()
        {
            List<Member> result = new List<Member>();

            using (DbContext context = new DbContext())
            {
                memberRepository = new MemberRepository(context);
                result = memberRepository.GetAllMember();
            }

            return result;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}
