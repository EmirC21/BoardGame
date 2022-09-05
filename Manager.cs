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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-72VV2AS\SQLEXPRESS;initial Catalog=BoardGame;Integrated Security=True");       
        private void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Users", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            String t2 = textBox2.Text;
            String t3 = textBox3.Text;
            String t4 = textBox4.Text;
            String t5 = textBox5.Text;
            String t6 = textBox6.Text;
            String t7 = textBox7.Text;
            String t8 = textBox8.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Users(KullaniciAdi,Sifre,AdSoyad,Telefon,Adres,Sehir,Ulke,Eposta)VALUES('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "','"+t7+ "','"+t8+ "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            String t2 = textBox2.Text;
            String t3 = textBox3.Text;
            String t4 = textBox4.Text;
            String t5 = textBox5.Text;
            String t6 = textBox6.Text;
            String t7 = textBox7.Text;
            String t8 = textBox8.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Users SET KullaniciAdi='" + t1 + "',Sifre='" + t2 + "',AdSoyad='" + t3 + "',Telefon='" + t4 + "',Adres='" + t5 + "',Sehir='" + t6 +"',Ulke='"+t7+"',Eposta='"+t8+ "'WHERE KullaniciAdi='" + t1 + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("silmek istediğinize emin misiniz?","sil",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes) 
            {
            String t1 = textBox1.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Users WHERE KullaniciAdi=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele(); 
            }
            else if(cevap == DialogResult.No) 
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[8],ListSortDirection.Ascending);
        }
    }
}
