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
namespace metin_belge_kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Metin Dosyaları|*.txt";
            saveFileDialog1.Title = "metin Belgesi Kayıt";
            saveFileDialog1.ShowDialog();
            StreamWriter saw = new StreamWriter(saveFileDialog1.FileName);
            saw.WriteLine(richTextBox1.Text);
            saw.Close();
            MessageBox.Show("Belge Oluşturuldu");


        }
    }
}
