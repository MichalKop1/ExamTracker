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

namespace ExamTracker.CustomControls
{
    public partial class ScheduledWorkControlItem : UserControl
    {
        Image Image { get; set; }
        string ShortDesc { get; set; }
        string LongDesc { get; set; }
        string DT { get; set; }
        public ScheduledWorkControlItem(Image image, string shortDesc,string dt, string longDesc)
        {
            InitializeComponent();
            Image = image;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            DT = dt;
            EventInfoLabel.Text = ShortDesc + ": " + dt;
            pictureBox.Image = Image;
            toolTip1.SetToolTip(this, longDesc);
            toolTip1.SetToolTip(EventInfoLabel, longDesc);

        }

        private void ScheduledWorkControlItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void ScheduledWorkControlItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ScheduledWorkControlItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void EventInfoLabel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void EventInfoLabel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
