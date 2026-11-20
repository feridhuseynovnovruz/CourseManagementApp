using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseManagementApp
{
    public partial class CoursesForm : Form
    {
        private readonly CourseRepository _repo = new CourseRepository();
        private int _selectedCourseId = 0;

        public CoursesForm()
        {
            InitializeComponent();

            this.Load += CoursesForm_Load;
            dgvCourses.CellClick += dgvCourses_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                dgvCourses.DataSource = null;
                dgvCourses.DataSource = _repo.GetAll();
                lblCount.Text = "Fənn sayı: " + _repo.Count();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Verilənlər bazası xətası: " + ex.Message);
            }
        }

        private bool TryGetCourseInput(out string title, out int credits)
        {
            title = txtTitle.Text.Trim();
            credits = 0;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Fənn adını daxil edin.");
                return false;
            }

            if (!int.TryParse(txtCredits.Text.Trim(), out credits) || credits < 1 || credits > 10)
            {
                MessageBox.Show("Kredit 1 ilə 10 arasında tam ədəd olmalıdır.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetCourseInput(out string title, out int credits)) return;

            try
            {
                _repo.Add(new Course
                {
                    Title = title,
                    Credits = credits
                });

                ClearInputs();
                LoadCourses();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Kredit və ya əlaqəli məhdudiyyət pozulub (1-10 arası olmalıdır).");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Verilənlər bazası xətası: " + ex.Message);
            }
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var course = dgvCourses.Rows[e.RowIndex].DataBoundItem as Course;
            if (course == null) return;

            _selectedCourseId = course.Id;
            txtTitle.Text = course.Title;
            txtCredits.Text = course.Credits.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Əvvəlcə cədvəldən fənn seçin.");
                return;
            }

            if (!TryGetCourseInput(out string title, out int credits)) return;

            try
            {
                int rows = _repo.Update(new Course
                {
                    Id = _selectedCourseId,
                    Title = title,
                    Credits = credits
                });

                if (rows == 0)
                    MessageBox.Show("Fənn tapılmadı.");

                ClearInputs();
                LoadCourses();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Kredit və ya əlaqəli məhdudiyyət pozulub (1-10 arası olmalıdır).");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Verilənlər bazası xətası: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == 0)
            {
                MessageBox.Show("Əvvəlcə silmək üçün fənn seçin.");
                return;
            }

            var res = MessageBox.Show("Fənn silinsin?", "Təsdiq",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            try
            {
                int rows = _repo.Delete(_selectedCourseId);
                if (rows == 0)
                    MessageBox.Show("Fənn tapılmadı.");

                ClearInputs();
                LoadCourses();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Bu fənn üzrə qiymətlər var, əvvəlcə onları silin.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Verilənlər bazası xətası: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            _selectedCourseId = 0;
            txtTitle.Clear();
            txtCredits.Clear();
        }
    }
}