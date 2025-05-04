using DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class MainAppViewUtilities
{
	private readonly IControlFactory _controlFactory;
	private readonly Dictionary<string, Control> _controls;
	private readonly Panel _dataPanel;

	public MainAppViewUtilities(IControlFactory controlFactory, Dictionary<string, Control> controls, Panel dataPanel)
	{
		_controls = controls;
		_dataPanel = dataPanel;
		_controlFactory = controlFactory;
	}

	public void SetControl(string key, Func<Control> createControl)
	{
		if (!_controls.ContainsKey(key))
		{
			var control = createControl();
			_controls[key] = control;
			_dataPanel.Controls.Add(control);
		}

		foreach (Control control in _dataPanel.Controls)
		{
			control.Visible = control == _controls[key];
		}
	}

	public void SetDashboardControl()
	{
		SetControl("Dashboard", () => _controlFactory.CreateAddStudents());
	}

	public void SetStudentsControl()
	{
		SetControl("Students", () => _controlFactory.CreateStudentsControl());
	}

	public void SetProfileControl()
	{
		SetControl("Profile", () => _controlFactory.CreateProfileControl());
	}

	public void SetScheduleControl()
	{
		SetControl("Schedule", () => _controlFactory.CreateScheduleControl());
	}

	public void SetBillingControl()
	{
		SetControl("Billing", () => _controlFactory.CreateBillingControl());
	}

	public void SetClientsControl()
	{
		SetControl("Clients", () => _controlFactory.CreateClientsControl());
	}

	public void AnErrorHasOccured(string errMsg)
	{
		MessageBox.Show(errMsg, "An error occured");
	}
}
