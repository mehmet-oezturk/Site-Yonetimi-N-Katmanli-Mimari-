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
    public partial class Personeller : Form
    {
        public Personeller()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlCommand komut = new SqlCommand();               //listeleme kalıbı
            komut.Connection = Baglanti.con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PListele";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            goruntule.Fill(dt);
            dataGridView1.DataSource = dt;
          

        }
        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entity.Personeller add = new Entity.Personeller();

            add.AdSoyad = (textBox1.Text);
            add.BolumNo = Convert.ToInt32(textBox2.Text);
            add.Tel = textBox3.Text;
            add.CalistigiBlokNo= Convert.ToInt32(textBox4.Text);



            if (PersonelManager.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");

            }
            else
                MessageBox.Show("Ekleme Başarısız");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Entity.Personeller add = new Entity.Personeller();
            add.ID = Convert.ToInt32(textBox1.Tag);
            add.AdSoyad = (textBox1.Text);
            add.BolumNo = Convert.ToInt32(textBox2.Text);
            add.Tel = textBox3.Text;
            add.CalistigiBlokNo = Convert.ToInt32(textBox4.Text); ;
            if (PersonelManager.Guncelleme(add) > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");

            }
            else
                MessageBox.Show("Güncelleme Başarısız");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[1].Value.ToString();
            textBox2.Text = s.Cells[2].Value.ToString();
            textBox3.Text = s.Cells[4].Value.ToString();
            textBox4.Text = s.Cells[5].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Entity.Personeller add = new Entity.Personeller();
            add.ID = Convert.ToInt32(textBox1.Tag);
            if (!FPersonel.Sil(add))
                MessageBox.Show("Silinemedi");
            listele();
        }

        private void Personeller_Load(object sender, EventArgs e)
        {

        }
    }
}
