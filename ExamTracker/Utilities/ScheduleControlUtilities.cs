using DomainModel.Contracts;
using DomainModel.Helpers;
using ExamTracker.Helpers;
using log4net;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamTracker.Utilities;

public class ScheduleControlUtilities
{
	protected readonly ILog log = LogManager.GetLogger(typeof(ScheduleControlUtilities));

	private readonly IMessageService _messageService;

    public ScheduleControlUtilities(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public bool ValidateForm(string eventName, bool examChecked, bool meetingChecked, MonthCalendar calendar)
    {
        var localization = LanguageHelper.Localization.ErrorMessages;
        FluentErrors errors = new FluentErrors(localization.FormErrorHeader);

        errors.Parameter(eventName)
            .IsNullOrEmptyString(localization.NoEventNameError);

        errors.SatysfiesCondition(() => examChecked != meetingChecked, localization.EventTypeNotSelected);

        errors.SatysfiesCondition(() => calendar.SelectionStart.Date.ToString() != string.Empty, localization.DateOfSaleMissingError);// add error

        if (errors.HasErrors)
        {
			string currErrors = errors.ToString();

			_messageService.ShowError(currErrors);
			log.ErrorFormat("Form invalid:\n{0}", currErrors);

			return false;
		}

        log.InfoFormat("Event {0} scheduled!", eventName);

        return true;
    }

}
