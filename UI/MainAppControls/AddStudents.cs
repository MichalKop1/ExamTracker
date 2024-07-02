using DataAcessLayer.Contracts;
using DomainModel.Models;
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
        public AddStudents(IStudentRepository studentRepository)
        {
            InitializeComponent();
            ChangeLanguage();
            _studentRepository = studentRepository;
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
            is8ClassCheckBox.Checked = false;
            isMaturaCheckBox.Checked = false;
        }

        private bool ValidateForm()
        {
            int counter = 1;
            StringBuilder sb = new StringBuilder("There were some problems with your form. Try:\n\n");
            bool isValid = true;
            string[] fullName = (studentNameTextBox.Text).Split();

            if (fullName.Length < 2)
            {
                sb.Append($"{counter}. Add both name and surname of your student.\n");
                counter++;
                isValid = false;
            }
            var pattern = @"/[a-zA-Z0-9]+\.?[a-zA-Z0-9]*\@[a-z]+\.[a-z]{2,3}/g";
            if (!string.IsNullOrWhiteSpace(studentEmailTextBox.Text) && !(Regex.Match(studentEmailTextBox.Text, pattern).Success)) // implement regex later for email
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
            if (!isMaturaCheckBox.Checked && !is8ClassCheckBox.Checked)
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
            isMaturaCheckBox.Enabled = !(isMaturaCheckBox.Enabled);
        }

        private void isMaturaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            is8ClassCheckBox.Enabled = !(is8ClassCheckBox.Enabled);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string examType = "";
            if (is8ClassCheckBox.Checked)
            {
                examType = "Grade8Exams";
            }
            else if (isMaturaCheckBox.Checked)
            {
                examType = "MaturaExams";
            }

            string[] fullname = (studentNameTextBox.Text).Split();
            string name = fullname[0];
            string surname = fullname[1];
            string? email = studentEmailTextBox.Text;
            int age;
            int.TryParse(studentAgeTextBox.Text, out age);
            
            

            Student student = new Student(name, surname, age,email, examType);

            _studentRepository.AddStudentToDB(student);
            ClearFields();
        }
    }
}
