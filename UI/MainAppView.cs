using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.UI.MainAppControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.UI
{
    public partial class MainAppView : Form
    {
        IStudentRepository _studentRepository;
        IMaturaExamRepository _maturaExamRepository;
        IGrade8ExamRepository _grade8ExamRepository;
        IAccountRepository _accountRepository;
        IEventRepository _eventRepository;
        IInvoiceRepository _invoiceRepository;
        IProductServiceRepository _productServiceRepository;
        ISessionService _sessionService;
        public MainAppView(IStudentRepository studentRepository, IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository, IAccountRepository accountRepository, ISessionService sesionService, IEventRepository eventRepository,
            IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository)
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
        }

        private void ChangeLanguage()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
                dashboardButton.Text = "Panel";
                studentsButton.Text = "Uczniowie";
                scheduleButton.Text = "Plan";
                billingButton.Text = "Opłaty";
                businessButton.Text = "Biznes";
                profileButton.Text = "Profil";
                this.Text = "Exam Tracker   -  Obecnie zalogowany/a: " + _sessionService.CurrentAccount.ContactName;
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
        private void MainAppView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainAppView_Load(object sender, EventArgs e)
        {
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
    }
}
