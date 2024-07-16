using System;
using DataAcessLayer.Repositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using DataAcessLayer.Contracts;
using ExamTracker.Helpers;

namespace ExamTracker.UI
{
    internal partial class LoginControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private IAccountRepository _accountRepository;
        private readonly ISessionService _sessionService;
        MainForm m;
        public LoginControl(MainForm mf, IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLanguage(LanguageHelper.Lang);
            _serviceProvider = serviceProvider;
            _accountRepository = accountRepository;
            _sessionService = sessionService;
            m = mf;
            m.LanguageChanged += ChangeLanguage;
        }
        internal void ChangeLanguage(string language)
        {
            if (language == "pl_pl")
            {
                passwordBox.PlaceholderText = "Hasło";
                loginButton.Text = "Zaloguj";
                loginButton.Size = new System.Drawing.Size(145, 51);
            }
            else if (language == "eng_us")
            {
                passwordBox.PlaceholderText = "Password";
                loginButton.Text = "Login";
                loginButton.Size = new System.Drawing.Size(121, 51);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string log = loginBox.Text;
            string pass = passwordBox.Text;
            Account account = _accountRepository.logIn(log);
            

            if (account != null && log == account.Login)
            {
                if (pass == account.Password)
                {
                    _sessionService.CurrentAccount = account;
                    MainAppView form = _serviceProvider.GetRequiredService<MainAppView>();
                    form.Show();

                    Form? main = FindForm();
                    if (main != null)
                    {
                        main.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Login is not correct", "Error");
            }

        }
    }
}
