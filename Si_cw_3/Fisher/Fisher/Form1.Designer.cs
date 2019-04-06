namespace Fisher
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
            this.OFDfish = new System.Windows.Forms.OpenFileDialog();
            this.ofdBtn = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.path1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownFisher = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFisher)).BeginInit();
            this.SuspendLayout();
            // 
            // OFDfish
            // 
            this.OFDfish.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ofdBtn
            // 
            this.ofdBtn.Location = new System.Drawing.Point(13, 13);
            this.ofdBtn.Name = "ofdBtn";
            this.ofdBtn.Size = new System.Drawing.Size(75, 23);
            this.ofdBtn.TabIndex = 0;
            this.ofdBtn.Text = "Wczytaj";
            this.ofdBtn.UseVisualStyleBackColor = true;
            this.ofdBtn.Click += new System.EventHandler(this.ofdBtn_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 63);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Uruchom";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // path1
            // 
            this.path1.Location = new System.Drawing.Point(95, 15);
            this.path1.Name = "path1";
            this.path1.ReadOnly = true;
            this.path1.Size = new System.Drawing.Size(480, 20);
            this.path1.TabIndex = 2;
            this.path1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ile najlepszych atrybutów";
            // 
            // numericUpDownFisher
            // 
            this.numericUpDownFisher.Location = new System.Drawing.Point(95, 66);
            this.numericUpDownFisher.Name = "numericUpDownFisher";
            this.numericUpDownFisher.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFisher.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 108);
            this.Controls.Add(this.numericUpDownFisher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.ofdBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Fisher";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFisher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OFDfish;
        private System.Windows.Forms.Button ofdBtn;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox path1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownFisher;
    }
}

