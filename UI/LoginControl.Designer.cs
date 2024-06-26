namespace ExamTracker.UI
{
    partial class LoginControl
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
            loginBox = new TextBox();
            passwordBox = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // loginBox
            // 
            loginBox.Font = new Font("Open Sans Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            loginBox.Location = new Point(45, 40);
            loginBox.Name = "loginBox";
            loginBox.PlaceholderText = "Login";
            loginBox.Size = new Size(338, 47);
            loginBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Open Sans Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            passwordBox.Location = new Point(45, 133);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Password";
            passwordBox.Size = new Size(338, 47);
            passwordBox.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.YellowGreen;
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Open Sans", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            loginButton.Location = new Point(45, 215);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(121, 51);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(loginButton);
            Controls.Add(passwordBox);
            Controls.Add(loginBox);
            Name = "LoginControl";
            Size = new Size(435, 325);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginBox;
        private TextBox passwordBox;
        private Button loginButton;
    }
}
