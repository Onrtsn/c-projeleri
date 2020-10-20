using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hesapmakinesi
{
    public partial class Form1 : Form
    {
        bool optdurum = false;
        int islem = 0;
        double sayi1 = 0, sayi2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ortakolay(object sender, EventArgs e)
        {
            if (txtkutu.Text == "0" || optdurum)
                txtkutu.Clear();
            optdurum = false;
            Button btn = (Button)sender;
            txtkutu.Text += btn.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtkutu.Text = "0";
        }

        private void btntop_Click(object sender, EventArgs e)
        {
            islem = 1;
            sayi1 = double.Parse(txtkutu.Text);
            sifirla();
        }

        private void btncık_Click(object sender, EventArgs e)
        {
            islem = 2;
            sayi1 = double.Parse(txtkutu.Text);
            sifirla();
        }

        private void btncarp_Click(object sender, EventArgs e)
        {
            islem = 3;
            sayi1 = double.Parse(txtkutu.Text);
            sifirla();
        }

        private void btnbol_Click(object sender, EventArgs e)
        {
            islem = 4;
            sayi1 = double.Parse(txtkutu.Text);
            sifirla();
        }

        private void btnesit_Click(object sender, EventArgs e)
        {
            sayi2 = double.Parse(txtkutu.Text);
            txtkutu.Text = hesapla().ToString("#,#.00");
        }
        public double hesapla()
        {
            double sonuc = 0;

            if (islem == 1)
                sonuc = sayi1 + sayi2;
            else if (islem == 2)
                sonuc = sayi1 - sayi2;
            else if (islem == 3)
                sonuc = sayi1 * sayi2;
            else if (islem == 4)
                sonuc = sayi1 / sayi2;
            else
                sonuc = 0;

            return sonuc;

        }
        private void btnclaer_Click(object sender, EventArgs e)
        {
            string veri = txtkutu.Text;
            txtkutu.Text = "";
            int i;
            for (i = 0; i < veri.Length - 1; i++)
            {
                txtkutu.Text += veri[i].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            txtkutu.Clear();
        }

        public void sifirla()
        {
            txtkutu.Text = "0";
        }
    }

}
