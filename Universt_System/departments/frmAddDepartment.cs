using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  University_Bussiness;

namespace Universt_System.departments
{
    public partial class frmAddDepartment: Form
    {
        public frmAddDepartment()
        {
            InitializeComponent();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {

            string departmentName = txtDepartmentName.Text.Trim();

            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                bool isAdded = clsDepartments.AddDepartment(departmentName);

                if (isAdded)
                {
                    lblStatus.Text = "Department added successfully!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    txtDepartmentName.Clear();
                }
                else
                {
                    lblStatus.Text = "Error adding department.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "Please enter a department name.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
