using System;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.categories
{
    public partial class frmDeleteCategory : Form
    {
        private int selectedID = 0;

        public frmDeleteCategory()
        {
            InitializeComponent();
            LoadCategories();
        }

        // Load categories into the DataGridView
        private void LoadCategories()
        {
            dgvCategories.DataSource = clsCategorie.GetAllCategories();
            dgvCategories.Columns["ID"].Visible = false;
        }

        // Handle category selection change in DataGridView
        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null && dgvCategories.CurrentRow.DataBoundItem is clsCategorie selectedCategory)
            {
                selectedID = selectedCategory.ID ?? 0;
            }
        }

        
       

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = clsCategorie.DeleteCategory(selectedID);
                if (isDeleted)
                {
                    MessageBox.Show("Category deleted successfully.");
                    LoadCategories(); // Refresh DataGridView after deletion
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }
            }
        }
    }
}
