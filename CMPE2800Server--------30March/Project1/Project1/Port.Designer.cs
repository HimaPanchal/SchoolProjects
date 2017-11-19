namespace Project1
{
    partial class Port
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
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonListening = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(56, 31);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(316, 20);
            this.textBoxPort.TabIndex = 0;
            // 
            // buttonListening
            // 
            this.buttonListening.Location = new System.Drawing.Point(83, 127);
            this.buttonListening.Name = "buttonListening";
            this.buttonListening.Size = new System.Drawing.Size(261, 34);
            this.buttonListening.TabIndex = 1;
            this.buttonListening.Text = "Begin Listening";
            this.buttonListening.UseVisualStyleBackColor = true;
            this.buttonListening.Click += new System.EventHandler(this.buttonListening_Click);
            // 
            // Port
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 238);
            this.Controls.Add(this.buttonListening);
            this.Controls.Add(this.textBoxPort);
            this.Name = "Port";
            this.Text = "Port";
            this.Load += new System.EventHandler(this.Port_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonListening;
    }
}