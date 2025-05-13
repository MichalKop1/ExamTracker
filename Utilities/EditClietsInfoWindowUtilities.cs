using DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class EditClietsInfoWindowUtilities
{
	private readonly IMessageService _messageService;

	public EditClietsInfoWindowUtilities(IMessageService messageService)
	{
		_messageService = messageService;
	}

	public bool ValidatePage()
	{
		return true;
	}
}
