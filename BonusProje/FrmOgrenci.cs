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

namespace BonusProje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_ogrenciTableAdapter ds1 = new DataSet1TableAdapters.tbl_ogrenciTableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-43VL7FN;Initial Catalog=BonusOkul;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds1.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*from tbl_kulupler",baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "kulupad";
            cmbkulup.ValueMember = "kulupid";
            cmbkulup.DataSource = dt;
            baglanti.Close();   
            
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            
        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            
            ds1.OgrenciEkle(txtadi.Text, txtsoyadi.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds1.OgrenciGuncelle(txtadi.Text,txtsoyadi.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),c,int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci Güncelle Yapıldı");
            dataGridView1.DataSource = ds1.OgrenciListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds1.OgrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci Silme Yapıldı");
            dataGridView1.DataSource = ds1.OgrenciListesi();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds1.OgrenciGetir(txtara.Text);
        }
    }
}
