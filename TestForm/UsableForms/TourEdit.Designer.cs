namespace TestForm
{
    partial class TourEdit
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
            this.txtTourName = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtTourName
            // 
            this.txtTourName.Location = new System.Drawing.Point(148, 115);
            this.txtTourName.Name = "txtTourName";
            this.txtTourName.Size = new System.Drawing.Size(147, 22);
            this.txtTourName.TabIndex = 1;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(12, 20);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 17);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "ID";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(148, 158);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(147, 22);
            this.txtRate.TabIndex = 3;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 115);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 17);
            this.label.TabIndex = 5;
            this.label.Text = "Tour Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rate";
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(139, 211);
            this.Update.MaximumSize = new System.Drawing.Size(75, 23);
            this.Update.MinimumSize = new System.Drawing.Size(75, 23);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(220, 211);
            this.Cancel.MaximumSize = new System.Drawing.Size(75, 23);
            this.Cancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(148, 71);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(147, 24);
            this.comboBoxPort.TabIndex = 9;
            // 
            // TourEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(307, 262);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txtTourName);
            this.MaximumSize = new System.Drawing.Size(325, 307);
            this.MinimumSize = new System.Drawing.Size(325, 307);
            this.Name = "TourEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeEdit";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.TourEdit_Activated);
            this.Load += new System.EventHandler(this.EmployeeEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTourName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.Button Update;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox comboBoxPort;
    }
}