namespace FoodiesReview
{
    partial class UserHomepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserHomepage));
            this.label1 = new System.Windows.Forms.Label();
            this.ByNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ByRestaurantButton = new System.Windows.Forms.Button();
            this.ByLocationButton = new System.Windows.Forms.Button();
            this.ByLocationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AllRestaurantButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(466, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // ByNameTextBox
            // 
            this.ByNameTextBox.Location = new System.Drawing.Point(270, 112);
            this.ByNameTextBox.Name = "ByNameTextBox";
            this.ByNameTextBox.Size = new System.Drawing.Size(499, 20);
            this.ByNameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ByRestaurantButton
            // 
            this.ByRestaurantButton.Location = new System.Drawing.Point(809, 109);
            this.ByRestaurantButton.Name = "ByRestaurantButton";
            this.ByRestaurantButton.Size = new System.Drawing.Size(132, 23);
            this.ByRestaurantButton.TabIndex = 3;
            this.ByRestaurantButton.Text = "By Restaurant";
            this.ByRestaurantButton.UseVisualStyleBackColor = true;
            this.ByRestaurantButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ByLocationButton
            // 
            this.ByLocationButton.Location = new System.Drawing.Point(809, 190);
            this.ByLocationButton.Name = "ByLocationButton";
            this.ByLocationButton.Size = new System.Drawing.Size(132, 23);
            this.ByLocationButton.TabIndex = 4;
            this.ByLocationButton.Text = "By Location";
            this.ByLocationButton.UseVisualStyleBackColor = true;
            this.ByLocationButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ByLocationTextBox
            // 
            this.ByLocationTextBox.Location = new System.Drawing.Point(270, 193);
            this.ByLocationTextBox.Name = "ByLocationTextBox";
            this.ByLocationTextBox.Size = new System.Drawing.Size(499, 20);
            this.ByLocationTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(508, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Or";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(270, 275);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(499, 304);
            this.listBox1.TabIndex = 7;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // AllRestaurantButton
            // 
            this.AllRestaurantButton.Location = new System.Drawing.Point(811, 402);
            this.AllRestaurantButton.Name = "AllRestaurantButton";
            this.AllRestaurantButton.Size = new System.Drawing.Size(132, 23);
            this.AllRestaurantButton.TabIndex = 13;
            this.AllRestaurantButton.Text = "All Restaurant";
            this.AllRestaurantButton.UseVisualStyleBackColor = true;
            this.AllRestaurantButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(270, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Double Click On The List Item To Check Ratings";
            // 
            // UserHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AllRestaurantButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ByLocationTextBox);
            this.Controls.Add(this.ByLocationButton);
            this.Controls.Add(this.ByRestaurantButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ByNameTextBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserHomepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserHomepage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ByNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ByRestaurantButton;
        private System.Windows.Forms.Button ByLocationButton;
        private System.Windows.Forms.TextBox ByLocationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button AllRestaurantButton;
        private System.Windows.Forms.Label label3;
    }
}