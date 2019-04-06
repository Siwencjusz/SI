namespace Reguły__decyzyjne
{
    partial class regulyDecyzyjne
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
            this.button1 = new System.Windows.Forms.Button();
            this.path1 = new System.Windows.Forms.TextBox();
            this.oFDData = new System.Windows.Forms.OpenFileDialog();
            this.coveringBox = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.exhaustivBtn = new System.Windows.Forms.CheckBox();
            this.lem2ChckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wczytaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // path1
            // 
            this.path1.Location = new System.Drawing.Point(95, 15);
            this.path1.Name = "path1";
            this.path1.ReadOnly = true;
            this.path1.Size = new System.Drawing.Size(266, 20);
            this.path1.TabIndex = 1;
            // 
            // coveringBox
            // 
            this.coveringBox.AutoSize = true;
            this.coveringBox.Location = new System.Drawing.Point(95, 42);
            this.coveringBox.Name = "coveringBox";
            this.coveringBox.Size = new System.Drawing.Size(68, 17);
            this.coveringBox.TabIndex = 2;
            this.coveringBox.Text = "Covering";
            this.coveringBox.UseVisualStyleBackColor = true;
            this.coveringBox.CheckedChanged += new System.EventHandler(this.coveringBox_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(13, 113);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Uruchom";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // exhaustivBtn
            // 
            this.exhaustivBtn.AutoSize = true;
            this.exhaustivBtn.Location = new System.Drawing.Point(95, 66);
            this.exhaustivBtn.Name = "exhaustivBtn";
            this.exhaustivBtn.Size = new System.Drawing.Size(72, 17);
            this.exhaustivBtn.TabIndex = 4;
            this.exhaustivBtn.Text = "Exhaustiv";
            this.exhaustivBtn.UseVisualStyleBackColor = true;
            this.exhaustivBtn.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lem2ChckBox
            // 
            this.lem2ChckBox.AutoSize = true;
            this.lem2ChckBox.Location = new System.Drawing.Point(95, 90);
            this.lem2ChckBox.Name = "lem2ChckBox";
            this.lem2ChckBox.Size = new System.Drawing.Size(52, 17);
            this.lem2ChckBox.TabIndex = 5;
            this.lem2ChckBox.Text = "Lem2";
            this.lem2ChckBox.UseVisualStyleBackColor = true;
            this.lem2ChckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // regulyDecyzyjne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 148);
            this.Controls.Add(this.lem2ChckBox);
            this.Controls.Add(this.exhaustivBtn);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.coveringBox);
            this.Controls.Add(this.path1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "regulyDecyzyjne";
            this.Text = "Reguły decyzyjne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox path1;
        private System.Windows.Forms.OpenFileDialog oFDData;
        private System.Windows.Forms.CheckBox coveringBox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox exhaustivBtn;
        private System.Windows.Forms.CheckBox lem2ChckBox;
    }
}

