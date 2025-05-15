using ExamTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel.Models;
using ExamTracker.UI.MainAppControls;
using static System.Windows.Forms.AxHost;

namespace ExamTracker.CustomControls
{
    public partial class ScheduledWorkControlItem : UserControl
    {
        // Event type list and their numbers:
        // 0 = Empty
        // 1 = Exam
        // 2 = Meeting
        //-1 = Error
        public event EventHandler Clicked = delegate { };
        public event EventHandler MouseHasEntered = delegate { };
        public event EventHandler MouseHasLeft = delegate { };
        public event EventHandler<int> RemoveRequested = delegate { };
        public event EventHandler DueDatePassed = delegate { };

        public bool isSelected { get; set; }
        public bool isPastDueDate { get; set; }
        Image Image { get; set; }
        string ShortDesc { get; set; }
        string LongDesc { get; set; }
        public DateTime SetDate { get; set; }
        int EventId { get; set; }
        public ScheduledWorkControlItem(Event _event)
        {
            InitializeComponent();
            Image = SetEventImage(_event.EventType);
            ShortDesc = _event.ShortDesc;
            LongDesc = _event.LongDesc;
            SetDate = _event.EventDate;
            isPastDueDate = PastDueDate();
            EventInfoLabel.Text = ShortDesc;
            DateLabel.Text = SetDate.ToString("dd/MM/yyyy");
            pictureBox.Image = Image;
            toolTip1.SetToolTip(this, LongDesc);
            toolTip1.SetToolTip(EventInfoLabel, LongDesc);
            EventId = _event.EventId;
        }

        private Image SetEventImage(int eventType)
        {
            Image img;
            if (eventType == 1)
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\exam.jpg");
            }
            else if (eventType == 2)
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\meeting.jpg");
            }
            else
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\exam.jpg");
            }
            return img;
        }
        public void ShowButtons()
        {
            XMarkButton.Visible = true;
            TickMarkButton.Visible = true;
        }
        public void HideButtons()
        {
            XMarkButton.Visible = false;
            TickMarkButton.Visible = false;
        }
        private bool PastDueDate()
        {
            if (DateTime.Now > SetDate)
            {
                DueDatePassed?.Invoke(this, new EventArgs());
                return true;
            }
            return false;
        }

        private void TickMarkButton_Click(object sender, EventArgs e)
        {
            XMarkButton.Visible = false;
            TickMarkButton.Visible = false;
            this.BackColor = Color.White;
        }
        private void XMarkButton_Click(object sender, EventArgs e)
        {
            RemoveRequested?.Invoke(this, EventId);
        }

        private void ScheduledWorkControlItem_MouseClick(object sender, MouseEventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        private void ScheduledWorkControlItem_MouseEnter(object sender, EventArgs e)
        {
            MouseHasEntered?.Invoke(this, e);
        }
        private void EventInfoLabel_MouseEnter(object sender, EventArgs e)
        {
            MouseHasEntered?.Invoke(this, e);
        }

        private void DateLabel_MouseEnter(object sender, EventArgs e)
        {
            MouseHasEntered?.Invoke(this, e);
        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            MouseHasEntered?.Invoke(this, e);
        }
        private void ScheduledWorkControlItem_MouseLeave(object sender, EventArgs e)
        {
            MouseHasLeft?.Invoke(this, e);
        }
        private void EventInfoLabel_MouseLeave(object sender, EventArgs e)
        {
            MouseHasLeft?.Invoke(this, e);
        }
        private void DateLabel_MouseLeave(object sender, EventArgs e)
        {
            MouseHasLeft?.Invoke(this, e);
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            MouseHasLeft?.Invoke(this, e);
        }
        private void ScheduledWorkControlItem_Load(object sender, EventArgs e)
        {
            PastDueDate();
        }
    }
}
