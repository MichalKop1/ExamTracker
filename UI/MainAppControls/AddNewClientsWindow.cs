using DomainModel.Models;
using DomainModel.Contracts;
using ExamTracker.Utilities;
using DataAcessLayer.Contracts;

namespace ExamTracker.UI.MainAppControls;

public partial class AddClientWindow : Form
{
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;

	private AddNewClientsWindowUtilities _utilities;
	private List<TextBox> textBoxes;
	public Action UpdateClientList;

	public AddClientWindow(ISessionService sessionService, IClientRepository clientRepository)
	{
		InitializeComponent();
		_sessionService = sessionService;
		_clientRepository = clientRepository;

		_utilities = new(_sessionService, _clientRepository);
		textBoxes = this.Controls.OfType<TextBox>().ToList();
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


		_utilities.ClearAllFields(textBoxes);
	}

	private void CancelButton_Click(object sender, EventArgs e)
	{
		this.Close();
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
		_utilities.CreateClient(CompanysNameTextBox.Text, CompanysAddressTextBox1.Text,
			CompanysAddressTextBox2.Text, CompanysNipTextBox.Text);
		_utilities.ClearAllFields(textBoxes);

		UpdateClientList?.Invoke();
		this.Close();
	}
}
