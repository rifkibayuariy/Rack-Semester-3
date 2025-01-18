using Guna.UI2.WinForms;
using LibraryManagement.Controller;
using LibraryManagement.Model.Entity;
using System;
using System.Windows.Forms;

namespace LibraryManagement.View.vCategory
{
    public partial class UC_UpdateCategory : UserControl
    {
        public event EventHandler<DialogResult> ClosePopUp;
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();
        private CategoryController controller = new CategoryController();
        private Category category = new Category();

        public UC_UpdateCategory(Category category)
        {
            InitializeComponent();

            this.category = category;

            categoryName.Text = category.category;
            categoryDescription.Text = category.description;

            created.Text = category.creation_date + " " + category.created_by_name;
            lastUpdateDate.Text = category.last_update_date + " " + category.last_update_by_name;

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
            category.category = categoryName.Text.Trim();
            category.description = categoryDescription.Text.Trim();
            category.last_update_by = adminInfromation.id_admin;

            int result = controller.Update(category);

            if (result > 0) ClosePopUp?.Invoke(this, DialogResult.Yes);
        }
    }
}
