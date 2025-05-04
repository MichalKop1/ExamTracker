namespace ExamTracker.UI.MainAppControls
{
    partial class BillingControl
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			InvoicesTable = new DataGridView();
			InvoiceLabel = new Label();
			InvoiceListLabel = new Label();
			CreateInvoiceLabel = new Label();
			DateOfSaleTextBox = new TextBox();
			DateOfPaymentTextBox = new TextBox();
			RemarksTextBox = new RichTextBox();
			button2 = new Button();
			PaymentCalendarButton = new Button();
			ItemsFlowLayoutPanel = new FlowLayoutPanel();
			AddItemButton = new Button();
			AddInvoiceButton = new Button();
			DescriptionLabel = new Label();
			QuantityLabel = new Label();
			UnitPriceLabel = new Label();
			SellDateCalendar = new MonthCalendar();
			PaymentCalendar = new MonthCalendar();
			ClientsComboBox = new ComboBox();
			TransferCheckBox = new RadioButton();
			CashCheckBox = new RadioButton();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)InvoicesTable).BeginInit();
			SuspendLayout();
			// 
			// InvoicesTable
			// 
			InvoicesTable.AllowUserToAddRows = false;
			InvoicesTable.AllowUserToDeleteRows = false;
			InvoicesTable.AllowUserToResizeColumns = false;
			InvoicesTable.AllowUserToResizeRows = false;
			InvoicesTable.BackgroundColor = Color.White;
			InvoicesTable.BorderStyle = BorderStyle.None;
			InvoicesTable.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.Silver;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			InvoicesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			InvoicesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = Color.Black;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			InvoicesTable.DefaultCellStyle = dataGridViewCellStyle2;
			InvoicesTable.Location = new Point(16, 112);
			InvoicesTable.MultiSelect = false;
			InvoicesTable.Name = "InvoicesTable";
			InvoicesTable.ReadOnly = true;
			InvoicesTable.RowTemplate.Height = 32;
			InvoicesTable.Size = new Size(463, 755);
			InvoicesTable.TabIndex = 1;
			InvoicesTable.CellClick += InvoicesTable_CellClick;
			InvoicesTable.CellMouseEnter += InvoicesTable_CellMouseEnter;
			InvoicesTable.CellMouseLeave += InvoicesTable_CellMouseLeave;
			InvoicesTable.DataBindingComplete += InvoicesTable_DataBindingComplete;
			InvoicesTable.SelectionChanged += InvoicesTable_SelectionChanged;
			// 
			// InvoiceLabel
			// 
			InvoiceLabel.AutoSize = true;
			InvoiceLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
			InvoiceLabel.Location = new Point(28, 75);
			InvoiceLabel.Name = "InvoiceLabel";
			InvoiceLabel.Size = new Size(138, 21);
			InvoiceLabel.TabIndex = 2;
			InvoiceLabel.Text = "Approved invoices";
			// 
			// InvoiceListLabel
			// 
			InvoiceListLabel.AutoSize = true;
			InvoiceListLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
			InvoiceListLabel.Location = new Point(16, 18);
			InvoiceListLabel.Name = "InvoiceListLabel";
			InvoiceListLabel.Size = new Size(171, 45);
			InvoiceListLabel.TabIndex = 3;
			InvoiceListLabel.Text = "Invoice list";
			// 
			// CreateInvoiceLabel
			// 
			CreateInvoiceLabel.AutoSize = true;
			CreateInvoiceLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
			CreateInvoiceLabel.Location = new Point(590, 18);
			CreateInvoiceLabel.Name = "CreateInvoiceLabel";
			CreateInvoiceLabel.Size = new Size(221, 45);
			CreateInvoiceLabel.TabIndex = 4;
			CreateInvoiceLabel.Text = "Create invoice";
			CreateInvoiceLabel.Click += label1_Click;
			// 
			// DateOfSaleTextBox
			// 
			DateOfSaleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
			DateOfSaleTextBox.Location = new Point(562, 72);
			DateOfSaleTextBox.Name = "DateOfSaleTextBox";
			DateOfSaleTextBox.PlaceholderText = "Sell date (YYYY-MM-DD)";
			DateOfSaleTextBox.Size = new Size(261, 29);
			DateOfSaleTextBox.TabIndex = 5;
			// 
			// DateOfPaymentTextBox
			// 
			DateOfPaymentTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
			DateOfPaymentTextBox.Location = new Point(562, 123);
			DateOfPaymentTextBox.Name = "DateOfPaymentTextBox";
			DateOfPaymentTextBox.PlaceholderText = "Payment date (YYYY-MM-DD)";
			DateOfPaymentTextBox.Size = new Size(261, 29);
			DateOfPaymentTextBox.TabIndex = 6;
			// 
			// RemarksTextBox
			// 
			RemarksTextBox.Location = new Point(562, 170);
			RemarksTextBox.Name = "RemarksTextBox";
			RemarksTextBox.Size = new Size(298, 109);
			RemarksTextBox.TabIndex = 7;
			RemarksTextBox.Text = "";
			// 
			// button2
			// 
			button2.BackgroundImageLayout = ImageLayout.Zoom;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Image = Properties.Resources.calendar;
			button2.Location = new Point(822, 70);
			button2.Name = "button2";
			button2.Size = new Size(40, 32);
			button2.TabIndex = 8;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// PaymentCalendarButton
			// 
			PaymentCalendarButton.BackgroundImageLayout = ImageLayout.Zoom;
			PaymentCalendarButton.FlatAppearance.BorderSize = 0;
			PaymentCalendarButton.FlatStyle = FlatStyle.Flat;
			PaymentCalendarButton.Image = Properties.Resources.calendar;
			PaymentCalendarButton.Location = new Point(822, 121);
			PaymentCalendarButton.Name = "PaymentCalendarButton";
			PaymentCalendarButton.Size = new Size(40, 32);
			PaymentCalendarButton.TabIndex = 9;
			PaymentCalendarButton.UseVisualStyleBackColor = true;
			PaymentCalendarButton.Click += PaymentCalendarButton_Click;
			// 
			// ItemsFlowLayoutPanel
			// 
			ItemsFlowLayoutPanel.AutoScroll = true;
			ItemsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
			ItemsFlowLayoutPanel.Location = new Point(498, 398);
			ItemsFlowLayoutPanel.Name = "ItemsFlowLayoutPanel";
			ItemsFlowLayoutPanel.Size = new Size(450, 396);
			ItemsFlowLayoutPanel.TabIndex = 10;
			ItemsFlowLayoutPanel.Click += ItemsFlowLayoutPanel_Click;
			// 
			// AddItemButton
			// 
			AddItemButton.Location = new Point(498, 810);
			AddItemButton.Name = "AddItemButton";
			AddItemButton.Size = new Size(92, 41);
			AddItemButton.TabIndex = 11;
			AddItemButton.Text = "Add item";
			AddItemButton.UseVisualStyleBackColor = true;
			AddItemButton.Click += AddRowButton_Click;
			// 
			// AddInvoiceButton
			// 
			AddInvoiceButton.BackColor = Color.DodgerBlue;
			AddInvoiceButton.Location = new Point(856, 810);
			AddInvoiceButton.Name = "AddInvoiceButton";
			AddInvoiceButton.Size = new Size(92, 41);
			AddInvoiceButton.TabIndex = 12;
			AddInvoiceButton.Text = "Add invoice";
			AddInvoiceButton.UseVisualStyleBackColor = false;
			AddInvoiceButton.Click += AddInvoiceButton_Click;
			// 
			// DescriptionLabel
			// 
			DescriptionLabel.AutoSize = true;
			DescriptionLabel.Location = new Point(532, 370);
			DescriptionLabel.Name = "DescriptionLabel";
			DescriptionLabel.Size = new Size(67, 15);
			DescriptionLabel.TabIndex = 13;
			DescriptionLabel.Text = "Description";
			// 
			// QuantityLabel
			// 
			QuantityLabel.AutoSize = true;
			QuantityLabel.Location = new Point(664, 370);
			QuantityLabel.Name = "QuantityLabel";
			QuantityLabel.Size = new Size(53, 15);
			QuantityLabel.TabIndex = 14;
			QuantityLabel.Text = "Quantity";
			// 
			// UnitPriceLabel
			// 
			UnitPriceLabel.AutoSize = true;
			UnitPriceLabel.Location = new Point(802, 370);
			UnitPriceLabel.Name = "UnitPriceLabel";
			UnitPriceLabel.Size = new Size(58, 15);
			UnitPriceLabel.TabIndex = 15;
			UnitPriceLabel.Text = "Unit Price";
			// 
			// SellDateCalendar
			// 
			SellDateCalendar.Location = new Point(562, 101);
			SellDateCalendar.MaxSelectionCount = 1;
			SellDateCalendar.Name = "SellDateCalendar";
			SellDateCalendar.TabIndex = 16;
			SellDateCalendar.Visible = false;
			SellDateCalendar.DateSelected += SellDateCalendar_DateSelected;
			// 
			// PaymentCalendar
			// 
			PaymentCalendar.Location = new Point(562, 150);
			PaymentCalendar.MaxSelectionCount = 1;
			PaymentCalendar.Name = "PaymentCalendar";
			PaymentCalendar.TabIndex = 17;
			PaymentCalendar.Visible = false;
			PaymentCalendar.DateChanged += PaymentCalendar_DateChanged;
			// 
			// ClientsComboBox
			// 
			ClientsComboBox.FormattingEnabled = true;
			ClientsComboBox.Location = new Point(562, 298);
			ClientsComboBox.Name = "ClientsComboBox";
			ClientsComboBox.Size = new Size(300, 23);
			ClientsComboBox.TabIndex = 19;
			ClientsComboBox.SelectedIndexChanged += ClientsComboBox_SelectedIndexChanged;
			// 
			// TransferCheckBox
			// 
			TransferCheckBox.AutoSize = true;
			TransferCheckBox.Location = new Point(631, 337);
			TransferCheckBox.Name = "TransferCheckBox";
			TransferCheckBox.Size = new Size(66, 19);
			TransferCheckBox.TabIndex = 20;
			TransferCheckBox.TabStop = true;
			TransferCheckBox.Text = "Transfer";
			TransferCheckBox.UseVisualStyleBackColor = true;
			TransferCheckBox.Click += TransferCheckBox_Click;
			// 
			// CashCheckBox
			// 
			CashCheckBox.AutoSize = true;
			CashCheckBox.Location = new Point(703, 337);
			CashCheckBox.Name = "CashCheckBox";
			CashCheckBox.Size = new Size(51, 19);
			CashCheckBox.TabIndex = 21;
			CashCheckBox.TabStop = true;
			CashCheckBox.Text = "Cash";
			CashCheckBox.UseVisualStyleBackColor = true;
			CashCheckBox.Click += CashCheckBox_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(568, 337);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 22;
			label1.Text = "Payment:";
			// 
			// BillingControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			Controls.Add(label1);
			Controls.Add(CashCheckBox);
			Controls.Add(TransferCheckBox);
			Controls.Add(ClientsComboBox);
			Controls.Add(PaymentCalendar);
			Controls.Add(SellDateCalendar);
			Controls.Add(UnitPriceLabel);
			Controls.Add(QuantityLabel);
			Controls.Add(DescriptionLabel);
			Controls.Add(AddInvoiceButton);
			Controls.Add(AddItemButton);
			Controls.Add(ItemsFlowLayoutPanel);
			Controls.Add(PaymentCalendarButton);
			Controls.Add(button2);
			Controls.Add(RemarksTextBox);
			Controls.Add(DateOfPaymentTextBox);
			Controls.Add(DateOfSaleTextBox);
			Controls.Add(CreateInvoiceLabel);
			Controls.Add(InvoiceListLabel);
			Controls.Add(InvoiceLabel);
			Controls.Add(InvoicesTable);
			Name = "BillingControl";
			Size = new Size(965, 870);
			Load += BillingControl_Load;
			Click += BillingControl_Click;
			MouseClick += BillingControl_MouseClick;
			((System.ComponentModel.ISupportInitialize)InvoicesTable).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private ComboBox ClientsComboBox;
		private DataGridView InvoicesTable;
        private Label InvoiceLabel;
        private Label InvoiceListLabel;
        private Label CreateInvoiceLabel;
        private TextBox DateOfSaleTextBox;
        private TextBox DateOfPaymentTextBox;
        private RichTextBox RemarksTextBox;
        private Button button2;
        private Button PaymentCalendarButton;
        private FlowLayoutPanel ItemsFlowLayoutPanel;
        private Button AddItemButton;
        private Button AddInvoiceButton;
        private Label DescriptionLabel;
        private Label QuantityLabel;
        private Label UnitPriceLabel;
        private MonthCalendar SellDateCalendar;
        private MonthCalendar PaymentCalendar;
		private RadioButton TransferCheckBox;
		private RadioButton CashCheckBox;
		private Label label1;
	}
}
