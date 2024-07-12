using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ERP_Projesi_V1._0
{
    public partial class Modul_Muhasebe : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HSH38D0\\SQLEXPRESS;Initial Catalog=KKP_V1;Integrated Security=True");
        public Modul_Muhasebe()
        {
            InitializeComponent();
            listele();
        }

        public void listele()
        {
            baglanti.Open();
            String sqlKomutu = "SELECT * FROM muhasebe";
            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label2.Visible = false;
                dateTimePicker2.Visible = false;
            }
            else
            {
                label2.Visible = true;
                dateTimePicker2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime Tarih = dateTimePicker1.Value;
            String tarih = Tarih.Month + "." + Tarih.Day + "." + Tarih.Year;
            baglanti.Open();
            String sqlKomutu = "SELECT * FROM muhasebe WHERE tarih='" + tarih + "'";
            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime ilkTarih = dateTimePicker1.Value;
            String ilktarih = ilkTarih.Month + "-" + ilkTarih.Day + "-" + ilkTarih.Year;
            DateTime sonTarih = dateTimePicker2.Value;
            String sontarih = sonTarih.Month + "-" + sonTarih.Day + "-" + sonTarih.Year;
            baglanti.Open();
            String sqlKomutu = "SELECT * FROM muhasebe WHERE tarih BETWEEN '" + ilktarih + "' AND '"+sontarih+"'";
            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
