using DataAcessLayer.Contracts;
using DomainModel.Models;
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
    public partial class ProfileControl : UserControl
    {
        IAccountRepository _accountRepository;
        ISessionService _sessionService;
        public ProfileControl(IAccountRepository accountRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLangueage();
            _accountRepository = accountRepository;
            _sessionService = sessionService;
        }

        private void ChangeLangueage()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
                profileLabel.Text = "Profil";
                manageInfoLabel.Text = "Zarzadzaj informacjami o profilu";
                businessInfoLabel.Text = "Informacje biznesowe";
                businesNameLabel.Text = "Nazwa firmy";
                BusinessNameBox.PlaceholderText = "Nazwa twojego biznesu";
                streetAdressLabel.Text = "Nazwa ulicy";
                cityLabel.Text = "Miasto";
                CityTextBox.PlaceholderText = "Warszawa";
                stateLabel.Text = "Województwo";
                StateTextBox.PlaceholderText = "Wielkopolska";
                zipCodeLabel.Text = "Kod pocztowy";
                ZipCodeTextBox.PlaceholderText = "00-019";
                contactInfoLabel.Text = "Informacje kontaktowe";
                contactNameLabel.Text = "Imię i nazwisko";
                ContactNameTextBox.PlaceholderText = "Jan Kowalski";
                EmailTextBox.PlaceholderText = "jan@gmail.com";
                phoneLabel.Text = "Telefon";
                PhoneTextBox.PlaceholderText = "430-255-670";
                saveChangesButton.Text = "Zapisz";
            }
        }
        private void ClearAllFields()
        {
            BusinessNameBox.Clear();
            StreetAddressRichTextBox.Clear();
            CityTextBox.Clear();
            StateTextBox.Clear();
            ZipCodeTextBox.Clear();
            ContactNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();
        }
        private void LoadCurrentUser()
        {
            string businesName = BusinessNameBox.Text;
            string streetAddress = StreetAddressRichTextBox.Text;
            string city = CityTextBox.Text;
            string state = StateTextBox.Text;
            string zipCode = ZipCodeTextBox.Text;
            string contactInfo = ContactNameTextBox.Text;
            string email = EmailTextBox.Text;
            string phone = PhoneTextBox.Text;
            Account account = new Account(_sessionService.CurrentAccount.Id, businesName, streetAddress, city, state, zipCode, contactInfo, email, phone);

            _accountRepository.updateAnAccount(account);
            ClearAllFields();


        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {

        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            LoadCurrentUser();
        }
    }
}
