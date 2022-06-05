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
    public partial class DestekTalep : Form
    {
        public DestekTalep()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void DestekTalep_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Entity.DestekTalep add = new Entity.DestekTalep();

            add.DaireID = Convert.ToInt32(textBox1.Text);
            add.DTAciklama = textBox2.Text;
           


            if (FDestek.Ekleme(add) > 0)
            {
                MessageBox.Show("Ekleme Başarılı");

            }
            else
                MessageBox.Show("Ekleme Başarısız");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris git = new Giris();
            git.Show();
            this.Hide();
        }
    }
}
