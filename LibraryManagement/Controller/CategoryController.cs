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

namespace LibraryManagement.Controller
{
    public class CategoryController
    {
        public Func<string, string, MessageDialogButtons, MessageDialogStyle, MessageDialogIcon, DialogResult> MessageDialog;
        private CategoryRepository categoryRepository;

        private int FormValidation(Category category)
        {
            if (string.IsNullOrEmpty(category.category))
            {
                SendWarning("Please input category name !!!");
                return 0;
            }

            return 1;
        }

        public int Create(Category category)
        {
            int result = 0;

            if (FormValidation(category) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to add category ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    categoryRepository = new CategoryRepository(context);
                    result = categoryRepository.Create(category);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Category added successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to add category!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Update(Category category)
        {
            int result = 0;

            if (FormValidation(category) == 0) return result;

            if (MessageDialog("Confirmation", "Do you want to update category ?", MessageDialogButtons.YesNo, MessageDialogStyle.Light, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                using (DbContext context = new DbContext())
                {
                    categoryRepository = new CategoryRepository(context);
                    result = categoryRepository.Update(category);
                }
            }
            else
            {
                return result;
            }

            if (result > 0)
                MessageDialog("Successfull", "Category update successfully!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
            else
                MessageDialog("Failed", "Failed to update category!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public int Delete(int idCategory)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                categoryRepository = new CategoryRepository(context);
                result = categoryRepository.Delete(idCategory);
            }

            if (result > 0) { }
            else
                MessageDialog("Failed", "Failed to delete category!", MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Error);

            return result;
        }

        public List<Category> GetAllCategory()
        {
            List<Category> result = new List<Category>();

            using (DbContext context = new DbContext())
            {
                categoryRepository = new CategoryRepository(context);
                result = categoryRepository.GetAllCategory();
            }

            return result;
        }

        private void SendWarning(string text)
        {
            MessageDialog("Warning", text, MessageDialogButtons.OK, MessageDialogStyle.Light, MessageDialogIcon.Warning);
        }
    }
}
