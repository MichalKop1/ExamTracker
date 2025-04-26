using DataAcessLayer.Contracts;
using ExamTracker.UI;
using System.Xml.Linq;
using ExamTracker.Helpers;
using System.Text.Json;
using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using ExamTracker.Utilities;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace ExamTracker
{
	public partial class MainForm : Form
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IAccountRepository _accountRepository;
		private readonly ISessionService _sessionService;
		private Dictionary<int, string> _languageDict;
		private readonly MainFormUtilities _mainFormUtilities;
		private LoginControl _loginControl;

		public MainForm(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_accountRepository = accountRepository;
			_sessionService = sessionService;
			_mainFormUtilities = new MainFormUtilities();
			_sessionService.Language = LanguageHelper.Lang;
			_languageDict = new Dictionary<int, string>() { { 0, "Polish_Pl" }, { 1, "English_Us" } };

			_accountRepository.OnError += _mainFormUtilities.OnErrorOccurred;
			
			_mainFormUtilities.ChangeLanguage(btnLogin, btnRegister, getStartedButton, newsletterLabel);
		}

		private void setLoginPage()
		{
			entryPanel.Controls.Clear();
			LoginControl loginControl = new LoginControl(_serviceProvider, _accountRepository, _sessionService);
			entryPanel.Controls.Add(loginControl);
		}
		private void setRegisterPage()
		{
			entryPanel.Controls.Clear();
			RegisterControl registerControl = new RegisterControl(this, _accountRepository);
			entryPanel.Controls.Add(registerControl);
		}

		private async void btnLogin_Click(object sender, EventArgs e)
		{
			await _mainFormUtilities.AnimateUnderline(panelUnderline, btnLogin);
			setLoginPage();

		}
		private async void btnRegister_Click(object sender, EventArgs e)
		{
			await _mainFormUtilities.AnimateUnderline(panelUnderline, btnRegister);
			setRegisterPage();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			logoBox.Image = Properties.Resources.icon;
			setLoginPage();

			if (LanguageHelper.GetLanguage == Language.Polish_Pl)
			{
				LanguagesComboBox.Text = "polski (Polish)";
			}
			else if (LanguageHelper.GetLanguage == Language.English_Us)
			{
				LanguagesComboBox.Text = "angielski (English)";
			}

			_loginControl = entryPanel.Controls.OfType<LoginControl>().First();
			_loginControl.OnLogiIn += ExecuteLogin;
		}

		private void ExecuteLogin()
		{
			MainAppView form = _serviceProvider.GetRequiredService<MainAppView>();
			form.Show();

			Form? main = FindForm();
			if (main != null)
			{
				main.Hide();
			}
		}

		private void LanguagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string SetLanguage = _languageDict[LanguagesComboBox.SelectedIndex];
			Language lang = (Language)Enum.Parse(typeof(Language), SetLanguage);

			_mainFormUtilities.UpdateConfigFileLanguage(lang);

			_mainFormUtilities.ChangeLanguage(btnLogin, btnRegister, getStartedButton, newsletterLabel);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
