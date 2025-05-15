using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.Utilities;
using log4net;

namespace ExamTracker.UI;

public partial class MainAppView : Form
{
	protected readonly ILog log = LogManager.GetLogger(typeof(MainAppView));

	private readonly IControlFactory _controlFactory;
	private readonly IServiceFactory _serviceFactory;
	private readonly IRepositoryFactory _repositoryFactory;
	private readonly ICacheService _cacheService;

	private readonly MainAppViewUtilities _mainViewUtilities;
	private readonly ISessionService _sessionService;
	private readonly Dictionary<string, Control> _controls;
	private readonly Panel _dataPanel;

	public event EventHandler? LogoutRequested;

	public MainAppView(IControlFactory controlFactory,
		IServiceFactory serviceFactory, IRepositoryFactory repositoryFactory)
	{
		InitializeComponent();

		_controlFactory = controlFactory;
		_controls = new Dictionary<string, Control>();
		_dataPanel = dataPanel;
		_mainViewUtilities = new MainAppViewUtilities(_controlFactory, _controls, _dataPanel);
		_serviceFactory = serviceFactory;
		_repositoryFactory = repositoryFactory;
		_sessionService = _serviceFactory.CreateSessionService();
		_cacheService = _serviceFactory.CreateCacheService();

		var maturaRepo = _repositoryFactory.CreateMaturaExamRepository();
		var grade8Repo = _repositoryFactory.CreateGrade8ExamRepository();
		maturaRepo.OnError += _mainViewUtilities.AnErrorHasOccured;
		grade8Repo.OnError += _mainViewUtilities.AnErrorHasOccured;
	}

	private void ChangeLanguage()
	{
		var locale = LanguageHelper.Localization.MainAppViewPage;

		dashboardButton.Text = locale.Buttons.DashboardButton;
		studentsButton.Text = locale.Buttons.StudentsButton;
		scheduleButton.Text = locale.Buttons.ScheduleButton;
		billingButton.Text = locale.Buttons.BillingButton;
		businessButton.Text = locale.Buttons.BusinessButton;
		profileButton.Text = locale.Buttons.ProfileButton;
		ClientsControlButton.Text = locale.Buttons.ClientsControlButton;
		logoutButton.Text = locale.Buttons.LogoutButton;
		this.Text = string.Format(locale.Labels.FormTitle, _sessionService.CurrentAccount.ContactName);
	}

	private void MainAppView_FormClosed(object sender, FormClosedEventArgs e)
	{
		log.Info("App closed");
		Application.Exit();
	}

	private void MainAppView_Load(object sender, EventArgs e)
	{
		LogoPictureBox.Image = Properties.Resources.icon;

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

		// clear cache
		_cacheService.Clear();
		log.Info($"Chache cleared. Logged out.");
		
		this.Hide();
	}
}
