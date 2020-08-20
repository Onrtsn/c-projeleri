using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace loginpaneli
{
    public partial class frmanagiris : Form
    {
        public int id =0;
        public frmanagiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NLU8KS5\\SQLEXPRESS;Initial Catalog=loginpanel;Integrated Security=True");

        void temizle()
        {
            txtid.Text = "";
            txtadi.Text = "";
            txtsoyadi.Text = "";
            txtepost.Text = "";
            msktel.Text = "";
            cmbshir.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            txtadi.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginpanelDataSet1.veri' table. You can move, or remove it, as needed.
            this.veriTableAdapter1.Fill(this.loginpanelDataSet1.veri);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            this.veriTableAdapter1.Fill(this.loginpanelDataSet1.veri);
        }

        private void btnkydt_Click(object sender, EventArgs e) 
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into veri (Adi,Soyadi,Telefon,E_posta,Sehir,Durum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyadi.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", txtepost.Text);
            komut.Parameters.AddWithValue("@p5", cmbshir.Text);
            komut.Parameters.AddWithValue("@p6", label7.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydedildi");
        }

        private void btndlte_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From veri where Adi=@a1", baglanti);
            komutsil.Parameters.AddWithValue("@a1", txtadi.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silinmiştir");
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            
            txtadi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyadi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            msktel.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtepost.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbshir.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            id = Int16.Parse (dataGridView1.Rows[secilen].Cells[0].Value.ToString());

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                label7.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label7.Text = "False";
            }
        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if (label7.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label7.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komutguncel = new SqlCommand("Update veri Set Adi=@g1,Soyadi=@g2,Telefon=@g3,E_posta=@g4,Sehir=@g5,Durum=@g6 where id='"+id+"'", baglanti);
            komutguncel.Parameters.AddWithValue("@g1", txtadi.Text);
            komutguncel.Parameters.AddWithValue("@g2", txtsoyadi.Text);
            komutguncel.Parameters.AddWithValue("@g3", msktel.Text);
            komutguncel.Parameters.AddWithValue("@g4", txtepost.Text);
            komutguncel.Parameters.AddWithValue("@g5", cmbshir.Text);
            komutguncel.Parameters.AddWithValue("@g6", label7.Text);
            komutguncel.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellenmiştir");
        }

        private void btnisttsk_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrfik frg = new frmgrfik();
            frg.Show();
        }

        private void btnraporlama_Click(object sender, EventArgs e)
        {

        }
    }
}
