namespace ExamTracker.UI
{
    partial class ProfileControl
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
            profileLabel = new Label();
            manageInfoLabel = new Label();
            businessInfoLabel = new Label();
            businesNameLabel = new Label();
            BusinessNameBox = new TextBox();
            streetAdressLabel = new Label();
            StreetAddressRichTextBox = new RichTextBox();
            cityLabel = new Label();
            stateLabel = new Label();
            CityTextBox = new TextBox();
            StateTextBox = new TextBox();
            zipCodeLabel = new Label();
            ZipCodeTextBox = new TextBox();
            contactInfoLabel = new Label();
            contactNameLabel = new Label();
            ContactNameTextBox = new TextBox();
            label11 = new Label();
            phoneLabel = new Label();
            PhoneTextBox = new TextBox();
            EmailTextBox = new TextBox();
            saveChangesButton = new Button();
            SuspendLayout();
            // 
            // profileLabel
            // 
            profileLabel.AutoSize = true;
            profileLabel.Font = new Font("Arial", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            profileLabel.Location = new Point(36, 0);
            profileLabel.Name = "profileLabel";
            profileLabel.Size = new Size(124, 40);
            profileLabel.TabIndex = 0;
            profileLabel.Text = "Profile";
            // 
            // manageInfoLabel
            // 
            manageInfoLabel.AutoSize = true;
            manageInfoLabel.Font = new Font("Arial", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            manageInfoLabel.ForeColor = SystemColors.ControlDark;
            manageInfoLabel.Location = new Point(36, 54);
            manageInfoLabel.Name = "manageInfoLabel";
            manageInfoLabel.Size = new Size(208, 16);
            manageInfoLabel.TabIndex = 1;
            manageInfoLabel.Text = "Manage your profile information";
            // 
            // businessInfoLabel
            // 
            businessInfoLabel.AutoSize = true;
            businessInfoLabel.Font = new Font("Arial", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            businessInfoLabel.Location = new Point(36, 88);
            businessInfoLabel.Name = "businessInfoLabel";
            businessInfoLabel.Size = new Size(254, 28);
            businessInfoLabel.TabIndex = 2;
            businessInfoLabel.Text = "Business information";
            // 
            // businesNameLabel
            // 
            businesNameLabel.AutoSize = true;
            businesNameLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            businesNameLabel.Location = new Point(36, 136);
            businesNameLabel.Name = "businesNameLabel";
            businesNameLabel.Size = new Size(154, 23);
            businesNameLabel.TabIndex = 3;
            businesNameLabel.Text = "Business name";
            // 
            // BusinessNameBox
            // 
            BusinessNameBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            BusinessNameBox.Location = new Point(36, 179);
            BusinessNameBox.Name = "BusinessNameBox";
            BusinessNameBox.PlaceholderText = "Your business name";
            BusinessNameBox.Size = new Size(431, 26);
            BusinessNameBox.TabIndex = 4;
            // 
            // streetAdressLabel
            // 
            streetAdressLabel.AutoSize = true;
            streetAdressLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            streetAdressLabel.Location = new Point(36, 246);
            streetAdressLabel.Name = "streetAdressLabel";
            streetAdressLabel.Size = new Size(148, 23);
            streetAdressLabel.TabIndex = 5;
            streetAdressLabel.Text = "Street Address";
            // 
            // StreetAddressRichTextBox
            // 
            StreetAddressRichTextBox.BorderStyle = BorderStyle.FixedSingle;
            StreetAddressRichTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            StreetAddressRichTextBox.Location = new Point(36, 287);
            StreetAddressRichTextBox.Name = "StreetAddressRichTextBox";
            StreetAddressRichTextBox.Size = new Size(431, 149);
            StreetAddressRichTextBox.TabIndex = 6;
            StreetAddressRichTextBox.Text = "";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            cityLabel.Location = new Point(42, 461);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(47, 23);
            cityLabel.TabIndex = 7;
            cityLabel.Text = "City";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            stateLabel.Location = new Point(259, 461);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(57, 23);
            stateLabel.TabIndex = 8;
            stateLabel.Text = "State";
            // 
            // CityTextBox
            // 
            CityTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            CityTextBox.Location = new Point(36, 489);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.PlaceholderText = "Phoenix";
            CityTextBox.Size = new Size(208, 26);
            CityTextBox.TabIndex = 9;
            // 
            // StateTextBox
            // 
            StateTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            StateTextBox.Location = new Point(259, 489);
            StateTextBox.Name = "StateTextBox";
            StateTextBox.PlaceholderText = "Arizona";
            StateTextBox.Size = new Size(208, 26);
            StateTextBox.TabIndex = 10;
            // 
            // zipCodeLabel
            // 
            zipCodeLabel.AutoSize = true;
            zipCodeLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            zipCodeLabel.Location = new Point(42, 545);
            zipCodeLabel.Name = "zipCodeLabel";
            zipCodeLabel.Size = new Size(94, 23);
            zipCodeLabel.TabIndex = 11;
            zipCodeLabel.Text = "Zip Code";
            // 
            // ZipCodeTextBox
            // 
            ZipCodeTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ZipCodeTextBox.Location = new Point(36, 573);
            ZipCodeTextBox.Name = "ZipCodeTextBox";
            ZipCodeTextBox.PlaceholderText = "51882";
            ZipCodeTextBox.Size = new Size(431, 26);
            ZipCodeTextBox.TabIndex = 12;
            // 
            // contactInfoLabel
            // 
            contactInfoLabel.AutoSize = true;
            contactInfoLabel.Font = new Font("Arial", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            contactInfoLabel.Location = new Point(42, 621);
            contactInfoLabel.Name = "contactInfoLabel";
            contactInfoLabel.Size = new Size(238, 28);
            contactInfoLabel.TabIndex = 13;
            contactInfoLabel.Text = "Contact information";
            // 
            // contactNameLabel
            // 
            contactNameLabel.AutoSize = true;
            contactNameLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            contactNameLabel.Location = new Point(42, 673);
            contactNameLabel.Name = "contactNameLabel";
            contactNameLabel.Size = new Size(141, 23);
            contactNameLabel.TabIndex = 14;
            contactNameLabel.Text = "Contact Name";
            // 
            // ContactNameTextBox
            // 
            ContactNameTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ContactNameTextBox.Location = new Point(36, 699);
            ContactNameTextBox.Name = "ContactNameTextBox";
            ContactNameTextBox.PlaceholderText = "John Smith";
            ContactNameTextBox.Size = new Size(431, 26);
            ContactNameTextBox.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label11.Location = new Point(42, 753);
            label11.Name = "label11";
            label11.Size = new Size(64, 23);
            label11.TabIndex = 16;
            label11.Text = "Email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Arial", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            phoneLabel.Location = new Point(259, 753);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(70, 23);
            phoneLabel.TabIndex = 17;
            phoneLabel.Text = "Phone";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            PhoneTextBox.Location = new Point(259, 779);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.PlaceholderText = "(415) 123 - 4567";
            PhoneTextBox.Size = new Size(208, 26);
            PhoneTextBox.TabIndex = 19;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            EmailTextBox.Location = new Point(36, 779);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.PlaceholderText = "john@hotmail.com";
            EmailTextBox.Size = new Size(208, 26);
            EmailTextBox.TabIndex = 18;
            // 
            // saveChangesButton
            // 
            saveChangesButton.BackColor = Color.DodgerBlue;
            saveChangesButton.FlatAppearance.BorderSize = 0;
            saveChangesButton.FlatStyle = FlatStyle.Flat;
            saveChangesButton.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            saveChangesButton.Location = new Point(501, 815);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(103, 42);
            saveChangesButton.TabIndex = 20;
            saveChangesButton.Text = "Save";
            saveChangesButton.UseVisualStyleBackColor = false;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // ProfileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(saveChangesButton);
            Controls.Add(PhoneTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(phoneLabel);
            Controls.Add(label11);
            Controls.Add(ContactNameTextBox);
            Controls.Add(contactNameLabel);
            Controls.Add(contactInfoLabel);
            Controls.Add(ZipCodeTextBox);
            Controls.Add(zipCodeLabel);
            Controls.Add(StateTextBox);
            Controls.Add(CityTextBox);
            Controls.Add(stateLabel);
            Controls.Add(cityLabel);
            Controls.Add(StreetAddressRichTextBox);
            Controls.Add(streetAdressLabel);
            Controls.Add(BusinessNameBox);
            Controls.Add(businesNameLabel);
            Controls.Add(businessInfoLabel);
            Controls.Add(manageInfoLabel);
            Controls.Add(profileLabel);
            Name = "ProfileControl";
            Size = new Size(617, 870);
            Load += ProfileControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label profileLabel;
        private Label manageInfoLabel;
        private Label businessInfoLabel;
        private Label businesNameLabel;
        private TextBox BusinessNameBox;
        private Label streetAdressLabel;
        private RichTextBox StreetAddressRichTextBox;
        private Label cityLabel;
        private Label stateLabel;
        private TextBox CityTextBox;
        private TextBox StateTextBox;
        private Label zipCodeLabel;
        private TextBox ZipCodeTextBox;
        private Label contactInfoLabel;
        private Label contactNameLabel;
        private TextBox ContactNameTextBox;
        private Label label11;
        private Label phoneLabel;
        private TextBox PhoneTextBox;
        private TextBox EmailTextBox;
        private Button saveChangesButton;
    }
}
