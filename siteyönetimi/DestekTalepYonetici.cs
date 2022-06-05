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
    public partial class DestekTalepYonetici : Form
    {
        public DestekTalepYonetici()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }
        private void Liste()
        {
            List<Entity.DestekTalep> destekTaleps = FDestek.Listele();
            dataGridView1.DataSource = destekTaleps;
        }
        private void DestekTalepYonetici_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[2].Value.ToString();
            textBox2.Text = s.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Entity.DestekTalep ka = new Entity.DestekTalep();
            ka.ID = Convert.ToInt32(textBox1.Tag);
            FDestek.Sil(ka);
            Liste();
        }
    }
}
