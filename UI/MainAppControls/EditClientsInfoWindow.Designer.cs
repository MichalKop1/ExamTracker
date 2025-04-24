namespace ExamTracker.UI.MainAppControls
{
	partial class EditClientsInfoWindow
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
			dummyLabel = new Label();
			CancelButton = new Button();
			UpdateClientButton = new Button();
			CompanysAddressTextBox2 = new TextBox();
			CompanysAddressTextBox1 = new TextBox();
			CompanysNipTextBox = new TextBox();
			CompanysNameTextBox = new TextBox();
			SuspendLayout();
			//
			// dummyLabel
			// 
			dummyLabel.AutoSize = true;
			dummyLabel.Location = new Point(157, -1);
			dummyLabel.Name = "dummyLabel";
			dummyLabel.Size = new Size(0, 15);
			dummyLabel.TabIndex = 29;
			// 
			// CancelButton
			// 
			CancelButton.BackColor = Color.Silver;
			CancelButton.FlatAppearance.BorderSize = 0;
			CancelButton.FlatStyle = FlatStyle.Flat;
			CancelButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			CancelButton.Location = new Point(259, 280);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(103, 42);
			CancelButton.TabIndex = 28;
			CancelButton.Text = "Cancel";
			CancelButton.UseVisualStyleBackColor = false;
			// 
			// UpdateClientButton
			// 
			UpdateClientButton.BackColor = Color.DodgerBlue;
			UpdateClientButton.FlatAppearance.BorderSize = 0;
			UpdateClientButton.FlatStyle = FlatStyle.Flat;
			UpdateClientButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			UpdateClientButton.Location = new Point(12, 280);
			UpdateClientButton.Name = "UpdateClientButton";
			UpdateClientButton.Size = new Size(103, 42);
			UpdateClientButton.TabIndex = 27;
			UpdateClientButton.Text = "Update";
			UpdateClientButton.UseVisualStyleBackColor = false;
			UpdateClientButton.Click += UpdateClientButton_Click;
			// 
			// CompanysAddressTextBox2
			// 
			CompanysAddressTextBox2.Location = new Point(12, 200);
			CompanysAddressTextBox2.Name = "CompanysAddressTextBox2";
			CompanysAddressTextBox2.PlaceholderText = "Address 2";
			CompanysAddressTextBox2.Size = new Size(350, 23);
			CompanysAddressTextBox2.TabIndex = 26;
			// 
			// CompanysAddressTextBox1
			// 
			CompanysAddressTextBox1.Location = new Point(12, 132);
			CompanysAddressTextBox1.Name = "CompanysAddressTextBox1";
			CompanysAddressTextBox1.PlaceholderText = "Address 1";
			CompanysAddressTextBox1.Size = new Size(350, 23);
			CompanysAddressTextBox1.TabIndex = 25;
			// 
			// CompanysNipTextBox
			// 
			CompanysNipTextBox.Location = new Point(12, 74);
			CompanysNipTextBox.Name = "CompanysNipTextBox";
			CompanysNipTextBox.PlaceholderText = "NIP";
			CompanysNipTextBox.Size = new Size(350, 23);
			CompanysNipTextBox.TabIndex = 24;
			// 
			// CompanysNameTextBox
			// 
			CompanysNameTextBox.Location = new Point(12, 18);
			CompanysNameTextBox.Name = "CompanysNameTextBox";
			CompanysNameTextBox.PlaceholderText = "Company's Name";
			CompanysNameTextBox.Size = new Size(350, 23);
			CompanysNameTextBox.TabIndex = 23;
			// 
			// EditClientsInfoWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(390, 350);
			Controls.Add(dummyLabel);
			Controls.Add(CancelButton);
			Controls.Add(UpdateClientButton);
			Controls.Add(CompanysAddressTextBox2);
			Controls.Add(CompanysAddressTextBox1);
			Controls.Add(CompanysNipTextBox);
			Controls.Add(CompanysNameTextBox);
			Name = "EditClientsInfoWindow";
			Text = "EditClientsInfoWindow";
			Load += EditClientsInfoWindow_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label dummyLabel;
		private Button CancelButton;
		private Button UpdateClientButton;
		private TextBox CompanysAddressTextBox2;
		private TextBox CompanysAddressTextBox1;
		private TextBox CompanysNipTextBox;
		private TextBox CompanysNameTextBox;
	}
}