using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.Helpers;

namespace ExamTracker.Utilities;

public class AddNewClientsWindowUtilities
{
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;

	public AddNewClientsWindowUtilities(ISessionService sessionService, IClientRepository clientRepository)
	{
		_sessionService = sessionService;
		_clientRepository = clientRepository;
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
}
