using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Facadee;
using System.Data.SqlClient;
using System.Data;

namespace siteyönetimi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "KULLANICI")
            {
                groupBox1.Visible = true;
               
                groupBox3.Visible = false;
            }
            else if (comboBox1.SelectedItem == "DAİRE")
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection
              ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Site;Integrated Security=True");
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "KGiris";
            komut.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            komut.Parameters.AddWithValue("Sifre", textBox2.Text);
            baglanti.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler başarılı giriş yaptınız.\n Menü sayfasına yönlendiriliyorsunuz.");
                menu git = new menu();
                git.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı tekrar deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglanti.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection
              ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Site;Integrated Security=True");
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DGiris";
            komut.Parameters.AddWithValue("ID", textBox5.Text);
            komut.Parameters.AddWithValue("AdSoyad", textBox6.Text);
            baglanti.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler başarılı giriş yaptınız.\n Destek Talep sayfasına yönlendiriliyorsunuz.");
                DestekTalep git = new DestekTalep();
                git.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı tekrar deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciGiris add = new KullaniciGiris();

            add.KullaniciAdi= textBox3.Text;
            add.Sifre = textBox4.Text;
           


            if (FKullanici.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız");
                textBox3.Clear();
                textBox4.Clear();
                    }
               
        }
    }
}
