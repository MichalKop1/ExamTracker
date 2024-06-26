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
            studentName = new Label();
            studentsComboBox = new ComboBox();
            ExamsGrid = new DataGridView();
            label1 = new Label();
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
            submitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ExamsGrid).BeginInit();
            SuspendLayout();
            // 
            // studentName
            // 
            studentName.AutoSize = true;
            studentName.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            studentName.Location = new Point(4, 4);
            studentName.Name = "studentName";
            studentName.Size = new Size(251, 50);
            studentName.TabIndex = 0;
            studentName.Text = "Exam Results";
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
            ExamsGrid.GridColor = Color.White;
            ExamsGrid.Location = new Point(19, 196);
            ExamsGrid.Name = "ExamsGrid";
            ExamsGrid.ReadOnly = true;
            ExamsGrid.Size = new Size(650, 305);
            ExamsGrid.TabIndex = 3;
            ExamsGrid.CellClick += ExamsGrid_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label1.Location = new Point(19, 74);
            label1.Name = "label1";
            label1.Size = new Size(89, 30);
            label1.TabIndex = 4;
            label1.Text = "Student";
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
            // submitButton
            // 
            submitButton.BackColor = Color.DodgerBlue;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.Location = new Point(548, 800);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(121, 54);
            submitButton.TabIndex = 20;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Visible = false;
            submitButton.Click += submitButton_Click;
            // 
            // StudentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(submitButton);
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
            Controls.Add(label1);
            Controls.Add(ExamsGrid);
            Controls.Add(studentsComboBox);
            Controls.Add(studentName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Name = "StudentsControl";
            Size = new Size(685, 870);
            Load += StudentsControl_Load;
            ((System.ComponentModel.ISupportInitialize)ExamsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label studentName;
        private ComboBox studentsComboBox;
        private DataGridView ExamsGrid;
        private Label label1;
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
        private Button submitButton;
    }
}
