using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.UI.MainAppControls;
using Microsoft.Extensions.DependencyInjection;

namespace ExamTracker.UI;

public partial class MainAppView : Form
{
	private readonly IStudentRepository _studentRepository;
	private readonly IMaturaExamRepository _maturaExamRepository;
	private readonly IGrade8ExamRepository _grade8ExamRepository;
	private readonly IAccountRepository _accountRepository;
	private readonly IEventRepository _eventRepository;
	private readonly IInvoiceRepository _invoiceRepository;
	private readonly IProductServiceRepository _productServiceRepository;
	private readonly ISessionService _sessionService;
	private readonly IServiceProvider _serviceProvider;
	private readonly IClientRepository _clientRepository;

	public MainAppView(IStudentRepository studentRepository, IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository, IAccountRepository accountRepository, ISessionService sesionService, IEventRepository eventRepository,
		IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository, IServiceProvider serviceProvider, IClientRepository clientRepository)
	{
		InitializeComponent();
		_studentRepository = studentRepository;
		_maturaExamRepository = maturaExamRepository;
		_grade8ExamRepository = grade8ExamRepository;
		_accountRepository = accountRepository;
		_sessionService = sesionService;
		_eventRepository = eventRepository;
		_studentRepository.OnError += AnErrorHasOccured;
		_invoiceRepository = invoiceRepository;
		_productServiceRepository = productServiceRepository;
		_serviceProvider = serviceProvider;
		_clientRepository = clientRepository;
	}

	private void ChangeLanguage()
	{
		// if (LanguageHelper.Lang == "pl_pl")
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

	private void AnErrorHasOccured(string errMsg)
	{
		MessageBox.Show(errMsg, "An error occured");
	}

	private void SetDashboardControl()
	{
		dataPanel.Controls.Clear();
		AddStudents dashboardControl = new AddStudents(_studentRepository, _sessionService);
		dataPanel.Controls.Add(dashboardControl);
	}
	private void SetStudentsControl()
	{
		dataPanel.Controls.Clear();
		StudentsControl studentsControl = new StudentsControl(_studentRepository, _maturaExamRepository, _grade8ExamRepository, _sessionService);
		dataPanel.Controls.Add(studentsControl);
	}
	private void SetProfileControl()
	{
		dataPanel.Controls.Clear();
		ProfileControl profileControl = new ProfileControl(_accountRepository, _sessionService);
		dataPanel.Controls.Add(profileControl);
	}

	private void SetScheduleControl()
	{
		dataPanel.Controls.Clear();
		ScheduleControl scheduleControl = new ScheduleControl(_eventRepository, _sessionService);
		dataPanel.Controls.Add(scheduleControl);
	}

	private void SetBillingControl()
	{
		dataPanel.Controls.Clear();
		BillingControl billingControl = new BillingControl(_invoiceRepository, _productServiceRepository, _sessionService);
		dataPanel.Controls.Add(billingControl);
	}

	private void SetClientsControl()
	{
		dataPanel.Controls.Clear();
		ClientsControl clientsControl = new ClientsControl(_sessionService, _clientRepository);
		dataPanel.Controls.Add(clientsControl);
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
		SetProfileControl();
		ChangeLanguage();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		SetProfileControl();
	}

	private void studentsButton_Click(object sender, EventArgs e)
	{
		SetStudentsControl();
	}

	private void dashboardButton_Click(object sender, EventArgs e)
	{
		SetDashboardControl();
	}

	private void scheduleButton_Click(object sender, EventArgs e)
	{
		SetScheduleControl();
	}

	private void billingButton_Click(object sender, EventArgs e)
	{
		SetBillingControl();
	}

	private void ClientsControlButton_Click(object sender, EventArgs e)
	{
		SetClientsControl();
	}

	private void logoutButton_Click(object sender, EventArgs e)
	{
		_sessionService.CurrentAccount = new Account();
		MainForm mainForm = _serviceProvider.GetService<MainForm>()!;
		mainForm.Show();

		Form? main = this;

		main?.Hide();
	}
}
