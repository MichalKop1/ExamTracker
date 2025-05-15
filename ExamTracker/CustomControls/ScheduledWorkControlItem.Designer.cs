namespace ExamTracker.CustomControls
{
    partial class ScheduledWorkControlItem
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduledWorkControlItem));
            pictureBox = new PictureBox();
            EventInfoLabel = new Label();
            toolTip1 = new ToolTip(components);
            DateLabel = new Label();
            TickMarkButton = new Button();
            XMarkButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(105, 79);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseEnter += pictureBox_MouseEnter;
            pictureBox.MouseLeave += pictureBox_MouseLeave;
            // 
            // EventInfoLabel
            // 
            EventInfoLabel.AutoSize = true;
            EventInfoLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            EventInfoLabel.Location = new Point(111, 8);
            EventInfoLabel.Name = "EventInfoLabel";
            EventInfoLabel.Size = new Size(183, 30);
            EventInfoLabel.TabIndex = 1;
            EventInfoLabel.Text = "[ TYPE OF EVENT ]";
            EventInfoLabel.MouseEnter += EventInfoLabel_MouseEnter;
            EventInfoLabel.MouseLeave += EventInfoLabel_MouseLeave;
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DateLabel.Location = new Point(111, 40);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(91, 30);
            DateLabel.TabIndex = 2;
            DateLabel.Text = " [ DATE ]";
            DateLabel.MouseEnter += DateLabel_MouseEnter;
            DateLabel.MouseLeave += DateLabel_MouseLeave;
            // 
            // TickMarkButton
            // 
            TickMarkButton.BackColor = Color.Transparent;
            TickMarkButton.Image = (Image)resources.GetObject("TickMarkButton.Image");
            TickMarkButton.Location = new Point(400, 3);
            TickMarkButton.Name = "TickMarkButton";
            TickMarkButton.Size = new Size(35, 35);
            TickMarkButton.TabIndex = 3;
            TickMarkButton.UseVisualStyleBackColor = false;
            TickMarkButton.Visible = false;
            TickMarkButton.Click += TickMarkButton_Click;
            // 
            // XMarkButton
            // 
            XMarkButton.BackColor = Color.Transparent;
            XMarkButton.Image = (Image)resources.GetObject("XMarkButton.Image");
            XMarkButton.Location = new Point(400, 40);
            XMarkButton.Name = "XMarkButton";
            XMarkButton.Size = new Size(35, 35);
            XMarkButton.TabIndex = 4;
            XMarkButton.UseVisualStyleBackColor = false;
            XMarkButton.Visible = false;
            XMarkButton.Click += XMarkButton_Click;
            // 
            // ScheduledWorkControlItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(XMarkButton);
            Controls.Add(TickMarkButton);
            Controls.Add(DateLabel);
            Controls.Add(EventInfoLabel);
            Controls.Add(pictureBox);
            Cursor = Cursors.Hand;
            Name = "ScheduledWorkControlItem";
            Size = new Size(438, 79);
            Load += ScheduledWorkControlItem_Load;
            MouseClick += ScheduledWorkControlItem_MouseClick;
            MouseEnter += ScheduledWorkControlItem_MouseEnter;
            MouseLeave += ScheduledWorkControlItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label EventInfoLabel;
        private ToolTip toolTip1;
        private Label DateLabel;
        private Button TickMarkButton;
        private Button XMarkButton;
    }
}
