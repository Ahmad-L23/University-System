using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using University_Bussiness;

namespace Universt_System.departments
{
    public partial class frmUpdateDeleteDepartment : Form
    {
        private int selectedDepartmentId = -1;
        private string selectedDepartmentName = "";

        public frmUpdateDeleteDepartment()
        {
            InitializeComponent();
            LoadDepartments();

            
            this.dgvDepartments.CellClick += new DataGridViewCellEventHandler(this.dgvDepartments_CellClick);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
        }
        
        private void LoadDepartments(string searchQuery = "")
        {
            DataTable departments;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                
                List<Tuple<int, string>> departmentList = clsDepartments.GetAllDepartments();
                departments = new DataTable();
                departments.Columns.Add("Department ID", typeof(int));
                departments.Columns.Add("Department Name", typeof(string));

                foreach (var d in departmentList)
                {
                    departments.Rows.Add(d.Item1, d.Item2);
                }
            }
            else
            {
                
                departments = clsDepartments.SearchDepartmentByName(searchQuery);
            }

            dgvDepartments.DataSource = departments;
            dgvDepartments.ClearSelection();
            selectedDepartmentId = -1;
            selectedDepartmentName = "";
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            pnlUpdate.Visible = false;

            if (departments.Rows.Count == 0)
            {
                lblStatus.Text = "⚠️ No departments found!";
            }
            else
            {
                lblStatus.Text = "👉 Select a department to update or delete.";
            }
        }


        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedDepartmentId = Convert.ToInt32(dgvDepartments.Rows[e.RowIndex].Cells[0].Value);
                selectedDepartmentName = dgvDepartments.Rows[e.RowIndex].Cells[1].Value.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                lblStatus.Text = $"✅ Selected Department: {selectedDepartmentName}";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentId == -1)
            {
                lblStatus.Text = "⚠️ Please select a department to update.";
                return;
            }

           

            
            pnlUpdate.Visible = true;
            
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentId == -1)
            {
                lblStatus.Text = "⚠️ No department selected! Please choose one.";
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to update '{selectedDepartmentName}'?",
               "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (!string.IsNullOrWhiteSpace(txtNewName.Text))
            {
                if (result == DialogResult.Yes)
                {
                    bool isUpdated = clsDepartments.UpdateDepartmentName(selectedDepartmentId, txtNewName.Text);
                    if (isUpdated)
                    {
                        lblStatus.Text = $"✅ Department '{selectedDepartmentName}' updated to '{txtNewName.Text}'!";
                        LoadDepartments();
                        pnlUpdate.Visible = false; 
                    }
                    else
                    {
                        lblStatus.Text = "❌ Update failed!";
                    }
                }
            }
            else
            {
                lblStatus.Text = "⚠️ Please enter a new department name.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDepartmentId == -1)
            {
                lblStatus.Text = "⚠️ Please select a department to delete.";
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{selectedDepartmentName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = clsDepartments.DeleteDepartment(selectedDepartmentId);
                if (isDeleted)
                {
                    lblStatus.Text = $"✅ Department '{selectedDepartmentName}' deleted successfully!";
                    LoadDepartments();
                }
                else
                {
                    lblStatus.Text = "❌ Deletion failed!";
                }
            }
        }

        

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadDepartments(searchQuery);
        }
    }
}
