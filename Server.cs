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
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M1 m1 = new M1(false, textBox1.Text);
            Visible = false;
            if (!m1.IsDisposed)
                m1.ShowDialog();
            Visible= true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            M1 m1 = new M1(true);
            Visible = false;
            if (!m1.IsDisposed)
                m1.ShowDialog();
            Visible = true;
        }
    }
}
