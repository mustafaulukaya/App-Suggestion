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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDislike = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.labelRate = new System.Windows.Forms.Label();
            this.labelLink = new System.Windows.Forms.LinkLabel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findPhone_button
            // 
            this.findPhone_button.Location = new System.Drawing.Point(9, 45);
            this.findPhone_button.Margin = new System.Windows.Forms.Padding(2);
            this.findPhone_button.Name = "findPhone_button";
            this.findPhone_button.Size = new System.Drawing.Size(165, 42);
            this.findPhone_button.TabIndex = 0;
            this.findPhone_button.Text = "Veritabanını Güncelle";
            this.findPhone_button.UseVisualStyleBackColor = true;
            this.findPhone_button.Click += new System.EventHandler(this.findPhone_button_Click);
            // 
            // suggest_button
            // 
            this.suggest_button.Location = new System.Drawing.Point(9, 236);
            this.suggest_button.Margin = new System.Windows.Forms.Padding(2);
            this.suggest_button.Name = "suggest_button";
            this.suggest_button.Size = new System.Drawing.Size(165, 42);
            this.suggest_button.TabIndex = 1;
            this.suggest_button.Text = "Öner";
            this.suggest_button.UseVisualStyleBackColor = true;
            this.suggest_button.Click += new System.EventHandler(this.suggest_button_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(223, 8);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(291, 119);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Uygulama Adı";
            this.columnHeader1.Width = 250;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDislike);
            this.groupBox1.Controls.Add(this.buttonLike);
            this.groupBox1.Controls.Add(this.labelRate);
            this.groupBox1.Controls.Add(this.labelLink);
            this.groupBox1.Controls.Add(this.labelTitle);
            this.groupBox1.Location = new System.Drawing.Point(223, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 215);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // buttonDislike
            // 
            this.buttonDislike.Location = new System.Drawing.Point(6, 164);
            this.buttonDislike.Name = "buttonDislike";
            this.buttonDislike.Size = new System.Drawing.Size(139, 23);
            this.buttonDislike.TabIndex = 5;
            this.buttonDislike.Text = "Beğenmedim";
            this.buttonDislike.UseVisualStyleBackColor = true;
            this.buttonDislike.Click += new System.EventHandler(this.buttonDislike_Click);
            // 
            // buttonLike
            // 
            this.buttonLike.Location = new System.Drawing.Point(151, 164);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(134, 23);
            this.buttonLike.TabIndex = 4;
            this.buttonLike.Text = "Beğendim";
            this.buttonLike.UseVisualStyleBackColor = true;
            this.buttonLike.Click += new System.EventHandler(this.buttonLike_Click);
            // 
            // labelRate
            // 
            this.labelRate.Location = new System.Drawing.Point(0, 59);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(291, 27);
            this.labelRate.TabIndex = 3;
            this.labelRate.Text = "label1";
            this.labelRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLink
            // 
            this.labelLink.Location = new System.Drawing.Point(0, 95);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(291, 32);
            this.labelLink.TabIndex = 2;
            this.labelLink.TabStop = true;
            this.labelLink.Text = "PlayStore";
            this.labelLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelLink_LinkClicked);
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(0, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(291, 29);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "label1";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 387);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.suggest_button);
            this.Controls.Add(this.findPhone_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findPhone_button;
        private System.Windows.Forms.Button suggest_button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.LinkLabel labelLink;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Button buttonDislike;
        private System.Windows.Forms.Button buttonLike;
    }
}

