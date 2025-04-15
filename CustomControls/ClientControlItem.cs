using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}
