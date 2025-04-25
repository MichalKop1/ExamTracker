using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class MainFormUtilities : IDisposable
{
	private CancellationTokenSource _animationTokenSource;
	public MainFormUtilities()
	{
		this._animationTokenSource = new();
	}

	public void UpdateConfigFileLanguage(string setLang)
	{
		string jsonConfigPath = Path.Join(Directory.GetCurrentDirectory(), "appsettings.json");

		if (File.Exists(jsonConfigPath))
		{
			string jsonString = File.ReadAllText(jsonConfigPath);

			Root? root = JsonSerializer.Deserialize<Root>(jsonString);
			if (root?.settings != null)
			{
				root.settings.AppSettings.Lang = setLang;
				string modifiedJson = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
				File.WriteAllText(jsonConfigPath, modifiedJson);
			}
		}
	}

	public void ChangeLanguage(Button btnLogin, Button btnRegister, Button getStartedButton, Label newsletterLabel)
	{
		if (LanguageHelper.GetLanguage == Language.Polish_Pl)
		{
			btnLogin.Text = "Zaloguj";
			btnRegister.Text = "Zarejestruj";
			newsletterLabel.Text = "Dołącz do naszego newslettera i stań się jednym\n z tysięcy nauczycieli którzy korzystają z Exam Tracker";
			getStartedButton.Text = "Zacznij";
		}
		else if (LanguageHelper.GetLanguage == Language.English_Us)
		{
			btnLogin.Text = "Login";
			btnRegister.Text = "Register";
			newsletterLabel.Text = "Join our newsletter and become one of thousands\r\n              teachers who use Exam Tracker\r\n";
			getStartedButton.Text = "Get started";
		}
	}

	public void OnErrorOccured(string errorMessage)
	{
		MessageBox.Show(errorMessage, "Error occured");
	}

	public async Task AnimateUnderline(Panel underlinePanel, Button targetButton)
	{
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

			underlinePanel.Invoke((MethodInvoker)delegate
			{
				underlinePanel.Location = new Point(nextX, underlinePanel.Location.Y);
				underlinePanel.BackColor = Color.Green;
			});

			await Task.Delay(10).ConfigureAwait(true);
		}
	}

	public void Dispose()
	{
		_animationTokenSource.Dispose();
	}
}
