namespace Apriori
{
    partial class Apriori
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
            this.aprioriOFD = new System.Windows.Forms.OpenFileDialog();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.aprioriTxtBox = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aprioriOFD
            // 
            this.aprioriOFD.FileName = "aprioriOFD";
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(4, 13);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(96, 23);
            this.btnWczytaj.TabIndex = 0;
            this.btnWczytaj.Text = "Wczytaj paragon";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // aprioriTxtBox
            // 
            this.aprioriTxtBox.Location = new System.Drawing.Point(106, 15);
            this.aprioriTxtBox.Name = "aprioriTxtBox";
            this.aprioriTxtBox.Size = new System.Drawing.Size(240, 20);
            this.aprioriTxtBox.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(13, 161);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Uruchom";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // Apriori
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 244);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.aprioriTxtBox);
            this.Controls.Add(this.btnWczytaj);
            this.Name = "Apriori";
            this.Text = "Apriori";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog aprioriOFD;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.TextBox aprioriTxtBox;
        private System.Windows.Forms.Button btnRun;
    }
}

