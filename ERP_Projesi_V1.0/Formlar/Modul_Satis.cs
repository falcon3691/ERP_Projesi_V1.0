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
        int x = 0, y = 0;


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
            String Ad = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int Adet;
            int Fiyat = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            int ToplamFiyat = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            bool durum = true, olurmu = true;


            if (Adlar.Count > 0)
            {
                int index = 0;
                for (int j = 0; j < Adlar.Count; j++)
                {
                    if (Ad.Equals(Adlar[j]))
                    {
                        durum = false;
                        index = j;
                    }
                }
                //Fişte bulunmayan 2. ve sonrasında eklenen ürünler
                if (durum == true)
                {
                    if ((int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())) > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) - 1;
                        olurmu = true;
                    }
                    else
                    {
                        olurmu = false;
                    }

                    if (olurmu)
                    {

                        Adlar.Add(Ad);
                        Adetler.Add(1);
                        Fiyatlar.Add(Fiyat);
                        ToplamFiyatlar.Add(ToplamFiyat);
                        y = (Adlar.Count - 1) * 20;


                        Label ad = new Label();
                        ad.Text = Adlar[Adlar.Count - 1];
                        ad.AutoSize = true;
                        ad.Location = new Point(x, y);
                        panel1.Controls.Add(ad);

                        Label adet = new Label();
                        adet.Text = Adetler[Adetler.Count - 1].ToString();
                        adet.AutoSize = true;
                        adet.Location = new Point(x + 150, y);
                        panel1.Controls.Add(adet);

                        Label fiyat = new Label();
                        fiyat.Text = Fiyatlar[Fiyatlar.Count - 1].ToString();
                        fiyat.AutoSize = true;
                        fiyat.Location = new Point(x + 210, y);
                        panel1.Controls.Add(fiyat);

                        Label toplamFiyat = new Label();
                        toplamFiyat.Text = ToplamFiyatlar[ToplamFiyatlar.Count - 1].ToString();
                        toplamFiyat.AutoSize = true;
                        toplamFiyat.Location = new Point(x + 300, y);
                        panel1.Controls.Add(toplamFiyat);
                    }


                }
                //Fişte bulunan ürünün tekrar eklenmesi
                else if (durum == false)
                {
                    if ((int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())) > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) - 1;
                        olurmu = true;
                    }
                    else
                    {
                        olurmu = false;
                    }
                    if (olurmu)
                    {

                        int ilkX, sonX, ilkY, sonY;
                        ToplamFiyatlar[index] += ToplamFiyat;
                        Adetler[index] += 1;
                        y = index * 20;
                        if (index == 0)
                        {
                            ilkX = 0;
                            sonX = 367;
                            ilkY = y;
                            sonY = 10;
                        }
                        else
                        {
                            ilkX = 0;
                            sonX = 367;
                            ilkY = y;
                            sonY = y - (index * 10);
                        }

                        Rectangle regionToClear = new Rectangle(ilkX, ilkY, sonX, sonY);
                        for (int i = panel1.Controls.Count - 1; i >= 0; i--)
                        {
                            Control ctrl = panel1.Controls[i];
                            if (regionToClear.Contains(ctrl.Location))
                            {
                                panel1.Controls.RemoveAt(i);
                            }
                        }

                        Label ad = new Label();
                        ad.Text = Adlar[index];
                        ad.AutoSize = true;
                        ad.Location = new Point(x, y);
                        panel1.Controls.Add(ad);

                        Label adet = new Label();
                        adet.Text = Adetler[index].ToString();
                        adet.AutoSize = true;
                        adet.Location = new Point(x + 150, y);
                        panel1.Controls.Add(adet);

                        Label fiyat = new Label();
                        fiyat.Text = Fiyatlar[index].ToString();
                        fiyat.AutoSize = true;
                        fiyat.Location = new Point(x + 210, y);
                        panel1.Controls.Add(fiyat);

                        Label toplamFiyat = new Label();
                        toplamFiyat.Text = ToplamFiyatlar[index].ToString();
                        toplamFiyat.AutoSize = true;
                        toplamFiyat.Location = new Point(x + 300, y);
                        panel1.Controls.Add(toplamFiyat);
                    }
                }
            }
            //Fişe eklenen ilk ürün
            else
            {
                if ((int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())) > 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) - 1;
                    olurmu = true;
                }
                else
                {
                    olurmu = false;
                }

                if (olurmu)
                {

                    Adlar.Add(Ad);
                    Adetler.Add(1);
                    Fiyatlar.Add(Fiyat);
                    ToplamFiyatlar.Add(ToplamFiyat);

                    Label ad = new Label();
                    ad.Text = Adlar[0];
                    ad.AutoSize = true;
                    ad.Location = new Point(x, y);
                    panel1.Controls.Add(ad);

                    Label adet = new Label();
                    adet.Text = Adetler[0].ToString();
                    adet.AutoSize = true;
                    adet.Location = new Point(x + 150, y);
                    panel1.Controls.Add(adet);

                    Label fiyat = new Label();
                    fiyat.Text = Fiyatlar[0].ToString();
                    fiyat.AutoSize = true;
                    fiyat.Location = new Point(x + 210, y);
                    panel1.Controls.Add(fiyat);

                    Label toplamFiyat = new Label();
                    toplamFiyat.Text = ToplamFiyatlar[0].ToString();
                    toplamFiyat.AutoSize = true;
                    toplamFiyat.Location = new Point(x + 300, y);
                    panel1.Controls.Add(toplamFiyat);
                }
            }

            genelToplam = 0;
            foreach (var item in ToplamFiyatlar)
            {
                genelToplam += item;
            }
            label6.Text = genelToplam.ToString();
            label6.Visible = true;
        }
        //SATIŞ YAP butonu
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime Tarih = DateTime.Today;
            String tarih = Tarih.Month + "." + Tarih.Day + "." + Tarih.Year;
            String eklemeKomutu = "INSERT INTO muhasebe(tarih, toplamFİyat)" +
                               "VALUES('" + tarih + "', '" + genelToplam + "')";
            SqlCommand komut1 = new SqlCommand(eklemeKomutu, baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            for (int item = 0; item < dataGridView1.RowCount; item++)
            {
                String güncellemeKomutu = "UPDATE malzeme SET miktari='" + dataGridView1.Rows[item].Cells[1].Value + "' " +
                    "WHERE adi='" + dataGridView1.Rows[item].Cells[0].Value + "'";
                SqlCommand komut2 = new SqlCommand(güncellemeKomutu, baglanti);
                komut2.ExecuteNonQuery();
            }
            baglanti.Close();
            temizle();
        }
        //FİŞİ TEMİZLE butonu
        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Adlar.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value == Adlar[i])
                    {
                        dataGridView1.Rows[j].Cells[1].Value = int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString()) + Adetler[i];
                    }
                }
            }
            temizle();
        }
        public void temizle()
        {
            panel1.Controls.Clear();
            Adlar.Clear();
            Adetler.Clear();
            Fiyatlar.Clear();
            ToplamFiyatlar.Clear();
            genelToplam = 0;
            label6.Text = genelToplam.ToString();
            y = 0;
        }
    }
}

