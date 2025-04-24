using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.CustomControls;
using ExamTracker.ExtensonMethods;

namespace ExamTracker.UI.MainAppControls;

public partial class ClientsControl : UserControl
{
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	private List<ClientControlItem> _allClientsItems = new();
	private Client _selectedClient = new();

	public ClientsControl(ISessionService sessionService, IClientRepository clientRepository)
	{
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		InitializeComponent();
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

	private void AssignClient(object? s, Client client)
	{
		_selectedClient = client;
		ClientControlItem clientControlItem = s as ClientControlItem;

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
		AddClientWindow addClientWindow = new AddClientWindow(_clientRepository, _sessionService);
		addClientWindow.UpdateClientList += async () => await PopulateClientsFlow();

		addClientWindow.ShowDialog();
	}

	private void ClientsControl_Load(object sender, EventArgs e)
	{
		PopulateClientsFlow();
	}

	private void UpdateClient(object? s, Client client)
	{
		_clientRepository.UpdateClient(client);

		PopulateClientsFlow();
	}

	private void EditStripButton_Click(object sender, EventArgs e)
	{
		EditClientsInfoWindow editClientsInfoWindow = new(_selectedClient);
		editClientsInfoWindow.ClientUpdated += UpdateClient;

		editClientsInfoWindow.ShowDialog();
	}

	private void DeleteStripButton_Click(object sender, EventArgs e)
	{
		_clientRepository.DeleteClient(_selectedClient);
		ClientsToolStrip.Visible = false;
		PopulateClientsFlow();

		_selectedClient = new Client();
	}

	private void CancelStripButton_Click(object sender, EventArgs e)
	{
		ResetClientsInFlow();

		ClientsToolStrip.Visible = false;
	}
}
