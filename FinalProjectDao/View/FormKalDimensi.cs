using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectDao.View
{
    public partial class FormKalDimensi : Form
    {
        private Entity.EntKalDimensi ek = new Entity.EntKalDimensi();
        private Interface.IntfKalDimension intfhitungberat;

        // Class Constructor
        public FormKalDimensi()
        {
            intfhitungberat = Factory.Factory.getBeratDimensi();
            InitializeComponent();
        }

        // Button To Calculate
        private void btn_hitung_Click(object sender, EventArgs e)
        {
            ek.setPanjang(Convert.ToDouble(txt_panjang.Text));
            ek.setLebar(Convert.ToDouble(txt_lebar.Text));
            ek.setTinggi(Convert.ToDouble(txt_tinggi.Text));
          
            txt_berat.Text = intfhitungberat.hitungberat(ek).ToString();
        }

        // Button To Reset
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_panjang.Text = "";
            txt_lebar.Text = "";
            txt_tinggi.Text = "";
            txt_berat.Text = "";
        }

        // Button To Close
        private void btn_keluar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // Preventing Interface from Flickering too often dan disable close button on window form
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                cp.ClassStyle = cp.ClassStyle | CP_NOCLOSE_BUTTON;
                return cp;
            }
        }

        // Useless Event Methods
        private void textBox3_TextChanged(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}
  
    }
}
