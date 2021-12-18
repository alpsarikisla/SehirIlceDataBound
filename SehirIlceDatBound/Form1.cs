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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataModel murtaza = new DataModel();
            cb_sehir.ValueMember = "ID";
            cb_sehir.DisplayMember = "Isim";
            cb_sehir.DataSource = murtaza.SehirleriGetir();
        }

        private void btn_gonder_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cb_sehir.Text + " " + cb_sehir.SelectedValue);
        }
    }
}
