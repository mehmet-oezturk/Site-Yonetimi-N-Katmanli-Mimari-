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

using BusinessLayer;

namespace siteyönetimi
{
    public partial class Bloklar : Form
    {
        public Bloklar()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            List<Bloks> blok = BlokManager.Listele();
            dataGridView1.DataSource = blok;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bloks add = new Bloks();
           
            add.Kat = Convert.ToInt32(textBox2.Text);
            add.Ad = textBox3.Text;
            add.YoneticiID = Convert.ToInt32(textBox4.Text);
            

            if (BlokManager.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");

            }
            else
                MessageBox.Show("Ekleme Başarısız");
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bloks add = new Bloks();
            add.ID = Convert.ToInt32(textBox1.Text);
            add.Kat = Convert.ToInt32(textBox2.Text);
            add.Ad = textBox3.Text;
            add.YoneticiID = Convert.ToInt32(textBox4.Text);
            if (BlokManager.Guncelle(add) > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");

            }
            else
                MessageBox.Show("Güncelleme Başarısız");
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Bloks k = new Bloks();
            k.ID = Convert.ToInt32(textBox2.Tag);
            if (!FBlok.Sil(k))
                MessageBox.Show("Silinemedi");
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox2.Tag = s.Cells[0].Value.ToString();
            textBox2.Text = s.Cells[1].Value.ToString();
            textBox3.Text = s.Cells[2].Value.ToString();
            textBox4.Text = s.Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }
    }
}
