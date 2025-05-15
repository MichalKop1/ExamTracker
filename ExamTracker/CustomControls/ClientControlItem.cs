using DomainModel.Models;
using ExamTracker.UI.MainAppControls;

namespace ExamTracker.CustomControls;

public partial class ClientControlItem : UserControl
{
	public event EventHandler<Client> CurrentClientInfo;
	public Action ToggleToolStrip;
	public bool Clicked { get; set; } = false;
	private Client _currentClient;

	public ClientControlItem(Client client)
	{
		_currentClient = client;
		InitializeComponent();
		PopulateValues();
	}

	private void PopulateValues()
	{
		CompanyName.Text = _currentClient.CompanyName;
		Address.Text = _currentClient.CompanyAddress;
		Nip.Text = _currentClient.CompanyNip;
	}

	public void UpdateClient(Client updatedClient)
	{
		_currentClient = updatedClient;
		PopulateValues();
	}

	private void ClientControlItem_MouseMove(object sender, MouseEventArgs e)
	{
		if (!Clicked)
		{
			this.BackColor = Color.Gray;
		}
		
	}

	private void ClientControlItem_MouseLeave(object sender, EventArgs e)
	{
		if (!Clicked)
		{
			this.BackColor = Color.LightSlateGray;
		}
	}

	private void CompanyName_Click(object sender, EventArgs e)
	{

	}

	private void ClientControlItem_Click(object sender, EventArgs e)
	{
		ToggleToolStrip?.Invoke();
		CurrentClientInfo?.Invoke(sender, _currentClient);
	}

	private void GetUpdatedClient(object? sender, Client e)
	{
		//Client updatedClient = sender as Client;
		//ClientChanged.Invoke(this, updatedClient);
	}
}
