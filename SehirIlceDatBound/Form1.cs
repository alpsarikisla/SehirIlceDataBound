using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SehirIlceDatBound
{
    public partial class Form1 : Form
    {
        DataModel murtaza = new DataModel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_sehir.ValueMember = "ID";
            cb_sehir.DisplayMember = "Isim";
            List<Sehir> sehirler = murtaza.SehirleriGetir();
            sehirler.Insert(0, new Sehir() { ID = 0, Isim = "Seçiniz..." });
            cb_sehir.DataSource = sehirler;
        }

        private void btn_gonder_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            bool tamammi = true;
            sb.AppendLine("Gerekli alanları dondurunuz");
            if (Convert.ToInt32(cb_sehir.SelectedValue) == 0)
            {
                sb.AppendLine ("Şehir Seçiniz");
                tamammi = false;
            }
            if (cb_ilce.Text == "Şehir Seçiniz")
            {
                sb.AppendLine("İlçe Seçiniz");
                tamammi = false;
            }
            if (tamammi)
            {
                StringBuilder sbadres = new StringBuilder();
                sbadres.AppendLine("Adres = " + tb_adres.Text);
                sbadres.AppendLine("Şehir = " + cb_sehir.Text);
                sbadres.AppendLine("Ilçe = " + cb_ilce.Text);
                tb_ozet.Text = sbadres.ToString();
            }
            else
            {

                MessageBox.Show(sb.ToString(), "Uyarı");
            }
        }

        private void cb_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sehirID = Convert.ToInt32(cb_sehir.SelectedValue);
            if (sehirID != 0)
            {
                cb_ilce.DisplayMember = "Isim";
                cb_ilce.ValueMember = "ID";
                cb_ilce.DataSource = murtaza.IlceleriGetir(sehirID);
            }
            else
            {
                cb_ilce.Text = "Şehir Seçiniz";
            }
        }
    }
}
