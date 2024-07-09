using DataAcessLayer.Contracts;
using ExamTracker.UI;
using DataAcessLayer;
using System.Windows.Forms;
using ExamTracker.Helpers;

namespace ExamTracker
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAccountRepository _accountRepository;
        private CancellationTokenSource? _animationTokenSource;
        private readonly ISessionService _sessionService;

        public MainForm(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _accountRepository = accountRepository;
            _sessionService = sessionService;
            ChangeLanguage(LanguageHelper.Lang);
            _accountRepository.OnError += OnErrorOccured;   
        }

        private void ChangeLanguage(string language)
        {
            if (language == "pl_pl")
            {
                btnLogin.Text = "Zaloguj";
                btnRegister.Text = "Zarejestruj";
                newsletterLabel.Text = "Do³¹cz do naszego newslettera i stañ siê jednym z tysiêcy\n        nauczycieli którzy korzystaj¹ z Exam Tracker";
                getStartedButton.Text = "Zacznij";
            }
        }

        private void OnErrorOccured(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error occured");
        }

        private async void AnimateUnderline(Panel underlinePanel, Button targetButton)
        {
            // Cancel any ongoing animation
            _animationTokenSource?.Cancel();
            _animationTokenSource = new CancellationTokenSource();
            var token = _animationTokenSource.Token;

            var targetLocation = new System.Drawing.Point(targetButton.Location.X, underlinePanel.Location.Y);

            while (underlinePanel.Location.X != targetLocation.X)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                int step = 20 * Math.Sign(targetLocation.X - underlinePanel.Location.X);
                int nextX = underlinePanel.Location.X + step;

                if (Math.Abs(targetLocation.X - nextX) < Math.Abs(step))
                {
                    nextX = targetLocation.X;
                }

                underlinePanel.Location = new System.Drawing.Point(nextX, underlinePanel.Location.Y);
                underlinePanel.BackColor = Color.Green;
                await Task.Delay(10);
            }
        }




        private void setLoginPage()
        {
            entryPanel.Controls.Clear();
            LoginControl loginControl = new LoginControl(_serviceProvider, _accountRepository, _sessionService);
            entryPanel.Controls.Add(loginControl);
        }
        private void setRegisterPage()
        {
            entryPanel.Controls.Clear();
            RegisterControl registerControl = new RegisterControl(_accountRepository);
            entryPanel.Controls.Add(registerControl);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AnimateUnderline(panelUnderline, btnLogin);
            setLoginPage();
            
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            AnimateUnderline(panelUnderline, btnRegister);
            setRegisterPage();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logoBox.ImageLocation = "C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\icon.png";
            setLoginPage();
        }
    }
}
