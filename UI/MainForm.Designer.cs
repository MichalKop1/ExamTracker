namespace ExamTracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panelUnderline;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnLogin = new Button();
            btnRegister = new Button();
            panelUnderline = new Panel();
            entryPanel = new Panel();
            newsletterLabel = new Label();
            textBox1 = new TextBox();
            getStartedButton = new Button();
            label2 = new Label();
            logoBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Open Sans Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnLogin.Location = new Point(105, 149);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(335, 60);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Open Sans Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnRegister.Location = new Point(439, 149);
            btnRegister.Margin = new Padding(2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(335, 60);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // panelUnderline
            // 
            panelUnderline.BackColor = Color.MediumSeaGreen;
            panelUnderline.Location = new Point(105, 213);
            panelUnderline.Margin = new Padding(2);
            panelUnderline.Name = "panelUnderline";
            panelUnderline.Size = new Size(335, 6);
            panelUnderline.TabIndex = 2;
            // 
            // entryPanel
            // 
            entryPanel.Location = new Point(105, 250);
            entryPanel.Margin = new Padding(4, 3, 4, 3);
            entryPanel.Name = "entryPanel";
            entryPanel.Size = new Size(634, 589);
            entryPanel.TabIndex = 3;
            // 
            // newsletterLabel
            // 
            newsletterLabel.AutoSize = true;
            newsletterLabel.Font = new Font("Open Sans Extrabold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            newsletterLabel.Location = new Point(94, 875);
            newsletterLabel.Margin = new Padding(4, 0, 4, 0);
            newsletterLabel.Name = "newsletterLabel";
            newsletterLabel.Size = new Size(709, 74);
            newsletterLabel.TabIndex = 5;
            newsletterLabel.Text = "Join our newsletter and become one of thousands\r\n              teachers who use Exam Tracker";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PeachPuff;
            textBox1.Font = new Font("Open Sans", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(94, 971);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Email";
            textBox1.Size = new Size(633, 40);
            textBox1.TabIndex = 6;
            // 
            // getStartedButton
            // 
            getStartedButton.BackColor = Color.YellowGreen;
            getStartedButton.Cursor = Cursors.Hand;
            getStartedButton.FlatAppearance.BorderSize = 0;
            getStartedButton.FlatStyle = FlatStyle.Flat;
            getStartedButton.Font = new Font("Open Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            getStartedButton.Location = new Point(589, 976);
            getStartedButton.Margin = new Padding(2);
            getStartedButton.Name = "getStartedButton";
            getStartedButton.Size = new Size(126, 30);
            getStartedButton.TabIndex = 7;
            getStartedButton.Text = "Get started";
            getStartedButton.TextAlign = ContentAlignment.TopLeft;
            getStartedButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sweets Smile", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(154, 34);
            label2.Name = "label2";
            label2.Size = new Size(176, 32);
            label2.TabIndex = 9;
            label2.Text = "Exam Tracker";
            // 
            // logoBox
            // 
            logoBox.InitialImage = null;
            logoBox.Location = new Point(12, 12);
            logoBox.MaximumSize = new Size(2000, 2000);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(114, 82);
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoBox.TabIndex = 8;
            logoBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(874, 1064);
            Controls.Add(label2);
            Controls.Add(logoBox);
            Controls.Add(getStartedButton);
            Controls.Add(textBox1);
            Controls.Add(newsletterLabel);
            Controls.Add(entryPanel);
            Controls.Add(panelUnderline);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Exam Tracker";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel entryPanel;
        private System.Windows.Forms.Label newsletterLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button getStartedButton;
        private Label label2;
        private PictureBox logoBox;
    }
}
