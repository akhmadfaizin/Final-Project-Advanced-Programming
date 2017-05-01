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
    public partial class FormLogin : Form
    {
        private Boolean status;
        private Interface.IntfPegawai pegawaiDao;

        // Class Constructor
        public FormLogin()
        {
            pegawaiDao = Factory.Factory.getPegawai();

            InitializeComponent();

            // Watermark Textbox NIK
            txt_nik.ForeColor = SystemColors.GrayText;
            txt_nik.Text = "NIK";
            this.txt_nik.Leave += new System.EventHandler(this.txt_nik_Leave);
            this.txt_nik.Enter += new System.EventHandler(this.txt_nik_Enter);

            // Watermark Textbox Password
            txt_password.ForeColor = SystemColors.GrayText;
            txt_password.Text = "PASSWORD";
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);

            // Set The Focus on Login Pegawai Label when FormLogin loaded
            this.ActiveControl = pb_LogoLogin;
        }

        // Reset Textbox on NIK and PASSWORD
        private void resetnikpass()
        {
            txt_password.PasswordChar = '\0';
            txt_password.Text = "PASSWORD";
            txt_password.ForeColor = SystemColors.GrayText;
            txt_nik.Text = "NIK";
            txt_nik.ForeColor = SystemColors.GrayText;
        }

        // Watermark Textbox NIK on Leave
        private void txt_nik_Leave(object sender, EventArgs e)
        {
            if (txt_nik.Text.Length == 0)
            {
                txt_nik.Text = "NIK";
                txt_nik.ForeColor = SystemColors.GrayText;
            }
        }

        // Watermark Textbox NIK Disappear on Enter
        private void txt_nik_Enter(object sender, EventArgs e)
        {
            if (txt_nik.Text == "NIK")
            {
                txt_nik.Text = "";
                txt_nik.ForeColor = SystemColors.WindowText;
            }
        }

        // Watermark Textbox PASSWORD on Leave
        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text.Length == 0)
            {
                txt_password.PasswordChar = '\0';
                txt_password.Text = "PASSWORD";               
                txt_password.ForeColor = SystemColors.GrayText;
            }
        }

        // Watermark Textbox PASSWORD Disappear on Enter
        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == "PASSWORD")
            {
                txt_password.Text = "";
                txt_password.PasswordChar = '*';
                txt_password.ForeColor = SystemColors.WindowText;
            }
        }

        // Login Button
        private void btn_login_Click(object sender, EventArgs e)
        {
            if(txt_nik.Text=="" || txt_password.Text == "")
            {
                MessageBox.Show("NIK dan PASSWORD harus diisi !");
            }
            else
            {                
                status = pegawaiDao.LoginPegawai(txt_nik.Text, txt_password.Text);
                
                if(status == true)
                {
                    Hide();
                    View.FormMenuUtama mu = new View.FormMenuUtama(txt_nik.Text);
                    mu.ShowDialog();
                    mu = null;
                    Show();
                    resetnikpass();
                }
                else
                {
                    MessageBox.Show("Maaf Login Gagal");
                    resetnikpass();
                }
            }         
        }

        // Button to Quit Application
        private void btn_quit_Click(object sender, EventArgs e)
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

    }
}
