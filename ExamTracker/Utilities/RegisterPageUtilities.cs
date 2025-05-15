using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Helpers;
using ExamTracker.Common;
using ExamTracker.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class RegisterPageUtilities
{
	private readonly ILog log = LogManager.GetLogger(typeof(RegisterPageUtilities));
	public EventHandler<string> OnInvalidForm;

	private readonly IAccountRepository _accountRepository;
	private readonly IMessageService _messageService;

    public RegisterPageUtilities(IAccountRepository accountRepository, IMessageService messageService)
    {
        _accountRepository = accountRepository;
		_messageService = messageService;
    }

    public bool ValidateRegistrationForm(
		string name,
		string surname,
		string login,
		string email,
		string password1,
		string password2)
	{
		var localization = LanguageHelper.Localization.ErrorMessages;
		FluentErrors errors = new FluentErrors(localization.FormErrorHeader);

		errors.Parameter(name)
			.IsNullOrEmptyString(localization.UserNameEmpty);//add errors

		errors.Parameter(surname)
			.IsNullOrEmptyString(localization.UserNameEmpty);

		errors.Parameter(email)
			.IsNullOrEmptyString(localization.EmailIsEmptyError)
			.SatisfyRegex(RegexConstants.EMAIL, localization.InvalidEmailError);

		errors.Parameter(login)
			.IsNullOrEmptyString(localization.UserNameEmpty)
			.SatysfiesCondition(() => _accountRepository.CheckForLoginDuplicates(login) > 0, localization.InvalidEmailError);

		errors.Parameter(password1)
			.IsNullOrEmptyString(localization.AgeIsEmptyError);

		errors.Parameter(password2)
			.IsNullOrEmptyString(localization.FormErrorHeader);

		errors.SatysfiesCondition(() => password1 == password2, localization.AgeIsEmptyError);

		if (errors.HasErrors)
		{
			string currErrors = errors.ToString();

			_messageService.ShowError(currErrors);
			log.ErrorFormat("Form invalid:\n{0}", currErrors);

			return false;
		}

		log.ErrorFormat("Created user {0} {1}", name, surname);
		return true;
	}

	public void ChangeLanguage(TextBox nameBox, TextBox surnameBox,
		TextBox loginBox, TextBox passwordBox1,
		TextBox passwordBox2, Button registerButton)
	{
		var locale = LanguageHelper.Localization.RegisterControlPage;

		nameBox.PlaceholderText = locale.Textboxes.NamePlaceholder;
		surnameBox.PlaceholderText = locale.Textboxes.SurnamePlaceholder;
		loginBox.PlaceholderText = locale.Textboxes.LoginPlaceholder;
		passwordBox1.PlaceholderText = locale.Textboxes.Password1Placeholder;
		passwordBox2.PlaceholderText = locale.Textboxes.Password2Placeholder;
		registerButton.Text = locale.Buttons.RegisterButton;

	}

	public void ClerarAllFields(List<TextBox> boxes)
	{
		boxes.ForEach(box => box.Clear());
	}

}
