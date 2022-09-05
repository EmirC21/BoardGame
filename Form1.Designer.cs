namespace BoardGame
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button_giris = new System.Windows.Forms.Button();
            this.txBox_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.txBox_sifre = new System.Windows.Forms.TextBox();
            this.label_kullaniciAdi = new System.Windows.Forms.Label();
            this.label_sifre = new System.Windows.Forms.Label();
            this.hosgeldiniz = new System.Windows.Forms.Label();
            this.button_kayit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_giris
            // 
            this.button_giris.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_giris.Location = new System.Drawing.Point(192, 417);
            this.button_giris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_giris.Name = "button_giris";
            this.button_giris.Size = new System.Drawing.Size(96, 39);
            this.button_giris.TabIndex = 0;
            this.button_giris.Text = "Giriş";
            this.button_giris.UseVisualStyleBackColor = true;
            this.button_giris.Click += new System.EventHandler(this.button_giris_Click);
            // 
            // txBox_kullaniciAdi
            // 
            this.txBox_kullaniciAdi.Location = new System.Drawing.Point(192, 291);
            this.txBox_kullaniciAdi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txBox_kullaniciAdi.Name = "txBox_kullaniciAdi";
            this.txBox_kullaniciAdi.Size = new System.Drawing.Size(195, 27);
            this.txBox_kullaniciAdi.TabIndex = 1;
            this.txBox_kullaniciAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txBox_kullaniciAdi_KeyPress);
            // 
            // txBox_sifre
            // 
            this.txBox_sifre.Location = new System.Drawing.Point(192, 353);
            this.txBox_sifre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txBox_sifre.Name = "txBox_sifre";
            this.txBox_sifre.PasswordChar = '*';
            this.txBox_sifre.Size = new System.Drawing.Size(195, 27);
            this.txBox_sifre.TabIndex = 2;
            // 
            // label_kullaniciAdi
            // 
            this.label_kullaniciAdi.AutoSize = true;
            this.label_kullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.label_kullaniciAdi.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_kullaniciAdi.Location = new System.Drawing.Point(32, 291);
            this.label_kullaniciAdi.Name = "label_kullaniciAdi";
            this.label_kullaniciAdi.Size = new System.Drawing.Size(135, 29);
            this.label_kullaniciAdi.TabIndex = 3;
            this.label_kullaniciAdi.Text = "Kullanıcı Adı";
            // 
            // label_sifre
            // 
            this.label_sifre.AutoSize = true;
            this.label_sifre.BackColor = System.Drawing.Color.Transparent;
            this.label_sifre.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_sifre.Location = new System.Drawing.Point(32, 353);
            this.label_sifre.Name = "label_sifre";
            this.label_sifre.Size = new System.Drawing.Size(75, 29);
            this.label_sifre.TabIndex = 4;
            this.label_sifre.Text = "Parola";
            // 
            // hosgeldiniz
            // 
            this.hosgeldiniz.AutoSize = true;
            this.hosgeldiniz.BackColor = System.Drawing.Color.Transparent;
            this.hosgeldiniz.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hosgeldiniz.Location = new System.Drawing.Point(192, 92);
            this.hosgeldiniz.Name = "hosgeldiniz";
            this.hosgeldiniz.Size = new System.Drawing.Size(155, 41);
            this.hosgeldiniz.TabIndex = 5;
            this.hosgeldiniz.Text = "GİRİŞ YAP";
            // 
            // button_kayit
            // 
            this.button_kayit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_kayit.Location = new System.Drawing.Point(291, 417);
            this.button_kayit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_kayit.Name = "button_kayit";
            this.button_kayit.Size = new System.Drawing.Size(96, 39);
            this.button_kayit.TabIndex = 6;
            this.button_kayit.Text = "Kayıt Ol";
            this.button_kayit.UseVisualStyleBackColor = true;
            this.button_kayit.Click += new System.EventHandler(this.button_kayit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(192, 386);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Şifreyi Göster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(513, 529);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_kayit);
            this.Controls.Add(this.hosgeldiniz);
            this.Controls.Add(this.label_sifre);
            this.Controls.Add(this.label_kullaniciAdi);
            this.Controls.Add(this.txBox_sifre);
            this.Controls.Add(this.txBox_kullaniciAdi);
            this.Controls.Add(this.button_giris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_giris;
        private TextBox txBox_sifre;
        private Label label_kullaniciAdi;
        private Label label_sifre;
        private Label hosgeldiniz;
        private Button button_kayit;
        public TextBox txBox_kullaniciAdi;
        private CheckBox checkBox1;
    }
}