using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.Utilities;

namespace ExamTracker.UI;

public partial class MainAppView : Form
{
	private readonly IControlFactory _controlFactory;
	private readonly IServiceFactory _serviceFactory;
	private readonly IRepositoryFactory _repositoryFactory;
	private readonly ICacheService _cacheService;

	private readonly MainForm _mainForm;
	private readonly MainAppViewUtilities _mainViewUtilities;
	private readonly ISessionService _sessionService;
	private readonly Dictionary<string, Control> _controls;
	private readonly Panel _dataPanel;

	public event EventHandler? LogoutRequested;

	public MainAppView(MainForm mainForm, IControlFactory controlFactory,
		IServiceFactory serviceFactory, IRepositoryFactory repositoryFactory)
	{
		InitializeComponent();

		_controlFactory = controlFactory;
		_controls = new Dictionary<string, Control>();
		_dataPanel = dataPanel;
		_mainViewUtilities = new MainAppViewUtilities(_controlFactory, _controls, _dataPanel);
		_serviceFactory = serviceFactory;
		_repositoryFactory = repositoryFactory;
		_mainForm = mainForm;
		_sessionService = _serviceFactory.CreateSessionService();
		_cacheService = _serviceFactory.CreateCacheService();

		var maturaRepo = _repositoryFactory.CreateMaturaExamRepository();
		var grade8Repo = _repositoryFactory.CreateGrade8ExamRepository();
		maturaRepo.OnError += _mainViewUtilities.AnErrorHasOccured;
		grade8Repo.OnError += _mainViewUtilities.AnErrorHasOccured;
	}

	private void ChangeLanguage()
	{
		if (LanguageHelper.GetLanguage == Language.Polish_Pl)
		{
			dashboardButton.Text = "Panel";
			studentsButton.Text = "Uczniowie";
			scheduleButton.Text = "Plan";
			billingButton.Text = "Opłaty";
			businessButton.Text = "Biznes";
			profileButton.Text = "Profil";
			ClientsControlButton.Text = "Klienci";
			logoutButton.Text = "Wyloguj";
			this.Text = "Exam Tracker   -  Obecnie zalogowany/a: " + _sessionService.CurrentAccount.ContactName;
		}
		else if (LanguageHelper.GetLanguage == Language.English_Us)
		{
			dashboardButton.Text = "Dashboard";
			studentsButton.Text = "Students";
			scheduleButton.Text = "Schedule";
			billingButton.Text = "Billing";
			businessButton.Text = "Business";
			profileButton.Text = "Profile";
			ClientsControlButton.Text = "Clients";
			logoutButton.Text = "Log out";
			this.Text = "Exam Tracker   -  Currently logged in: " + _sessionService.CurrentAccount.ContactName;
		}
	}

	private void MainAppView_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
	}

	private void MainAppView_Load(object sender, EventArgs e)
	{
		LogoPictureBox.Image = Properties.Resources.icon;
		Account currentAccount = _sessionService.CurrentAccount;
		this.Text = "Exam Tracker   -   Currently logged: " + currentAccount.ContactName;
		_mainViewUtilities.SetProfileControl();
		ChangeLanguage();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetProfileControl();
	}

	private void studentsButton_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetStudentsControl();
	}

	private void dashboardButton_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetDashboardControl();
	}

	private void scheduleButton_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetScheduleControl();
	}

	private void billingButton_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetBillingControl();
	}

	private void ClientsControlButton_Click(object sender, EventArgs e)
	{
		_mainViewUtilities.SetClientsControl();
	}

	private void logoutButton_Click(object sender, EventArgs e)
	{
		_sessionService.CurrentAccount = new Account();
		LogoutRequested?.Invoke(this, EventArgs.Empty);
		
		this.Hide();
	}
}
