namespace ExamTracker.Common;

public static class RegexConstants
{
	public const string FULL_NAME = "^[a-zA-Z]+ [a-zA-Z]+$";
	
	public const string ARE_NUMBERS_IN_STRING = "^[0-9]+( [0-9]+)?$";
	
	public const string EMAIL = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
}
