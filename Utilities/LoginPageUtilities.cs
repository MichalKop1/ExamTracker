using ExamTracker.Helpers;

namespace ExamTracker.Utilities;

public class LoginPageUtilities
{
	public void ChangeLanguage(TextBox passwordBox, Button loginButton)
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
}
