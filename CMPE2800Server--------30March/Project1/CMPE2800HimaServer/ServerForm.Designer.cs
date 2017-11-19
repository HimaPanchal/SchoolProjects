namespace CMPE2800HimaServer
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.tbMessages = new System.Windows.Forms.MaskedTextBox();
            this.buttonPort = new System.Windows.Forms.Button();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblPortTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMessages
            // 
            this.tbMessages.Location = new System.Drawing.Point(12, 321);
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(756, 20);
            this.tbMessages.TabIndex = 5;
            // 
            // buttonPort
            // 
            this.buttonPort.Location = new System.Drawing.Point(12, 366);
            this.buttonPort.Name = "buttonPort";
            this.buttonPort.Size = new System.Drawing.Size(756, 31);
            this.buttonPort.TabIndex = 4;
            this.buttonPort.Text = "Port";
            this.buttonPort.UseVisualStyleBackColor = true;
            this.buttonPort.Click += new System.EventHandler(this.buttonPort_Click);
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(12, 12);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(756, 303);
            this.listBoxDisplay.TabIndex = 3;
          //  this.listBoxDisplay.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplay_SelectedIndexChanged);
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 50;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(774, 41);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(87, 20);
            this.tbPort.TabIndex = 10;
            // 
            // lblPortTitle
            // 
            this.lblPortTitle.AutoSize = true;
            this.lblPortTitle.Location = new System.Drawing.Point(771, 25);
            this.lblPortTitle.Name = "lblPortTitle";
            this.lblPortTitle.Size = new System.Drawing.Size(32, 13);
            this.lblPortTitle.TabIndex = 9;
            this.lblPortTitle.Text = "Port: ";
          //  this.lblPortTitle.Click += new System.EventHandler(this.lblPortTitle_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 421);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lblPortTitle);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.buttonPort);
            this.Controls.Add(this.listBoxDisplay);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbMessages;
        private System.Windows.Forms.Button buttonPort;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblPortTitle;
    }
}

