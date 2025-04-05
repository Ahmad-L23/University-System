using System;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.categories
{
    public partial class frmAddCategory : Form
    {
        public event Action OnCategoryAdded;

        public frmAddCategory()
        {
            InitializeComponent();
        }

        

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            int hours = (int)numHours.Value;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a valid category name.");
                return;
            }

            clsCategorie category = new clsCategorie(name: name, numberOfHours: hours);
            if (category.AddCategory())
            {
                MessageBox.Show("Category added successfully.");
                OnCategoryAdded?.Invoke(); // Notify update form
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add category.");
            }
        }
    }
}
