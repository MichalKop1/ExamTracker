namespace ExamTracker.UI.MainAppControls
{
	partial class ClientsControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsControl));
			ClientsFlowPanel = new FlowLayoutPanel();
			ClientsLabel = new Label();
			AddClientButton = new Button();
			ClientsToolStrip = new ToolStrip();
			EditStripButton = new ToolStripButton();
			DeleteStripButton = new ToolStripButton();
			CancelStripButton = new ToolStripButton();
			ClientsToolStrip.SuspendLayout();
			SuspendLayout();
			// 
			// ClientsFlowPanel
			// 
			ClientsFlowPanel.Location = new Point(18, 104);
			ClientsFlowPanel.Name = "ClientsFlowPanel";
			ClientsFlowPanel.Size = new Size(931, 704);
			ClientsFlowPanel.TabIndex = 0;
			// 
			// ClientsLabel
			// 
			ClientsLabel.AutoSize = true;
			ClientsLabel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 238);
			ClientsLabel.Location = new Point(383, 25);
			ClientsLabel.Name = "ClientsLabel";
			ClientsLabel.RightToLeft = RightToLeft.Yes;
			ClientsLabel.Size = new Size(170, 65);
			ClientsLabel.TabIndex = 1;
			ClientsLabel.Text = "Clients";
			// 
			// AddClientButton
			// 
			AddClientButton.BackColor = Color.DodgerBlue;
			AddClientButton.FlatAppearance.BorderSize = 0;
			AddClientButton.FlatStyle = FlatStyle.Flat;
			AddClientButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
			AddClientButton.Location = new Point(833, 814);
			AddClientButton.Name = "AddClientButton";
			AddClientButton.Size = new Size(116, 42);
			AddClientButton.TabIndex = 21;
			AddClientButton.Text = "Add Client";
			AddClientButton.UseVisualStyleBackColor = false;
			AddClientButton.Click += AddClientButton_Click;
			// 
			// ClientsToolStrip
			// 
			ClientsToolStrip.Items.AddRange(new ToolStripItem[] { EditStripButton, DeleteStripButton, CancelStripButton });
			ClientsToolStrip.Location = new Point(0, 0);
			ClientsToolStrip.Name = "ClientsToolStrip";
			ClientsToolStrip.Size = new Size(965, 25);
			ClientsToolStrip.TabIndex = 22;
			ClientsToolStrip.Text = "toolStrip1";
			ClientsToolStrip.Visible = false;
			// 
			// EditStripButton
			// 
			EditStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			EditStripButton.Image = (Image)resources.GetObject("EditStripButton.Image");
			EditStripButton.ImageTransparentColor = Color.Magenta;
			EditStripButton.Name = "EditStripButton";
			EditStripButton.Size = new Size(31, 22);
			EditStripButton.Text = "Edit";
			EditStripButton.Click += EditStripButton_Click;
			// 
			// DeleteStripButton
			// 
			DeleteStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			DeleteStripButton.Image = (Image)resources.GetObject("DeleteStripButton.Image");
			DeleteStripButton.ImageTransparentColor = Color.Magenta;
			DeleteStripButton.Name = "DeleteStripButton";
			DeleteStripButton.Size = new Size(44, 22);
			DeleteStripButton.Text = "Delete";
			DeleteStripButton.Click += DeleteStripButton_Click;
			// 
			// CancelStripButton
			// 
			CancelStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
			CancelStripButton.Image = (Image)resources.GetObject("CancelStripButton.Image");
			CancelStripButton.ImageTransparentColor = Color.Magenta;
			CancelStripButton.Name = "CancelStripButton";
			CancelStripButton.Size = new Size(47, 22);
			CancelStripButton.Text = "Cancel";
			CancelStripButton.Click += CancelStripButton_Click;
			// 
			// ClientsControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			Controls.Add(ClientsToolStrip);
			Controls.Add(AddClientButton);
			Controls.Add(ClientsLabel);
			Controls.Add(ClientsFlowPanel);
			Name = "ClientsControl";
			Size = new Size(965, 870);
			Load += ClientsControl_Load;
			ClientsToolStrip.ResumeLayout(false);
			ClientsToolStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private FlowLayoutPanel ClientsFlowPanel;
		private Label ClientsLabel;
		private Button AddClientButton;
		private ToolStrip ClientsToolStrip;
		private ToolStripButton EditStripButton;
		private ToolStripButton DeleteStripButton;
		private ToolStripButton CancelStripButton;
	}
}
