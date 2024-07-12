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
            button1 = new Button();
            InvoicesTable = new DataGridView();
            InvoiceLabel = new Label();
            InvoiceListLabel = new Label();
            label1 = new Label();
            DateOfSaleTextBox = new TextBox();
            DateOfPaymentTextBox = new TextBox();
            RemarksTextBox = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            ItemsFlowLayoutPanel = new FlowLayoutPanel();
            AddRowButton = new Button();
            AddInvoiceButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)InvoicesTable).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Location = new Point(319, 18);
            button1.Name = "button1";
            button1.Size = new Size(83, 66);
            button1.TabIndex = 0;
            button1.Text = "Test invoice";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // InvoicesTable
            // 
            InvoicesTable.AllowUserToAddRows = false;
            InvoicesTable.AllowUserToDeleteRows = false;
            InvoicesTable.AllowUserToResizeColumns = false;
            InvoicesTable.AllowUserToResizeRows = false;
            InvoicesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InvoicesTable.Location = new Point(16, 112);
            InvoicesTable.MultiSelect = false;
            InvoicesTable.Name = "InvoicesTable";
            InvoicesTable.Size = new Size(463, 755);
            InvoicesTable.TabIndex = 1;
            InvoicesTable.CellClick += InvoicesTable_CellClick;
            InvoicesTable.DataBindingComplete += InvoicesTable_DataBindingComplete;
            // 
            // InvoiceLabel
            // 
            InvoiceLabel.AutoSize = true;
            InvoiceLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            InvoiceLabel.Location = new Point(16, 88);
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
            InvoiceListLabel.Size = new Size(185, 45);
            InvoiceListLabel.TabIndex = 3;
            InvoiceListLabel.Text = "Invoices list";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(674, 18);
            label1.Name = "label1";
            label1.Size = new Size(221, 45);
            label1.TabIndex = 4;
            label1.Text = "Create invoice";
            // 
            // DateOfSaleTextBox
            // 
            DateOfSaleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DateOfSaleTextBox.Location = new Point(498, 112);
            DateOfSaleTextBox.Name = "DateOfSaleTextBox";
            DateOfSaleTextBox.PlaceholderText = "Sell date (YYYY-MM-DD)";
            DateOfSaleTextBox.Size = new Size(261, 29);
            DateOfSaleTextBox.TabIndex = 5;
            // 
            // DateOfPaymentTextBox
            // 
            DateOfPaymentTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            DateOfPaymentTextBox.Location = new Point(498, 163);
            DateOfPaymentTextBox.Name = "DateOfPaymentTextBox";
            DateOfPaymentTextBox.PlaceholderText = "Payment date (YYYY-MM-DD)";
            DateOfPaymentTextBox.Size = new Size(261, 29);
            DateOfPaymentTextBox.TabIndex = 6;
            // 
            // RemarksTextBox
            // 
            RemarksTextBox.Location = new Point(498, 210);
            RemarksTextBox.Name = "RemarksTextBox";
            RemarksTextBox.Size = new Size(298, 109);
            RemarksTextBox.TabIndex = 7;
            RemarksTextBox.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(756, 112);
            button2.Name = "button2";
            button2.Size = new Size(40, 29);
            button2.TabIndex = 8;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(756, 163);
            button3.Name = "button3";
            button3.Size = new Size(40, 30);
            button3.TabIndex = 9;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // ItemsFlowLayoutPanel
            // 
            ItemsFlowLayoutPanel.AutoScroll = true;
            ItemsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            ItemsFlowLayoutPanel.Location = new Point(498, 354);
            ItemsFlowLayoutPanel.Name = "ItemsFlowLayoutPanel";
            ItemsFlowLayoutPanel.Size = new Size(450, 440);
            ItemsFlowLayoutPanel.TabIndex = 10;
            // 
            // AddRowButton
            // 
            AddRowButton.Location = new Point(498, 810);
            AddRowButton.Name = "AddRowButton";
            AddRowButton.Size = new Size(92, 41);
            AddRowButton.TabIndex = 11;
            AddRowButton.Text = "Add row";
            AddRowButton.UseVisualStyleBackColor = true;
            AddRowButton.Click += AddRowButton_Click;
            // 
            // AddInvoiceButton
            // 
            AddInvoiceButton.Location = new Point(856, 810);
            AddInvoiceButton.Name = "AddInvoiceButton";
            AddInvoiceButton.Size = new Size(92, 41);
            AddInvoiceButton.TabIndex = 12;
            AddInvoiceButton.Text = "Add invoice";
            AddInvoiceButton.UseVisualStyleBackColor = true;
            AddInvoiceButton.Click += AddInvoiceButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 330);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 13;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(664, 330);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 14;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(802, 330);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 15;
            label4.Text = "Unit Price";
            // 
            // BillingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(AddInvoiceButton);
            Controls.Add(AddRowButton);
            Controls.Add(ItemsFlowLayoutPanel);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(RemarksTextBox);
            Controls.Add(DateOfPaymentTextBox);
            Controls.Add(DateOfSaleTextBox);
            Controls.Add(label1);
            Controls.Add(InvoiceListLabel);
            Controls.Add(InvoiceLabel);
            Controls.Add(InvoicesTable);
            Controls.Add(button1);
            Name = "BillingControl";
            Size = new Size(965, 870);
            Load += BillingControl_Load;
            ((System.ComponentModel.ISupportInitialize)InvoicesTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView InvoicesTable;
        private Label InvoiceLabel;
        private Label InvoiceListLabel;
        private Label label1;
        private TextBox DateOfSaleTextBox;
        private TextBox DateOfPaymentTextBox;
        private RichTextBox RemarksTextBox;
        private Button button2;
        private Button button3;
        private FlowLayoutPanel ItemsFlowLayoutPanel;
        private Button AddRowButton;
        private Button AddInvoiceButton;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
