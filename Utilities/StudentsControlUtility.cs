using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamTracker.Utilities;

public class StudentsControlUtility
{
	private readonly IMaturaExamRepository _maturaExamRepository;
	private readonly IGrade8ExamRepository _grade8ExamRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly ISessionService _sessionService;

	public StudentsControlUtility(IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository,
		IStudentRepository studentRepository, ISessionService sessionService)
	{
		_maturaExamRepository = maturaExamRepository;
		_studentRepository = studentRepository;
		_grade8ExamRepository = grade8ExamRepository;
		_sessionService = sessionService;
	}

	public Student Student { get; set; } = new();

	public void ClearAllTextBoxes(List<TextBox> boxes)
	{
		boxes.ForEach(box => box.Clear());
	}

	public void ResetExerciseBoxes(List<TextBox> boxes)
	{
		boxes.ForEach(box => box.Visible = false);
	}

	public void ResetEditBoxes(List<TextBox> editBoxes)
	{
		editBoxes.ForEach(box =>
		{
			box.Visible = false;
			box.Text = string.Empty;
		});
	}

	public void ShowEditBoxes(List<TextBox> editBoxes)
	{
		editBoxes.ForEach(box =>
		{
			box.Visible = true;
		});
	}

	public void OnErrorOccured(string errMg)
	{
		MessageBox.Show(errMg, "An error occured");
	}

	public async Task RefreshMaturaDataInTheGrid(DataGridView table)
	{
		table.DataSource = await _maturaExamRepository.GetAllExams(Student.Id);
	}

	public async Task RefreshGrade8DataInTheGrid(DataGridView table)
	{
		table.DataSource = await _grade8ExamRepository.GetAllExams(Student.Id);
	}

	public void CustomizeGridAppearance(DataGridView table, Exam exam)
	{
		table.AutoSizeColumnsMode =
			DataGridViewAutoSizeColumnsMode.Fill;

		table.AutoGenerateColumns = false;
		table.AllowUserToResizeColumns = false;
		table.AllowUserToResizeRows = false;

		DataGridViewColumn[] columns;
		int totalScoreColumnIdx = 11;
		int editBtnColumnIdx = 12;
		int deleteBtnColumnIdx = 13;

		if (exam == Exam.Matura)
		{
			columns = new DataGridViewColumn[14];
		}
		else if (exam == Exam.Grade8th)
		{
			columns = new DataGridViewColumn[18];
			totalScoreColumnIdx = 15;
			editBtnColumnIdx = 16;
			deleteBtnColumnIdx = 17;
		}
		else
		{
			throw new ArgumentException("There was an error with exams");
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

		if (exam == Exam.Grade8th)
		{
			columns[11] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise11", HeaderText = "Ex. 11" };
			columns[12] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise12", HeaderText = "Ex. 12" };
			columns[13] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise13", HeaderText = "Ex. 13" };
			columns[14] = new DataGridViewTextBoxColumn() { DataPropertyName = "exercise14", HeaderText = "Ex. 14" };
		}

		columns[totalScoreColumnIdx] = new DataGridViewTextBoxColumn() { DataPropertyName = "totalScore", HeaderText = "Total Score" };
		columns[editBtnColumnIdx] = new DataGridViewButtonColumn() { Text = "Edit", Name = "EditBtn", HeaderText = "", UseColumnTextForButtonValue = true };
		columns[deleteBtnColumnIdx] = new DataGridViewButtonColumn() { Text = "Delete", Name = "DeleteBtn", HeaderText = "", UseColumnTextForButtonValue = true };

		table.RowHeadersVisible = false;
		table.Columns.Clear();
		table.Columns.AddRange(columns);
	}

	public async Task<List<Student>> LoadAllStudentToList(ComboBox comboBox)
	{
		var _students = await _studentRepository.GetAllStudents(_sessionService.CurrentAccount.Id);

		return _students;
	}

	public bool ValidateEditBoxes(string name, string surname, string age, string email)
	{
		int counter = 1;
		bool isValid = true;
		StringBuilder errorMessage = new StringBuilder("There was in issue with your student data. Try:\n");

		if (string.IsNullOrWhiteSpace(name))
		{
			errorMessage.Append($"{counter}. Provide student's name.\n");
			isValid = false;
			counter++;
		}

		if (string.IsNullOrWhiteSpace(surname))
		{
			errorMessage.Append($"{counter}. Provide student's surname.\n");
			isValid = false;
			counter++;
		}

		if (!Int16.TryParse(age, out _))
		{
			errorMessage.Append($"{counter}. Provide a number.\n");
			isValid = false;
			counter++;
		}

		else if (Convert.ToInt16(age) < 10)
		{
			errorMessage.Append($"{counter}. Student is too young.\n");
			isValid = false;
			counter++;
		}

		var pattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
		if (!(Regex.Match(email, pattern).Success))
		{
			errorMessage.Append($"{counter}. Provide a valid email.");
		}

		if (!isValid)
		{
			MessageBox.Show(errorMessage.ToString(), "An error has occured");
		}

		return isValid;
	}

	public bool Validate8GradeExamPointsBoxes(List<TextBox> examBoxes)
	{
		StringBuilder errorMessage = new StringBuilder("Invalid input. Try:\n");
		int counter = 1;
		bool isValid = true;

		examBoxes.ForEach(box =>
		{
			if (string.IsNullOrWhiteSpace(box.Text))
			{
				errorMessage.Append($"{counter}. Fill the empty boxes.\n");
				MessageBox.Show(errorMessage.ToString(), "Invalid input");
				isValid = false;
			}
			else if (!int.TryParse(box.Text, out _))
			{
				errorMessage.Append($"{counter}. Use numbers.\n");
				MessageBox.Show(errorMessage.ToString(), "Invalid input");
				isValid = false;
			}});

		return isValid;
	}

	public bool ValidateMaturaExamPointsBoxes(List<TextBox> examBoxes)
	{
		StringBuilder errorMessage = new StringBuilder("Invalid input. Try:\n");
		int counter = 1;
		bool isValid = true;

		examBoxes.ForEach(box =>
		{
			if (string.IsNullOrWhiteSpace(box.Text))
			{
				errorMessage.Append($"{counter}. Fill the empty boxes.\n");
				MessageBox.Show(errorMessage.ToString(), "Invalid input");
				isValid = false;
			}
			else if (!int.TryParse(box.Text, out _))
			{
				errorMessage.Append($"{counter}. Use numbers.\n");
				MessageBox.Show(errorMessage.ToString(), "Invalid input");
				isValid = false;
			}
		});

		return isValid;
	}
}
