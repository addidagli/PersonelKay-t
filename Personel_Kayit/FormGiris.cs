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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9FKNVJM\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                FormAnaform frm = new FormAnaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ya da Şifre Yanlış");
            }
            baglanti.Close();
        }
    }
}
