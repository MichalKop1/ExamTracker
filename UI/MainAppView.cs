using DataAcessLayer.Contracts;
using DomainModel.Models;
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
        ISessionService _sessionService;
        public MainAppView(IStudentRepository studentRepository, IMaturaExamRepository maturaExamRepository, IGrade8ExamRepository grade8ExamRepository, IAccountRepository accountRepository, ISessionService sesionService)
        {
            InitializeComponent();
            _studentRepository = studentRepository;
            _maturaExamRepository = maturaExamRepository;
            _grade8ExamRepository = grade8ExamRepository;
            _accountRepository = accountRepository;
            _sessionService = sesionService;
            ChangeLanguage();
            _studentRepository.OnError += AnErrorHasOccured;
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
            }
        }

        private void AnErrorHasOccured(string errMsg)
        {
            MessageBox.Show(errMsg, "An error occured");
        }

        private void setDashboardControl()
        {
            dataPanel.Controls.Clear();
            AddStudents dashboardControl = new AddStudents(_studentRepository);
            dataPanel.Controls.Add(dashboardControl);
        }
        private void setStudentsControl()
        {
            dataPanel.Controls.Clear();
            StudentsControl studentsControl = new StudentsControl(_studentRepository, _maturaExamRepository, _grade8ExamRepository);
            dataPanel.Controls.Add(studentsControl);
        }
        private void setProfileControl()
        {
            dataPanel.Controls.Clear();
            ProfileControl profileControl = new ProfileControl(_accountRepository, _sessionService);
            dataPanel.Controls.Add(profileControl);
        }


        private void MainAppView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainAppView_Load(object sender, EventArgs e)
        {
            Account currentAccount = _sessionService.CurrentAccount;
            this.Text = "Exam Tracker   -   Currently logged: " + currentAccount.ContactName;
            setProfileControl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setProfileControl();
        }

        private void studentsButton_Click(object sender, EventArgs e)
        {
            setStudentsControl();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            setDashboardControl();
        }
    }
}
