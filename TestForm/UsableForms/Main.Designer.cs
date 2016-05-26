namespace TestForm
{
    partial class Main
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
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonTours = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Location = new System.Drawing.Point(34, 40);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(138, 113);
            this.buttonEmployee.TabIndex = 0;
            this.buttonEmployee.Text = "Employees";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonTours
            // 
            this.buttonTours.Location = new System.Drawing.Point(34, 187);
            this.buttonTours.Name = "buttonTours";
            this.buttonTours.Size = new System.Drawing.Size(138, 111);
            this.buttonTours.TabIndex = 1;
            this.buttonTours.Text = "Tours";
            this.buttonTours.UseVisualStyleBackColor = true;
            this.buttonTours.Click += new System.EventHandler(this.buttonTours_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTours);
            this.Controls.Add(this.buttonEmployee);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonTours;
        private System.Windows.Forms.Button button1;
    }
}