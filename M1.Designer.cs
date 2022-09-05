namespace BoardGame
{
    partial class M1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txBox_puan = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(655, 343);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(655, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 69);
            this.button3.TabIndex = 12;
            this.button3.Text = "OYUNU BİTİR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(584, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Puan:";
            // 
            // txBox_puan
            // 
            this.txBox_puan.Location = new System.Drawing.Point(655, 192);
            this.txBox_puan.Name = "txBox_puan";
            this.txBox_puan.Size = new System.Drawing.Size(125, 27);
            this.txBox_puan.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(655, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 69);
            this.button2.TabIndex = 9;
            this.button2.Text = "KONTROL ET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(655, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 69);
            this.button1.TabIndex = 8;
            this.button1.Text = "BAŞLA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "cb.png");
            this.ımageList1.Images.SetKeyName(1, "cr.png");
            this.ımageList1.Images.SetKeyName(2, "cy.png");
            this.ımageList1.Images.SetKeyName(3, "sb.png");
            this.ımageList1.Images.SetKeyName(4, "sr.png");
            this.ımageList1.Images.SetKeyName(5, "sy.png");
            this.ımageList1.Images.SetKeyName(6, "tb.png");
            this.ımageList1.Images.SetKeyName(7, "tr.png");
            this.ımageList1.Images.SetKeyName(8, "ty.png");
            // 
            // M1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txBox_puan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "M1";
            this.Text = "M1";
            this.Load += new System.EventHandler(this.M1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button3;
        private Label label1;
        private TextBox txBox_puan;
        private Button button2;
        private Button button1;
        private ImageList ımageList1;
    }
}