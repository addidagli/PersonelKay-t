using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;                //sql bağlanmak için bu kütüphaneyi açıyoruz

namespace Personel_Kayit
{
    public partial class FormAnaform : Form
    {
        public FormAnaform()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9FKNVJM\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
                                                                       //tam burada 2 tane ters slash olmalı

            void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text== "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where Perid=@k1 ", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5, PerMeslek=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Güncellendi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Formistatistik fr = new Formistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            Formgrafikler frg = new Formgrafikler();
            frg.Show();
        }
    }
}
