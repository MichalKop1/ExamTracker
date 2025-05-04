using ExamTracker.Helpers;


namespace ExamTracker.Utilities;

public class LoginPageUtilities
{
	public void ChangeLanguage(TextBox loginBox, TextBox passwordBox, Button loginButton)
	{
		var locale = LanguageHelper.Localization;

		loginBox.PlaceholderText = locale.LoginControlPage.Textboxes.LoginPlaceholder;
		passwordBox.PlaceholderText = locale.LoginControlPage.Textboxes.PasswordPlaceholder;
		loginButton.Text = locale.LoginControlPage.Buttons.LoginButton;
		loginButton.Size = new System.Drawing.Size(145, 51);
	}
}
