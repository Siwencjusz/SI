namespace KNN_v_2
{
    partial class KNN
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
            this.btnWczytajTest = new System.Windows.Forms.Button();
            this.btnWczytajTrening = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtBoxWczTst = new System.Windows.Forms.TextBox();
            this.txtBoxTrening = new System.Windows.Forms.TextBox();
            this.metrykaComboBox = new System.Windows.Forms.ComboBox();
            this.metryka = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.Label();
            this.TestOFD = new System.Windows.Forms.OpenFileDialog();
            this.TreningOFD = new System.Windows.Forms.OpenFileDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWczytajTest
            // 
            this.btnWczytajTest.Location = new System.Drawing.Point(69, 24);
            this.btnWczytajTest.Name = "btnWczytajTest";
            this.btnWczytajTest.Size = new System.Drawing.Size(131, 23);
            this.btnWczytajTest.TabIndex = 0;
            this.btnWczytajTest.Text = "Wczytaj test";
            this.btnWczytajTest.UseVisualStyleBackColor = true;
            this.btnWczytajTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWczytajTrening
            // 
            this.btnWczytajTrening.Location = new System.Drawing.Point(69, 91);
            this.btnWczytajTrening.Name = "btnWczytajTrening";
            this.btnWczytajTrening.Size = new System.Drawing.Size(131, 23);
            this.btnWczytajTrening.TabIndex = 1;
            this.btnWczytajTrening.Text = "Wczytaj trening";
            this.btnWczytajTrening.UseVisualStyleBackColor = true;
            this.btnWczytajTrening.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(69, 251);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Uruchom";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBoxWczTst
            // 
            this.txtBoxWczTst.Location = new System.Drawing.Point(69, 54);
            this.txtBoxWczTst.Name = "txtBoxWczTst";
            this.txtBoxWczTst.ReadOnly = true;
            this.txtBoxWczTst.Size = new System.Drawing.Size(392, 20);
            this.txtBoxWczTst.TabIndex = 3;
            // 
            // txtBoxTrening
            // 
            this.txtBoxTrening.Location = new System.Drawing.Point(69, 121);
            this.txtBoxTrening.Name = "txtBoxTrening";
            this.txtBoxTrening.ReadOnly = true;
            this.txtBoxTrening.Size = new System.Drawing.Size(392, 20);
            this.txtBoxTrening.TabIndex = 4;
            // 
            // metrykaComboBox
            // 
            this.metrykaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metrykaComboBox.FormattingEnabled = true;
            this.metrykaComboBox.Location = new System.Drawing.Point(69, 179);
            this.metrykaComboBox.Name = "metrykaComboBox";
            this.metrykaComboBox.Size = new System.Drawing.Size(121, 21);
            this.metrykaComboBox.TabIndex = 5;
            this.metrykaComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // metryka
            // 
            this.metryka.AutoSize = true;
            this.metryka.Location = new System.Drawing.Point(69, 160);
            this.metryka.Name = "metryka";
            this.metryka.Size = new System.Drawing.Size(45, 13);
            this.metryka.TabIndex = 7;
            this.metryka.Text = "Metryka";
            // 
            // k
            // 
            this.k.AutoSize = true;
            this.k.Location = new System.Drawing.Point(250, 159);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(14, 13);
            this.k.TabIndex = 8;
            this.k.Text = "K";
            // 
            // TestOFD
            // 
            this.TestOFD.FileName = "testOFD";
            // 
            // TreningOFD
            // 
            this.TreningOFD.FileName = "TreningOFD";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(253, 179);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // KNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 305);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.k);
            this.Controls.Add(this.metryka);
            this.Controls.Add(this.metrykaComboBox);
            this.Controls.Add(this.txtBoxTrening);
            this.Controls.Add(this.txtBoxWczTst);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnWczytajTrening);
            this.Controls.Add(this.btnWczytajTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KNN";
            this.Text = "KNN";
            this.Load += new System.EventHandler(this.KNN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWczytajTest;
        private System.Windows.Forms.Button btnWczytajTrening;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtBoxWczTst;
        private System.Windows.Forms.TextBox txtBoxTrening;
        private System.Windows.Forms.ComboBox metrykaComboBox;
        private System.Windows.Forms.Label metryka;
        private System.Windows.Forms.Label k;
        private System.Windows.Forms.OpenFileDialog TestOFD;
        private System.Windows.Forms.OpenFileDialog TreningOFD;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

