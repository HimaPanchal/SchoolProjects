namespace CMPE2800HimaPanchalICAMultidraw
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
            this.tbServerCommunication = new System.Windows.Forms.TextBox();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.tsConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsThickness = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsFramesReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsFragments = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsAverage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.cdColors = new System.Windows.Forms.ColorDialog();
            this.stsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServerCommunication
            // 
            this.tbServerCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerCommunication.Location = new System.Drawing.Point(0, 448);
            this.tbServerCommunication.Name = "tbServerCommunication";
            this.tbServerCommunication.ReadOnly = true;
            this.tbServerCommunication.Size = new System.Drawing.Size(870, 20);
            this.tbServerCommunication.TabIndex = 2;
            this.tbServerCommunication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbServerCommunication.TextChanged += new System.EventHandler(this.tbServerCommunication_TextChanged);
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnect,
            this.tsColor,
            this.tsThickness,
            this.tsFramesReceived,
            this.tsFragments,
            this.tsAverage,
            this.tsBytes});
            this.stsStatus.Location = new System.Drawing.Point(0, 499);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(867, 24);
            this.stsStatus.TabIndex = 3;
            this.stsStatus.Text = "Interface";
            this.stsStatus.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stsStatus_ItemClicked);
            // 
            // tsConnect
            // 
            this.tsConnect.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsConnect.Name = "tsConnect";
            this.tsConnect.Size = new System.Drawing.Size(117, 19);
            this.tsConnect.Spring = true;
            this.tsConnect.Text = "Connect";
            this.tsConnect.Click += new System.EventHandler(this.tsConnect_Click);
            // 
            // tsColor
            // 
            this.tsColor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsColor.ForeColor = System.Drawing.Color.Red;
            this.tsColor.Name = "tsColor";
            this.tsColor.Size = new System.Drawing.Size(117, 19);
            this.tsColor.Spring = true;
            this.tsColor.Text = "Color";
            // 
            // tsThickness
            // 
            this.tsThickness.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsThickness.Name = "tsThickness";
            this.tsThickness.Size = new System.Drawing.Size(117, 19);
            this.tsThickness.Spring = true;
            this.tsThickness.Text = "Thickness: ";
            // 
            // tsFramesReceived
            // 
            this.tsFramesReceived.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsFramesReceived.Name = "tsFramesReceived";
            this.tsFramesReceived.Size = new System.Drawing.Size(117, 19);
            this.tsFramesReceived.Spring = true;
            this.tsFramesReceived.Text = "Frames RX\'ed: ";
            // 
            // tsFragments
            // 
            this.tsFragments.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsFragments.Name = "tsFragments";
            this.tsFragments.Size = new System.Drawing.Size(117, 19);
            this.tsFragments.Spring = true;
            this.tsFragments.Text = "Fragments: ";
            // 
            // tsAverage
            // 
            this.tsAverage.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsAverage.Name = "tsAverage";
            this.tsAverage.Size = new System.Drawing.Size(117, 19);
            this.tsAverage.Spring = true;
            this.tsAverage.Text = "Destack Avg. : ";
            // 
            // tsBytes
            // 
            this.tsBytes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsBytes.Name = "tsBytes";
            this.tsBytes.Size = new System.Drawing.Size(117, 19);
            this.tsBytes.Spring = true;
            this.tsBytes.Text = "Bytes RX\'ed: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 523);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.tbServerCommunication);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerCommunication;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsConnect;
        private System.Windows.Forms.ToolStripStatusLabel tsColor;
        private System.Windows.Forms.ToolStripStatusLabel tsThickness;
        private System.Windows.Forms.ToolStripStatusLabel tsFramesReceived;
        private System.Windows.Forms.ToolStripStatusLabel tsFragments;
        private System.Windows.Forms.ToolStripStatusLabel tsAverage;
        private System.Windows.Forms.ToolStripStatusLabel tsBytes;
        private System.Windows.Forms.ColorDialog cdColors;
    }
}

