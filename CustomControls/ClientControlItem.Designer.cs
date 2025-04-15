namespace ExamTracker.CustomControls
{
	partial class ClientControlItem
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
			pictureBox1 = new PictureBox();
			CompanyName = new Label();
			InvoiceCountLabel = new Label();
			Address = new Label();
			Nip = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(59, 48);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// CompanyName
			// 
			CompanyName.AutoSize = true;
			CompanyName.Location = new Point(87, 15);
			CompanyName.Name = "CompanyName";
			CompanyName.Size = new Size(108, 15);
			CompanyName.TabIndex = 1;
			CompanyName.Text = "[ Company Name ]";
			// 
			// InvoiceCountLabel
			// 
			InvoiceCountLabel.AutoSize = true;
			InvoiceCountLabel.Location = new Point(3, 132);
			InvoiceCountLabel.Name = "InvoiceCountLabel";
			InvoiceCountLabel.Size = new Size(53, 15);
			InvoiceCountLabel.TabIndex = 2;
			InvoiceCountLabel.Text = "Invoices:";
			// 
			// Address
			// 
			Address.AutoSize = true;
			Address.Location = new Point(3, 65);
			Address.Name = "Address";
			Address.Size = new Size(63, 15);
			Address.TabIndex = 3;
			Address.Text = "[ Address ]";
			// 
			// Nip
			// 
			Nip.AutoSize = true;
			Nip.Location = new Point(3, 98);
			Nip.Name = "Nip";
			Nip.Size = new Size(40, 15);
			Nip.TabIndex = 4;
			Nip.Text = "[ NIP ]";
			// 
			// ClientControlItem
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Transparent;
			Controls.Add(Nip);
			Controls.Add(Address);
			Controls.Add(InvoiceCountLabel);
			Controls.Add(CompanyName);
			Controls.Add(pictureBox1);
			Name = "ClientControlItem";
			Size = new Size(225, 179);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
		private Label CompanyName;
		private Label InvoiceCountLabel;
		private Label Address;
		private Label Nip;
	}
}
