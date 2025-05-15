using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTrackerTests.TestData;

public static class RegisterFormData
{
	public static IEnumerable<object[]> ValidNewUser()
	{
		yield return new object[] { "samplename", "samplesurname", "samplelogin", "sampleemail@gmail.com", "password1", "password1", true };
		yield return new object[] { "samplename", "samplesurname", "3123125534", "sampleemail@hotmail.com", "12345", "12345", true };
	}

	public static IEnumerable<object[]> InvalidNewUser()
	{
		yield return new object[] { "samplename", "", "samplelogin", "sampleemail@gmail.com", "password1", "password1", false };
		yield return new object[] { "", "usersurname", "samplelogin", "sampleemail@gmail.com", "password1", "password1", false };
		yield return new object[] { "user", "usersurname", "samplelogin", "sampleemail@gmail.com", "abalbalba", "password1", false };
		yield return new object[] { "user", "usersurname", "", "sampleemail@gmail.com", "abalbalba", "password1", false };
		yield return new object[] { "user", "usersurname", "mylogin", "", "abalbalba", "password1", false };
		yield return new object[] { "user", "usersurname", "thelogin", "sampleemail@gmail.com", "", "password1", false };
		yield return new object[] { "user", "usersurname", "loginusmaximus", "sampleemail@gmail.com", "abalbalba", "", false };
		yield return new object[] { "user", "usersurname", "loginusmaximus", "myemail     ", "abalbalba", "", false };
		yield return new object[] { "", "", "", "", "", "", false };
	}
}
