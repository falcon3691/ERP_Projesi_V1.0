
namespace ERP_Projesi_V1._0
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Malzeme = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Satis = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Muhasebe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Malzeme,
            this.Menu_Satis,
            this.Menu_Muhasebe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Malzeme
            // 
            this.Menu_Malzeme.Name = "Menu_Malzeme";
            this.Menu_Malzeme.Size = new System.Drawing.Size(91, 24);
            this.Menu_Malzeme.Text = "MALZEME";
            this.Menu_Malzeme.Click += new System.EventHandler(this.Menu_Malzeme_Click);
            // 
            // Menu_Satis
            // 
            this.Menu_Satis.Name = "Menu_Satis";
            this.Menu_Satis.Size = new System.Drawing.Size(60, 24);
            this.Menu_Satis.Text = "SATIŞ";
            this.Menu_Satis.Click += new System.EventHandler(this.Menu_Satis_Click);
            // 
            // Menu_Muhasebe
            // 
            this.Menu_Muhasebe.Name = "Menu_Muhasebe";
            this.Menu_Muhasebe.Size = new System.Drawing.Size(100, 24);
            this.Menu_Muhasebe.Text = "MUHASEBE";
            this.Menu_Muhasebe.Click += new System.EventHandler(this.Menu_Muhasebe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ANA EKRAN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Malzeme;
        private System.Windows.Forms.ToolStripMenuItem Menu_Satis;
        private System.Windows.Forms.ToolStripMenuItem Menu_Muhasebe;
    }
}

