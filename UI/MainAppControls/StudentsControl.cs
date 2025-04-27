using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.Utilities;


namespace ExamTracker.UI.MainAppControls;

public partial class StudentsControl : UserControl
{
	private readonly IServiceProvider _serviceProvider;
	private readonly IServiceFactory _serviceFactory;
	private readonly IRepositoryFactory _repositoryFactory;
	private readonly IStudentRepository _studentRepository;
	private readonly IMaturaExamRepository _maturaExamRepository;
	private readonly IGrade8ExamRepository _grade8ExamRepository;
	private readonly ISessionService _sessionService;
	private StudentsControlUtility _studentsControlUtility;
	private List<TextBox> _editTextBoxes;
	private List<Student> _students;
	private int _student_id;
	private Student _selectedStudent;
	public StudentsControl(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		ChangeLanguage();
		_students = [];
		_selectedStudent = new Student();
		_serviceProvider = serviceProvider;
		_serviceFactory = new ServiceFactory(_serviceProvider);
		_repositoryFactory = new RepositoryFactory(_serviceProvider);
		_studentsControlUtility = new(_serviceProvider);

		_editTextBoxes = this.Controls.OfType<TextBox>()
			.Where(box => box.Name
			.Contains("Edit")).ToList();

		_studentRepository = _repositoryFactory.CreateStudentRepository();
		_maturaExamRepository = _repositoryFactory.CreateMaturaExamRepository();
		_grade8ExamRepository = _repositoryFactory.CreateGrade8ExamRepository();
		_sessionService = _serviceFactory.CreateSessionService();
		_maturaExamRepository.OnError += OnErrorOccured;
		_grade8ExamRepository.OnError += OnErrorOccured;
	}

	private void OnErrorOccured(string errMg)
	{
		MessageBox.Show(errMg, "An error occured");
	}

	private void ChangeLanguage()
	{
		List<TextBox> allBoxes = Get8ClassTextBoxes();
		Language lang = LanguageHelper.GetLanguage;

		if (lang == Language.Polish_Pl)
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
			TableDescLabel.Text = "Tabela egzaminów";
		}
		else if (lang == Language.English_Us)
		{
			int allBoxesCount = 14;
			StudentName.Text = "Exam Results";
			StudentLabel.Text = "Student";
			for (int i = 0; i < allBoxesCount; i++)
			{
				allBoxes[i].PlaceholderText = $"Exercise {i + 1}";
			}
			SubmitButton.Text = "Submit";
			EditButton.Text = "Edit";
			ConfirmButton.Text = "Confirm";
			EditStudentAgeBox.PlaceholderText = "Age";
			EditStudentNameBox.PlaceholderText = "Name";
			EditStudentSurnameBox.PlaceholderText = "Surname";
		}
	}

	private List<TextBox> GetMaturaTextBoxes()
	{
		List<TextBox> exercises = new List<TextBox> { ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10 };
		return exercises;
	}

	private List<TextBox> Get8ClassTextBoxes()
	{
		List<TextBox> exercises = new List<TextBox> { ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ex11, ex12, ex13, ex14 };
		return exercises;
	}

	private async void StudentsControl_Load(object sender, EventArgs e)
	{
		_students = await _studentsControlUtility.LoadAllStudentToList(studentsComboBox);

		_students.ForEach(student =>
		studentsComboBox.Items.Add($"{student.Name} {student.Surname}"));
	}

	private async void studentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		var allBoxes = this.Controls.OfType<TextBox>().ToList();
		_studentsControlUtility.ResetExerciseBoxes(allBoxes);

		_studentsControlUtility.ResetEditBoxes(_editTextBoxes);

		string? selectedItem = studentsComboBox.SelectedItem?.ToString();

		foreach (Student student in _students)
		{
			if ((student.Name + " " + student.Surname) == selectedItem)
			{
				_student_id = student.Id;
				_selectedStudent = student;
				_studentsControlUtility.Student = student;
			}
		}

		if (_selectedStudent.ExamType == "MaturaExams")
		{
			GetMaturaTextBoxes()
				.ForEach(box => box.Visible = true);

			_studentsControlUtility.CustomizeGridAppearance(ExamsGrid, Exam.Matura);
			ExamsGrid.DataSource = await _maturaExamRepository.GetAllExams(_student_id);
		}
		else if (_selectedStudent.ExamType == "Grade8Exams")
		{
			Get8ClassTextBoxes()
				.ForEach(box => box.Visible = true);

			_studentsControlUtility.CustomizeGridAppearance(ExamsGrid, Exam.Grade8th);
			ExamsGrid.DataSource = await _grade8ExamRepository.GetAllExams(_student_id);
		}
		else
		{
			throw new ArgumentException("There was an error with the exam type");
		}

		SubmitButton.Visible = true;
		EditButton.Visible = true;
	}

	private async void submitButton_Click(object sender, EventArgs e)
	{
		if (_selectedStudent.ExamType == "MaturaExams" 
			&& _studentsControlUtility.ValidateMaturaExamPointsBoxes(GetMaturaTextBoxes()))
		{
			int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text);
			DateTime currDate = DateTime.Now;
			ExamMatura examMatura = new ExamMatura(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), sum);
			await _maturaExamRepository.AddExamToDB(examMatura);
			await _studentsControlUtility.RefreshMaturaDataInTheGrid(ExamsGrid);
		}

		else if (_selectedStudent.ExamType == "Grade8Exams" 
			&& _studentsControlUtility.Validate8GradeExamPointsBoxes(Get8ClassTextBoxes()))
		{
			int sum = Convert.ToInt32(ex1.Text) + Convert.ToInt32(ex2.Text) + Convert.ToInt32(ex3.Text) + Convert.ToInt32(ex4.Text) + Convert.ToInt32(ex5.Text) + Convert.ToInt32(ex6.Text) + Convert.ToInt32(ex7.Text) + Convert.ToInt32(ex8.Text) + Convert.ToInt32(ex9.Text) + Convert.ToInt32(ex10.Text) + Convert.ToInt32(ex11.Text) + Convert.ToInt32(ex12.Text) + Convert.ToInt32(ex13.Text) + Convert.ToInt32(ex14.Text);
			DateTime currDate = DateTime.Now;
			Exam8Grade exam8Grade = new Exam8Grade(_selectedStudent.Id, currDate, Convert.ToInt32(ex1.Text), Convert.ToInt32(ex2.Text), Convert.ToInt32(ex3.Text), Convert.ToInt32(ex4.Text), Convert.ToInt32(ex5.Text), Convert.ToInt32(ex6.Text), Convert.ToInt32(ex7.Text), Convert.ToInt32(ex8.Text), Convert.ToInt32(ex9.Text), Convert.ToInt32(ex10.Text), Convert.ToInt32(ex11.Text), Convert.ToInt32(ex12.Text), Convert.ToInt32(ex13.Text), Convert.ToInt32(ex14.Text), sum);
			await _grade8ExamRepository.AddExamToDB(exam8Grade);
			await _studentsControlUtility.RefreshGrade8DataInTheGrid(ExamsGrid);
		}

		var allBoxes = this.Controls.OfType<TextBox>().ToList();
		_studentsControlUtility.ClearAllTextBoxes(allBoxes);
	}

	private async void ExamsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && ExamsGrid.CurrentCell is DataGridViewButtonCell)
		{
			var dataBoundItem = ExamsGrid.Rows[e.RowIndex].DataBoundItem;

			if (dataBoundItem is ExamMatura)
			{
				ExamMatura clickedExam = (ExamMatura)ExamsGrid.Rows[e.RowIndex].DataBoundItem;

				if (ExamsGrid.CurrentCell.OwningColumn.Name == "EditBtn")
				{

					// to be implemented

				}

				else if (ExamsGrid.CurrentCell.OwningColumn.Name == "DeleteBtn")
				{
					await _maturaExamRepository.DeleteExam(clickedExam.ExamId);
					await _studentsControlUtility.RefreshMaturaDataInTheGrid(ExamsGrid);
				}
			}

			else if (dataBoundItem is Exam8Grade)
			{
				Exam8Grade clickedExam = (Exam8Grade)ExamsGrid.Rows[e.RowIndex].DataBoundItem;

				if (ExamsGrid.CurrentCell.OwningColumn.Name == "EditBtn")
				{
					MessageBox.Show("Not implemented yet");
				}

				else if (ExamsGrid.CurrentCell.OwningColumn.Name == "DeleteBtn")
				{
					await _grade8ExamRepository.DeleteExam(clickedExam.ExamId);
					await _studentsControlUtility.RefreshGrade8DataInTheGrid(ExamsGrid);
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

		_studentsControlUtility.ShowEditBoxes(_editTextBoxes);

		EditButton.Visible = false;
		ConfirmButton.Visible = true;
		CancelEditButton.Visible = true;
	}

	private void ConfirmButton_Click(object sender, EventArgs e)
	{
		if (!_studentsControlUtility.ValidateEditBoxes(
			EditStudentNameBox.Text,
			EditStudentSurnameBox.Text,
			EditStudentAgeBox.Text,
			EditStudentEmailBox.Text))
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

		Student updatedStudent = new Student(name, surname, email, age, _selectedStudent.Id);
		_studentRepository.UpdateStudentInfo(updatedStudent);
		ConfirmButton.Visible = false;
		EditButton.Visible = true;

		_studentsControlUtility.ResetEditBoxes(_editTextBoxes);
	}

	private void CancelEditButton_Click(object sender, EventArgs e)
	{
		_studentsControlUtility.ResetEditBoxes(_editTextBoxes);

		ConfirmButton.Visible = false;
		CancelEditButton.Visible = false;
		EditButton.Visible = true;
	}
}

