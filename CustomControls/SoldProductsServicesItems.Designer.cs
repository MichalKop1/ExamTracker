namespace ExamTracker.CustomControls
{
    partial class SoldProductsServicesItems
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
            QuantityTextBox = new TextBox();
            PricePerUnitTextBox = new TextBox();
            ItemsComboBox = new ComboBox();
            SuspendLayout();
            // 
            // QuantityTextBox
            // 
            QuantityTextBox.Location = new Point(154, 17);
            QuantityTextBox.Name = "QuantityTextBox";
            QuantityTextBox.Size = new Size(100, 23);
            QuantityTextBox.TabIndex = 1;
            QuantityTextBox.Text = "0";
            // 
            // PricePerUnitTextBox
            // 
            PricePerUnitTextBox.Location = new Point(299, 17);
            PricePerUnitTextBox.Name = "PricePerUnitTextBox";
            PricePerUnitTextBox.Size = new Size(100, 23);
            PricePerUnitTextBox.TabIndex = 2;
            PricePerUnitTextBox.Text = "0,00";
            // 
            // ItemsComboBox
            // 
            ItemsComboBox.FormattingEnabled = true;
            ItemsComboBox.Items.AddRange(new object[] { "Vending (GTU_24)", "Languages (GTU_12)", "Cleaning (GTU_8)" });
            ItemsComboBox.Location = new Point(15, 17);
            ItemsComboBox.Name = "ItemsComboBox";
            ItemsComboBox.Size = new Size(121, 23);
            ItemsComboBox.TabIndex = 4;
            // 
            // SoldProductsServicesItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(ItemsComboBox);
            Controls.Add(PricePerUnitTextBox);
            Controls.Add(QuantityTextBox);
            Name = "SoldProductsServicesItems";
            Size = new Size(420, 55);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox QuantityTextBox;
        private TextBox PricePerUnitTextBox;
        private ComboBox ItemsComboBox;
    }
}
