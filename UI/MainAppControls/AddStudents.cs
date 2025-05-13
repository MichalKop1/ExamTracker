using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Helpers;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.Utilities;
using log4net;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamTracker.UI.MainAppControls;

public partial class AddStudents : UserControl
{
    private readonly IStudentRepository _studentRepository;
    private readonly ISessionService _sessionService;
    private readonly ICacheService _cacheService;
    private readonly IMessageService _messageService;

    private AddStudentsUtilities _studentsUtilities;
	private readonly ILog log = LogManager.GetLogger(typeof(AddStudents));


	public AddStudents(IStudentRepository studentRepository, ISessionService sessionService,
        ICacheService cacheService, IMessageService messageService)
    {
        InitializeComponent();
        ChangeLanguage();
        _studentRepository = studentRepository;
        _sessionService = sessionService;
        _cacheService = cacheService;
        _messageService = messageService;
        _studentsUtilities = new(messageService);
    }
    private void ChangeLanguage()
    {
        var locale = LanguageHelper.Localization.AddStudentsPage;

		addStudentLabel.Text = locale.Labels.AddStudentLabel;
		studentNameLabel.Text = locale.Labels.StudentNameLabel;
		studentEmailLabel.Text = locale.Labels.StudentEmailLabel;
		studentEmailTextBox.PlaceholderText = locale.Textboxes.StudentEmailPlaceholder;
		studentAgeLabel.Text = locale.Labels.StudentAgeLabel;
		studentAgeTextBox.PlaceholderText = locale.Textboxes.StudentAgePlaceholder;
		cancelButton.Text = locale.Buttons.CancelButton;
		submitButton.Text = locale.Buttons.SubmitButton;
		submitButton.Size = new System.Drawing.Size(155, 54);
		Grade8RadioButton.Text = locale.RadioButtons.Grade8RadioButton;
		MaturaRadioButton.Text = locale.RadioButtons.MaturaRadioButton;
	}

	private void ClearFields()
    {
        studentNameTextBox.Clear();
        studentEmailTextBox.Clear();
        studentAgeTextBox.Clear();
        Grade8RadioButton.Checked = false;
        MaturaRadioButton.Checked = false;
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
        if (!_studentsUtilities.ValidateForm(studentNameTextBox.Text, studentEmailTextBox.Text,
            studentAgeTextBox.Text, MaturaRadioButton.Checked, Grade8RadioButton.Checked))
        {
            return;
        }

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
