namespace FoodiesReview
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.PersonName = new System.Windows.Forms.TextBox();
            this.PersonEmail = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Age = new System.Windows.Forms.TextBox();
            this.RadioButtonMale = new System.Windows.Forms.RadioButton();
            this.RadioButtonFemale = new System.Windows.Forms.RadioButton();
            this.TypeGroupBox = new System.Windows.Forms.GroupBox();
            this.RadioButtonUser = new System.Windows.Forms.RadioButton();
            this.RadioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.GenderGroupBox = new System.Windows.Forms.GroupBox();
            this.TypeGroupBox.SuspendLayout();
            this.GenderGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(371, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(374, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(353, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(380, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Age";
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.Location = new System.Drawing.Point(406, 183);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(211, 55);
            this.RegisterLabel.TabIndex = 6;
            this.RegisterLabel.Text = "Register";
            // 
            // PersonName
            // 
            this.PersonName.Location = new System.Drawing.Point(416, 263);
            this.PersonName.Name = "PersonName";
            this.PersonName.Size = new System.Drawing.Size(193, 20);
            this.PersonName.TabIndex = 7;
            // 
            // PersonEmail
            // 
            this.PersonEmail.Location = new System.Drawing.Point(416, 304);
            this.PersonEmail.Name = "PersonEmail";
            this.PersonEmail.Size = new System.Drawing.Size(193, 20);
            this.PersonEmail.TabIndex = 8;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(416, 343);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(193, 20);
            this.Password.TabIndex = 9;
            // 
            // Age
            // 
            this.Age.Location = new System.Drawing.Point(416, 382);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(193, 20);
            this.Age.TabIndex = 10;
            // 
            // RadioButtonMale
            // 
            this.RadioButtonMale.AutoSize = true;
            this.RadioButtonMale.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonMale.Location = new System.Drawing.Point(14, 19);
            this.RadioButtonMale.Name = "RadioButtonMale";
            this.RadioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.RadioButtonMale.TabIndex = 11;
            this.RadioButtonMale.TabStop = true;
            this.RadioButtonMale.Text = "Male";
            this.RadioButtonMale.UseVisualStyleBackColor = false;
            // 
            // RadioButtonFemale
            // 
            this.RadioButtonFemale.AutoSize = true;
            this.RadioButtonFemale.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonFemale.Location = new System.Drawing.Point(122, 19);
            this.RadioButtonFemale.Name = "RadioButtonFemale";
            this.RadioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.RadioButtonFemale.TabIndex = 12;
            this.RadioButtonFemale.TabStop = true;
            this.RadioButtonFemale.Text = "Female";
            this.RadioButtonFemale.UseVisualStyleBackColor = false;
            // 
            // TypeGroupBox
            // 
            this.TypeGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.TypeGroupBox.Controls.Add(this.RadioButtonUser);
            this.TypeGroupBox.Controls.Add(this.RadioButtonAdmin);
            this.TypeGroupBox.Location = new System.Drawing.Point(416, 485);
            this.TypeGroupBox.Name = "TypeGroupBox";
            this.TypeGroupBox.Size = new System.Drawing.Size(193, 51);
            this.TypeGroupBox.TabIndex = 13;
            this.TypeGroupBox.TabStop = false;
            this.TypeGroupBox.Text = "Type";
            // 
            // RadioButtonUser
            // 
            this.RadioButtonUser.AutoSize = true;
            this.RadioButtonUser.Location = new System.Drawing.Point(122, 21);
            this.RadioButtonUser.Name = "RadioButtonUser";
            this.RadioButtonUser.Size = new System.Drawing.Size(47, 17);
            this.RadioButtonUser.TabIndex = 1;
            this.RadioButtonUser.TabStop = true;
            this.RadioButtonUser.Text = "User";
            this.RadioButtonUser.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAdmin
            // 
            this.RadioButtonAdmin.AutoSize = true;
            this.RadioButtonAdmin.Location = new System.Drawing.Point(14, 21);
            this.RadioButtonAdmin.Name = "RadioButtonAdmin";
            this.RadioButtonAdmin.Size = new System.Drawing.Size(54, 17);
            this.RadioButtonAdmin.TabIndex = 0;
            this.RadioButtonAdmin.TabStop = true;
            this.RadioButtonAdmin.Text = "Admin";
            this.RadioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(416, 558);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 14;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.button1_Click);
            this.submitButton.Enter += new System.EventHandler(this.button1_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(534, 558);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // GenderGroupBox
            // 
            this.GenderGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.GenderGroupBox.Controls.Add(this.RadioButtonFemale);
            this.GenderGroupBox.Controls.Add(this.RadioButtonMale);
            this.GenderGroupBox.Location = new System.Drawing.Point(416, 421);
            this.GenderGroupBox.Name = "GenderGroupBox";
            this.GenderGroupBox.Size = new System.Drawing.Size(193, 51);
            this.GenderGroupBox.TabIndex = 16;
            this.GenderGroupBox.TabStop = false;
            this.GenderGroupBox.Text = "Gender";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.GenderGroupBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.TypeGroupBox);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.PersonEmail);
            this.Controls.Add(this.PersonName);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.TypeGroupBox.ResumeLayout(false);
            this.TypeGroupBox.PerformLayout();
            this.GenderGroupBox.ResumeLayout(false);
            this.GenderGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.TextBox PersonName;
        private System.Windows.Forms.TextBox PersonEmail;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Age;
        private System.Windows.Forms.RadioButton RadioButtonMale;
        private System.Windows.Forms.RadioButton RadioButtonFemale;
        private System.Windows.Forms.GroupBox TypeGroupBox;
        private System.Windows.Forms.RadioButton RadioButtonUser;
        private System.Windows.Forms.RadioButton RadioButtonAdmin;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.GroupBox GenderGroupBox;
    }
}