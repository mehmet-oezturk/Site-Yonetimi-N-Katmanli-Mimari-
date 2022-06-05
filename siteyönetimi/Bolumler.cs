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

namespace siteyönetimi
{
    public partial class Bolumler : Form
    {
        

        public Bolumler()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }
        private void Liste()
        {
            List<Entity.Bolumler> bolumlers = BolumManager.Listele();

            dataGridView1.DataSource = bolumlers;
        }
        private void Bolumler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entity.Bolumler add = new Entity.Bolumler();
          
            add.Ad = textBox1.Text;
            FBolumler.Ekleme(add);
            Liste();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Entity.Bolumler add = new Entity.Bolumler();
            add.ID = Convert.ToInt32(textBox1.Tag);
            add.Ad = textBox1.Text;
            FBolumler.Guncelle(add);
            //if (BlokManager.Guncelle(add) > 0)
            //{
            //    MessageBox.Show("Güncelleme Başarılı");

            //}
            //else
            //    MessageBox.Show("Güncelleme Başarısız");
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Entity.Bolumler add = new Entity.Bolumler();
            add.ID = Convert.ToInt32(textBox1.Tag);

            FBolumler.Sil(add);
            Liste();
        }
    }
}
