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
    public partial class Modul_Satis : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HSH38D0\\SQLEXPRESS;Initial Catalog=KKP_V1;Integrated Security=True");
        public Modul_Satis()
        {
            InitializeComponent();
            listele();
        }
        int genelToplam = 0;
        List<String> Adlar = new List<string>();
        List<int> Adetler = new List<int>();
        List<int> Fiyatlar = new List<int>();
        List<int> ToplamFiyatlar = new List<int>();
       
        

        public void listele()
        {
            baglanti.Open();
            String sqlKomutu = "SELECT adi, miktari FROM malzeme";
            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Fiyat", typeof(int));
            dataGridView1.DataSource = dt;
            baglanti.Close();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = 10;
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Adlar.Add("asd");
            Adetler.Add(1);
            Fiyatlar.Add(100);
            ToplamFiyatlar.Add(1000);
            int y = 0;
            for(int i = 0; i < Adlar.Count; i++)
            {
                int x = 0;
                String Ad = Adlar[i];
                int Adet = Adetler[i];
                int Fiyat = Fiyatlar[i];
                int ToplamFiyat = ToplamFiyatlar[i];

                Label ad = new Label();
                ad.Text = "Ad";
                ad.AutoSize = true;
                label1.AutoSize = true;
                ad.Location = new Point(x, y);
                panel1.Controls.Add(ad);

                Label adet = new Label();
                adet.Text =  "Adet";
                adet.AutoSize = true;
                adet.Location = new Point(x + 143, y);
                panel1.Controls.Add(adet);

                Label fiyat = new Label();
                fiyat.Text = "Fiyat";
                fiyat.AutoSize = true;
                fiyat.Location = new Point(x + 205, y);
                panel1.Controls.Add(fiyat);

                Label toplamFiyat = new Label();
                toplamFiyat.Text = "ToplamFiyat";
                toplamFiyat.AutoSize = true;
                toplamFiyat.Location = new Point( x + 273, y);
                panel1.Controls.Add(toplamFiyat);


            }
            y += 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }
    }
}

