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

namespace siteyönetimi
{
    public partial class Yoneticiler : Form
    {
        public Yoneticiler()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[1].Value.ToString();
            textBox2.Text = s.Cells[2].Value.ToString();
        }
        public void listele()
        {
            SqlCommand komut = new SqlCommand();               
            komut.Connection = Baglanti.con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "YListele";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entity.Yoneticiler add = new Entity.Yoneticiler();

            add.AdSoyad = (textBox1.Text);
           
            add.Tel = textBox2.Text;
            if (YoneticilerManager.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");

            }
            else
                MessageBox.Show("Ekleme Başarısız");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Entity.Yoneticiler add = new Entity.Yoneticiler();
            add.ID = Convert.ToInt32(textBox1.Tag);
            add.AdSoyad = (textBox1.Text);

            add.Tel = textBox2.Text;
            if (YoneticilerManager.Guncelle(add) > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");

            }
            else
                MessageBox.Show("Güncelleme Başarısız");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;
            Entity.Yoneticiler add = new Entity.Yoneticiler();
            add.ID = Convert.ToInt32(textBox1.Tag);
            if (!FYonetici.Sil(add))
                MessageBox.Show("Silinemedi");
            listele();
        }
    }
}
