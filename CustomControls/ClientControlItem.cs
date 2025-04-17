namespace ExamTracker.CustomControls;

public partial class ClientControlItem : UserControl
{
	public ClientControlItem()
	{
		InitializeComponent();
	}

	public void PopulateValues(string name, string address, string nip)
	{
		CompanyName.Text = name;
		Address.Text = address;
		Nip.Text = nip;
	}

	private void ClientControlItem_MouseMove(object sender, MouseEventArgs e)
	{
		this.BackColor = Color.Gray;
	}

	private void ClientControlItem_MouseLeave(object sender, EventArgs e)
	{
		this.BackColor = Color.LightSlateGray;
	}

	private void CompanyName_Click(object sender, EventArgs e)
	{

	}

	private void CancelActionButton_Click(object sender, EventArgs e)
	{
		EditClientButton.Visible = false;
		CancelActionButton.Visible = false;
	}

	private void ClientControlItem_Click(object sender, EventArgs e)
	{
		EditClientButton.Visible = true;
		CancelActionButton.Visible = true;
	}

	private void EditClientButton_Click(object sender, EventArgs e)
	{
		
	}
}
