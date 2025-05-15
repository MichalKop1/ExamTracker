using DomainModel.Contracts;
using DomainModel.Helpers;
using ExamTracker.Helpers;
using ExamTracker.Common;
using log4net;
using System.Text;


namespace ExamTracker.Utilities;

public class AddStudentsUtilities
{
	private readonly ILog log = LogManager.GetLogger(typeof(AddStudentsUtilities));

	private readonly IMessageService _messageService;

    public AddStudentsUtilities(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void ClearFields(TextBox name, TextBox email, TextBox age,
		RadioButton grade8, RadioButton matura)
	{
		name.Clear();
		email.Clear();
		age.Clear();
		grade8.Checked = false;
		matura.Checked = false;
	}

	public bool ValidateForm(string name, string email, string age, bool isMaturaChecked, bool isGrade8Checked)
	{
		var _localization = LanguageHelper.Localization.ErrorMessages;
		FluentErrors _errors = new(_localization.FormErrorHeader);

		int thisAge = -1;
		int minimumAge = 10;
		int maximumAge = 30;

		_errors.Parameter(name)
		.IsNullOrEmptyString(_localization.StudentNameIsEmptyError)
			.SatisfyRegex(RegexConstants.FULL_NAME, _localization.StudentNameIsNotFullError);

		_errors.Parameter(email).IsNullOrEmptyString(_localization.EmailIsEmptyError)
			.SatisfyRegex(RegexConstants.EMAIL, _localization.InvalidEmailError);

		_errors.Parameter(age)
			.IsNullOrEmptyString(_localization.AgeIsEmptyError)
			.SatysfiesCondition(() => int.TryParse(age, out thisAge), _localization.InvalidAgeNotNumber)
			.SatysfiesCondition(() => (thisAge > minimumAge && thisAge < maximumAge), _localization.InvalidAge);
		_errors
			.SatysfiesCondition(() => isMaturaChecked != isGrade8Checked, _localization.StudentExamTypeNotChecked);

		if (_errors.HasErrors)
		{
			string currError = _errors.ToString()!;

			log.InfoFormat("Validation failed:\n{0}", currError);
			_messageService.ShowError(currError);

			return false;
		}


		log.InfoFormat("Validation successful.\n{0} added!", name);
		return true;
	}
}
