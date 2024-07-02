namespace ExamTracker.UI
{
    partial class MainAppView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAppView));
            dataPanel = new Panel();
            miscPanel = new Panel();
            label1 = new Label();
            dashboardButton = new Button();
            studentsButton = new Button();
            scheduleButton = new Button();
            billingButton = new Button();
            businessButton = new Button();
            profileButton = new Button();
            SuspendLayout();
            // 
            // dataPanel
            // 
            dataPanel.Location = new Point(263, 6);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(965, 870);
            dataPanel.TabIndex = 1;
            // 
            // miscPanel
            // 
            miscPanel.Location = new Point(12, 688);
            miscPanel.Name = "miscPanel";
            miscPanel.Size = new Size(229, 188);
            miscPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(151, 24);
            label1.TabIndex = 3;
            label1.Text = "Exam Tracker";
            // 
            // dashboardButton
            // 
            dashboardButton.FlatAppearance.BorderSize = 0;
            dashboardButton.FlatStyle = FlatStyle.Flat;
            dashboardButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic);
            dashboardButton.Image = (Image)resources.GetObject("dashboardButton.Image");
            dashboardButton.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardButton.Location = new Point(34, 55);
            dashboardButton.Name = "dashboardButton";
            dashboardButton.Size = new Size(163, 42);
            dashboardButton.TabIndex = 4;
            dashboardButton.Text = "Dashboard";
            dashboardButton.UseVisualStyleBackColor = true;
            dashboardButton.Click += dashboardButton_Click;
            // 
            // studentsButton
            // 
            studentsButton.FlatAppearance.BorderSize = 0;
            studentsButton.FlatStyle = FlatStyle.Flat;
            studentsButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic);
            studentsButton.Image = (Image)resources.GetObject("studentsButton.Image");
            studentsButton.ImageAlign = ContentAlignment.MiddleLeft;
            studentsButton.Location = new Point(35, 117);
            studentsButton.Name = "studentsButton";
            studentsButton.Size = new Size(162, 42);
            studentsButton.TabIndex = 5;
            studentsButton.Text = "Students";
            studentsButton.UseVisualStyleBackColor = true;
            studentsButton.Click += studentsButton_Click;
            // 
            // scheduleButton
            // 
            scheduleButton.FlatAppearance.BorderSize = 0;
            scheduleButton.FlatStyle = FlatStyle.Flat;
            scheduleButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            scheduleButton.Image = (Image)resources.GetObject("scheduleButton.Image");
            scheduleButton.ImageAlign = ContentAlignment.MiddleLeft;
            scheduleButton.Location = new Point(35, 185);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(162, 42);
            scheduleButton.TabIndex = 6;
            scheduleButton.Text = "Schedule";
            scheduleButton.UseVisualStyleBackColor = true;
            // 
            // billingButton
            // 
            billingButton.FlatAppearance.BorderSize = 0;
            billingButton.FlatStyle = FlatStyle.Flat;
            billingButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            billingButton.Image = (Image)resources.GetObject("billingButton.Image");
            billingButton.ImageAlign = ContentAlignment.MiddleLeft;
            billingButton.Location = new Point(34, 248);
            billingButton.Name = "billingButton";
            billingButton.Size = new Size(163, 42);
            billingButton.TabIndex = 7;
            billingButton.Text = "Billing";
            billingButton.UseVisualStyleBackColor = true;
            // 
            // businessButton
            // 
            businessButton.FlatAppearance.BorderSize = 0;
            businessButton.FlatStyle = FlatStyle.Flat;
            businessButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            businessButton.Image = (Image)resources.GetObject("businessButton.Image");
            businessButton.ImageAlign = ContentAlignment.MiddleLeft;
            businessButton.Location = new Point(34, 306);
            businessButton.Name = "businessButton";
            businessButton.Size = new Size(163, 42);
            businessButton.TabIndex = 8;
            businessButton.Text = "Business";
            businessButton.UseVisualStyleBackColor = true;
            // 
            // profileButton
            // 
            profileButton.FlatAppearance.BorderSize = 0;
            profileButton.FlatStyle = FlatStyle.Flat;
            profileButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            profileButton.Image = (Image)resources.GetObject("profileButton.Image");
            profileButton.ImageAlign = ContentAlignment.MiddleLeft;
            profileButton.Location = new Point(34, 374);
            profileButton.Name = "profileButton";
            profileButton.Size = new Size(163, 42);
            profileButton.TabIndex = 9;
            profileButton.Text = "Profile";
            profileButton.UseVisualStyleBackColor = true;
            profileButton.Click += button6_Click;
            // 
            // MainAppView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1240, 898);
            Controls.Add(profileButton);
            Controls.Add(businessButton);
            Controls.Add(billingButton);
            Controls.Add(scheduleButton);
            Controls.Add(studentsButton);
            Controls.Add(dashboardButton);
            Controls.Add(label1);
            Controls.Add(miscPanel);
            Controls.Add(dataPanel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainAppView";
            Text = "Exam Tracker";
            FormClosed += MainAppView_FormClosed;
            Load += MainAppView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel dataPanel;
        private Panel miscPanel;
        private Label label1;
        private Button dashboardButton;
        private Button studentsButton;
        private Button scheduleButton;
        private Button billingButton;
        private Button businessButton;
        private Button profileButton;
    }
}