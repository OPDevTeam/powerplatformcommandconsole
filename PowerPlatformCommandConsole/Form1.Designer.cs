namespace PowerPlatformCommandConsole
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.LocationsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PPVerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BootstrapButton = new System.Windows.Forms.Button();
            this.PullButton = new System.Windows.Forms.Button();
            this.BuildButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UpdateToPPVerTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveLKGsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LocationsComboBox
            // 
            this.LocationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationsComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationsComboBox.FormattingEnabled = true;
            this.LocationsComboBox.Location = new System.Drawing.Point(12, 45);
            this.LocationsComboBox.Name = "LocationsComboBox";
            this.LocationsComboBox.Size = new System.Drawing.Size(244, 24);
            this.LocationsComboBox.TabIndex = 0;
            this.LocationsComboBox.SelectedIndexChanged += new System.EventHandler(this.LocationsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Locations:";
            // 
            // PPVerTextBox
            // 
            this.PPVerTextBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPVerTextBox.Location = new System.Drawing.Point(12, 110);
            this.PPVerTextBox.Name = "PPVerTextBox";
            this.PPVerTextBox.Size = new System.Drawing.Size(244, 26);
            this.PPVerTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version:";
            // 
            // BootstrapButton
            // 
            this.BootstrapButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BootstrapButton.Location = new System.Drawing.Point(16, 176);
            this.BootstrapButton.Name = "BootstrapButton";
            this.BootstrapButton.Size = new System.Drawing.Size(117, 23);
            this.BootstrapButton.TabIndex = 4;
            this.BootstrapButton.Text = "Bootstrap";
            this.BootstrapButton.UseVisualStyleBackColor = true;
            this.BootstrapButton.Click += new System.EventHandler(this.BootstrapButton_Click);
            // 
            // PullButton
            // 
            this.PullButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PullButton.Location = new System.Drawing.Point(16, 205);
            this.PullButton.Name = "PullButton";
            this.PullButton.Size = new System.Drawing.Size(117, 23);
            this.PullButton.TabIndex = 5;
            this.PullButton.Text = "Pull";
            this.PullButton.UseVisualStyleBackColor = true;
            this.PullButton.Click += new System.EventHandler(this.PullButton_Click);
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildButton.Location = new System.Drawing.Point(16, 234);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(117, 23);
            this.BuildButton.TabIndex = 6;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(612, 112);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(117, 23);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // UpdateToPPVerTextBox
            // 
            this.UpdateToPPVerTextBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateToPPVerTextBox.Location = new System.Drawing.Point(294, 110);
            this.UpdateToPPVerTextBox.Name = "UpdateToPPVerTextBox";
            this.UpdateToPPVerTextBox.Size = new System.Drawing.Size(244, 26);
            this.UpdateToPPVerTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Update To Version:";
            // 
            // SaveLKGsButton
            // 
            this.SaveLKGsButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLKGsButton.Location = new System.Drawing.Point(16, 263);
            this.SaveLKGsButton.Name = "SaveLKGsButton";
            this.SaveLKGsButton.Size = new System.Drawing.Size(117, 23);
            this.SaveLKGsButton.TabIndex = 10;
            this.SaveLKGsButton.Text = "Save LKGs";
            this.SaveLKGsButton.UseVisualStyleBackColor = true;
            this.SaveLKGsButton.Click += new System.EventHandler(this.SaveLKGsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveLKGsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpdateToPPVerTextBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.PullButton);
            this.Controls.Add(this.BootstrapButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PPVerTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocationsComboBox);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PowerPlatform Command Console";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LocationsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PPVerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BootstrapButton;
        private System.Windows.Forms.Button PullButton;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox UpdateToPPVerTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveLKGsButton;
        private System.Windows.Forms.Button button1;
    }
}

