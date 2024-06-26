namespace ExamTracker.UI
{
    partial class RegisterControl
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
            nameBox = new TextBox();
            surnameBox = new TextBox();
            loginBox = new TextBox();
            emailBox = new TextBox();
            registerButton = new Button();
            passwordBox1 = new TextBox();
            passwordBox2 = new TextBox();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.BackColor = Color.White;
            nameBox.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            nameBox.Location = new Point(62, 19);
            nameBox.Margin = new Padding(7, 8, 7, 8);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Name";
            nameBox.Size = new Size(408, 36);
            nameBox.TabIndex = 0;
            // 
            // surnameBox
            // 
            surnameBox.BackColor = Color.White;
            surnameBox.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            surnameBox.Location = new Point(62, 83);
            surnameBox.Margin = new Padding(7, 8, 7, 8);
            surnameBox.Name = "surnameBox";
            surnameBox.PlaceholderText = "Surname";
            surnameBox.Size = new Size(408, 36);
            surnameBox.TabIndex = 1;
            // 
            // loginBox
            // 
            loginBox.BackColor = Color.White;
            loginBox.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            loginBox.Location = new Point(62, 150);
            loginBox.Margin = new Padding(7, 8, 7, 8);
            loginBox.Name = "loginBox";
            loginBox.PlaceholderText = "User Name";
            loginBox.Size = new Size(408, 36);
            loginBox.TabIndex = 2;
            // 
            // emailBox
            // 
            emailBox.BackColor = Color.White;
            emailBox.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            emailBox.Location = new Point(62, 217);
            emailBox.Margin = new Padding(7, 8, 7, 8);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "E-mail";
            emailBox.Size = new Size(408, 36);
            emailBox.TabIndex = 3;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.YellowGreen;
            registerButton.Cursor = Cursors.Hand;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Location = new Point(62, 410);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(152, 61);
            registerButton.TabIndex = 4;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // passwordBox1
            // 
            passwordBox1.BackColor = Color.White;
            passwordBox1.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            passwordBox1.Location = new Point(62, 280);
            passwordBox1.Margin = new Padding(7, 8, 7, 8);
            passwordBox1.Name = "passwordBox1";
            passwordBox1.PlaceholderText = "Password";
            passwordBox1.Size = new Size(408, 36);
            passwordBox1.TabIndex = 5;
            // 
            // passwordBox2
            // 
            passwordBox2.BackColor = Color.White;
            passwordBox2.Font = new Font("Open Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            passwordBox2.Location = new Point(62, 350);
            passwordBox2.Margin = new Padding(7, 8, 7, 8);
            passwordBox2.Name = "passwordBox2";
            passwordBox2.PlaceholderText = "Confirm password";
            passwordBox2.Size = new Size(408, 36);
            passwordBox2.TabIndex = 6;
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(17F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(passwordBox2);
            Controls.Add(passwordBox1);
            Controls.Add(registerButton);
            Controls.Add(emailBox);
            Controls.Add(loginBox);
            Controls.Add(surnameBox);
            Controls.Add(nameBox);
            Font = new Font("Open Sans Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Margin = new Padding(7, 8, 7, 8);
            Name = "RegisterControl";
            Size = new Size(714, 509);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameBox;
        private TextBox surnameBox;
        private TextBox loginBox;
        private TextBox emailBox;
        private Button registerButton;
        private TextBox passwordBox1;
        private TextBox passwordBox2;
    }
}
