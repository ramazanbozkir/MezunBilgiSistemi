namespace MezunBilgiSistemi
{
    partial class FrmGiris
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
            this.btnOgrenci = new System.Windows.Forms.Button();
            this.btnSirket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOgrenci
            // 
            this.btnOgrenci.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.btnOgrenci.Location = new System.Drawing.Point(12, 12);
            this.btnOgrenci.Name = "btnOgrenci";
            this.btnOgrenci.Size = new System.Drawing.Size(411, 375);
            this.btnOgrenci.TabIndex = 0;
            this.btnOgrenci.Text = "ÖĞRENCİ GİRİŞİ";
            this.btnOgrenci.UseVisualStyleBackColor = true;
            this.btnOgrenci.Click += new System.EventHandler(this.btnOgrenci_Click);
            // 
            // btnSirket
            // 
            this.btnSirket.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.btnSirket.Location = new System.Drawing.Point(429, 12);
            this.btnSirket.Name = "btnSirket";
            this.btnSirket.Size = new System.Drawing.Size(411, 375);
            this.btnSirket.TabIndex = 0;
            this.btnSirket.Text = "ŞİRKET GİRİŞİ";
            this.btnSirket.UseVisualStyleBackColor = true;
            this.btnSirket.Click += new System.EventHandler(this.btnSirket_Click);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 399);
            this.Controls.Add(this.btnSirket);
            this.Controls.Add(this.btnOgrenci);
            this.Name = "FrmGiris";
            this.Text = "MEZUN BİLGİ SİSTEMİ";
            this.Load += new System.EventHandler(this.FrmGiris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOgrenci;
        private System.Windows.Forms.Button btnSirket;
    }
}

