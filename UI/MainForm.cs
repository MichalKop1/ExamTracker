using DataAcessLayer.Contracts;
using ExamTracker.UI;
using System.Xml.Linq;
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
        private Dictionary<int, string> _languageDict;
        public event Action<string> LanguageChanged = delegate { };

        public MainForm(IServiceProvider serviceProvider, IAccountRepository accountRepository, ISessionService sessionService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _accountRepository = accountRepository;
            _sessionService = sessionService;
            _sessionService.Language = LanguageHelper.Lang;
            _languageDict = new Dictionary<int, string>() { {0, "pl_pl" }, {1, "eng_us" } };
            ChangeLanguage();
            _accountRepository.OnError += OnErrorOccured;
        }

        private void UpdateConfigFileLanguage(string filePath, string setLang)
        {
            XDocument configFile = XDocument.Load(filePath);
            var appSettings = configFile.Descendants("appSettings").FirstOrDefault();
            if (appSettings != null)
            {
                var langElement = appSettings.Elements("add").FirstOrDefault(e => e.Attribute("key")?.Value == "Lang");
                if (langElement != null)
                {
                    langElement.SetAttributeValue("value", setLang);
                    LanguageHelper.Lang = setLang;
                    LanguageChanged?.Invoke(setLang);
                }
            }
            configFile.Save(filePath);
        }
        private void ChangeLanguage()
        {
            // resources.resx can be used for language change
            if (LanguageHelper.Lang == "pl_pl")
            {
                btnLogin.Text = "Zaloguj";
                btnRegister.Text = "Zarejestruj";
                newsletterLabel.Text = "Do³¹cz do naszego newslettera i stañ siê jednym z tysiêcy\n        nauczycieli którzy korzystaj¹ z Exam Tracker";
                getStartedButton.Text = "Zacznij";
            }
            else if (LanguageHelper.Lang == "eng_us")
            {
                btnLogin.Text = "Login";
                btnRegister.Text = "Register";
                newsletterLabel.Text = "Join our newsletter and become one of thousands\r\n              teachers who use Exam Tracker\r\n";
                getStartedButton.Text = "Get started";
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
            LoginControl loginControl = new LoginControl(this,_serviceProvider, _accountRepository, _sessionService);
            entryPanel.Controls.Add(loginControl);
        }
        private void setRegisterPage()
        {
            entryPanel.Controls.Clear();
            RegisterControl registerControl = new RegisterControl(this, _accountRepository);
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
            // must equal: polski (Polish) or angielski (English)
            if (LanguageHelper.Lang == "pl_pl")
            {
                LanguagesComboBox.Text = "polski (Polish)";
            }
            else if (LanguageHelper.Lang == "eng_us")
            {
                LanguagesComboBox.Text = "angielski (English)";
            }
            
        }

        private void LanguagesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SetLanguage = _languageDict[LanguagesComboBox.SelectedIndex];
            UpdateConfigFileLanguage("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\App.config", SetLanguage);
            
            ChangeLanguage();
        }
    }
}
