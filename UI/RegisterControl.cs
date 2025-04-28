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
	private readonly RegisterPageUtilities _pageUtilities;

	public RegisterControl(MainForm mf, IAccountRepository accountRepository)
	{
		InitializeComponent();
		_accountRepository = accountRepository;

		_pageUtilities = new RegisterPageUtilities();
		_pageUtilities.OnInvalidForm += HandleInvalidForm;

		_pageUtilities.ChangeLanguage(nameBox, surnameBox, loginBox, passwordBox1, passwordBox2, registerButton);
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
		}
		else if (language == "eng_us")
		{
			nameBox.PlaceholderText = "Name";
			surnameBox.PlaceholderText = "Surname";
			surnameBox.PlaceholderText = "User Name";
			passwordBox1.PlaceholderText = "Password";
			passwordBox2.PlaceholderText = "Confirm password";
			registerButton.Text = "Register";
		}
	}

	private void registerButton_Click(object sender, EventArgs e)
	{
		if (!_pageUtilities.ValidateRegistrationForm(
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

			var boxes = this.Controls.OfType<TextBox>().ToList();
			_pageUtilities.ClerarAllFields(boxes);

			MessageBox.Show("You have created an account!", "Registered successfully!");
		}
	}

	private void RegisterControl_Leave(object sender, EventArgs e)
	{
		
	}
}
