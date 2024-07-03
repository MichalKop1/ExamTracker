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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.UI.MainAppControls
{
    public partial class StudentsControl : UserControl
    {
        IStudentRepository _studentRepository;
        IMaturaExamRepository _maturaExamRepository;
        IGrade8ExamRepository _grade8ExamRepository;
        ISessionService _sessionService;
        private List<Student> _students;
        private int _student_id;
        private Student _selectedStudent;
        public StudentsControl(IStudentRepository studentRepository, IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLanguage(LanguageHelper.Lang);
            _students = [];
            _selectedStudent = new Student();
            _studentRepository = studentRepository;
            _maturaExamRepository = maturaExamRepository;
            _grade8ExamRepository = grade8ExamRepository;
            _sessionService = sessionService;
            _maturaExamRepository.OnError += OnErrorOccured;
            _grade8ExamRepository.OnError += OnErrorOccured;
        }

        private void OnErrorOccured(string errMg)
        {
            MessageBox.Show(errMg, "An error occured");
        }

        private void ChangeLanguage(string language)
        {
            List<TextBox> allBoxes = get8ClassTextBoxes();
            if (language == "pl_pl")
            {
                int allBoxesCount = 14;
                StudentName.Text = "Wyniki egzaminów";
                StudentLabel.Text = "Uczeń";
                for (int i = 0; i < allBoxesCount; i++)
                {
                    allBoxes[i].PlaceholderText = $"Zadanie {i + 1}";
                }
                SubmitButton.Text = "Zatwierdź";
                EditButton.Text = "Edytuj";
                ConfirmButton.Text = "Potwierdź";
                EditStudentAgeBox.PlaceholderText = "Wiek";
                EditStudentNameBox.PlaceholderText = "Imię";
                EditStudentSurnameBox.PlaceholderText = "Nazwisko";

            }
        }
        private bool ValidateEditBoxes()
        {
            int counter = 1;
            bool isValid = true;
            StringBuilder errorMessage = new StringBuilder("There was in issue with your student data. Try:\n");
            if (string.IsNullOrWhiteSpace(EditStudentNameBox.Text))
            {
                errorMessage.Append($"{counter}. Provide student's name.\n");
                isValid = false;
                counter++;
            }
            if (string.IsNullOrWhiteSpace(EditStudentSurnameBox.Text))
            {
                errorMessage.Append($"{counter}. Provide student's surname.\n");
                isValid = false;
                counter++;
            }
            if (!Int16.TryParse(EditStudentAgeBox.Text, out _))
            {
                errorMessage.Append($"{counter}. Provide a number.\n");
                isValid = false;
                counter++;
            }
            else if (Convert.ToInt16(EditStudentAgeBox.Text) < 10)
            {
                errorMessage.Append($"{counter}. Student is too young.\n");
                isValid = false;
                counter++;
            }
            var pattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
            if (!(Regex.Match(EditStudentEmailBox.Text, pattern).Success))
            {
                errorMessage.Append($"{counter}. Provide a valid email.");
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "An error has occured");
            }
            return isValid;
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

        private void ResetExerciseBoxes()
        {
            foreach (TextBox box in get8ClassTextBoxes())
            {
                box.Visible = false;
            }
        }

        private void ShowEditBoxes()
        {
            EditStudentAgeBox.Visible = true;
            EditStudentEmailBox.Visible = true;
            EditStudentNameBox.Visible = true;
            EditStudentSurnameBox.Visible = true;
        }
        private void ResetEditBoxes()
        {
            EditStudentNameBox.Visible = false;
            EditStudentNameBox.Text = string.Empty;
            EditStudentSurnameBox.Visible = false;
            EditStudentSurnameBox.Text= string.Empty;
            EditStudentEmailBox.Visible = false;
            EditStudentEmailBox.Text= string.Empty;
            EditStudentAgeBox.Visible = false;
            EditStudentAgeBox.Text= string.Empty;
        }
        
        private async void LoadAllStudentToList()
        {
            _students = await _studentRepository.GetAllStudents(_sessionService.CurrentAccount.Id);
            foreach (Student student in _students)
            {
                studentsComboBox.Items.Add(student.Name + " " + student.Surname);
            }
        }

        private void CustomizeGridAppearance(bool is8GradeExam)
        {
            ExamsGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            ExamsGrid.AutoGenerateColumns = false;

            DataGridViewColumn[] columns;
            int totalScoreColumnIdx = 11;
            int editBtnColumnIdx = 12;
            int deleteBtnColumnIdx = 13;

            if (!is8GradeExam)
            {
                columns = new DataGridViewColumn[14];
            }
            else
            {
                columns = new DataGridViewColumn[18];
                totalScoreColumnIdx = 15;
                editBtnColumnIdx = 16;
                deleteBtnColumnIdx = 17;
            }
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


            if (is8GradeExam)
            {
                columns[11] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise11", HeaderText = "Ex. 11" };
                columns[12] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise12", HeaderText = "Ex. 12" };
                columns[13] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise13", HeaderText = "Ex. 13" };
                columns[14] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise14", HeaderText = "Ex. 14" };
            }
            columns[totalScoreColumnIdx] = new DataGridViewTextBoxColumn() { DataPropertyName = "totalScore", HeaderText = "Total Score" };
            columns[editBtnColumnIdx] = new DataGridViewButtonColumn() { Text = "Edit", Name = "EditBtn", HeaderText = "", UseColumnTextForButtonValue = true };
            columns[deleteBtnColumnIdx] = new DataGridViewButtonColumn() { Text = "Delete", Name = "DeleteBtn", HeaderText = "", UseColumnTextForButtonValue = true };

            ExamsGrid.RowHeadersVisible = false;
            ExamsGrid.Columns.Clear();
            ExamsGrid.Columns.AddRange(columns);
        }

        private async Task RefreshDataInTheGrid(bool isMatura)
        {
            if (isMatura)
            {
                ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);
            }
            else
            {
                ExamsGrid.DataSource = await _grade8ExamRepository.GetAllExams(_student_id);
            }
        }

        private void StudentsControl_Load(object sender, EventArgs e)
        {
            LoadAllStudentToList();

        }

        private async void studentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetExerciseBoxes();
            ResetEditBoxes();
            string? selectedItem = studentsComboBox.SelectedItem?.ToString();

            // load exam dates here
            foreach (Student student in _students)
            {
                if ((student.Name + " " + student.Surname) == selectedItem)
                {
                    _student_id = student.Id;
                    _selectedStudent = student;
                }
            }

            if (_selectedStudent.ExamType == "MaturaExams")
            {
                foreach (TextBox tBox in getMaturaTextBoxes())
                {
                    tBox.Visible = true;
                }
                CustomizeGridAppearance(false);
                ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);

            }
            else if (_selectedStudent.ExamType == "Grade8Exams")
            {
                foreach (TextBox tBox in get8ClassTextBoxes())
                {
                    tBox.Visible = true;
                }
                CustomizeGridAppearance(true);
                ExamsGrid.DataSource = await _grade8ExamRepository.GetAllExams(_student_id);

            }
            SubmitButton.Visible = true;
            EditButton.Visible = true;

            //ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (_selectedStudent.ExamType == "MaturaExams")
            {
                int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text);
                DateTime currDate = DateTime.Now;
                ExamMatura examMatura = new ExamMatura(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), sum);
                await _maturaExamRepository.AddExamToDB(examMatura);
                await RefreshDataInTheGrid(true);
            }
            else if (_selectedStudent.ExamType == "Grade8Exams")
            {
                int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text) + Convert.ToInt32(ex11.Text) + Convert.ToInt32(ex12.Text) + Convert.ToInt32(ex13.Text) + Convert.ToInt32(ex14.Text);
                DateTime currDate = DateTime.Now;
                Exam8Grade exam8Grade = new Exam8Grade(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), Convert.ToInt32(ex11.Text), Convert.ToInt32(ex12.Text), Convert.ToInt32(ex13.Text), Convert.ToInt32(ex14.Text), sum);
                await _grade8ExamRepository.AddExamToDB(exam8Grade);
                await RefreshDataInTheGrid(false);
            }

            foreach (TextBox txt in get8ClassTextBoxes())
            {
                txt.Clear();
            }

        }

        private async void ExamsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataBoundItem = ExamsGrid.Rows[e.RowIndex].DataBoundItem;

            if (e.RowIndex >= 0 && ExamsGrid.CurrentCell is DataGridViewButtonCell)
            {
                if (dataBoundItem is ExamMatura)
                {
                    ExamMatura clickedExam = (ExamMatura)ExamsGrid.Rows[e.RowIndex].DataBoundItem;

                    if (ExamsGrid.CurrentCell.OwningColumn.Name == "EditBtn")
                    {



                    }

                    else if (ExamsGrid.CurrentCell.OwningColumn.Name == "DeleteBtn")
                    {
                        await _maturaExamRepository.DeleteExam(clickedExam.ExamId);
                        await RefreshDataInTheGrid(true);
                    }
                }

                else if (dataBoundItem is Exam8Grade)
                {
                    Exam8Grade clickedExam = (Exam8Grade)ExamsGrid.Rows[e.RowIndex].DataBoundItem;

                    if (ExamsGrid.CurrentCell.OwningColumn.Name == "EditBtn")
                    {
                        MessageBox.Show("I bet you shat yourself");
                    }
                    else if (ExamsGrid.CurrentCell.OwningColumn.Name == "DeleteBtn")
                    {
                        await _grade8ExamRepository.DeleteExam(clickedExam.ExamId);
                        await RefreshDataInTheGrid(false);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditStudentAgeBox.Text = (_selectedStudent.Age)?.ToString();
            EditStudentEmailBox.Text = _selectedStudent.Email;
            EditStudentNameBox.Text = _selectedStudent.Name;
            EditStudentSurnameBox.Text = _selectedStudent.Surname;
            ShowEditBoxes();
            EditButton.Visible = false;
            ConfirmButton.Visible = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!ValidateEditBoxes())
            {
                return;
            }
            string name = EditStudentNameBox.Text;
            string surname = EditStudentSurnameBox.Text;
            string email = EditStudentEmailBox.Text;
            int age = 0;
            if (!string.IsNullOrWhiteSpace(EditStudentAgeBox.Text))
                {
                    age = Convert.ToInt16(EditStudentAgeBox.Text);
                }
            // if age is 0 the query won't update the age in database
            Student updatedStudent = new Student(name, surname, email, age, _selectedStudent.Id);
            _studentRepository.UpdateStudentInfo(updatedStudent);
            ConfirmButton.Visible = false;
            EditButton.Visible = true;
            ResetEditBoxes();
        }
    }
}

