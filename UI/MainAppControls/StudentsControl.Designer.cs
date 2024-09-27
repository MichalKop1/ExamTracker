namespace ExamTracker.UI.MainAppControls
{
    partial class StudentsControl
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            StudentName = new Label();
            studentsComboBox = new ComboBox();
            ExamsGrid = new DataGridView();
            StudentLabel = new Label();
            ex1 = new TextBox();
            ex2 = new TextBox();
            ex3 = new TextBox();
            ex4 = new TextBox();
            ex5 = new TextBox();
            ex6 = new TextBox();
            ex7 = new TextBox();
            ex8 = new TextBox();
            ex9 = new TextBox();
            ex10 = new TextBox();
            ex11 = new TextBox();
            ex12 = new TextBox();
            ex13 = new TextBox();
            ex14 = new TextBox();
            SubmitButton = new Button();
            EditStudentNameBox = new TextBox();
            EditStudentSurnameBox = new TextBox();
            EditStudentEmailBox = new TextBox();
            EditStudentAgeBox = new TextBox();
            EditButton = new Button();
            ConfirmButton = new Button();
            TableDescLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ExamsGrid).BeginInit();
            SuspendLayout();
            // 
            // StudentName
            // 
            StudentName.AutoSize = true;
            StudentName.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            StudentName.Location = new Point(4, 4);
            StudentName.Name = "StudentName";
            StudentName.Size = new Size(251, 50);
            StudentName.TabIndex = 0;
            StudentName.Text = "Exam Results";
            // 
            // studentsComboBox
            // 
            studentsComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            studentsComboBox.FormattingEnabled = true;
            studentsComboBox.Location = new Point(19, 112);
            studentsComboBox.Name = "studentsComboBox";
            studentsComboBox.Size = new Size(278, 29);
            studentsComboBox.TabIndex = 1;
            studentsComboBox.SelectedIndexChanged += studentsComboBox_SelectedIndexChanged;
            // 
            // ExamsGrid
            // 
            ExamsGrid.AllowUserToAddRows = false;
            ExamsGrid.AllowUserToDeleteRows = false;
            ExamsGrid.BackgroundColor = Color.White;
            ExamsGrid.BorderStyle = BorderStyle.Fixed3D;
            ExamsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ExamsGrid.DefaultCellStyle = dataGridViewCellStyle3;
            ExamsGrid.GridColor = Color.ForestGreen;
            ExamsGrid.Location = new Point(19, 196);
            ExamsGrid.Name = "ExamsGrid";
            ExamsGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            ExamsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            ExamsGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ExamsGrid.Size = new Size(923, 305);
            ExamsGrid.TabIndex = 3;
            ExamsGrid.CellClick += ExamsGrid_CellClick;
            // 
            // StudentLabel
            // 
            StudentLabel.AutoSize = true;
            StudentLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            StudentLabel.Location = new Point(19, 74);
            StudentLabel.Name = "StudentLabel";
            StudentLabel.Size = new Size(187, 30);
            StudentLabel.TabIndex = 4;
            StudentLabel.Text = "Choose a student:";
            // 
            // ex1
            // 
            ex1.Location = new Point(21, 539);
            ex1.Name = "ex1";
            ex1.PlaceholderText = "Exercise 1";
            ex1.Size = new Size(67, 23);
            ex1.TabIndex = 6;
            ex1.Visible = false;
            // 
            // ex2
            // 
            ex2.Location = new Point(21, 596);
            ex2.Name = "ex2";
            ex2.PlaceholderText = "Exercise 2";
            ex2.Size = new Size(67, 23);
            ex2.TabIndex = 7;
            ex2.Visible = false;
            // 
            // ex3
            // 
            ex3.Location = new Point(21, 650);
            ex3.Name = "ex3";
            ex3.PlaceholderText = "Exercise 3";
            ex3.Size = new Size(67, 23);
            ex3.TabIndex = 8;
            ex3.Visible = false;
            // 
            // ex4
            // 
            ex4.Location = new Point(21, 704);
            ex4.Name = "ex4";
            ex4.PlaceholderText = "Exercise 4";
            ex4.Size = new Size(67, 23);
            ex4.TabIndex = 9;
            ex4.Visible = false;
            // 
            // ex5
            // 
            ex5.Location = new Point(21, 758);
            ex5.Name = "ex5";
            ex5.PlaceholderText = "Exercise 5";
            ex5.Size = new Size(67, 23);
            ex5.TabIndex = 10;
            ex5.Visible = false;
            // 
            // ex6
            // 
            ex6.Location = new Point(21, 810);
            ex6.Name = "ex6";
            ex6.PlaceholderText = "Exercise 6";
            ex6.Size = new Size(67, 23);
            ex6.TabIndex = 11;
            ex6.Visible = false;
            // 
            // ex7
            // 
            ex7.Location = new Point(111, 539);
            ex7.Name = "ex7";
            ex7.PlaceholderText = "Exercise 7";
            ex7.Size = new Size(67, 23);
            ex7.TabIndex = 12;
            ex7.Visible = false;
            // 
            // ex8
            // 
            ex8.Location = new Point(111, 596);
            ex8.Name = "ex8";
            ex8.PlaceholderText = "Exercise 8";
            ex8.Size = new Size(67, 23);
            ex8.TabIndex = 13;
            ex8.Visible = false;
            // 
            // ex9
            // 
            ex9.Location = new Point(111, 650);
            ex9.Name = "ex9";
            ex9.PlaceholderText = "Exercise 9";
            ex9.Size = new Size(67, 23);
            ex9.TabIndex = 14;
            ex9.Visible = false;
            // 
            // ex10
            // 
            ex10.Location = new Point(111, 704);
            ex10.Name = "ex10";
            ex10.PlaceholderText = "Exercise 10";
            ex10.Size = new Size(67, 23);
            ex10.TabIndex = 15;
            ex10.Visible = false;
            // 
            // ex11
            // 
            ex11.Location = new Point(111, 758);
            ex11.Name = "ex11";
            ex11.PlaceholderText = "Exercise 11";
            ex11.Size = new Size(67, 23);
            ex11.TabIndex = 16;
            ex11.Visible = false;
            // 
            // ex12
            // 
            ex12.Location = new Point(111, 810);
            ex12.Name = "ex12";
            ex12.PlaceholderText = "Exercise 12";
            ex12.Size = new Size(67, 23);
            ex12.TabIndex = 17;
            ex12.Visible = false;
            // 
            // ex13
            // 
            ex13.Location = new Point(204, 539);
            ex13.Name = "ex13";
            ex13.PlaceholderText = "Exercise 13";
            ex13.Size = new Size(67, 23);
            ex13.TabIndex = 18;
            ex13.Visible = false;
            // 
            // ex14
            // 
            ex14.Location = new Point(204, 596);
            ex14.Name = "ex14";
            ex14.PlaceholderText = "Exercise 14";
            ex14.Size = new Size(67, 23);
            ex14.TabIndex = 19;
            ex14.Visible = false;
            // 
            // SubmitButton
            // 
            SubmitButton.BackColor = Color.DodgerBlue;
            SubmitButton.FlatAppearance.BorderSize = 0;
            SubmitButton.FlatStyle = FlatStyle.Flat;
            SubmitButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubmitButton.Location = new Point(793, 797);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(155, 54);
            SubmitButton.TabIndex = 20;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = false;
            SubmitButton.Visible = false;
            SubmitButton.Click += submitButton_Click;
            // 
            // EditStudentNameBox
            // 
            EditStudentNameBox.BackColor = Color.LightGray;
            EditStudentNameBox.BorderStyle = BorderStyle.None;
            EditStudentNameBox.Font = new Font("Segoe UI", 15.75F);
            EditStudentNameBox.ForeColor = Color.White;
            EditStudentNameBox.Location = new Point(428, 86);
            EditStudentNameBox.Name = "EditStudentNameBox";
            EditStudentNameBox.PlaceholderText = "Name";
            EditStudentNameBox.Size = new Size(241, 28);
            EditStudentNameBox.TabIndex = 21;
            EditStudentNameBox.Visible = false;
            // 
            // EditStudentSurnameBox
            // 
            EditStudentSurnameBox.BackColor = Color.LightGray;
            EditStudentSurnameBox.BorderStyle = BorderStyle.None;
            EditStudentSurnameBox.Font = new Font("Segoe UI", 15.75F);
            EditStudentSurnameBox.ForeColor = Color.White;
            EditStudentSurnameBox.Location = new Point(428, 136);
            EditStudentSurnameBox.Name = "EditStudentSurnameBox";
            EditStudentSurnameBox.PlaceholderText = "Surname";
            EditStudentSurnameBox.Size = new Size(241, 28);
            EditStudentSurnameBox.TabIndex = 22;
            EditStudentSurnameBox.Visible = false;
            // 
            // EditStudentEmailBox
            // 
            EditStudentEmailBox.BackColor = Color.LightGray;
            EditStudentEmailBox.BorderStyle = BorderStyle.None;
            EditStudentEmailBox.Font = new Font("Segoe UI", 15.75F);
            EditStudentEmailBox.ForeColor = Color.White;
            EditStudentEmailBox.Location = new Point(692, 136);
            EditStudentEmailBox.Name = "EditStudentEmailBox";
            EditStudentEmailBox.PlaceholderText = "Email";
            EditStudentEmailBox.Size = new Size(241, 28);
            EditStudentEmailBox.TabIndex = 23;
            EditStudentEmailBox.Visible = false;
            // 
            // EditStudentAgeBox
            // 
            EditStudentAgeBox.BackColor = Color.LightGray;
            EditStudentAgeBox.BorderStyle = BorderStyle.None;
            EditStudentAgeBox.Font = new Font("Segoe UI", 15.75F);
            EditStudentAgeBox.ForeColor = Color.White;
            EditStudentAgeBox.Location = new Point(692, 86);
            EditStudentAgeBox.Name = "EditStudentAgeBox";
            EditStudentAgeBox.PlaceholderText = "Age";
            EditStudentAgeBox.Size = new Size(241, 28);
            EditStudentAgeBox.TabIndex = 24;
            EditStudentAgeBox.Visible = false;
            // 
            // EditButton
            // 
            EditButton.BackColor = Color.Gray;
            EditButton.FlatAppearance.BorderSize = 0;
            EditButton.FlatStyle = FlatStyle.Flat;
            EditButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EditButton.Location = new Point(618, 797);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(155, 54);
            EditButton.TabIndex = 25;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Visible = false;
            EditButton.Click += button1_Click;
            // 
            // ConfirmButton
            // 
            ConfirmButton.BackColor = Color.Gray;
            ConfirmButton.FlatAppearance.BorderSize = 0;
            ConfirmButton.FlatStyle = FlatStyle.Flat;
            ConfirmButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConfirmButton.Location = new Point(618, 797);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(155, 54);
            ConfirmButton.TabIndex = 26;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = false;
            ConfirmButton.Visible = false;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // TableDescLabel
            // 
            TableDescLabel.AutoSize = true;
            TableDescLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            TableDescLabel.Location = new Point(21, 163);
            TableDescLabel.Name = "TableDescLabel";
            TableDescLabel.Size = new Size(129, 30);
            TableDescLabel.TabIndex = 27;
            TableDescLabel.Text = "Exams' table";
            // 
            // StudentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(TableDescLabel);
            Controls.Add(ConfirmButton);
            Controls.Add(EditButton);
            Controls.Add(EditStudentAgeBox);
            Controls.Add(EditStudentEmailBox);
            Controls.Add(EditStudentSurnameBox);
            Controls.Add(EditStudentNameBox);
            Controls.Add(SubmitButton);
            Controls.Add(ex14);
            Controls.Add(ex13);
            Controls.Add(ex12);
            Controls.Add(ex11);
            Controls.Add(ex10);
            Controls.Add(ex9);
            Controls.Add(ex8);
            Controls.Add(ex7);
            Controls.Add(ex6);
            Controls.Add(ex5);
            Controls.Add(ex4);
            Controls.Add(ex3);
            Controls.Add(ex2);
            Controls.Add(ex1);
            Controls.Add(StudentLabel);
            Controls.Add(ExamsGrid);
            Controls.Add(studentsComboBox);
            Controls.Add(StudentName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Name = "StudentsControl";
            Size = new Size(965, 870);
            Load += StudentsControl_Load;
            ((System.ComponentModel.ISupportInitialize)ExamsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label StudentName;
        private ComboBox studentsComboBox;
        private DataGridView ExamsGrid;
        private Label StudentLabel;
        private TextBox ex1;
        private TextBox ex2;
        private TextBox ex3;
        private TextBox ex4;
        private TextBox ex5;
        private TextBox ex6;
        private TextBox ex7;
        private TextBox ex8;
        private TextBox ex9;
        private TextBox ex10;
        private TextBox ex11;
        private TextBox ex12;
        private TextBox ex13;
        private TextBox ex14;
        private Button SubmitButton;
        private TextBox EditStudentNameBox;
        private TextBox EditStudentSurnameBox;
        private TextBox EditStudentEmailBox;
        private TextBox EditStudentAgeBox;
        private Button EditButton;
        private Button ConfirmButton;
        private Label TableDescLabel;
    }
}
