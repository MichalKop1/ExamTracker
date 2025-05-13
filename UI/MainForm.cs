using DataAcessLayer.Contracts;
using ExamTracker.UI;
using ExamTracker.Helpers;
using ExamTracker.Utilities;
using DomainModel.Contracts;
using ExamTracker.Factories;
using log4net;
using log4net.Config;

namespace ExamTracker;

public partial class MainForm : Form
{
	protected readonly ILog log = LogManager.GetLogger(typeof(MainForm));


	private readonly IServiceFactory _serviceFactory;
	private readonly IRepositoryFactory _repositoryFactory;
	private readonly IMessageService _messageService;
	private readonly ISessionService _sessionService;
	private readonly ICacheService _cacheService;
	private readonly IAccountRepository _accountRepository;
	private readonly IFormFactory _formFactory;

	private Dictionary<int, string> _languageDict;
	private readonly MainFormUtilities _mainFormUtilities;

	private LoginControl _loginControl;
	private RegisterControl _registerControl;

	public MainForm(IServiceFactory serviceFactory, IRepositoryFactory repositoryFactory, 
		IControlFactory controlFactory,IFormFactory formFactory,
		MainFormUtilities mainFormUtilities, ICacheService cacheService, IMessageService messageService)
	{
		InitializeComponent();
		_serviceFactory = serviceFactory;
		_repositoryFactory = repositoryFactory;
		_cacheService = cacheService;
		_formFactory = formFactory;
		_mainFormUtilities = mainFormUtilities;
		_messageService = messageService;

		_sessionService = _serviceFactory.CreateSessionService();
		_accountRepository = _repositoryFactory.CreateAccountRepository();

		_loginControl = new(_accountRepository, _sessionService);
		_registerControl = new(this, _accountRepository, _messageService);
		entryPanel.Controls.Add(_loginControl);
		entryPanel.Controls.Add(_registerControl);

		//_sessionService.Language = LanguageHelper.Lang;
		_languageDict = new Dictionary<int, string>() { { 0, "Polish_Pl" }, { 1, "English_Us" } };

		_accountRepository.OnError += _mainFormUtilities.OnErrorOccurred;
		_mainFormUtilities.ChangeLanguage(btnLogin, btnRegister, getStartedButton, newsletterLabel);
	}

	private async void btnLogin_Click(object sender, EventArgs e)
	{
		log.Info($"Navigating to: sender");
		await _mainFormUtilities.AnimateUnderline(panelUnderline, btnLogin);
		_mainFormUtilities.SetLoginPage(_loginControl, _registerControl);
	}

	private async void btnRegister_Click(object sender, EventArgs e)
	{
		log.Info($"Navigating to: {sender}");
		await _mainFormUtilities.AnimateUnderline(panelUnderline, btnRegister);
		_mainFormUtilities.SetRegisterPage(_loginControl, _registerControl);
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		log.Info($"{sender.ToString()} ExamTracker started. \nLanguage set to: {LanguageHelper.GetLanguage.ToString()}");

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

	public void ExecuteLogin()
	{
		MainAppView form = _formFactory.CreateMainAppView();
		form.LogoutRequested += (s, e) => this.Show();
		form.Show();
		this.Hide();
		log.Info("Login successful");
	}

	private void LanguagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		string SetLanguage = _languageDict[LanguagesComboBox.SelectedIndex];

		log.Info($"Changed language to: {SetLanguage}");

		Language lang = (Language)Enum.Parse(typeof(Language), SetLanguage);

		_mainFormUtilities.UpdateConfigFileLanguage(lang);
		LanguageHelper.LoadLocalization();

		_mainFormUtilities.ChangeLanguage(btnLogin, btnRegister, getStartedButton, newsletterLabel);
		_loginControl.ChangeLanguage();
		_registerControl.ChangeLanguage();
	}

	private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		log.Info($"{sender.ToString()} app quit.");
		Application.Exit();
	}
}
