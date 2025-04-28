using DataAcessLayer.Contracts;
using DomainModel.Models;

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
