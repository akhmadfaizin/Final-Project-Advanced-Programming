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
    public partial class FormMenuUtama : Form
    {
        private Interface.IntfMenuUtama intfmenuutama;

        private string v2id_pegawai;
        private int no_transaksi_dgv;
        private Boolean status;

        // Class Constructor
        public FormMenuUtama(string id_pegawai)
        {
            intfmenuutama = Factory.Factory.getMenuUtama();

            InitializeComponent();

            // Autopopulate Datagridview
            load_table();               // Populate Datagridview
            load_combobox_search();     // Populate Combobox for Searching

            // Set value id_pegawai to v2id_pegawai
            v2id_pegawai = id_pegawai;

            // Get Nama Pegawai From Database by passing id_pegawai as parameter
            lbl_namapegawai.Text = intfmenuutama.getNamaPegawai(v2id_pegawai);

        }

        // Method to populate Datagridview
        public void load_table()
        {
            DataTable ltdgv = intfmenuutama.load_table();
            dataGridView1.DataSource = ltdgv;
            // Set Date Format on "Tanggal Pengiriman" column to dd/MM/yyyy
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        // Method to populate ComboBox cmbSearchBox
        void load_combobox_search()
        {
            cmbSearchBox.Items.Add("Kode Kiriman");
            cmbSearchBox.Items.Add("Tanggal Pengiriman");
            cmbSearchBox.Items.Add("Nama Pengirim");
            cmbSearchBox.Items.Add("Nama Penerima");        
            cmbSearchBox.Items.Add("Kota Penerima");
            cmbSearchBox.Items.Add("Berat");
            cmbSearchBox.Items.Add("Lama Pengiriman");
            cmbSearchBox.Items.Add("Biaya Pengiriman");
            cmbSearchBox.SelectedItem = "Kode Kiriman";
        }

        // Set Dataview Filter by TextChanged Event
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            
            DataTable ltdgv = intfmenuutama.load_table();
            DataView dv = new DataView(ltdgv);

            var column = cmbSearchBox.GetItemText(cmbSearchBox.SelectedItem);
            var value = txt_Search.Text;
            var filter = string.Format("Convert([{0}], System.String) LIKE '%{1}%'", column, value);
            dv.RowFilter = filter;

            dataGridView1.DataSource = dv;
        }

        
        // Get id_transaksi whenever a row on Datagridview is selected
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                no_transaksi_dgv = Convert.ToInt32(selectedRow.Cells["Kode Kiriman"].Value);
            }
        }

        // Method To return id_transaksi value
        public int getNoTransaksi()
        {
            return no_transaksi_dgv;
        }

        // Method To return id_pegawai value
        public string getIdPegawai()
        {
            return v2id_pegawai;
        }

        // Button Add
        private void btn_add_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                FormTambahData td = new FormTambahData(this);
                td.ShowDialog();
            }
            else
            {
                MessageBox.Show("Silahkan Pilih Data yang ingin diedit");
            }           
        }

        // Button Edit
        private void btn_edit_Click(object sender, EventArgs e)
        {
            FormEditData ed = new FormEditData(this);
            ed.ShowDialog();         
        }

        // Button Delete
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Apakah anda ingin menghapus No Transaksi " + no_transaksi_dgv + " ?", "Konfirmasi Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    status = intfmenuutama.deletedata(no_transaksi_dgv);

                    if (status == true)
                    {
                        MessageBox.Show("DATA TELAH DIHAPUS");
                    }
                    else
                    {
                        MessageBox.Show("DATA GAGAL TERHAPUS");
                    }

                    load_table();
                }
            }
            else
            {
                MessageBox.Show("Silahkan Pilih Data yang ingin dihapus");
            }
        }

        // Button Print
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FormSlip fs = new FormSlip(this);
                fs.ShowDialog();
            }
            else
            {
                MessageBox.Show("Silahkan Pilih Data yang ingin dicetak");
            }           
        }

        // Button Logout
        private void btn_logout_Click(object sender, EventArgs e)
        {
            Close();
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