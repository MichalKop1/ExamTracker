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

namespace ExamTracker.CustomControls
{
    public partial class ScheduledWorkControlItem : UserControl
    {
        // Event type list and their numbers:
        // 0 = Empty
        // 1 = Exam
        // 2 = Meeting
        //-1 = Error
        public event EventHandler<int> RemoveRequested;
        public event EventHandler EventClicked;

        bool Clicked;
        Image Image { get; set; }
        string ShortDesc { get; set; }
        string LongDesc { get; set; }
        DateTime DT { get; set; }
        int EventId { get; set; }
        public ScheduledWorkControlItem(Event _event)
        {
            InitializeComponent();
            Image = SetEventImage(_event.EventType);
            ShortDesc = _event.ShortDesc;
            LongDesc = _event.LongDesc;
            DT = _event.EventDate;
            DueDatePassed(DT);
            EventInfoLabel.Text = ShortDesc;
            DateLabel.Text = DT.ToString();
            pictureBox.Image = Image;
            toolTip1.SetToolTip(this, LongDesc);
            toolTip1.SetToolTip(EventInfoLabel, LongDesc);
            EventId = _event.EventId;

            this.MouseClick += ScheduledWorkControlItem_MouseClick;
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
        private bool DueDatePassed(DateTime dt)
        {
            bool tooLate = false;
            if (dt > DateTime.Now)
            {
                this.BackColor = Color.Red;
                tooLate = true;
            }
            return tooLate;
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

        private void ScheduledWorkControlItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void ScheduledWorkControlItem_MouseEnter(object sender, EventArgs e)
        {
            if (!DueDatePassed(DT) && !Clicked)
                this.BackColor = Color.Silver;


        }

        private void ScheduledWorkControlItem_MouseLeave(object sender, EventArgs e)
        {
            if (!DueDatePassed(DT) && !Clicked)
                this.BackColor = Color.White;
        }

        private void EventInfoLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!DueDatePassed(DT) && !Clicked)
                this.BackColor = Color.Silver;
        }

        private void EventInfoLabel_MouseLeave(object sender, EventArgs e)
        {
            if (DueDatePassed(DT) && !Clicked)
                this.BackColor = Color.White;
        }

        private void ScheduledWorkControlItem_MouseClick(object sender, MouseEventArgs e)
        {
            XMarkButton.Visible = true;
            TickMarkButton.Visible = true;
            this.BackColor = Color.Thistle;
            Clicked = true;

            EventClicked?.Invoke(this, EventArgs.Empty);
        }

        private void TickMarkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void XMarkButton_Click(object sender, EventArgs e)
        {
            RemoveRequested?.Invoke(this, EventId);
        }
    }
}
