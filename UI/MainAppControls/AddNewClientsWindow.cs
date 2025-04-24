using DomainModel.Models;
using DataAcessLayer.Contracts;

namespace ExamTracker.UI.MainAppControls;

public partial class AddClientWindow : Form
{
	readonly IClientRepository _clientRepository;
	readonly ISessionService _sessionService;
	public Action UpdateClientList;
	public AddClientWindow(IClientRepository clientRepository, ISessionService sessionService)
	{
		InitializeComponent();
		_clientRepository = clientRepository;
		_sessionService = sessionService;
	}

	private void ClearAllFields()
	{
		CompanysNameTextBox.Clear();
		CompanysAddressTextBox1.Clear();
		CompanysAddressTextBox2.Clear();
		CompanysNipTextBox.Clear();
	}

	private void CreateClient()
	{
		var uniqueId = _sessionService.CurrentAccount.Id.ToString();

		Client client = new Client(
			CompanysNameTextBox.Text,
			string.Concat(CompanysAddressTextBox1.Text, CompanysAddressTextBox2.Text),
			CompanysNipTextBox.Text,
			uniqueId);
		
		_clientRepository.AddClient(client);

		UpdateClientList?.Invoke();

		ClearAllFields();
	}

	private void CancelButton_Click(object sender, EventArgs e)
	{
		this.Close();
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		CreateClient();
		this.Close();
	}
}
