using DataAcessLayer.Contracts;
using DomainModel.Models;
using ExamTracker.CustomControls;
using ExamTracker.UI.MainAppControls;
using log4net;
using ExamTracker.ExtensonMethods;
using DataAcessLayer.Repositories;
using ExamTracker.Helpers;

namespace ExamTracker.Utilities;

public class ClientsControlUtility
{
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	private readonly ICacheService _cacheService;

	protected readonly ILog log = LogManager.GetLogger(typeof(ClientsControl));

	private ToolStrip _toolStrip;
	private Client _selectedClient;

	public ClientsControlUtility(ISessionService sessionService, IClientRepository clientRepository,
		ICacheService cacheService, ToolStrip clientToolStrip)
    {
        _sessionService = sessionService;
		_clientRepository = clientRepository;
		_cacheService = cacheService;

		_toolStrip = clientToolStrip;
    }

	public void ChangeLanguage(Label client, Button addClient,
		ToolStripButton editStrip, ToolStripButton cancelStrip, ToolStripButton deleteStrip)
	{
		var locale = LanguageHelper.Localization.ClientsControlPage;

		client.Text = locale.Labels.ClientsLabel;
		addClient.Text = locale.Buttons.AddClientButton;
		editStrip.Text = locale.Buttons.EditStripButton;
		cancelStrip.Text = locale.Buttons.CancelStripButton;
		deleteStrip.Text = locale.Buttons.DeleteStripButton;
	}

	public Client SelectedClient
	{
		get
		{
			return _selectedClient ?? throw new ArgumentNullException();
		}

		set
		{
			_selectedClient = value;
		}
	}

	public async Task PopulateClientsFlow(FlowLayoutPanel clientFlow)
	{
		clientFlow.Controls.Clear();

		var userId = _sessionService.CurrentAccount.Id.ToString();
		var clients = await _clientRepository.GetAllClients(userId);

		foreach (Client client in clients)
		{
			ClientControlItem clientItem = new ClientControlItem(client);
			clientItem.ToggleToolStrip += ToggleToolBarVisibility;
			clientItem.CurrentClientInfo += AssignClient;
			clientItem.RoundCorners(25);

			clientFlow.Controls.Add(clientItem);

			string key = $"clientControlItem:{_sessionService.CurrentAccount.Id}";
			_cacheService.SetAddToList<ClientControlItem>(clientItem, key, TimeSpan.FromHours(1));

		}
	}

	public void ToggleToolBarVisibility()
	{
		_toolStrip.Visible = true;
	}

	public void AssignClient(object s, Client client)
	{
		_selectedClient = client;
		ClientControlItem clientControlItem = (ClientControlItem)s;

		ResetClientsInFlow();

		clientControlItem.Clicked = true;
		clientControlItem.BackColor = Color.Yellow;
	}

	public void ResetClientsInFlow()
	{
		string key = $"clientControlItem:{_sessionService.CurrentAccount.Id}";
		HashSet<ClientControlItem> clients = _cacheService.Get<HashSet<ClientControlItem>>(key);

		foreach (ClientControlItem item in clients)
		{
			item.BackColor = Color.LightSlateGray;
			item.Clicked = false;
		}
	}
}
