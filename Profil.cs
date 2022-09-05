using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BoardGame
{
    public partial class Profil : Form
    {
        public Profil()
        {

            InitializeComponent();
            textBoxKullaniciAdi.Text = Properties.Settings.Default.kullaniciAdi;
            textBoxSifre.Text = Properties.Settings.Default.sifre;
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-72VV2AS\SQLEXPRESS;initial Catalog=BoardGame;Integrated Security=True");
        Main main=new Main();
        private void Profil_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            button1.Visible = false;

        }

        private void buttonOnayla_Click(object sender, EventArgs e)
        {
            if (textBoxOnayla.Text == Properties.Settings.Default.sifre)
            {
                String t1 = textBoxKullaniciAdi.Text;
                String t2 = textBoxSifre.Text;
                String t3 = textBoxAdSoyad.Text;
                String t4 = textBoxTelefon.Text;
                String t5 = textBoxAdres.Text;
                String t6 = textBoxSehir.Text;
                String t7 = textBoxUlke.Text;
                String t8 = textBoxEposta.Text;
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Users SET KullaniciAdi='" + t1 + "',Sifre='" + t2 + "',AdSoyad='" + t3 + "',Telefon='" + t4 + "',Adres='" + t5 + "',Sehir='" + t6 + "',Ulke='" + t7 + "',Eposta='" + t8 + "'WHERE KullaniciAdi='" + t1 + "' ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Değişikler kaydedildi");
                this.Close();
            }
                else
                {
                    MessageBox.Show("Şifreniz Hatalı");
                }

            


        }

    }
}
