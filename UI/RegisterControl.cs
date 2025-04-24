using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.Utilities;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamTracker.UI;

public partial class RegisterControl : UserControl
{
	private readonly IAccountRepository _accountRepository;
	MainForm mainForm;

	public RegisterControl(MainForm mf, IAccountRepository accountRepository)
	{
		InitializeComponent();
		mainForm = mf;
		mainForm.LanguageChanged += ChangeLanguage;
		ChangeLanguage(LanguageHelper.Lang);
		_accountRepository = accountRepository;
		ValidateRegisterForm.OnInvalidForm += HandleInvalidForm;
	}

	public void HandleInvalidForm(object? o, string errorMessage)
	{
		MessageBox.Show(errorMessage, "Form validation failed");
	}

	private void ChangeLanguage(string language)
	{
		if (language == "pl_pl")
		{
			nameBox.PlaceholderText = "Imię";
			surnameBox.PlaceholderText = "Nazwisko";
			loginBox.PlaceholderText = "Nazwa użytkownika";
			passwordBox1.PlaceholderText = "Hasło";
			passwordBox2.PlaceholderText = "Potwierdź hasło";
			registerButton.Text = "Zarejestruj";
			registerButton.Size = new System.Drawing.Size(190, 61);
		}
		else if (language == "eng_us")
		{
			nameBox.PlaceholderText = "Name";
			surnameBox.PlaceholderText = "Surname";
			surnameBox.PlaceholderText = "User Name";
			passwordBox1.PlaceholderText = "Password";
			passwordBox2.PlaceholderText = "Confirm password";
			registerButton.Text = "Register";
			registerButton.Size = new System.Drawing.Size(190, 61);
		}
	}

	private bool ValidateForm()
	{
		bool isValid = true;
		int counter = 1;

		StringBuilder sb = new StringBuilder("There was a problem with your form. To resolve the issue: \n\n");
		if (string.IsNullOrEmpty(nameBox.Text))
		{
			sb.Append($"{counter}. Provide your name\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(surnameBox.Text))
		{
			sb.Append($"{counter}. Provide your surname\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(loginBox.Text))
		{
			sb.Append($"{counter}. Provide user name\n");
			counter++;
			isValid = false;
		}
		else if (_accountRepository.CheckForLoginDuplicates(loginBox.Text) > 0)
		{
			sb.Append($"{counter}. Login already exists. Use a different one.\n");
			counter++;
			isValid = false;
		}

		var pattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
		if (string.IsNullOrWhiteSpace(emailBox.Text))
		{
			sb.Append($"{counter}. Provide an email\n");
			counter++;
			isValid = false;
		}
		else if (!(Regex.Match(emailBox.Text, pattern).Success)) // implement regex later for email
		{
			sb.Append($"{counter}. Provide a valid email.\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(passwordBox1.Text))
		{
			sb.Append($"{counter}. Provide password\n");
			counter++;
			isValid = false;
		}
		if (string.IsNullOrEmpty(passwordBox2.Text))
		{
			sb.Append($"{counter}. Provide password verification\n");
			counter++;
			isValid = false;
		}
		if (passwordBox1.Text != passwordBox2.Text)
		{
			sb.Append($"{counter}. Provide matching passwords\n");
			counter++;
			isValid = false;
		}

		if (!isValid)
		{
			MessageBox.Show(sb.ToString(), "Form validation failed");
		}

		return isValid;
	}
	private void ClearForm()
	{
		nameBox.Clear();
		surnameBox.Clear();
		loginBox.Clear();
		emailBox.Clear();
		passwordBox1.Clear();
		passwordBox2.Clear();
	}

	private void registerButton_Click(object sender, EventArgs e)
	{
		if (!ValidateRegisterForm.ValidateRegistrationForm(
			_accountRepository,
			nameBox.Text,
			surnameBox.Text,
			loginBox.Text,
			emailBox.Text,
			passwordBox1.Text,
			passwordBox2.Text
			)) return;

		string contactName = (nameBox.Text).Trim() + " " + (surnameBox.Text).Trim();
		string userName = (loginBox.Text).Trim();
		string email = (emailBox.Text).Trim();
		string password = (passwordBox1.Text).Trim();
		string passwordConfirmation = (passwordBox2.Text).Trim();

		if (password == passwordConfirmation)
		{
			Account account = new Account(userName, password, contactName, email);
			_accountRepository.registerAnAccount(account);
			ClearForm();
			MessageBox.Show("You have created an account!", "Registered successfully!");
		}

	}

	private void RegisterControl_Leave(object sender, EventArgs e)
	{
		ValidateRegisterForm.OnInvalidForm -= HandleInvalidForm;
	}
}
