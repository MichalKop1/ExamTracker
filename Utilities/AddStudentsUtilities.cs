using ExamTracker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class AddStudentsUtilities
{
	public void ClearFields(TextBox name, TextBox email, TextBox age,
		RadioButton grade8, RadioButton matura)
	{
		name.Clear();
		email.Clear();
		age.Clear();
		grade8.Checked = false;
		matura.Checked = false;
	}

	//private bool ValidateForm()
	//{
	//	StringBuilder sb = new StringBuilder();
	//	int counter = 1;
	//	bool isValid = true;
	//	string fullNamePattern = "^[a-zA-Z]+ [a-zA-Z]+$";
	//	string areNumbersInString = "^[0-9]+( [0-9]+)?$";
	//	Language lang = LanguageHelper.GetLanguage;

	//	if (lang == Language.Polish_Pl)
	//	{
	//		sb.Append("Wystąpił problem z twoim formularzem. Spróbuj:\n\n");
	//	}
	//	else if (lang == Language.English_Us)
	//	{
	//		sb.Append("There were some problems with your form. Try:\n\n");
	//	}

	//	if (Regex.Match(studentNameTextBox.Text, areNumbersInString).Success)
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			sb.Append($"{counter}. W imieniu ucznia nie mogą pojawić się liczby.\n");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			sb.Append($"{counter}. Student name can't be numbers.\n");
	//		}
	//		counter++;
	//		isValid = false;
	//	}
	//	if (!Regex.Match(studentNameTextBox.Text, fullNamePattern).Success)
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			sb.Append($"{counter}. Podaj imię i nazwisko ucznia.\n");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			sb.Append($"{counter}. Add both name and surname of your student.\n");
	//		}
	//		counter++;
	//		isValid = false;
	//	}
	//	var emailPattern = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
	//	if (!string.IsNullOrWhiteSpace(studentEmailTextBox.Text) && !(Regex.Match(studentEmailTextBox.Text, emailPattern).Success))
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			sb.Append($"{counter}. Wprowadź poprawny email.\n");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			sb.Append($"{counter}. Provide a valid email.\n");
	//		}
	//		counter++;
	//		isValid = false;
	//	}
	//	if (!(int.TryParse(studentAgeTextBox.Text, out _)) && !string.IsNullOrWhiteSpace(studentAgeTextBox.Text))
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			sb.Append($"{counter}. Wprowadź poprawny wiek.\n");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			sb.Append($"{counter}. Provide a corrent age.\n");
	//		}
	//		counter++;
	//		isValid = false;
	//	}
	//	if (!MaturaRadioButton.Checked && !Grade8RadioButton.Checked)
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			sb.Append($"{counter}. Zaznacz odpowiedni egzamin.\n");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			sb.Append($"{counter}. Check the box with an appriopriate exam type.\n");
	//		}
	//		counter++;
	//		isValid = false;
	//	}

	//	if (!isValid)
	//	{
	//		if (lang == Language.Polish_Pl)
	//		{
	//			MessageBox.Show(sb.ToString(), "Formularz nie jest poprawny");
	//		}
	//		else if (lang == Language.English_Us)
	//		{
	//			MessageBox.Show(sb.ToString(), "Form not valid");
	//		}
	//	}
	//	return isValid;
	//}



}
