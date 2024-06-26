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
    public partial class RegisterControl : UserControl
    {
        private readonly IAccountRepository _accountRepository;
        public RegisterControl(IAccountRepository accountRepository)
        {
            InitializeComponent();
            ChangeLanguage(LanguageHelper.Lang);
            _accountRepository = accountRepository;
        }
        private void ChangeLanguage(string language)
        {
            if (language == "pl_pl")
            {
                nameBox.PlaceholderText = "Imię";
                surnameBox.PlaceholderText = "Nazwisko";
                surnameBox.PlaceholderText = "Nazwa użytkownika";
                passwordBox1.PlaceholderText = "Hasło";
                passwordBox2.PlaceholderText = "Potwierdź hasło";
                registerButton.Text = "Zarejestruj";
                registerButton.Size = new System.Drawing.Size(190, 61);
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            int counter = 1;

            StringBuilder sb = new StringBuilder("There was a problem with your form. To resolve the issue: \n\n");
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                sb.Append($"{counter}. Provide your name\n");
                counter++;
                isValid = false;
            }
            if (string.IsNullOrEmpty(surnameBox.Text))
            {
                sb.Append($"{counter}. Provide your surname\n");
                counter++;
                isValid = false;
            }
            if (string.IsNullOrEmpty(loginBox.Text))
            {
                sb.Append($"{counter}. Provide user name\n");
                counter++;
                isValid = false;
            }
            if (string.IsNullOrEmpty(emailBox.Text))
            {
                sb.Append($"{counter}. Provide email\n");
                counter++;
                isValid = false;
            }
            if (string.IsNullOrEmpty(passwordBox1.Text))
            {
                sb.Append($"{counter}. Provide password\n");
                counter++;
                isValid = false;
            }
            if (string.IsNullOrEmpty(passwordBox2.Text))
            {
                sb.Append($"{counter}. Provide password verification\n");
                counter++;
                isValid = false;
            }
            if (passwordBox1.Text != passwordBox2.Text)
            {
                sb.Append($"{counter}. Provide matching passwords\n");
                counter++;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(sb.ToString(), "Form validation failed");
            }

            return isValid;
        }
        private void ClearForm()
        {
            nameBox.Clear();
            surnameBox.Clear();
            loginBox.Clear();
            emailBox.Clear();
            passwordBox1.Clear();
            passwordBox2.Clear();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string contactName = (nameBox.Text).Trim() + " " + (surnameBox.Text).Trim();
            string userName = (loginBox.Text).Trim();
            string email = (emailBox.Text).Trim();
            string password = (passwordBox1.Text).Trim();
            string passwordConfirmation = (passwordBox2.Text).Trim();

            if (password == passwordConfirmation)
            {
                Account account = new Account(userName, password, email, contactName);
                _accountRepository.registerAnAccount(account);
                ClearForm();
                MessageBox.Show("You have created an account!", "Registered successfully!");
            }
            
        }
    }
}
