using DataAcessLayer.Contracts;
using ExamTracker.CustomControls;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamTracker.Helpers;

namespace ExamTracker.UI.MainAppControls
{
    public partial class ScheduleControl : UserControl
    {
        public event EventHandler OneEventClicked;
        private readonly IEventRepository _eventRepository;
        private readonly ISessionService _sessionService;
        private List<Event> _eventToLoad;
        int EventType = 0;

        private ScheduledWorkControlItem _selectedItem;
        public ScheduleControl(IEventRepository eventRepository, ISessionService sessionService)
        {
            InitializeComponent();
            ChangeLanguage();
            _eventRepository = eventRepository;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.AutoScroll = true;
            _sessionService = sessionService;
            _eventToLoad = [];
        }

        private void ChangeLanguage()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
                AddEventButton.Text = "Dodaj wydarzenie";
                ExamRadioButton.Text = "Egzamin";
                MeetingRadioButton.Text = "Spotkanie";
                ShortDescTextBox.PlaceholderText = "Nazwa wydarzenia";

            }
            else if (LanguageHelper.Lang == "eng_us")
            {
                AddEventButton.Text = "Add event";
                ExamRadioButton.Text = "Exam";
                MeetingRadioButton.Text = "Meeting";
                ShortDescTextBox.PlaceholderText = "Event name";
            }
        }

        private void ClearAllFields()
        {
            ShortDescTextBox.Clear();
            LongDescTextBox.Clear();
            ExamRadioButton.Checked = false;
            MeetingRadioButton.Checked = false;
        }

        private bool VerifyInformation()
        {
            int counter = 1;
            StringBuilder sb = new StringBuilder("There was an issue with your form. Try:\n");
            bool isValid = true;

            if (string.IsNullOrEmpty(ShortDescTextBox.Text))
            {
                sb.Append($"{counter}. You have to give a name to your event.\n");
                counter++;
                isValid = false;
            }
            if(!ExamRadioButton.Checked && !MeetingRadioButton.Checked)
            {
                sb.Append($"{counter}. Select type of event.");
                counter++;
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(sb.ToString(), "Form not valid!");
            }
            return isValid;
        }

        private async void LoadEventsToList()
        {
            _eventToLoad = await _eventRepository.GetAllEvents(_sessionService.CurrentAccount.Id);
            foreach (var ev in _eventToLoad)
            {
                AddEventToPanel(ev);
            }
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            if (!VerifyInformation()) return;

            string shortDesc = ShortDescTextBox.Text;
            string longDesc = LongDescTextBox.Text;
            DateTime dt = Calendar.SelectionStart.Date;
            Event _event = new Event(EventType, longDesc, shortDesc, dt, _sessionService.CurrentAccount.Id);
            ScheduledWorkControlItem item = new ScheduledWorkControlItem(_event);    
            AddEventToPanel(_event);
            _eventRepository.AddEventToDB(_event);
            ClearAllFields();
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
            ScheduledWorkControlItem item = sender as ScheduledWorkControlItem;
            if (item != null)
            {
                item.BackColor = Color.Red;
            }
        }

        private void ScheduledWorkControlItem_MouseHasLeft(object? sender, EventArgs e)
        {
            ScheduledWorkControlItem item = sender as ScheduledWorkControlItem;
            
            if (item != null && !item.isSelected && !item.isPastDueDate)
            {
                item.BackColor = Color.White;
            }
        }

        private void ScheduledWorkControlItem_MouseHasEntered(object? sender, EventArgs e)
        {
            ScheduledWorkControlItem item = sender as ScheduledWorkControlItem;

            if(item != null && !item.isSelected && !item.isPastDueDate)
            {
                item.BackColor = Color.Silver;
            }
        }

        private void ScheduledWorkControlItem_Clicked(object? sender, EventArgs e)
        {
            ScheduledWorkControlItem item = sender as ScheduledWorkControlItem;

            if (item != null)
            {
                if (_selectedItem != null && _selectedItem != item)
                {
                    _selectedItem.isSelected = false;
                    _selectedItem.HideButtons();
                    if(_selectedItem.isPastDueDate)
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
            ScheduledWorkControlItem item = sender as ScheduledWorkControlItem;
            if (item != null)
            {
                //flowLayoutPanel.Controls.Remove(item);
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
}
