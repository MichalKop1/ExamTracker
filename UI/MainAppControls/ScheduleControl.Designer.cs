namespace ExamTracker.UI.MainAppControls
{
    partial class ScheduleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar = new MonthCalendar();
            flowLayoutPanel = new FlowLayoutPanel();
            AddEventButton = new Button();
            ShortDescTextBox = new TextBox();
            ExamRadioButton = new RadioButton();
            MeetingRadioButton = new RadioButton();
            SuspendLayout();
            // 
            // Calendar
            // 
            Calendar.CalendarDimensions = new Size(2, 2);
            Calendar.Location = new Point(498, 9);
            Calendar.MaxSelectionCount = 1;
            Calendar.Name = "Calendar";
            Calendar.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(19, 9);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(467, 845);
            flowLayoutPanel.TabIndex = 1;
            flowLayoutPanel.WrapContents = false;
            // 
            // AddEventButton
            // 
            AddEventButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            AddEventButton.Location = new Point(570, 395);
            AddEventButton.Name = "AddEventButton";
            AddEventButton.Size = new Size(178, 38);
            AddEventButton.TabIndex = 2;
            AddEventButton.Text = "Add event";
            AddEventButton.UseVisualStyleBackColor = true;
            AddEventButton.Click += AddEventButton_Click;
            // 
            // ShortDescTextBox
            // 
            ShortDescTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ShortDescTextBox.Location = new Point(507, 343);
            ShortDescTextBox.Name = "ShortDescTextBox";
            ShortDescTextBox.Size = new Size(315, 33);
            ShortDescTextBox.TabIndex = 3;
            // 
            // ExamRadioButton
            // 
            ExamRadioButton.AutoSize = true;
            ExamRadioButton.Font = new Font("Segoe UI", 14.25F);
            ExamRadioButton.Location = new Point(841, 330);
            ExamRadioButton.Name = "ExamRadioButton";
            ExamRadioButton.Size = new Size(75, 29);
            ExamRadioButton.TabIndex = 4;
            ExamRadioButton.TabStop = true;
            ExamRadioButton.Text = "Exam";
            ExamRadioButton.UseVisualStyleBackColor = true;
            ExamRadioButton.CheckedChanged += ExamRadioButton_CheckedChanged;
            // 
            // MeetingRadioButton
            // 
            MeetingRadioButton.AutoSize = true;
            MeetingRadioButton.Font = new Font("Segoe UI", 14.25F);
            MeetingRadioButton.Location = new Point(841, 365);
            MeetingRadioButton.Name = "MeetingRadioButton";
            MeetingRadioButton.Size = new Size(100, 29);
            MeetingRadioButton.TabIndex = 5;
            MeetingRadioButton.TabStop = true;
            MeetingRadioButton.Text = "Meeting";
            MeetingRadioButton.UseVisualStyleBackColor = true;
            MeetingRadioButton.CheckedChanged += MeetingRadioButton_CheckedChanged;
            // 
            // ScheduleControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(MeetingRadioButton);
            Controls.Add(ExamRadioButton);
            Controls.Add(ShortDescTextBox);
            Controls.Add(AddEventButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(Calendar);
            Name = "ScheduleControl";
            Size = new Size(965, 870);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar Calendar;
        private FlowLayoutPanel flowLayoutPanel;
        private Button AddEventButton;
        private TextBox ShortDescTextBox;
        private RadioButton ExamRadioButton;
        private RadioButton MeetingRadioButton;
    }
}
