using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace BoardGame
{
    public partial class Login : Form
    {
       
       
      
        public Login()
        {
            InitializeComponent();
          

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-72VV2AS\SQLEXPRESS;initial Catalog=BoardGame;Integrated Security=True");
        SqlCommand scmd;
        private void button_giris_Click(object sender, EventArgs e)
        {
           
            bool isUserok = false, ispassok = false;
            Properties.Settings.Default.kullaniciAdi = txBox_kullaniciAdi.Text;
            Properties.Settings.Default.sifre = txBox_sifre.Text;
           
            Main main = new Main();
            string query = "SELECT * FROM Users WHERE KullaniciAdi=@USER";
            baglanti.Open();
            scmd = new SqlCommand(query, baglanti);
            scmd.Parameters.Add("@USER", SqlDbType.VarChar);
            scmd.Parameters["@USER"].Value = txBox_kullaniciAdi.Text;
            SqlDataReader sda = scmd.ExecuteReader();
            if (sda.HasRows)
            {
                isUserok = true;
            }
            baglanti.Close();
            baglanti.Open();
            query = "SELECT * FROM Users WHERE KullaniciAdi=@USER AND Sifre=@PASS";
            scmd = new SqlCommand(query, baglanti);

            //adding parameters
            scmd.Parameters.Add("@USER", SqlDbType.VarChar);
            scmd.Parameters["@USER"].Value = txBox_kullaniciAdi.Text;

            scmd.Parameters.Add("@PASS", SqlDbType.VarChar);
            scmd.Parameters["@PASS"].Value = txBox_sifre.Text;

            sda = scmd.ExecuteReader();
           

            if (sda.HasRows)
            {
                ispassok = true;
            }

            if (isUserok == false)
            {
                MessageBox.Show("User does not exist!");
            }

            else if (isUserok == true && ispassok == false)
            {
                MessageBox.Show("wrong password!!!");
            }

            else
            {
                if (txBox_kullaniciAdi.Text == "admin" && txBox_sifre.Text == "admin")
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();
                }
                else 
                { 
                Hide();
                main.ShowDialog();  
                Close();
                }
            }
            baglanti.Close();
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_giris.PerformClick();

            }
        }

        private void button_kayit_Click(object sender, EventArgs e)
        {

            
            Kayit kayit = new Kayit();
            kayit.Show();
        }

        private void txBox_kullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)&&!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { txBox_sifre.PasswordChar = '\0'; }
            else { txBox_sifre.PasswordChar = '*'; }
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
    }
}