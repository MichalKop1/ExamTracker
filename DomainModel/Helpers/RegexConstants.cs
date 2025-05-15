namespace ExamTracker.Common;

public static class RegexConstants
{
	public const string FULL_NAME = "^[a-zA-Z]+ [a-zA-Z]+$";
	
	public const string ARE_NUMBERS_IN_STRING = "^[0-9]+( [0-9]+)?$";
	
	public const string EMAIL = @"^[a-zA-Z0-9]+\.?[a-zA-Z0-9]*@[a-z]+\.[a-z]{2,3}$";
	
	public const string VALID_DATE = "^(?:(?:0?[1-9]|[12]\\d|3[01])/(?:0?[1-9]|1[0-2])|(?:0?[1-9]|1[0-2])/(?:0?[1-9]|[12]\\d|3[01]))/\\d{4}$";

	public const string VALID_PHONE_NUMBER = @"^\+?[0-9\s\-().]{7,20}$";

	public const string VALID_ZIP_CODE = @"^(?:\d{5}(?:-\d{4})?|(?:\d{2}-\d{3}))$";
}
