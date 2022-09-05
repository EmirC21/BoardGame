using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();//form kapaninca uygulamayi da kapatir
        }

        private void button_ayarlar_Click(object sender, EventArgs e)
        {
            Ayarlar ayar = new Ayarlar();
            ayar.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//form kapaninca uygulamayi da kapatir
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            Profil profil = new Profil();
            profil.ShowDialog();
        }

        private void button_Oyna_Click(object sender, EventArgs e)
        {
            Oyun oyun=new Oyun();           
            oyun.Show();
        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yardım yardım = new Yardım();
            yardım.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
        }
    }
}
