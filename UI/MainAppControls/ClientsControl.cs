using DataAcessLayer.Contracts;
using DataAcessLayer.Repositories;
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
	private readonly ICacheService _cacheService;
	private readonly IMessageService _messageService;

	private ClientsControlUtility _clientsUtility;

	public ClientsControl(ISessionService sessionService, IClientRepository clientRepository,
		ICacheService cacheService, IMessageService messageService)
	{
		InitializeComponent();
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		_cacheService = cacheService;
		_messageService = messageService;

		_clientsUtility = new(_sessionService, _clientRepository, _cacheService, ClientsToolStrip);
		
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		AddClientWindow addClientWindow = new AddClientWindow(_sessionService, _clientRepository, _messageService);
		addClientWindow.UpdateClientList += async () => await _clientsUtility.PopulateClientsFlow(ClientsFlowPanel);
		
		_clientsUtility.ResetClientsInFlow();
		ClientsToolStrip.Visible = false;
		_clientsUtility.SelectedClient = new Client();

		addClientWindow.ShowDialog();
	}

	private async void ClientsControl_Load(object sender, EventArgs e)
	{
		await _clientsUtility.PopulateClientsFlow(ClientsFlowPanel);
		_clientsUtility.ChangeLanguage(ClientsLabel, AddClientButton, EditStripButton, CancelStripButton, DeleteStripButton);
	}

	private async void UpdateClient(object? s, Client client)
	{
		await _clientRepository.UpdateClient(client);

		await _clientsUtility.PopulateClientsFlow(ClientsFlowPanel);

		log.InfoFormat("Client updated to: {0}", client.CompanyName);
	}

	private void EditStripButton_Click(object sender, EventArgs e)
	{
		EditClientsInfoWindow editClientsInfoWindow = new(_clientsUtility.SelectedClient);
		editClientsInfoWindow.ClientUpdated += UpdateClient;

		editClientsInfoWindow.ShowDialog();
	}

	private async void DeleteStripButton_Click(object sender, EventArgs e)
	{
		await _clientRepository.DeleteClient(_clientsUtility.SelectedClient);

		string key = $"clientControlitem:{_sessionService.CurrentAccount.Id}";
		_cacheService.SetRemoveFromList(_clientsUtility.SelectedClient, key, TimeSpan.FromHours(1));


		ClientsToolStrip.Visible = false;
		await _clientsUtility.PopulateClientsFlow(ClientsFlowPanel);

		log.Info($"{_clientsUtility.SelectedClient.CompanyName} was deleted.");

		_clientsUtility.SelectedClient = new Client();
	}

	private void CancelStripButton_Click(object sender, EventArgs e)
	{
		_clientsUtility.ResetClientsInFlow();
		_clientsUtility.SelectedClient = new Client();

		ClientsToolStrip.Visible = false;
	}
}
