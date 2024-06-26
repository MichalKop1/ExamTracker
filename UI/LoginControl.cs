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

namespace ExamTracker.UI
{
    public partial class LoginControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private IAccountRepository _accountRepository;
        private readonly ISessionService _sessionService;
        
        public LoginControl(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLanguage(LanguageHelper.Lang);
            _serviceProvider = serviceProvider;
            _accountRepository = accountRepository;
            _sessionService = sessionService;
        }
        private void ChangeLanguage(string language)
        {
            if (language == "pl_pl")
            {
                passwordBox.PlaceholderText = "Hasło";
                loginButton.Text = "Zaloguj";
                loginButton.Size = new System.Drawing.Size(145, 51);
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
