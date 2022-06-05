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
    public partial class Daireler : Form
    {
        public Daireler()
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
            List<Entity.Daireler> dairelers = FDaireler.Listele();
            dataGridView1.DataSource = dairelers;
        }
        private void Daireler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Entity.Daireler> dairelers = FDaireler.BorcluListele();
            dataGridView1.DataSource = dairelers;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Entity.Daireler> dairelers = FDaireler.BorcsuzListele();
            dataGridView1.DataSource = dairelers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entity.Daireler add = new Entity.Daireler();

            add.DaireNo = Convert.ToInt32(textBox1.Text);
            add.BlokNo = Convert.ToInt32(textBox2.Text);
            add.AdSoyad = textBox3.Text;
            add.Tel = textBox4.Text;
            add.Aidat = Convert.ToDecimal(textBox5.Text);
            add.Kira = Convert.ToDecimal(textBox6.Text);
            add.Dolu = Convert.ToBoolean(comboBox1.SelectedItem);

            if (DaireManager.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");

            }
            else
                MessageBox.Show("Ekleme Başarısız");
            Liste();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Entity.Daireler add = new Entity.Daireler();

            add.DaireNo = Convert.ToInt32(textBox1.Text);
            add.BlokNo = Convert.ToInt32(textBox2.Text);
            add.AdSoyad = textBox3.Text;
            add.Tel = textBox4.Text;
            add.Aidat = Convert.ToDecimal(textBox5.Text);
            add.Kira = Convert.ToDecimal(textBox6.Text);
            add.Dolu = Convert.ToBoolean(comboBox1.SelectedItem);
            add.ID = Convert.ToInt32(textBox1.Tag);

            if (DaireManager.Guncelle(add) > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");

            }
            else
                MessageBox.Show("Güncelleme Başarısız");
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Text = s.Cells[0].Value.ToString();
            textBox2.Text = s.Cells[1].Value.ToString();
            textBox3.Text = s.Cells[2].Value.ToString();
            textBox4.Text = s.Cells[3].Value.ToString();
            textBox5.Text = s.Cells[4].Value.ToString();
            textBox6.Text = s.Cells[5].Value.ToString();
            comboBox1.Text = s.Cells[6].Value.ToString();
            textBox1.Tag = s.Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
           Entity.Daireler k = new Entity.Daireler();
            k.ID = Convert.ToInt32(textBox1.Tag);
            if (!FDaireler.Sil(k))
                MessageBox.Show("Silinemedi");
            Liste();
        }
    }
}
