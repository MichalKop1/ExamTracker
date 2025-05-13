using DataAcessLayer.Contracts;
using ExamTracker.CustomControls;
using DomainModel.Models;
using ExamTracker.Helpers;
using System.Text;
using log4net;
using DomainModel.Contracts;
using ExamTracker.Utilities;

namespace ExamTracker.UI.MainAppControls;

public partial class ScheduleControl : UserControl
{
	protected readonly ILog log = LogManager.GetLogger(typeof(ScheduleControl));

	public event EventHandler OneEventClicked;
    private readonly IEventRepository _eventRepository;
    private readonly ISessionService _sessionService;
    private readonly IMessageService _messageService;

    private List<Event> _eventToLoad;
    private ScheduleControlUtilities _utilities;
    int EventType = 0;

    private ScheduledWorkControlItem _selectedItem;
    public ScheduleControl(IEventRepository eventRepository, ISessionService sessionService,
        IMessageService messageService)
    {
        InitializeComponent();
        ChangeLanguage();
        _eventRepository = eventRepository;
        flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel.AutoScroll = true;
        _sessionService = sessionService;
        _eventToLoad = [];
        _messageService = messageService;
        _utilities = new(_messageService);
    }

    private void ChangeLanguage()
    {
		var locale = LanguageHelper.Localization.ScheduleControlPage;

		AddEventButton.Text = locale.Buttons.AddEventButton;
		ExamRadioButton.Text = locale.RadioButtons.ExamRadioButton;
		MeetingRadioButton.Text = locale.RadioButtons.MeetingRadioButton;
		ShortDescTextBox.PlaceholderText = locale.Textboxes.ShortDescriptionTextBox;
		currScheduleLabel.Text = locale.Labels.CurrentScheduleLabel;
	}

	private void ClearAllFields()
    {
        ShortDescTextBox.Clear();
        LongDescTextBox.Clear();
        ExamRadioButton.Checked = false;
        MeetingRadioButton.Checked = false;
    }

    private async Task LoadEventsToList()
    {
        _eventToLoad = await _eventRepository.GetAllEvents(_sessionService.CurrentAccount.Id);
        foreach (var ev in _eventToLoad)
        {
            AddEventToPanel(ev);
        }
    }

    private void AddEventButton_Click(object sender, EventArgs e)
    {
        if (!_utilities.ValidateForm(ShortDescTextBox.Text, ExamRadioButton.Checked,
            MeetingRadioButton.Checked, Calendar)) return;

        string shortDesc = ShortDescTextBox.Text;
        string longDesc = LongDescTextBox.Text;
        DateTime dt = Calendar.SelectionStart.Date;
        Event _event = new Event(EventType, longDesc, shortDesc, dt, _sessionService.CurrentAccount.Id);
        
        AddEventToPanel(_event);
        _eventRepository.AddEventToDB(_event);
        ClearAllFields();

        log.Info($"Event: {EventType} added.");
    }

    private void AddEventToPanel(Event _event)
    {
        ScheduledWorkControlItem item = new ScheduledWorkControlItem(_event);
        item.Clicked += ScheduledWorkControlItem_Clicked;
        item.MouseHasEntered += ScheduledWorkControlItem_MouseHasEntered;
        item.MouseHasLeft += ScheduledWorkControlItem_MouseHasLeft;
        item.RemoveRequested += ScheduledWorkControlItem_RemoveRequested;
        item.DueDatePassed += ScheduledWorkControlItem_DateHasPassed;
        flowLayoutPanel.Controls.Add(item);   
    }

    private void ScheduledWorkControlItem_DateHasPassed(object? sender, EventArgs e)
    {
			if (sender is ScheduledWorkControlItem item)
			{
				item.BackColor = Color.Red;
			}
		}

    private void ScheduledWorkControlItem_MouseHasLeft(object? sender, EventArgs e)
    {
			if (sender is ScheduledWorkControlItem item && !item.isSelected && !item.isPastDueDate)
			{
				item.BackColor = Color.White;
			}
		}

    private void ScheduledWorkControlItem_MouseHasEntered(object? sender, EventArgs e)
    {
			if (sender is ScheduledWorkControlItem item && !item.isSelected && !item.isPastDueDate)
			{
				item.BackColor = Color.Silver;
			}
		}

    private void ScheduledWorkControlItem_Clicked(object? sender, EventArgs e)
    {
			if (sender is ScheduledWorkControlItem item)
			{
				if (_selectedItem != null && _selectedItem != item)
				{
					_selectedItem.isSelected = false;
					_selectedItem.HideButtons();

					if (_selectedItem.isPastDueDate)
					{
						_selectedItem.BackColor = Color.Red;
					}
					else
					{
						_selectedItem.BackColor = Color.White;
					}
				}

				_selectedItem = item;
				_selectedItem.BackColor = Color.Yellow;
				_selectedItem.isSelected = true;
				_selectedItem.ShowButtons();
			}
		}

    private void ScheduledWorkControlItem_RemoveRequested(object sender, int e)
    {
			if (sender is ScheduledWorkControlItem item)
			{
				_eventRepository.DeleteEvent(e);
				item.Dispose();
			}
		}
    
    private void ExamRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        EventType = 1;
    }

    private void MeetingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        EventType = 2;
    }

    private void toolTip1_Popup(object sender, PopupEventArgs e)
    {

    }

    private void ScheduleControl_Load(object sender, EventArgs e)
    {
        LoadEventsToList();
    }
}
