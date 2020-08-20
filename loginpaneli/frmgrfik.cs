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
    public partial class frmgrfik : Form
    {
        public frmgrfik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NLU8KS5\\SQLEXPRESS;Initial Catalog=loginpanel;Integrated Security=True");

        private void chart1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select Sehir,count(*) from veri group by Sehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
                while(dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select Durum,count(*) from veri group by Durum", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Durumlar"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

        private void frmgrfik_Load(object sender, EventArgs e)
        {

        }
    }
}
