using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtdersadi.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır.");
            dataGridView1.DataSource=ds.DersListesi();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(txtdersadi.Text, byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Yapılmıştır.");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır.");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
