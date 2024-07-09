using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.UI.MainAppControls
{
    public partial class AddStudents : UserControl
    {
        IStudentRepository _studentRepository;
        ISessionService _sessionService;
        public AddStudents(IStudentRepository studentRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLanguage();
            _studentRepository = studentRepository;
            _sessionService = sessionService;
        }
        private void ChangeLanguage()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
                addStudentLabel.Text = "Dodaj ucznia";
                studentNameLabel.Text = "Imię ucznia";
                studentEmailLabel.Text = "Email ucznia";
                studentEmailTextBox.PlaceholderText = "(opcjonalne)";
                studentAgeLabel.Text = "Wiek ucznia";
                studentAgeTextBox.PlaceholderText = "(opcjonalne)";
                cancelButton.Text = "Anuluj";
                submitButton.Text = "Zatwierdź";
                submitButton.Size = new System.Drawing.Size(155,54);
            }
        }
        private void ClearFields()
        {
            studentNameTextBox.Clear();
            studentEmailTextBox.Clear();
            studentAgeTextBox.Clear();
            Grade8RadioButton.Checked = false;
            MaturaRadioButton.Checked = false;
        }

        private bool ValidateForm()
        {
            StringBuilder sb = new StringBuilder("There were some problems with your form. Try:\n\n");
            int counter = 1;
            bool isValid = true;
            string fullNamePattern = "^[a-zA-Z]+ [a-zA-Z]+$";
            string areNumbersInString = "^[0-9]+( [0-9]+)?$";
            if (Regex.Match(studentNameTextBox.Text, areNumbersInString).Success)
            {
                sb.Append($"{counter}. Student name can't be numbers.\n");
                counter++;
                isValid = false;
            }
            if (!Regex.Match(studentNameTextBox.Text, fullNamePattern).Success)
            {
                sb.Append($"{counter}. Add both name and surname of your student.\n");
                counter++;
                isValid = false;
            }
            var emailPattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
            if (!string.IsNullOrWhiteSpace(studentEmailTextBox.Text) && !(Regex.Match(studentEmailTextBox.Text, emailPattern).Success))
            { 
                sb.Append($"{counter}. Provide a valid email.\n");
                counter++;
                isValid = false;
            }
            if (!(int.TryParse(studentAgeTextBox.Text, out _)) && !string.IsNullOrWhiteSpace(studentAgeTextBox.Text))
            {
                sb.Append($"{counter}. Provide a corrent age.\n");
                counter++;
                isValid = false;
            }
            if (!MaturaRadioButton.Checked && !Grade8RadioButton.Checked)
            {
                sb.Append($"{counter}. Check the box with an appriopriate exam type.\n");
                counter++;
                isValid = false;
            }

            if (!isValid) MessageBox.Show(sb.ToString(), "Form not valid");
            
            return isValid;
        }

        private void AddStudents_Load(object sender, EventArgs e)
        {

        }

        private void is8ClassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void isMaturaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string examType = "";
            if (Grade8RadioButton.Checked)
            {
                examType = "Grade8Exams";
            }
            else if (MaturaRadioButton.Checked)
            {
                examType = "MaturaExams";
            }

            string[] fullname = (studentNameTextBox.Text).Split();
            string name = fullname[0];
            string surname = fullname[1];
            string? email = studentEmailTextBox.Text;
            int age;
            int.TryParse(studentAgeTextBox.Text, out age);
            int teacherId = _sessionService.CurrentAccount.Id;
            

            Student student = new Student(name, surname, age,email, examType, teacherId);

            _studentRepository.AddStudentToDB(student);
            ClearFields();
        }
    }
}
