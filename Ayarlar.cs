using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;


namespace BoardGame
{
   
    public partial class Ayarlar : Form
    {
        
        
       

        public Ayarlar()
        {
            InitializeComponent();
            checkBox_kolay.Checked = Properties.Settings.Default.CheckBoxKolay;
            checkBox_orta.Checked = Properties.Settings.Default.CheckBoxOrta;
            checkBox_zor.Checked = Properties.Settings.Default.CheckBoxZor;
            checkBox_ucgen.Checked = Properties.Settings.Default.CheckBoxUcgen;
            checkBox_kare.Checked = Properties.Settings.Default.CheckBoxKare;
            checkBox_daire.Checked = Properties.Settings.Default.CheckBoxDaire;
            checkBoxSari.Checked = Properties.Settings.Default.CheckBoxSari;
            checkBoxMavi.Checked = Properties.Settings.Default.CheckBoxMavi;
            checkBoxKirmizi.Checked = Properties.Settings.Default.CheckBoxKirmizi;
            checkBox_özel.Checked = Properties.Settings.Default.CheckBoxOzel;
            txBox_n1.Text = Properties.Settings.Default.n1.ToString();
            txBox_n2.Text = Properties.Settings.Default.n2.ToString(); 
        }
       

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txBox_n1.Text) < 5 ||Convert.ToInt32(txBox_n1.Text)>20|| Convert.ToInt32(txBox_n2.Text) < 5 || Convert.ToInt32(txBox_n2.Text) > 20)
            {
                MessageBox.Show("Özel girilen değerler 20'den büyük ve 5' ten küçük olamaz");
            }
            else 
            {
                MessageBox.Show("Değişiklikler kaydedildi.");
                Main main = new Main();
                Properties.Settings.Default.CheckBoxKolay = checkBox_kolay.Checked;
                Properties.Settings.Default.CheckBoxOrta = checkBox_orta.Checked;
                Properties.Settings.Default.CheckBoxZor = checkBox_zor.Checked;
                Properties.Settings.Default.CheckBoxDaire = checkBox_daire.Checked;
                Properties.Settings.Default.CheckBoxKare = checkBox_kare.Checked;
                Properties.Settings.Default.CheckBoxUcgen = checkBox_ucgen.Checked;
                Properties.Settings.Default.CheckBoxSari = checkBoxSari.Checked;
                Properties.Settings.Default.CheckBoxMavi = checkBoxMavi.Checked;
                Properties.Settings.Default.CheckBoxKirmizi = checkBoxKirmizi.Checked;
                Properties.Settings.Default.CheckBoxOzel = checkBox_özel.Checked;
                Properties.Settings.Default.n1 = Convert.ToInt32(txBox_n1.Text);
                Properties.Settings.Default.n2 = Convert.ToInt32(txBox_n2.Text);

                Properties.Settings.Default.Save();
                this.Hide();
                
            }
        }

        private void checkBox_kolay_Click(object sender, EventArgs e)
        {
            checkBox_zor.Checked = false;
            checkBox_orta.Checked = false;
            checkBox_özel.Checked = false;
        }

        private void checkBox_orta_Click(object sender, EventArgs e)
        {
            checkBox_zor.Checked = false;
            checkBox_kolay.Checked = false;
            checkBox_özel.Checked = false;
        }

        private void checkBox_zor_Click(object sender, EventArgs e)
        {
            checkBox_kolay.Checked = false;
            checkBox_orta.Checked = false;
            checkBox_özel.Checked = false;
        }
       
        private void exit_button_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_özel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_özel.Checked == false) { txBox_n1.Enabled = false; }
            if (checkBox_özel.Checked == false) { txBox_n2.Enabled = false; }
            if (checkBox_özel.Checked == true) { txBox_n1.Enabled = true; }
            if (checkBox_özel.Checked == true) { txBox_n2.Enabled = true; }
        }

        private void checkBox_özel_Click(object sender, EventArgs e)
        {
            checkBox_zor.Checked=false;
            checkBox_kolay.Checked=false;
            checkBox_orta.Checked=false;

        }
    }
}

