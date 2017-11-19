namespace GameClient
{
    partial class gameClient
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
            this.buttonGuess = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxMaximum = new System.Windows.Forms.TextBox();
            this.textBoxCorrect = new System.Windows.Forms.TextBox();
            this.textBoxMinimum = new System.Windows.Forms.TextBox();
            this.textBoxDisplay = new System.Windows.Forms.TextBox();
            this.trackBarGuess = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGuess)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGuess
            // 
            this.buttonGuess.Location = new System.Drawing.Point(272, 209);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(100, 23);
            this.buttonGuess.TabIndex = 19;
            this.buttonGuess.Text = "Guess";
            this.buttonGuess.UseVisualStyleBackColor = true;
            this.buttonGuess.Click += new System.EventHandler(this.buttonGuess_Click_1);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(465, 34);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(100, 23);
            this.buttonConnect.TabIndex = 18;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(87, 34);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(336, 20);
            this.textBoxIPAddress.TabIndex = 17;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(25, 34);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(45, 13);
            this.labelAddress.TabIndex = 16;
            this.labelAddress.Text = "Address";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(25, 28);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 15;
            // 
            // textBoxMaximum
            // 
            this.textBoxMaximum.Location = new System.Drawing.Point(495, 173);
            this.textBoxMaximum.Name = "textBoxMaximum";
            this.textBoxMaximum.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaximum.TabIndex = 14;
            // 
            // textBoxCorrect
            // 
            this.textBoxCorrect.Location = new System.Drawing.Point(272, 173);
            this.textBoxCorrect.Name = "textBoxCorrect";
            this.textBoxCorrect.Size = new System.Drawing.Size(100, 20);
            this.textBoxCorrect.TabIndex = 13;
            // 
            // textBoxMinimum
            // 
            this.textBoxMinimum.Location = new System.Drawing.Point(58, 173);
            this.textBoxMinimum.Name = "textBoxMinimum";
            this.textBoxMinimum.Size = new System.Drawing.Size(100, 20);
            this.textBoxMinimum.TabIndex = 12;
            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Enabled = false;
            this.textBoxDisplay.Location = new System.Drawing.Point(41, 37);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ReadOnly = true;
            this.textBoxDisplay.Size = new System.Drawing.Size(578, 20);
            this.textBoxDisplay.TabIndex = 11;
            // 
            // trackBarGuess
            // 
            this.trackBarGuess.Location = new System.Drawing.Point(30, 89);
            this.trackBarGuess.Maximum = 1000;
            this.trackBarGuess.Name = "trackBarGuess";
            this.trackBarGuess.Size = new System.Drawing.Size(589, 45);
            this.trackBarGuess.TabIndex = 10;
            this.trackBarGuess.TickFrequency = 10;
            this.trackBarGuess.Scroll += new System.EventHandler(this.trackBarGuess_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.textBoxIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(30, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 72);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // gameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 379);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonGuess);
            this.Controls.Add(this.textBoxMaximum);
            this.Controls.Add(this.textBoxCorrect);
            this.Controls.Add(this.textBoxMinimum);
            this.Controls.Add(this.textBoxDisplay);
            this.Controls.Add(this.trackBarGuess);
            this.Name = "gameClient";
            this.Text = "Guess Game!!!";
            this.Load += new System.EventHandler(this.gameClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGuess)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuess;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxMaximum;
        private System.Windows.Forms.TextBox textBoxCorrect;
        private System.Windows.Forms.TextBox textBoxMinimum;
        private System.Windows.Forms.TextBox textBoxDisplay;
        private System.Windows.Forms.TrackBar trackBarGuess;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

