using DataAcessLayer.Contracts;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.UI.MainAppControls
{
    public partial class StudentsControl : UserControl
    {
        IStudentRepository _studentRepository;
        IMaturaExamRepository _maturaExamRepository;
        IGrade8ExamRepository _grade8ExamRepository;
        private List<Student> _students;
        private int _student_id;
        private Student _selectedStudent;
        public StudentsControl(IStudentRepository studentRepository, IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository)
        {
            InitializeComponent();
            _students = [];
            _selectedStudent = new Student();
            _studentRepository = studentRepository;
            _maturaExamRepository = maturaExamRepository;
            _grade8ExamRepository = grade8ExamRepository;
        }

        private List<TextBox> getMaturaTextBoxes()
        {
            List<TextBox> exercises = new List<TextBox> { ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10 };
            return exercises;
        }
        private List<TextBox> get8ClassTextBoxes()
        {
            List<TextBox> exercises = new List<TextBox> { ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ex11, ex12, ex13, ex14 };
            return exercises;
        }

        private async void LoadAllStudentToList()
        {
            _students = await _studentRepository.GetAllStudents();
            foreach (Student student in _students)
            {
                studentsComboBox.Items.Add(student.Name + " " + student.Surname);
            }
        }

        private void CustomizeGridAppearance()
        {
            ExamsGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            ExamsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[13];
            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "date", HeaderText = "Date" };
            columns[1] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise1", HeaderText = "Ex. 1" };
            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise2", HeaderText = "Ex. 2" };
            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise3", HeaderText = "Ex. 3" };
            columns[4] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise4", HeaderText = "Ex. 4" };
            columns[5] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise5", HeaderText = "Ex. 5" };
            columns[6] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise6", HeaderText = "Ex. 6" };
            columns[7] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise7", HeaderText = "Ex. 7" };
            columns[8] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise8", HeaderText = "Ex. 8" };
            columns[9] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise9", HeaderText = "Ex. 9" };
            columns[10] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise10", HeaderText = "Ex. 10" };
            columns[11] = new DataGridViewTextBoxColumn() { DataPropertyName = "totalScore", HeaderText = "Total Score" };
            columns[12] = new DataGridViewButtonColumn() { Text = "Edit", Name = "EditBtn", HeaderText = "", UseColumnTextForButtonValue = true };

            ExamsGrid.RowHeadersVisible = false;
            ExamsGrid.Columns.Clear();
            ExamsGrid.Columns.AddRange(columns);
        }

        private async Task RefreshDataInTheGrid()
        {
            ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);
        }

        private void StudentsControl_Load(object sender, EventArgs e)
        {
            LoadAllStudentToList();

        }

        private async void studentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedItem = studentsComboBox.SelectedItem?.ToString();

            // load exam dates here
            foreach (Student student in _students)
            {
                if ((student.Name + " " + student.Surname) != selectedItem)
                {
                    continue;
                }
                _student_id = student.Id;
                _selectedStudent = student;
                break;
            }

            if (_selectedStudent.ExamType == "MaturaExams")
            {
                foreach (TextBox tBox in getMaturaTextBoxes())
                {
                    tBox.Visible = true;
                }
            }
            else if (_selectedStudent.ExamType == "Grade8Exams")
            {
                foreach (TextBox tBox in get8ClassTextBoxes())
                {
                    tBox.Visible = true;
                }
            }
            submitButton.Visible = true;
            CustomizeGridAppearance();
            ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (_selectedStudent.ExamType == "MaturaExams")
            {
                int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text);
                DateTime currDate = DateTime.Now;
                ExamMatura examMatura = new ExamMatura(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), sum);
                await _maturaExamRepository.AddExamToDB(examMatura);
            }
            else if (_selectedStudent.ExamType == "Grade8Exams")
            {
                int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text) + Convert.ToInt32(ex11.Text) + Convert.ToInt32(ex12.Text) + Convert.ToInt32(ex13.Text) + Convert.ToInt32(ex14.Text);
                DateTime currDate = DateTime.Now;
                Exam8Grade exam8Grade = new Exam8Grade(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), Convert.ToInt32(ex11.Text), Convert.ToInt32(ex12.Text), Convert.ToInt32(ex13.Text), Convert.ToInt32(ex14.Text), sum);
                await _grade8ExamRepository.AddExamToDB(exam8Grade);
            }

            foreach (TextBox txt in get8ClassTextBoxes())
            {
                txt.Clear();
            }
            await RefreshDataInTheGrid();
        }

        private void ExamsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ExamsGrid.CurrentCell is DataGridViewButtonCell)
            {

            }
        }
    }
}
