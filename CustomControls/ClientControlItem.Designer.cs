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
			label1 = new Label();
			EditClientButton = new Button();
			CancelActionButton = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Enabled = false;
			pictureBox1.Image = Properties.Resources.icon;
			pictureBox1.Location = new Point(3, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(59, 48);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// CompanyName
			// 
			CompanyName.AutoEllipsis = true;
			CompanyName.AutoSize = true;
			CompanyName.Enabled = false;
			CompanyName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
			CompanyName.Location = new Point(68, 12);
			CompanyName.Name = "CompanyName";
			CompanyName.Size = new Size(141, 21);
			CompanyName.TabIndex = 1;
			CompanyName.Text = "[ Company Name ]";
			CompanyName.Click += CompanyName_Click;
			// 
			// InvoiceCountLabel
			// 
			InvoiceCountLabel.AutoSize = true;
			InvoiceCountLabel.Enabled = false;
			InvoiceCountLabel.Location = new Point(3, 122);
			InvoiceCountLabel.Name = "InvoiceCountLabel";
			InvoiceCountLabel.Size = new Size(53, 15);
			InvoiceCountLabel.TabIndex = 2;
			InvoiceCountLabel.Text = "Invoices:";
			// 
			// Address
			// 
			Address.AutoEllipsis = true;
			Address.Enabled = false;
			Address.Location = new Point(3, 65);
			Address.Name = "Address";
			Address.Size = new Size(215, 48);
			Address.TabIndex = 3;
			Address.Text = "[ Address ]";
			// 
			// Nip
			// 
			Nip.AutoSize = true;
			Nip.Enabled = false;
			Nip.Location = new Point(38, 98);
			Nip.Name = "Nip";
			Nip.Size = new Size(40, 15);
			Nip.TabIndex = 4;
			Nip.Text = "[ NIP ]";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Enabled = false;
			label1.Location = new Point(3, 98);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.TabIndex = 5;
			label1.Text = "NIP:";
			// 
			// EditClientButton
			// 
			EditClientButton.BackColor = Color.DodgerBlue;
			EditClientButton.FlatAppearance.BorderSize = 0;
			EditClientButton.FlatStyle = FlatStyle.Flat;
			EditClientButton.ForeColor = Color.Black;
			EditClientButton.Location = new Point(3, 149);
			EditClientButton.Name = "EditClientButton";
			EditClientButton.Size = new Size(75, 23);
			EditClientButton.TabIndex = 6;
			EditClientButton.Text = "Edit";
			EditClientButton.UseVisualStyleBackColor = false;
			EditClientButton.Visible = false;
			EditClientButton.Click += EditClientButton_Click;
			// 
			// CancelActionButton
			// 
			CancelActionButton.BackColor = SystemColors.ActiveBorder;
			CancelActionButton.FlatAppearance.BorderSize = 0;
			CancelActionButton.FlatStyle = FlatStyle.Flat;
			CancelActionButton.Location = new Point(134, 149);
			CancelActionButton.Name = "CancelActionButton";
			CancelActionButton.Size = new Size(75, 23);
			CancelActionButton.TabIndex = 7;
			CancelActionButton.Text = "Cancel";
			CancelActionButton.UseVisualStyleBackColor = false;
			CancelActionButton.Visible = false;
			CancelActionButton.Click += CancelActionButton_Click;
			// 
			// ClientControlItem
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LightSlateGray;
			BorderStyle = BorderStyle.Fixed3D;
			Controls.Add(CancelActionButton);
			Controls.Add(EditClientButton);
			Controls.Add(label1);
			Controls.Add(Nip);
			Controls.Add(Address);
			Controls.Add(InvoiceCountLabel);
			Controls.Add(CompanyName);
			Controls.Add(pictureBox1);
			Cursor = Cursors.Hand;
			Name = "ClientControlItem";
			Size = new Size(221, 175);
			Click += ClientControlItem_Click;
			MouseLeave += ClientControlItem_MouseLeave;
			MouseMove += ClientControlItem_MouseMove;
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
		private Label label1;
		private Button EditClientButton;
		private Button CancelActionButton;
	}
}
