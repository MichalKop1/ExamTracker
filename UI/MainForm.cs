using DataAcessLayer.Contracts;
using ExamTracker.UI;
using ExamTracker.Helpers;
using Microsoft.Extensions.DependencyInjection;
using ExamTracker.Utilities;

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
		private RegisterControl _registerControl;

		public MainForm(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
		{
			InitializeComponent();
			_serviceProvider = serviceProvider;
			_accountRepository = accountRepository;
			_sessionService = sessionService;

			_loginControl = new(_serviceProvider, _accountRepository, _sessionService);
			_registerControl = new(this, _accountRepository);
			entryPanel.Controls.Add(_loginControl);
			entryPanel.Controls.Add(_registerControl);

			_mainFormUtilities = new MainFormUtilities(_serviceProvider);
			_sessionService.Language = LanguageHelper.Lang;
			_languageDict = new Dictionary<int, string>() { { 0, "Polish_Pl" }, { 1, "English_Us" } };

			_accountRepository.OnError += _mainFormUtilities.OnErrorOccurred;
			
			_mainFormUtilities.ChangeLanguage(btnLogin, btnRegister, getStartedButton, newsletterLabel);
		}

		private async void btnLogin_Click(object sender, EventArgs e)
		{
			await _mainFormUtilities.AnimateUnderline(panelUnderline, btnLogin);
			_mainFormUtilities.SetLoginPage(_loginControl, _registerControl);
		}
		private async void btnRegister_Click(object sender, EventArgs e)
		{
			await _mainFormUtilities.AnimateUnderline(panelUnderline, btnRegister);
			_mainFormUtilities.SetRegisterPage(_loginControl, _registerControl);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			logoBox.Image = Properties.Resources.icon;
			_mainFormUtilities.SetLoginPage(_loginControl, _registerControl);

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
			this.Hide();
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
