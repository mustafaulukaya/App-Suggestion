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
            this.suggest_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // findPhone_button
            // 
            this.findPhone_button.Location = new System.Drawing.Point(25, 68);
            this.findPhone_button.Name = "findPhone_button";
            this.findPhone_button.Size = new System.Drawing.Size(220, 52);
            this.findPhone_button.TabIndex = 0;
            this.findPhone_button.Text = "Veritabanını Güncelle";
            this.findPhone_button.UseVisualStyleBackColor = true;
            this.findPhone_button.Click += new System.EventHandler(this.findPhone_button_Click);
            // 
            // suggest_button
            // 
            this.suggest_button.Location = new System.Drawing.Point(488, 314);
            this.suggest_button.Name = "suggest_button";
            this.suggest_button.Size = new System.Drawing.Size(220, 52);
            this.suggest_button.TabIndex = 1;
            this.suggest_button.Text = "Öner";
            this.suggest_button.UseVisualStyleBackColor = true;
            this.suggest_button.Click += new System.EventHandler(this.suggest_button_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(344, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(473, 243);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Uygulama Adı";
            this.columnHeader1.Width = 250;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 466);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.suggest_button);
            this.Controls.Add(this.findPhone_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findPhone_button;
        private System.Windows.Forms.Button suggest_button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

