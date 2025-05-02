using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using DomainModel.Models;
using ExamTracker.CustomControls;
using ExamTracker.ExtensonMethods;
using ExamTracker.Utilities;
using log4net;

namespace ExamTracker.UI.MainAppControls;

public partial class ClientsControl : UserControl
{
	protected readonly ILog log = LogManager.GetLogger(typeof(ClientsControl));

	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;

	private List<ClientControlItem> _allClientsItems = new();
	private Client _selectedClient = new();

	public ClientsControl(ISessionService sessionService, IClientRepository clientRepository)
	{
		InitializeComponent();
		_sessionService = sessionService;
		_clientRepository = clientRepository;
	}

	private async Task PopulateClientsFlow()
	{
		ClientsFlowPanel.Controls.Clear();

		var userId = _sessionService.CurrentAccount.Id.ToString();
		var clients = await _clientRepository.GetAllClients(userId);

		foreach (Client client in clients)
		{
			ClientControlItem clientItem = new ClientControlItem(client);
			clientItem.ToggleToolStrip += ToggleToolBarVisibility;
			clientItem.CurrentClientInfo += AssignClient;
			clientItem.RoundCorners(25);

			ClientsFlowPanel.Controls.Add(clientItem);
			_allClientsItems.Add(clientItem);
		}
	}

	private void ToggleToolBarVisibility()
	{
		ClientsToolStrip.Visible = true;
	}

	private void AssignClient(object s, Client client)
	{
		_selectedClient = client;
		ClientControlItem clientControlItem = (ClientControlItem)s;

		ResetClientsInFlow();

		clientControlItem.Clicked = true;
		clientControlItem.BackColor = Color.Yellow;
	}

	private void ResetClientsInFlow()
	{
		_allClientsItems.ForEach(item =>
		{
			item.BackColor = Color.LightSlateGray;
			item.Clicked = false;
		});
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		AddClientWindow addClientWindow = new AddClientWindow(_sessionService, _clientRepository);
		addClientWindow.UpdateClientList += async () => await PopulateClientsFlow();

		addClientWindow.ShowDialog();
	}

	private async void ClientsControl_Load(object sender, EventArgs e)
	{
		await PopulateClientsFlow();
	}

	private async void UpdateClient(object? s, Client client)
	{
		await _clientRepository.UpdateClient(client);

		await PopulateClientsFlow();

		log.Info($"Client updated to: {client.CompanyName}");
	}

	private void EditStripButton_Click(object sender, EventArgs e)
	{
		EditClientsInfoWindow editClientsInfoWindow = new(_selectedClient);
		editClientsInfoWindow.ClientUpdated += UpdateClient;

		editClientsInfoWindow.ShowDialog();
	}

	private async void DeleteStripButton_Click(object sender, EventArgs e)
	{
		await _clientRepository.DeleteClient(_selectedClient);
		ClientsToolStrip.Visible = false;
		await PopulateClientsFlow();

		log.Info($"{_selectedClient.CompanyName} was deleted.");

		_selectedClient = new Client();
	}

	private void CancelStripButton_Click(object sender, EventArgs e)
	{
		ResetClientsInFlow();

		ClientsToolStrip.Visible = false;
	}
}
