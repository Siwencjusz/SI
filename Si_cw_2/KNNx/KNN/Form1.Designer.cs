namespace KNN
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
            this.TestOFD = new System.Windows.Forms.OpenFileDialog();
            this.btnWczTest = new System.Windows.Forms.Button();
            this.TreningOFD = new System.Windows.Forms.OpenFileDialog();
            this.btnTrenngOFD = new System.Windows.Forms.Button();
            this.metrykaComboBox = new System.Windows.Forms.ComboBox();
            this.kNNComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtBoxTest = new System.Windows.Forms.TextBox();
            this.txtBoxTrening = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TestOFD
            // 
            this.TestOFD.FileName = "testOFD";
            this.TestOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.TestOFD_FileOk);
            // 
            // btnWczTest
            // 
            this.btnWczTest.Location = new System.Drawing.Point(13, 13);
            this.btnWczTest.Name = "btnWczTest";
            this.btnWczTest.Size = new System.Drawing.Size(109, 23);
            this.btnWczTest.TabIndex = 0;
            this.btnWczTest.Text = "Wczytaj test";
            this.btnWczTest.UseVisualStyleBackColor = true;
            this.btnWczTest.Click += new System.EventHandler(this.btnWczTest_Click);
            // 
            // TreningOFD
            // 
            this.TreningOFD.FileName = "TreningOFD";
            this.TreningOFD.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnTrenngOFD
            // 
            this.btnTrenngOFD.Location = new System.Drawing.Point(13, 69);
            this.btnTrenngOFD.Name = "btnTrenngOFD";
            this.btnTrenngOFD.Size = new System.Drawing.Size(115, 23);
            this.btnTrenngOFD.TabIndex = 1;
            this.btnTrenngOFD.Text = "Wczytaj trening";
            this.btnTrenngOFD.UseVisualStyleBackColor = true;
            this.btnTrenngOFD.Click += new System.EventHandler(this.btnTrenngOFD_Click);
            // 
            // metrykaComboBox
            // 
            this.metrykaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metrykaComboBox.FormattingEnabled = true;
            this.metrykaComboBox.Items.AddRange(new object[] {
            "Metryka Manhattan",
            "Metryka Euklidesowa",
            "Metryka Canberra",
            "Metryka Czebyszewa",
            "Bezwzgledny współczynnik korelacji Pearsona"});
            this.metrykaComboBox.Location = new System.Drawing.Point(13, 140);
            this.metrykaComboBox.Name = "metrykaComboBox";
            this.metrykaComboBox.Size = new System.Drawing.Size(121, 21);
            this.metrykaComboBox.TabIndex = 2;
            this.metrykaComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // kNNComboBox
            // 
            this.kNNComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kNNComboBox.FormattingEnabled = true;
            this.kNNComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.kNNComboBox.Location = new System.Drawing.Point(161, 140);
            this.kNNComboBox.Name = "kNNComboBox";
            this.kNNComboBox.Size = new System.Drawing.Size(121, 21);
            this.kNNComboBox.TabIndex = 3;
            this.kNNComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Metryka";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "KNN";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(13, 181);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(110, 20);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Uruchom";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtBoxTest
            // 
            this.txtBoxTest.Location = new System.Drawing.Point(16, 43);
            this.txtBoxTest.Name = "txtBoxTest";
            this.txtBoxTest.ReadOnly = true;
            this.txtBoxTest.Size = new System.Drawing.Size(559, 20);
            this.txtBoxTest.TabIndex = 7;
            this.txtBoxTest.TextChanged += new System.EventHandler(this.txtBoxTest_TextChanged);
            // 
            // txtBoxTrening
            // 
            this.txtBoxTrening.Location = new System.Drawing.Point(13, 98);
            this.txtBoxTrening.Name = "txtBoxTrening";
            this.txtBoxTrening.ReadOnly = true;
            this.txtBoxTrening.Size = new System.Drawing.Size(562, 20);
            this.txtBoxTrening.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 220);
            this.Controls.Add(this.txtBoxTrening);
            this.Controls.Add(this.txtBoxTest);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kNNComboBox);
            this.Controls.Add(this.metrykaComboBox);
            this.Controls.Add(this.btnTrenngOFD);
            this.Controls.Add(this.btnWczTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "KNN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog TestOFD;
        private System.Windows.Forms.Button btnWczTest;
        private System.Windows.Forms.OpenFileDialog TreningOFD;
        private System.Windows.Forms.Button btnTrenngOFD;
        private System.Windows.Forms.ComboBox metrykaComboBox;
        private System.Windows.Forms.ComboBox kNNComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtBoxTest;
        private System.Windows.Forms.TextBox txtBoxTrening;

    }
}

