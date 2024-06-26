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
            is8ClassCheckBox = new CheckBox();
            isMaturaCheckBox = new CheckBox();
            studentNameTextBox = new TextBox();
            submitButton = new Button();
            cancelButton = new Button();
            studentEmailTextBox = new TextBox();
            studentEmailLabel = new Label();
            studentAgeTextBox = new TextBox();
            studentAgeLabel = new Label();
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
            // is8ClassCheckBox
            // 
            is8ClassCheckBox.AutoSize = true;
            is8ClassCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            is8ClassCheckBox.FlatAppearance.BorderSize = 0;
            is8ClassCheckBox.FlatStyle = FlatStyle.Flat;
            is8ClassCheckBox.Location = new Point(36, 449);
            is8ClassCheckBox.Name = "is8ClassCheckBox";
            is8ClassCheckBox.Size = new Size(152, 41);
            is8ClassCheckBox.TabIndex = 2;
            is8ClassCheckBox.Text = "8 klasisty";
            is8ClassCheckBox.TextAlign = ContentAlignment.TopCenter;
            is8ClassCheckBox.UseVisualStyleBackColor = true;
            is8ClassCheckBox.CheckedChanged += is8ClassCheckBox_CheckedChanged;
            // 
            // isMaturaCheckBox
            // 
            isMaturaCheckBox.AutoSize = true;
            isMaturaCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            isMaturaCheckBox.Location = new Point(221, 449);
            isMaturaCheckBox.Name = "isMaturaCheckBox";
            isMaturaCheckBox.Size = new Size(129, 41);
            isMaturaCheckBox.TabIndex = 3;
            isMaturaCheckBox.Text = "matura";
            isMaturaCheckBox.UseVisualStyleBackColor = true;
            isMaturaCheckBox.CheckedChanged += isMaturaCheckBox_CheckedChanged;
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
            // AddStudents
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.White;
            Controls.Add(studentAgeTextBox);
            Controls.Add(studentAgeLabel);
            Controls.Add(studentEmailTextBox);
            Controls.Add(studentEmailLabel);
            Controls.Add(cancelButton);
            Controls.Add(submitButton);
            Controls.Add(studentNameTextBox);
            Controls.Add(isMaturaCheckBox);
            Controls.Add(is8ClassCheckBox);
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
        private CheckBox is8ClassCheckBox;
        private CheckBox isMaturaCheckBox;
        private TextBox studentNameTextBox;
        private Button submitButton;
        private Button cancelButton;
        private TextBox studentEmailTextBox;
        private Label studentEmailLabel;
        private TextBox studentAgeTextBox;
        private Label studentAgeLabel;
    }
}
