namespace Project1
{
    partial class Server
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
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.buttonPort = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(12, 19);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(692, 277);
            this.listBoxDisplay.TabIndex = 0;
            // 
            // buttonPort
            // 
            this.buttonPort.Location = new System.Drawing.Point(12, 362);
            this.buttonPort.Name = "buttonPort";
            this.buttonPort.Size = new System.Drawing.Size(692, 31);
            this.buttonPort.TabIndex = 1;
            this.buttonPort.Text = "Port";
            this.buttonPort.UseVisualStyleBackColor = true;
            this.buttonPort.Click += new System.EventHandler(this.buttonPort_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(12, 317);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(692, 20);
            this.maskedTextBox1.TabIndex = 2;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 421);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.buttonPort);
            this.Controls.Add(this.listBoxDisplay);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.Button buttonPort;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}