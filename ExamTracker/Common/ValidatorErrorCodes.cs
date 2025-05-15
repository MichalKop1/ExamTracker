using ExamTracker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTracker.Common;

public static class ValidatorErrorCodes
{
	public static Dictionary<ErrorCode, KeyValuePair<Language, string>> errorMessage = new Dictionary<ErrorCode, KeyValuePair<Language, string>>();




}

public enum ErrorCode
{
	InvalidName,
	InvalidEmail,
	ContainsNumbers
}
