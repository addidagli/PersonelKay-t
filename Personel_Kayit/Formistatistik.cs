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

namespace Personel_Kayit
{
    public partial class Formistatistik : Form
    {
        public Formistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9FKNVJM\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Formistatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count (*) from Tbl_Personel ",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count (*) from Tbl_Personel where Perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            
            //BEKAR PERSONEL
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count (*) from Tbl_Personel where Perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //SEHİR SAYISI
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(Persehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblpersonelsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //TOPLAM MAAS
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortalamamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
