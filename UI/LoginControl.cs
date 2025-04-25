using DomainModel.Models;
using Microsoft.Extensions.DependencyInjection;
using DataAcessLayer.Contracts;
using ExamTracker.Helpers;

namespace ExamTracker.UI;

internal partial class LoginControl : UserControl
{
    private readonly IServiceProvider _serviceProvider;
    private IAccountRepository _accountRepository;
    private readonly ISessionService _sessionService;
    public Action OnLogiIn;

    public LoginControl(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
    {
        InitializeComponent();
        ChangeLanguage();
        _serviceProvider = serviceProvider;
        _accountRepository = accountRepository;
        _sessionService = sessionService;
    }
    internal void ChangeLanguage()
    {
        if (LanguageHelper.GetLanguage == Language.Polish_Pl)
        {
            passwordBox.PlaceholderText = "Hasło";
            loginButton.Text = "Zaloguj";
            loginButton.Size = new System.Drawing.Size(145, 51);
        }
        else if (LanguageHelper.GetLanguage == Language.English_Us)
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
                OnLogiIn?.Invoke();
            }
        }
        else
        {
            MessageBox.Show("Login is not correct", "Error");
        }

    }
}
