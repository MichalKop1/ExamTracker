using ExamTracker.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTracker.UI.MainAppControls
{
    public partial class ScheduleControl : UserControl
    {
        // Event type list and their numbers:
        // 0 = Empty
        // 1 = Exam
        // 2 = Meeting
        //-1 = Error

        int EventType = 0;
        public ScheduleControl()
        {
            InitializeComponent();
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.AutoScroll = true;
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            Image img;
            if (EventType == 1)
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\exam.jpg");
            }
            else if (EventType == 2)
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\meeting.jpg");
            }
            else
            {
                img = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\exam.jpg");

            }
            string shortDesc = ShortDescTextBox.Text;
            string longDesc = "Very long description of the planned event";
            string dt = Calendar.SelectionRange.Start.ToShortDateString();
            ScheduledWorkControlItem item = new ScheduledWorkControlItem(img, shortDesc, dt, longDesc);
            flowLayoutPanel.Controls.Add(item);
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
    }
}
