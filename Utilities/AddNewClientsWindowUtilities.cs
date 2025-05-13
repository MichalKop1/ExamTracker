using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Helpers;
using DomainModel.Models;
using ExamTracker.Helpers;
using ExamTracker.UI.MainAppControls;
using log4net;
using System.Text;

namespace ExamTracker.Utilities;

public class AddNewClientsWindowUtilities
{
	private readonly ILog log = LogManager.GetLogger(typeof(AddNewClientsWindowUtilities));

	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	private readonly IMessageService _messageService;

	public AddNewClientsWindowUtilities(ISessionService sessionService, IClientRepository clientRepository,
		IMessageService messageService)
	{
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		_messageService = messageService;
	}

	public void ChangeLanguage(TextBox companyName, TextBox nip, TextBox address1, TextBox address2, Button addButton, Button cancelButton)
	{
		var locale = LanguageHelper.Localization.AddNewClientsWindow;

		companyName.PlaceholderText = locale.Labels.CompanyNameLabel;
		nip.PlaceholderText = locale.Labels.NipLabel;
		address1.PlaceholderText = locale.Labels.Address1Label;
		address2.PlaceholderText = locale.Labels.Address2Label;
		addButton.Text = locale.Buttons.AddButton;
		cancelButton.Text = locale.Buttons.CancelButton;
	}

	public void ClearAllFields(List<TextBox> boxes)
	{
		boxes.ForEach(box => box.Clear());
	}

	public void CreateClient(string companyName, string companyAddress1, string companyAddress2, string companyNip)
	{
		var uniqueId = _sessionService.CurrentAccount.Id.ToString();

		Client client = new Client(
			companyName,
			string.Concat(companyAddress1, companyAddress2),
			companyNip,
			uniqueId);

		_clientRepository.AddClient(client);
	}

	public bool ValidateForm(string companyName, string nip, string address1, string address2)
	{
		var localization = LanguageHelper.Localization.ErrorMessages;
		FluentErrors _errors = new FluentErrors(localization.FormErrorHeader);

		_errors.Parameter(companyName)
			.IsNullOrEmptyString(localization.CompanyNameEmpty);

		_errors.Parameter(nip)
			.IsNullOrEmptyString(localization.TaxNumberEmpty);

		_errors.Parameter(address1)
			.IsNullOrEmptyString(localization.CompanyAddressEmpty);

		if (_errors.HasErrors)
		{
			string currErrors = _errors.ToString();

			_messageService.ShowError(currErrors);
			log.ErrorFormat("Form invalid:\n{0}", currErrors);

			return false;
		}

		log.InfoFormat("Form validation successful!\nAdded a new client:\n{0}", companyName);
		return true;
	}
}
