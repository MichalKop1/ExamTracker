namespace ExamTracker.UI.MainAppControls
{
    partial class AddStudents
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
            addStudentLabel = new Label();
            studentNameLabel = new Label();
            studentNameTextBox = new TextBox();
            submitButton = new Button();
            cancelButton = new Button();
            studentEmailTextBox = new TextBox();
            studentEmailLabel = new Label();
            studentAgeTextBox = new TextBox();
            studentAgeLabel = new Label();
            Grade8RadioButton = new RadioButton();
            MaturaRadioButton = new RadioButton();
            SuspendLayout();
            // 
            // addStudentLabel
            // 
            addStudentLabel.AutoSize = true;
            addStudentLabel.Location = new Point(131, 21);
            addStudentLabel.Name = "addStudentLabel";
            addStudentLabel.Size = new Size(177, 37);
            addStudentLabel.TabIndex = 0;
            addStudentLabel.Text = "Add Student";
            // 
            // studentNameLabel
            // 
            studentNameLabel.AutoSize = true;
            studentNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            studentNameLabel.ForeColor = Color.FromArgb(64, 64, 64);
            studentNameLabel.Location = new Point(33, 85);
            studentNameLabel.Name = "studentNameLabel";
            studentNameLabel.Size = new Size(140, 25);
            studentNameLabel.TabIndex = 1;
            studentNameLabel.Text = "Student Name";
            // 
            // studentNameTextBox
            // 
            studentNameTextBox.BackColor = Color.Gainsboro;
            studentNameTextBox.BorderStyle = BorderStyle.None;
            studentNameTextBox.Location = new Point(33, 132);
            studentNameTextBox.Name = "studentNameTextBox";
            studentNameTextBox.Size = new Size(317, 36);
            studentNameTextBox.TabIndex = 4;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.DodgerBlue;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.Location = new Point(232, 557);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(121, 54);
            submitButton.TabIndex = 5;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Gainsboro;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            cancelButton.Location = new Point(36, 557);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(121, 54);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // studentEmailTextBox
            // 
            studentEmailTextBox.BackColor = Color.Gainsboro;
            studentEmailTextBox.BorderStyle = BorderStyle.None;
            studentEmailTextBox.Location = new Point(33, 229);
            studentEmailTextBox.Name = "studentEmailTextBox";
            studentEmailTextBox.PlaceholderText = "(optional)";
            studentEmailTextBox.Size = new Size(317, 36);
            studentEmailTextBox.TabIndex = 8;
            // 
            // studentEmailLabel
            // 
            studentEmailLabel.AutoSize = true;
            studentEmailLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            studentEmailLabel.ForeColor = Color.FromArgb(64, 64, 64);
            studentEmailLabel.Location = new Point(33, 182);
            studentEmailLabel.Name = "studentEmailLabel";
            studentEmailLabel.Size = new Size(135, 25);
            studentEmailLabel.TabIndex = 7;
            studentEmailLabel.Text = "Student Email";
            // 
            // studentAgeTextBox
            // 
            studentAgeTextBox.BackColor = Color.Gainsboro;
            studentAgeTextBox.BorderStyle = BorderStyle.None;
            studentAgeTextBox.Location = new Point(36, 326);
            studentAgeTextBox.Name = "studentAgeTextBox";
            studentAgeTextBox.PlaceholderText = "(optional)";
            studentAgeTextBox.Size = new Size(317, 36);
            studentAgeTextBox.TabIndex = 10;
            // 
            // studentAgeLabel
            // 
            studentAgeLabel.AutoSize = true;
            studentAgeLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            studentAgeLabel.ForeColor = Color.FromArgb(64, 64, 64);
            studentAgeLabel.Location = new Point(36, 279);
            studentAgeLabel.Name = "studentAgeLabel";
            studentAgeLabel.Size = new Size(123, 25);
            studentAgeLabel.TabIndex = 9;
            studentAgeLabel.Text = "Student Age";
            // 
            // Grade8RadioButton
            // 
            Grade8RadioButton.AutoSize = true;
            Grade8RadioButton.Location = new Point(36, 394);
            Grade8RadioButton.Name = "Grade8RadioButton";
            Grade8RadioButton.Size = new Size(154, 41);
            Grade8RadioButton.TabIndex = 12;
            Grade8RadioButton.TabStop = true;
            Grade8RadioButton.Text = "8 klasisty";
            Grade8RadioButton.UseVisualStyleBackColor = true;
            // 
            // MaturaRadioButton
            // 
            MaturaRadioButton.AutoSize = true;
            MaturaRadioButton.Location = new Point(36, 458);
            MaturaRadioButton.Name = "MaturaRadioButton";
            MaturaRadioButton.Size = new Size(129, 41);
            MaturaRadioButton.TabIndex = 13;
            MaturaRadioButton.TabStop = true;
            MaturaRadioButton.Text = "Matura";
            MaturaRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddStudents
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.White;
            Controls.Add(MaturaRadioButton);
            Controls.Add(Grade8RadioButton);
            Controls.Add(studentAgeTextBox);
            Controls.Add(studentAgeLabel);
            Controls.Add(studentEmailTextBox);
            Controls.Add(studentEmailLabel);
            Controls.Add(cancelButton);
            Controls.Add(submitButton);
            Controls.Add(studentNameTextBox);
            Controls.Add(studentNameLabel);
            Controls.Add(addStudentLabel);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Margin = new Padding(7);
            Name = "AddStudents";
            Size = new Size(473, 811);
            Load += AddStudents_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label addStudentLabel;
        private Label studentNameLabel;
        private TextBox studentNameTextBox;
        private Button submitButton;
        private Button cancelButton;
        private TextBox studentEmailTextBox;
        private Label studentEmailLabel;
        private TextBox studentAgeTextBox;
        private Label studentAgeLabel;
        private RadioButton Grade8RadioButton;
        private RadioButton MaturaRadioButton;
    }
}
