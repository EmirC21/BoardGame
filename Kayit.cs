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


namespace BoardGame
{
    public partial class Kayit : Form
    {   
        
        public Kayit()
        {
            InitializeComponent();
           

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-72VV2AS\SQLEXPRESS;initial Catalog=BoardGame;Integrated Security=True");
        private void Kayit_yukle()
        {

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Users", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglanti.Close();
        }
        
        private void Kayit_Load(object sender, EventArgs e)
        {
            Kayit_yukle();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            String t1 = txBox_KullaniciAdi.Text;
            String t2 = txBox_Sifre.Text;
            String t3 = txBox_AdSoyad.Text;
            String t4 = txBox_Telefon.Text;
            String t5 = txBox_Adres.Text;
            String t6 = txBox_Sehir.Text;
            String t7 = txBox_Ulke.Text;
            String t8 = txBox_Eposta.Text;           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Users(KullaniciAdi,Sifre,AdSoyad,Telefon,Adres,Sehir,Ulke,Eposta)VALUES('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "','"+t7+"','"+t8+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Kayit_yukle();

        }
    }
}
