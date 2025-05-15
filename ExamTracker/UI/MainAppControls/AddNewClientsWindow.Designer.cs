namespace ExamTracker.UI.MainAppControls
{
	partial class AddClientWindow
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
			CompanysNameTextBox = new TextBox();
			CompanysNipTextBox = new TextBox();
			CompanysAddressTextBox1 = new TextBox();
			CompanysAddressTextBox2 = new TextBox();
			AddClientButton = new Button();
			CancelButton = new Button();
			SuspendLayout();
			// 
			// CompanysNameTextBox
			// 
			CompanysNameTextBox.Location = new Point(29, 32);
			CompanysNameTextBox.Name = "CompanysNameTextBox";
			CompanysNameTextBox.PlaceholderText = "Company's Name";
			CompanysNameTextBox.Size = new Size(350, 23);
			CompanysNameTextBox.TabIndex = 0;
			// 
			// CompanysNipTextBox
			// 
			CompanysNipTextBox.Location = new Point(29, 88);
			CompanysNipTextBox.Name = "CompanysNipTextBox";
			CompanysNipTextBox.PlaceholderText = "NIP";
			CompanysNipTextBox.Size = new Size(350, 23);
			CompanysNipTextBox.TabIndex = 1;
			// 
			// CompanysAddressTextBox1
			// 
			CompanysAddressTextBox1.Location = new Point(29, 146);
			CompanysAddressTextBox1.Name = "CompanysAddressTextBox1";
			CompanysAddressTextBox1.PlaceholderText = "Address 1";
			CompanysAddressTextBox1.Size = new Size(350, 23);
			CompanysAddressTextBox1.TabIndex = 2;
			// 
			// CompanysAddressTextBox2
			// 
			CompanysAddressTextBox2.Location = new Point(29, 214);
			CompanysAddressTextBox2.Name = "CompanysAddressTextBox2";
			CompanysAddressTextBox2.PlaceholderText = "Address 2";
			CompanysAddressTextBox2.Size = new Size(350, 23);
			CompanysAddressTextBox2.TabIndex = 3;
			// 
			// AddClientButton
			// 
			AddClientButton.BackColor = Color.DodgerBlue;
			AddClientButton.FlatAppearance.BorderSize = 0;
			AddClientButton.FlatStyle = FlatStyle.Flat;
			AddClientButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			AddClientButton.Location = new Point(12, 468);
			AddClientButton.Name = "AddClientButton";
			AddClientButton.Size = new Size(103, 42);
			AddClientButton.TabIndex = 21;
			AddClientButton.Text = "Add";
			AddClientButton.UseVisualStyleBackColor = false;
			AddClientButton.Click += AddClientButton_Click;
			// 
			// CancelButton
			// 
			CancelButton.BackColor = Color.Silver;
			CancelButton.FlatAppearance.BorderSize = 0;
			CancelButton.FlatStyle = FlatStyle.Flat;
			CancelButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			CancelButton.Location = new Point(297, 468);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(103, 42);
			CancelButton.TabIndex = 22;
			CancelButton.Text = "Cancel";
			CancelButton.UseVisualStyleBackColor = false;
			CancelButton.Click += CancelButton_Click;
			// 
			// AddClientWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(424, 531);
			Controls.Add(CancelButton);
			Controls.Add(AddClientButton);
			Controls.Add(CompanysAddressTextBox2);
			Controls.Add(CompanysAddressTextBox1);
			Controls.Add(CompanysNipTextBox);
			Controls.Add(CompanysNameTextBox);
			Name = "AddClientWindow";
			Text = "Add Client";
			Load += AddClientWindow_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox CompanysNameTextBox;
		private TextBox CompanysNipTextBox;
		private TextBox CompanysAddressTextBox1;
		private TextBox CompanysAddressTextBox2;
		private Button AddClientButton;
		private Button CancelButton;
	}
}