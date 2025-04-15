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
			ClientsFlowPanel = new FlowLayoutPanel();
			ClientsLabel = new Label();
			AddClientButton = new Button();
			SuspendLayout();
			// 
			// ClientsFlowPanel
			// 
			ClientsFlowPanel.Location = new Point(18, 78);
			ClientsFlowPanel.Name = "ClientsFlowPanel";
			ClientsFlowPanel.Size = new Size(931, 704);
			ClientsFlowPanel.TabIndex = 0;
			// 
			// ClientsLabel
			// 
			ClientsLabel.AutoSize = true;
			ClientsLabel.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 238);
			ClientsLabel.Location = new Point(385, 7);
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
			AddClientButton.Location = new Point(833, 805);
			AddClientButton.Name = "AddClientButton";
			AddClientButton.Size = new Size(116, 42);
			AddClientButton.TabIndex = 21;
			AddClientButton.Text = "Add Client";
			AddClientButton.UseVisualStyleBackColor = false;
			AddClientButton.Click += AddClientButton_Click;
			// 
			// ClientsControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			Controls.Add(AddClientButton);
			Controls.Add(ClientsLabel);
			Controls.Add(ClientsFlowPanel);
			Name = "ClientsControl";
			Size = new Size(965, 870);
			Load += ClientsControl_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private FlowLayoutPanel ClientsFlowPanel;
		private Label ClientsLabel;
		private Button AddClientButton;
	}
}
