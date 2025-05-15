using DomainModel.Models;

namespace ExamTracker.UI.MainAppControls;

public partial class EditClientsInfoWindow : Form
{
	public event EventHandler<Client> ClientUpdated;
	private readonly Client _originalClient;

	public EditClientsInfoWindow(Client originalClient)
	{
		InitializeComponent();

		_originalClient = originalClient;
		LoadClientData();
	}

	private void LoadClientData()
	{
		CompanysNameTextBox.PlaceholderText = _originalClient.CompanyName;
		CompanysAddressTextBox1.PlaceholderText = _originalClient.CompanyAddress;
		CompanysNipTextBox.PlaceholderText = _originalClient.CompanyNip;
	}

	private void UpdateClientButton_Click(object sender, EventArgs e)
	{
		var updatedClient = new Client
		{
			Id = _originalClient.Id,
			CompanyName = CompanysNameTextBox.Text ?? _originalClient.CompanyName,
			CompanyAddress = $"{CompanysAddressTextBox1.Text} {CompanysAddressTextBox2.Text}" ?? _originalClient.CompanyAddress,
			CompanyNip = CompanysNipTextBox.Text ?? _originalClient.CompanyNip,
		};

		ClientUpdated?.Invoke(this, updatedClient);
		DialogResult = DialogResult.OK;
	}

	private void EditClientsInfoWindow_Load(object sender, EventArgs e)
	{
		
	}
}
