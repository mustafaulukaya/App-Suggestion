namespace Uzman_Sistem
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.findPhone_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findPhone_button
            // 
            this.findPhone_button.Location = new System.Drawing.Point(299, 81);
            this.findPhone_button.Name = "findPhone_button";
            this.findPhone_button.Size = new System.Drawing.Size(220, 52);
            this.findPhone_button.TabIndex = 0;
            this.findPhone_button.Text = "Magic Button\r\n";
            this.findPhone_button.UseVisualStyleBackColor = true;
            this.findPhone_button.Click += new System.EventHandler(this.findPhone_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 466);
            this.Controls.Add(this.findPhone_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findPhone_button;
    }
}

