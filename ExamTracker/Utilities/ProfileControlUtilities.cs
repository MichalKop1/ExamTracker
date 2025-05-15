using DomainModel.Contracts;
using DomainModel.Helpers;
using ExamTracker.Common;
using ExamTracker.Helpers;
using log4net;

namespace ExamTracker.Utilities;

public class ProfileControlUtilities
{
	private readonly ILog log = LogManager.GetLogger(typeof(ProfileControlUtilities));
	private readonly IMessageService _messageService;

    public ProfileControlUtilities(IMessageService messageService)
    {
        _messageService = messageService;
    }

	public bool ValidateForm(string phoneNumber, string zipCode, string email)
	{
		var localization = LanguageHelper.Localization.ErrorMessages;

		FluentErrors errors = new FluentErrors(localization.FormErrorHeader);

		errors.Parameter(phoneNumber)
			.SatisfyRegex(RegexConstants.VALID_PHONE_NUMBER, localization.PhoneNumberInvalid);

		errors.Parameter(zipCode)
			.SatisfyRegex(RegexConstants.VALID_ZIP_CODE, localization.ZipCodeInvalid);

		errors.Parameter(email)
			.SatisfyRegex(RegexConstants.EMAIL, localization.InvalidEmailError);

		if (errors.HasErrors)
		{
			string currErrors = errors.ToString();

			log.InfoFormat("Form is invalid!\n{0}", currErrors);
			_messageService.ShowError(currErrors);
			return false;
		}

		log.InfoFormat("User validated successfully!\n");
		return true;
	}
}
