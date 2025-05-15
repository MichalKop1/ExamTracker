using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTrackerTests.TestData;

public static class ProfileControlData
{
	public static IEnumerable<object[]> ValidUserData()// = new List<object[]>()
	{
		yield return new object[] { "000-111-222", "12-390", "testemail@gmail.com", true };
		yield return new object[] { "000-111-999", "56-640", "testemail@hotmail.com", true };
	}

	public static IEnumerable<object[]> InvalidUserData()// = new List<object[]>()
	{
		yield return new object[] { "000-111-222", "1234", "bad-email.com", false };
		yield return new object[] { "000", "90-210", "valid@email.com", false };
		yield return new object[] { "000-111-222", "12-390", "noatsign", false };
	}
}
