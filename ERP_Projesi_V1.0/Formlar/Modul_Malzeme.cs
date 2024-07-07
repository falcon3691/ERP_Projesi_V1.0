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
    public partial class Modul_Malzeme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HSH38D0\\SQLEXPRESS;Initial Catalog=KKP_V1;Integrated Security=True");

        public Modul_Malzeme()
        {
            InitializeComponent();
            listele();
        }
        private void Modul_Malzeme_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kKP_V1DataSet.malzeme' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.malzemeTableAdapter.Fill(this.kKP_V1DataSet.malzeme);

        }

        //EKLE butonu
        private void button1_Click(object sender, EventArgs e)
        {
            String adi;
            int miktari;
            try
            {
                adi = textBox1.Text.ToString();
            }
            catch (Exception hata)
            {
                adi = "";
            }
            try
            {
                miktari = int.Parse(textBox2.Text.ToString());
            }
            catch (Exception hata)
            {

                miktari = 0;
            }
            if (adi != "")
            {
                if (miktari > 0)
                {
                    baglanti.Open();
                    String sqlKomutu = "INSERT INTO malzeme(adi, miktari) " +
                        "VALUES('" + adi + "', '" + miktari + "')";
                    SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
                    int i = komut.ExecuteNonQuery();
                    baglanti.Close();
                    if (i > 0)
                        Console.Out.WriteLine("Ürün başarılı bir şekilde eklendi.");
                    else
                        MessageBox.Show("Ürün eklenemedi.");
                }
                else
                {
                    MessageBox.Show("Miktarı boş bırakılamaz.");
                }
            }
            else
            {
                MessageBox.Show("Adı boş bırakılamaz.");
            }
            listele();
            temizle();
        }
        //SİL butonu
        private void button2_Click(object sender, EventArgs e)
        {
            String adi;
            int miktari;
            try
            {
                adi = textBox1.Text.ToString();
            }
            catch (Exception hata)
            {
                adi = "";
            }
            try
            {
                miktari = int.Parse(textBox2.Text.ToString());
            }
            catch (Exception hata)
            {

                miktari = 0;
            }
            if (adi != "")
            {
                if (miktari > 0)
                {
                    baglanti.Open();
                    String sqlKomutu = "DELETE FROM malzeme WHERE adi='" + adi + "'";
                    SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
                    int i = komut.ExecuteNonQuery();
                    baglanti.Close();
                    if (i > 0)
                        Console.Out.WriteLine("Ürün başarılı bir şekilde silindi.");
                    else
                        MessageBox.Show("Ürün silinemedi.");
                }
                else
                {
                    MessageBox.Show("Miktarı boş bırakılamaz.");
                }
            }
            else
            {
                MessageBox.Show("Adı boş bırakılamaz.");
            }
            listele();
            temizle();
        }
        int id;
        //DÜZELT botonu
        private void button3_Click(object sender, EventArgs e)
        {
            {
                String adi;
                int miktari;
                try
                {
                    adi = textBox1.Text.ToString();
                }
                catch (Exception hata)
                {
                    adi = "";
                }
                try
                {
                    miktari = int.Parse(textBox2.Text.ToString());
                }
                catch (Exception hata)
                {

                    miktari = 0;
                }
                if (id > 0)
                {
                    if (adi != "")
                    {
                        if (miktari > 0)
                        {
                            baglanti.Open();
                            String sqlKomutu = "UPDATE malzeme SET adi='" + adi + "', miktari='" + miktari + "' WHERE id='" + id + "'";
                            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
                            int i = komut.ExecuteNonQuery();
                            baglanti.Close();
                            if (i > 0)
                                Console.Out.WriteLine("Ürün başarılı bir şekilde düzeltildi.");
                            else
                                MessageBox.Show("Ürün düzeltilemedi.");
                        }
                        else
                        {
                            MessageBox.Show("Miktarı boş bırakılamaz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Adı boş bırakılamaz.");
                    }
                }
                else
                {
                    MessageBox.Show("Listeden bir ürün seçin.");
                }

                listele();
                temizle();
            }
        }

        public void listele()
        {
            baglanti.Open();
            String sqlKomutu = "SELECT * FROM malzeme";
            SqlCommand komut = new SqlCommand(sqlKomutu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
