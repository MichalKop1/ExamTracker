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
            removeButton = new Button();
            SuspendLayout();
            // 
            // QuantityTextBox
            // 
            QuantityTextBox.Location = new Point(142, 17);
            QuantityTextBox.Name = "QuantityTextBox";
            QuantityTextBox.Size = new Size(100, 23);
            QuantityTextBox.TabIndex = 1;
            QuantityTextBox.Text = "0";
            // 
            // PricePerUnitTextBox
            // 
            PricePerUnitTextBox.Location = new Point(260, 17);
            PricePerUnitTextBox.Name = "PricePerUnitTextBox";
            PricePerUnitTextBox.Size = new Size(100, 23);
            PricePerUnitTextBox.TabIndex = 2;
            PricePerUnitTextBox.Text = "0,00";
            // 
            // ItemsComboBox
            // 
            ItemsComboBox.FormattingEnabled = true;
            ItemsComboBox.Location = new Point(3, 17);
            ItemsComboBox.Name = "ItemsComboBox";
            ItemsComboBox.Size = new Size(121, 23);
            ItemsComboBox.TabIndex = 4;
            // 
            // removeButton
            // 
            removeButton.FlatAppearance.BorderSize = 0;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Image = Properties.Resources.x_mark;
            removeButton.Location = new Point(379, 5);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(45, 45);
            removeButton.TabIndex = 5;
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // SoldProductsServicesItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(removeButton);
            Controls.Add(ItemsComboBox);
            Controls.Add(PricePerUnitTextBox);
            Controls.Add(QuantityTextBox);
            Name = "SoldProductsServicesItems";
            Size = new Size(437, 55);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox QuantityTextBox;
        private TextBox PricePerUnitTextBox;
        private ComboBox ItemsComboBox;
        private Button removeButton;
    }
}
