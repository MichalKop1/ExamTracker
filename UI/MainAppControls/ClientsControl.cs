using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.CustomControls;
using ExamTracker.ExtensonMethods;

namespace ExamTracker.UI.MainAppControls;

public partial class ClientsControl : UserControl
{
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	public ClientsControl(ISessionService sessionService, IClientRepository clientRepository)
	{
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		InitializeComponent();
		

	}

	private async Task PopulateClientsFlow()
	{
		var userId = _sessionService.CurrentAccount.Id.ToString();
		var clients = await _clientRepository.GetAllClients(userId);

		foreach (Client client in clients)
		{
			ClientControlItem clientItem = new ClientControlItem();
			clientItem.PopulateValues(client.CompanyName, client.CompanyAddress, client.CompanyNip);
			clientItem.RoundCorners(25);
			ClientsFlowPanel.Controls.Add(clientItem);
		}
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		AddClientWindow addClientWindow = new AddClientWindow(_clientRepository, _sessionService);
		addClientWindow.ShowDialog();
	}

	private void ClientsControl_Load(object sender, EventArgs e)
	{
		PopulateClientsFlow();
	}
}
