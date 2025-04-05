using System;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.categories
{
    public partial class frmUpdateCategory : Form
    {
        private int selectedID = 0;

        public frmUpdateCategory()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            dgvCategories.DataSource = clsCategorie.GetAllCategories();
            dgvCategories.Columns["ID"].Visible = false;
        }

        private void dgvCategories_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null && dgvCategories.CurrentRow.DataBoundItem is clsCategorie selectedCategory)
            {
                selectedID = selectedCategory.ID ?? 0;
                txtCategoryName.Text = selectedCategory.Name;
                numHours.Value = selectedCategory.NumberOfHours > 0 ? selectedCategory.NumberOfHours : 1;
            }
        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }

            string newName = txtCategoryName.Text.Trim();
            int newHours = (int)numHours.Value;

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Category name cannot be empty.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to update this category?", "Confirm Update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clsCategorie category = new clsCategorie(selectedID, newName, newHours);
                if (category.UpdateCategory())
                {
                    MessageBox.Show("Category updated successfully.");
                    LoadCategories(); // Refresh
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            var addForm = new frmAddCategory();
            addForm.OnCategoryAdded += LoadCategories; // auto-refresh
            addForm.ShowDialog();
        }

       
    }
}
