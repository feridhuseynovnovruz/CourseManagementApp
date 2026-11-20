using System.Drawing;
using System.Windows.Forms;

namespace CourseManagementApp
{
    partial class CoursesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblCredits;
        private TextBox txtCredits;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblCount;
        private DataGridView dgvCourses;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblCredits = new Label();
            this.txtCredits = new TextBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.lblCount = new Label();
            this.dgvCourses = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(55, 13);
            this.lblTitle.Text = "Fənn adı:";

            this.txtTitle.Location = new Point(95, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(220, 20);

            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new Point(340, 22);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new Size(85, 13);
            this.lblCredits.Text = "Kredit (1-10):";

            this.txtCredits.Location = new Point(430, 18);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new Size(70, 20);

            this.btnAdd.Location = new Point(20, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(90, 28);
            this.btnAdd.Text = "Əlavə et";
            this.btnAdd.UseVisualStyleBackColor = true;

            this.btnUpdate.Location = new Point(120, 56);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(90, 28);
            this.btnUpdate.Text = "Yenilə";
            this.btnUpdate.UseVisualStyleBackColor = true;

            this.btnDelete.Location = new Point(220, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(90, 28);
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;

            this.lblCount.AutoSize = true;
            this.lblCount.Location = new Point(20, 100);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new Size(80, 13);
            this.lblCount.Text = "Fənn sayı: 0";

            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new Point(20, 130);
            this.dgvCourses.MultiSelect = false;
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new Size(680, 270);

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(720, 420);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "CoursesForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fənlərin İdarəedilməsi";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}