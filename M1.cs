using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;

namespace BoardGame
{
    public partial class M1 : Form
    {
        public M1(bool isHost ,string ip=null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            kullanici = Properties.Settings.Default.kullaniciAdi;
            if (isHost) 
            {
                playerChar = 'X';
                OpponentChar = 'O';
                server = new TcpListener(System.Net.IPAddress.Any,5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else 
            {
                playerChar = 'O';
                OpponentChar = 'X';
                try 
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }

            }
        }
        public System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-72VV2AS\SQLEXPRESS;initial Catalog=BoardGame;Integrated Security=True");
        Ayarlar ayarlar = new Ayarlar();
        int m1 = 0;
        public static int n1;
        public static int n2;
        Button[,] buttons = new Button[15, 15];
        int top = 0;
        int left = 0;
        int a;
        int bname;
        double x;
        int c;
        double y, z;
        int rxKonum;
        int ryKonum;
        int puan = 0;
        int bestScore = 0;
        String kullanici;
        private void MessageReceiver_DoWork(object? sender, DoWorkEventArgs e)
        {
            button1_Click(sender,e);

        }
        
        private char playerChar;
        private char OpponentChar;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
           
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                if (ayarlar.checkBox_kolay.Checked == true) { n1 = 15; n2 = 15; }
                else if (ayarlar.checkBox_orta.Checked == true) { n1 = 9; n2 = 9; }
                else if (ayarlar.checkBox_zor.Checked == true) { n1 = 6; n2 = 6; }
                else if (ayarlar.checkBox_özel.Checked) { n1 = Convert.ToInt32(ayarlar.txBox_n1.Text); n2 = Convert.ToInt32(ayarlar.txBox_n2.Text); }


                int a = r.Next(0, n1);
                int b = r.Next(0, n2);
                int c = 0;
                if (ayarlar.checkBox_ucgen.Checked) { c = r.Next(1, 4); }
                else if (ayarlar.checkBox_daire.Checked) { c = r.Next(4, 7); }
                else if (ayarlar.checkBox_kare.Checked) { c = r.Next(7, 10); }
               

                if (c == 1 && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "ty.png";
                }

                if (c == 2 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "tr.png";
                }
                if (c == 3 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "tb.png";
                }

                if (c == 4 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "cy.png";
                }
                if (c == 5 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "cr.png";
                }
                if (c == 6 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "cb.png";
                }

                if (c == 7 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "sy.png";
                }
                if (c == 8 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sb.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "sr.png";
                }
                if (c == 9 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png")
                {
                    buttons[a, b].ImageList = ımageList1;
                    if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "sb.png";
                }





            }
            //buttons[0, 2].Name = "r";
            //textBox1.Text = buttons[0, 2].Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ayarlar.checkBox_kolay.Checked) { n1 = 15; n2 = 15; }
            else if (ayarlar.checkBox_orta.Checked) { n1 = 9; n2 = 9; }
            else if (ayarlar.checkBox_zor.Checked) { n1 = 6; n2 = 6; }
            else if (ayarlar.checkBox_özel.Checked) { n1 = Convert.ToInt32(ayarlar.txBox_n1.Text); n2 = Convert.ToInt32(ayarlar.txBox_n2.Text); }


            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "ty.png" && buttons[i, j + 1].ImageKey == "ty.png" && buttons[i, j + 2].ImageKey == "ty.png" && buttons[i, j + 3].ImageKey == "ty.png" && buttons[i, j + 4].ImageKey == "ty.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); ; }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }

                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "ty.png" && buttons[i + 1, j].ImageKey == "ty.png" && buttons[i + 2, j].ImageKey == "ty.png" && buttons[i + 3, j].ImageKey == "ty.png" && buttons[i + 4, j].ImageKey == "ty.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }

                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "tr.png" && buttons[i, j + 1].ImageKey == "tr.png" && buttons[i, j + 2].ImageKey == "tr.png" && buttons[i, j + 3].ImageKey == "tr.png" && buttons[i, j + 4].ImageKey == "tr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "tr.png" && buttons[i + 1, j].ImageKey == "tr.png" && buttons[i + 2, j].ImageKey == "tr.png" && buttons[i + 3, j].ImageKey == "tr.png" && buttons[i + 4, j].ImageKey == "tr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }

                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "tb.png" && buttons[i, j + 1].ImageKey == "tb.png" && buttons[i, j + 2].ImageKey == "tb.png" && buttons[i, j + 3].ImageKey == "tb.png" && buttons[i, j + 4].ImageKey == "tb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "tb.png" && buttons[i + 1, j].ImageKey == "tb.png" && buttons[i + 2, j].ImageKey == "tb.png" && buttons[i + 3, j].ImageKey == "tb.png" && buttons[i + 4, j].ImageKey == "tb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "cy.png" && buttons[i, j + 1].ImageKey == "cy.png" && buttons[i, j + 2].ImageKey == "cy.png" && buttons[i, j + 3].ImageKey == "cy.png" && buttons[i, j + 4].ImageKey == "cy.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "cy.png" && buttons[i + 1, j].ImageKey == "cy.png" && buttons[i + 2, j].ImageKey == "cy.png" && buttons[i + 3, j].ImageKey == "cy.png" && buttons[i + 4, j].ImageKey == "cy.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "cr.png" && buttons[i, j + 1].ImageKey == "cr.png" && buttons[i, j + 2].ImageKey == "cr.png" && buttons[i, j + 3].ImageKey == "cr.png" && buttons[i, j + 4].ImageKey == "cr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "cr.png" && buttons[i + 1, j].ImageKey == "cr.png" && buttons[i + 2, j].ImageKey == "cr.png" && buttons[i + 3, j].ImageKey == "cr.png" && buttons[i + 4, j].ImageKey == "cr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "cb.png" && buttons[i, j + 1].ImageKey == "cb.png" && buttons[i, j + 2].ImageKey == "cb.png" && buttons[i, j + 3].ImageKey == "cb.png" && buttons[i, j + 4].ImageKey == "cb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "cb.png" && buttons[i + 1, j].ImageKey == "cb.png" && buttons[i + 2, j].ImageKey == "cb.png" && buttons[i + 3, j].ImageKey == "cb.png" && buttons[i + 4, j].ImageKey == "cb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "sy.png" && buttons[i, j + 1].ImageKey == "sy.png" && buttons[i, j + 2].ImageKey == "sy.png" && buttons[i, j + 3].ImageKey == "sy.png" && buttons[i, j + 4].ImageKey == "sy.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "sy.png" && buttons[i + 1, j].ImageKey == "sy.png" && buttons[i + 2, j].ImageKey == "sy.png" && buttons[i + 3, j].ImageKey == "sy.png" && buttons[i + 4, j].ImageKey == "sy.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "sr.png" && buttons[i, j + 1].ImageKey == "sr.png" && buttons[i, j + 2].ImageKey == "sr.png" && buttons[i, j + 3].ImageKey == "sr.png" && buttons[i, j + 4].ImageKey == "sr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "sr.png" && buttons[i + 1, j].ImageKey == "sr.png" && buttons[i + 2, j].ImageKey == "sr.png" && buttons[i + 3, j].ImageKey == "sr.png" && buttons[i + 4, j].ImageKey == "sr.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (j != n2 - 1 && j != n2 - 2 && j != n2 - 3 && j != n2 - 4 && buttons[i, j].ImageKey == "sb.png" && buttons[i, j + 1].ImageKey == "sb.png" && buttons[i, j + 2].ImageKey == "sb.png" && buttons[i, j + 3].ImageKey == "sb.png" && buttons[i, j + 4].ImageKey == "sb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i, j + 1].ImageKey = null;
                        buttons[i, j + 1].ImageList = null;
                        buttons[i, j + 2].ImageKey = null;
                        buttons[i, j + 2].ImageList = null;
                        buttons[i, j + 3].ImageKey = null;
                        buttons[i, j + 3].ImageList = null;
                        buttons[i, j + 4].ImageKey = null;
                        buttons[i, j + 4].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }
                    if (i != n1 - 1 && i != n1 - 2 && i != n1 - 3 && i != n1 - 4 && buttons[i, j].ImageKey == "sb.png" && buttons[i + 1, j].ImageKey == "sb.png" && buttons[i + 2, j].ImageKey == "sb.png" && buttons[i + 3, j].ImageKey == "sb.png" && buttons[i + 4, j].ImageKey == "sb.png")
                    {
                        buttons[i, j].ImageKey = null;
                        buttons[i, j].ImageList = null;
                        buttons[i + 1, j].ImageKey = null;
                        buttons[i + 1, j].ImageList = null;
                        buttons[i + 2, j].ImageKey = null;
                        buttons[i + 2, j].ImageList = null;
                        buttons[i + 3, j].ImageKey = null;
                        buttons[i + 3, j].ImageList = null;
                        buttons[i + 4, j].ImageKey = null;
                        buttons[i + 4, j].ImageList = null;
                        if (ayarlar.checkBox_kolay.Checked) { puan += 5; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_orta.Checked) { puan += 15; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_kolay.Checked) { puan += 25; ses.SoundLocation = "tik.wav"; ses.Play(); }
                        else if (ayarlar.checkBox_özel.Checked) { puan += 10; ses.SoundLocation = "tik.wav"; ses.Play(); }
                    }

                    txBox_puan.Text = puan.ToString();
                    if (puan > bestScore)
                    {
                        baglanti.Open();
                        bestScore = puan;
                        textBox1.Text = bestScore.ToString();
                        SqlCommand komut = new SqlCommand("UPDATE Users SET Puan='" + bestScore + "'WHERE KullaniciAdi='" + kullanici + "' ", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();


                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oyun biti");
            MessageBox.Show("Puanınız" + " " + puan);
            this.Hide();
        }

        private void M1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Users where KullaniciAdi=@KullaniciAdi", baglanti);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("KullaniciAdi", kullanici);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                textBox1.Text = $"En iyi Skor: {rdr["Puan"].ToString()}";
            }
            baglanti.Close();
            if (ayarlar.checkBox_zor.Checked == true) { n1 = 6; n2 = 6; }
            else if (ayarlar.checkBox_kolay.Checked) { n1 = 15; n2 = 15; }
            else if (ayarlar.checkBox_orta.Checked) { n1 = 9; n2 = 9; }
            else if (ayarlar.checkBox_özel.Checked) { n1 = Convert.ToInt32(ayarlar.txBox_n1.Text); n2 = Convert.ToInt32(ayarlar.txBox_n2.Text); }

            button1.Location = new Point((75 * n1), 0);
            button2.Location = new Point((75 * n1), 85);
            button3.Location = new Point((75 * n1), 205);
            txBox_puan.Location = new Point((75 * n1) + 65, 170);
            textBox1.Location = new Point((75 * n1), 280);
            label1.Location = new Point((75 * n1), 170);

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {

                    buttons[i, j] = new Button();
                    buttons[i, j].Name = i + "" + j;
                    buttons[i, j].BackColor = Color.Black;
                    buttons[i, j].Width = 75;
                    buttons[i, j].Height = 75;
                    buttons[i, j].Left = left;
                    buttons[i, j].Top = top;
                    left += 75;

                    buttons[i, j].Click += (sender3, e3) =>
                    {
                        Button p = sender3 as Button;
                        // textBox1.Text = p.ImageKey;
                        txBox_puan.Text = puan.ToString();


                        if (p.Image != null)
                        {

                            p.BackColor = Color.Red;


                            a = 1;
                            bname = Convert.ToInt32(p.Name);
                            if (bname > 100)
                            {
                                c = bname / 100;
                                x = (double)bname / 100;
                                z = (x - c) * 100;
                                y = Math.Round(z, MidpointRounding.AwayFromZero);
                                rxKonum = c;
                                ryKonum = (int)y;
                            }
                            else
                            {
                                c = bname / 10;
                                x = (double)bname / 10;
                                z = (x - c) * 10;
                                y = Math.Round(z, MidpointRounding.AwayFromZero);
                                rxKonum = c;
                                ryKonum = (int)y;
                            }
                        }
                        if (p.BackColor != Color.Red && a == 1)
                        {

                            p.ImageList = ımageList1;
                            if (buttons[rxKonum, ryKonum].ImageKey == "ty.png") p.ImageKey = "ty.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "tr.png") p.ImageKey = "tr.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "tb.png") p.ImageKey = "tb.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "cy.png") p.ImageKey = "cy.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "cr.png") p.ImageKey = "cr.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "cb.png") p.ImageKey = "cb.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "sy.png") p.ImageKey = "sy.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "sr.png") p.ImageKey = "sr.png";
                            if (buttons[rxKonum, ryKonum].ImageKey == "sb.png") p.ImageKey = "sb.png";
                            ses.SoundLocation = "move.wav"; ses.Play();
                            // p.Name = "r";
                            buttons[rxKonum, ryKonum].ImageKey = null;
                            buttons[rxKonum, ryKonum].ImageList = null;
                            buttons[rxKonum, ryKonum].BackColor = Color.Black;

                            //textBox2.Text = ryKonum.ToString();


                            a = 0;
                            Random r = new Random();
                            Random r1 = new Random();
                            Random r2 = new Random();
                            for (int i = 0; i < 3; i++)
                            {
                                if (ayarlar.checkBox_kolay.Checked) { n1 = 15; n2 = 15; }
                                else if (ayarlar.checkBox_orta.Checked) { n1 = 9; n2 = 9; }
                                else if (ayarlar.checkBox_zor.Checked) { n1 = 6; n2 = 6; }
                                else if (ayarlar.checkBox_özel.Checked) { n1 = Convert.ToInt32(ayarlar.txBox_n1.Text); n2 = Convert.ToInt32(ayarlar.txBox_n2.Text); }

                                int a = r.Next(0, n1);
                                int b = r.Next(0, n2);
                                int c = r.Next(1, 10);




                                if (ayarlar.checkBox_kolay.Checked)
                                {
                                    if (c == 1 && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "ty.png";
                                    }
                                    if (c == 2 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "tr.png";
                                    }
                                    if (c == 3 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "tb.png";
                                    }
                                }
                                if (ayarlar.checkBox_daire.Checked)
                                {
                                    if (c == 4 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "cy.png";
                                    }
                                    if (c == 5 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "cr.png";
                                    }
                                    if (c == 6 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "cb.png";
                                    }
                                }
                                if (ayarlar.checkBox_kare.Checked)
                                {
                                    if (c == 7 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sr.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxSari.Checked) buttons[a, b].ImageKey = "sy.png";
                                    }
                                    if (c == 8 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sb.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxKirmizi.Checked) buttons[a, b].ImageKey = "sr.png";
                                    }
                                    if (c == 9 && buttons[a, b].ImageKey != "ty.png" && buttons[a, b].ImageKey != "tr.png" && buttons[a, b].ImageKey != "tb.png" && buttons[a, b].ImageKey != "cy.png" && buttons[a, b].ImageKey != "cr.png" && buttons[a, b].ImageKey != "cb.png" && buttons[a, b].ImageKey != "sy.png" && buttons[a, b].ImageKey != "sr.png")
                                    {
                                        buttons[a, b].ImageList = ımageList1;
                                        if (ayarlar.checkBoxMavi.Checked) buttons[a, b].ImageKey = "sb.png";
                                    }
                                }




                            }
                        }

                    };

                    this.Controls.Add(buttons[i, j]);
                }
                top += 75;
                left = 0;
            }


        }
    }
    }


