namespace WindowsFormsApplication1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSortName = new System.Windows.Forms.Button();
            this.btnSortAtomic = new System.Windows.Forms.Button();
            this.btnSingleChar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMolarMass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 431);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.TabStop = false;
            // 
            // btnSortName
            // 
            this.btnSortName.Location = new System.Drawing.Point(641, 12);
            this.btnSortName.Name = "btnSortName";
            this.btnSortName.Size = new System.Drawing.Size(178, 26);
            this.btnSortName.TabIndex = 1;
            this.btnSortName.Text = "Sort By Name";
            this.btnSortName.UseVisualStyleBackColor = true;
            this.btnSortName.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSortAtomic
            // 
            this.btnSortAtomic.Location = new System.Drawing.Point(641, 77);
            this.btnSortAtomic.Name = "btnSortAtomic";
            this.btnSortAtomic.Size = new System.Drawing.Size(178, 26);
            this.btnSortAtomic.TabIndex = 3;
            this.btnSortAtomic.Text = "Sort By Atomic #";
            this.btnSortAtomic.UseVisualStyleBackColor = true;
            this.btnSortAtomic.Click += new System.EventHandler(this.btnSortAtomic_Click);
            // 
            // btnSingleChar
            // 
            this.btnSingleChar.Location = new System.Drawing.Point(641, 45);
            this.btnSingleChar.Name = "btnSingleChar";
            this.btnSingleChar.Size = new System.Drawing.Size(178, 26);
            this.btnSingleChar.TabIndex = 2;
            this.btnSingleChar.Text = "Single Character Symbols";
            this.btnSingleChar.UseVisualStyleBackColor = true;
            this.btnSingleChar.Click += new System.EventHandler(this.btnSingleChar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chemical Formula:";
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(109, 449);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(526, 20);
            this.tbInput.TabIndex = 0;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Approx. Molar Mass:";
            // 
            // tbMolarMass
            // 
            this.tbMolarMass.BackColor = System.Drawing.Color.Black;
            this.tbMolarMass.ForeColor = System.Drawing.Color.White;
            this.tbMolarMass.Location = new System.Drawing.Point(641, 449);
            this.tbMolarMass.Name = "tbMolarMass";
            this.tbMolarMass.Size = new System.Drawing.Size(177, 20);
            this.tbMolarMass.TabIndex = 5;
            this.tbMolarMass.TabStop = false;
            this.tbMolarMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 483);
            this.Controls.Add(this.tbMolarMass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSingleChar);
            this.Controls.Add(this.btnSortAtomic);
            this.Controls.Add(this.btnSortName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Molar Mass Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSortName;
        private System.Windows.Forms.Button btnSortAtomic;
        private System.Windows.Forms.Button btnSingleChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMolarMass;
    }
}

