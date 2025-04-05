namespace Universt_System.categories
{
    partial class frmAddCategory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Button btnAdd;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(71, 71, 71); // Modern gray for text
            this.lblCategoryName.Location = new System.Drawing.Point(26, 26);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(83, 13);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Category Name:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.White;
            this.txtCategoryName.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45); // Darker text for clarity
            this.txtCategoryName.Location = new System.Drawing.Point(120, 23);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(172, 20);
            this.txtCategoryName.TabIndex = 1;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.ForeColor = System.Drawing.Color.FromArgb(71, 71, 71); // Matching color for text labels
            this.lblHours.Location = new System.Drawing.Point(26, 61);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(90, 13);
            this.lblHours.TabIndex = 2;
            this.lblHours.Text = "Number of Hours:";
            // 
            // numHours
            // 
            this.numHours.BackColor = System.Drawing.Color.White;
            this.numHours.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45); // Matching input fields text color
            this.numHours.Location = new System.Drawing.Point(120, 59);
            this.numHours.Maximum = new decimal(new int[] {
    1000,
    0,
    0,
    0});
            this.numHours.Minimum = new decimal(new int[] {
    1,
    0,
    0,
    0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(86, 20);
            this.numHours.TabIndex = 3;
            this.numHours.Value = new decimal(new int[] {
    1,
    0,
    0,
    0});
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113); // Fresh green for add button
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(120, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 26);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Category";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // frmAddCategory
            // 
            this.AcceptButton = this.btnAdd;
            this.BackColor = System.Drawing.Color.FromArgb(249, 249, 249); // Lighter gray background for a fresh look
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 147);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Category";
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}
