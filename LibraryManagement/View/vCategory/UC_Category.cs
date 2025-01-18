using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LibraryManagement.Model.Entity;
using LibraryManagement.Controller;

namespace LibraryManagement.View.vCategory
{
    public partial class UC_Category : UserControl
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;

        public Admin adminInfromation = new Admin();

        private CategoryController controller = new CategoryController();

        public UC_Category()
        {
            InitializeComponent();

            List<Category> listCategory = controller.GetAllCategory();

            dataGridViewCategory.AutoGenerateColumns = false;
            dataGridViewCategory.MultiSelect = true;

            dataGridViewCategory.DataSource = listCategory;

            dataGridViewCategory.Columns.Add("id_category", "id_category");
            dataGridViewCategory.Columns.Add("category", "Category Name");
            dataGridViewCategory.Columns.Add("description", "Description");

            DataGridViewButtonColumn buttonEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "editButton",
                Text = "Edit"
            };

            dataGridViewCategory.Columns.Add(buttonEdit);

            dataGridViewCategory.Columns["id_category"].DataPropertyName = "id_category";
            dataGridViewCategory.Columns["category"].DataPropertyName = "category";
            dataGridViewCategory.Columns["description"].DataPropertyName = "description";

            dataGridViewCategory.Columns["id_category"].Visible = false;

            dataGridViewCategory.Columns["editButton"].Width = 80;

            dataGridViewCategory.CellClick += DataGridViewMember_CellClick;

            dataGridViewCategory.ReadOnly = true;

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
            categoryName.Text = "";
            categoryDescription.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.category = categoryName.Text.Trim();
            category.description = categoryDescription.Text.Trim();
            category.created_by = adminInfromation.id_admin;

            int result = controller.Create(category);

            if (result > 0) {
                categoryName.Text = "";
                categoryDescription.Text = "";

                refreshTable();
            }
        }

        private void refreshTable()
        {
            List<Category> list = controller.GetAllCategory();

            dataGridViewCategory.DataSource = list;
        }

        private void deleteCategory_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategory.SelectedRows.Count > 0)
            {
                int result = 1;
                var confirmation = MessageDialog("Confirmation", "Do you want to delete category ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    foreach(DataGridViewRow row in dataGridViewCategory.SelectedRows)
                    {
                        int rslt = controller.Delete(Convert.ToInt32(row.Cells["id_category"].Value));
                        if (rslt == 0) result = 0;
                    }

                    if (result > 0)
                        MessageDialog("Successfull", "Category deleted successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
                    else
                        MessageDialog("Failed", "Failed to delete category!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

                    refreshTable();
                }
            }
            else
            {
                MessageDialog("Warning", "Please select the category you want to delete !!!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            }
        }

        private void DataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewCategory.Columns[e.ColumnIndex].Name == "editButton")
            {
                Category category = (Category)dataGridViewCategory.Rows[e.RowIndex].DataBoundItem;

                UC_UpdateCategory updateCategory = new UC_UpdateCategory(category);
                updateCategory.adminInfromation = adminInfromation;

                PopUpForm popUpForm = new PopUpForm(updateCategory, "Update Category", 400);
                if (popUpForm.ShowDialog() == DialogResult.Yes) refreshTable();
            }
        }
    }
}
