using DomainModel.Models;
using DataAcessLayer.Contracts;
using ExamTracker.Utilities;
using ExamTracker.Helpers;

namespace ExamTracker.UI;

public partial class LoginControl : UserControl
{
    private IAccountRepository _accountRepository;
    private readonly ISessionService _sessionService;
    private LoginPageUtilities _loginPageUtilities;
    public Action OnLogiIn;

    public LoginControl(IAccountRepository accountRepository, ISessionService sessionService)
    {
        InitializeComponent();
		_loginPageUtilities = new LoginPageUtilities();
		_loginPageUtilities.ChangeLanguage(loginBox, passwordBox, loginButton);
        _accountRepository = accountRepository;
        _sessionService = sessionService;
    }

	public void ChangeLanguage()
	{
		var locale = LanguageHelper.Localization;

		loginBox.PlaceholderText = locale.LoginControlPage.Textboxes.LoginPlaceholder;
		passwordBox.PlaceholderText = locale.LoginControlPage.Textboxes.PasswordPlaceholder;
		loginButton.Text = locale.LoginControlPage.Buttons.LoginButton;
		loginButton.Size = new System.Drawing.Size(145, 51);
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
                loginBox.Clear();
                passwordBox.Clear();
            }
        }
        else
        {
            MessageBox.Show("Login is not correct", "Error");
        }

    }
}
