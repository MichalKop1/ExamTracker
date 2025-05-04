using DataAcessLayer.Contracts;
using ExamTracker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class RegisterPageUtilities
{
	public EventHandler<string> OnInvalidForm;

	public bool ValidateRegistrationForm(
		IAccountRepository accountRepository,
		string name,
		string surname,
		string login,
		string email,
		string password1,
		string password2)
	{ 
		bool isValid = true;
		int counter = 1;

		StringBuilder sb = new StringBuilder("There was a problem with your form. To resolve the issue: \n\n");
		if (string.IsNullOrEmpty(name))
		{
			sb.Append($"{counter}. Provide your name\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(surname))
		{
			sb.Append($"{counter}. Provide your surname\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(login))
		{
			sb.Append($"{counter}. Provide user name\n");
			counter++;
			isValid = false;
		}
		else if (accountRepository.CheckForLoginDuplicates(login) > 0)
		{
			sb.Append($"{counter}. Login already exists. Use a different one.\n");
			counter++;
			isValid = false;
		}

		var pattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
		if (string.IsNullOrWhiteSpace(email))
		{
			sb.Append($"{counter}. Provide an email\n");
			counter++;
			isValid = false;
		}
		else if (!(Regex.Match(email, pattern).Success)) // implement regex later for email
		{
			sb.Append($"{counter}. Provide a valid email.\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(password1))
		{
			sb.Append($"{counter}. Provide password\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(password2))
		{
			sb.Append($"{counter}. Provide password verification\n");
			counter++;
			isValid = false;
		}
		if (password1 != password2)
		{
			sb.Append($"{counter}. Provide matching passwords\n");
			counter++;
			isValid = false;
		}

		if (!isValid)
		{
			OnInvalidForm?.Invoke(null, sb.ToString());
			//MessageBox.Show(sb.ToString(), "Form validation failed");
		}

		sb.Clear();
		return isValid;
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
