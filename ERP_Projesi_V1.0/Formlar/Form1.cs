using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Projesi_V1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Menu_Malzeme_Click(object sender, EventArgs e)
        {
            Modul_Malzeme form = new Modul_Malzeme();
            form.MdiParent = this;
            form.Show();
        }

        private void Menu_Satis_Click(object sender, EventArgs e)
        {
            Modul_Satis form = new Modul_Satis();
            form.MdiParent = this;
            form.Show();
        }

        private void Menu_Muhasebe_Click(object sender, EventArgs e)
        {
            Modul_Muhasebe form = new Modul_Muhasebe();
            form.MdiParent = this;
            form.Show();
        }
    }
}
