using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Globalization;


namespace FinalProjectDao.View
{
    public partial class FormSlip : Form
    {
        private View.FormMenuUtama fmu2;
        private string id_petugas;

        private Interface.IntfEditData intfeditdata;
        private Interface.IntfAddData intfadddata;
        private Interface.IntfMenuUtama intfmenuutama;

        // Instantiation an object from EntData class
        private Entity.EntData data_print = new Entity.EntData();

        // Class Constructor
        public FormSlip(View.FormMenuUtama fmu1)
        {
            intfeditdata = Factory.Factory.getEditData();
            intfmenuutama = Factory.Factory.getMenuUtama();
            intfadddata = Factory.Factory.getTambahData();

            InitializeComponent();

            fmu2 = fmu1;

            // SET id petugas
            id_petugas = fmu1.getIdPegawai();

            // Retrieve id_transaksi by calling other class function
            data_print.setIdTransaksi(fmu1.getNoTransaksi());

            // GET DATA TRANSAKSI
            GetTransaksiDetail();

            // GET DATA PENGIRIM based on id_transaksi
            GetPengirimDetail();

            // GET DATA PENERIMA based on id_transaksi
            GetPenerimaDetail();

            // GET DATA TARIF based on id_transaksi
            GetTarifDetail();

            // Change All Label based on id_transaksi
            GetChangeLabel();

        }

        // Set All Transaksi Datas that has been retrieve to its Entity Set Functions
        void GetTransaksiDetail()
        {
            DataTable dt = intfeditdata.getTransaksi(data_print.getIdTransaksi());

            foreach (DataRow row in dt.Rows)
            {
                data_print.setTglTransaksi(Convert.ToString(row["tgl_transaksi"]));
                data_print.setBerat(Convert.ToInt32(row["berat"]));
                data_print.setIdPengirim(Convert.ToString(row["id_pengirim"]));
                data_print.setIdTarif(Convert.ToInt32(row["id_tarif"]));
                data_print.setIdPenerima(Convert.ToString(row["id_penerima"]));
            }
        }

        // Set All Pengirim Datas that has been retrieve to its Entity Set Functions
        void GetPengirimDetail()
        {
            DataTable dt = intfeditdata.getDataPengirim(data_print.getIdPengirim());

            foreach (DataRow row in dt.Rows)
            {
                data_print.setNamaPengirim(Convert.ToString(row["nama_pengirim"]));
                data_print.setJkPengirim(Convert.ToChar(row["jk"]));
                data_print.setNoHubPengirim(Convert.ToString(row["no_hub"]));
                data_print.setKodePosPengirim(Convert.ToString(row["kode_pos"]));
                data_print.setAlamatPengirim(Convert.ToString(row["alamat"]));
                data_print.setRtPengirim(Convert.ToString(row["rt"]));
                data_print.setRwPengirim(Convert.ToString(row["rw"]));
                data_print.setDesaPengirim(Convert.ToString(row["desa"]));
                data_print.setKecPengirim(Convert.ToString(row["kec"]));

                if (row["id_kabupaten"] == DBNull.Value)
                {
                    data_print.setId_KabPengirim(0);
                }
                else
                {
                    data_print.setId_KabPengirim(Convert.ToInt32(row["id_kabupaten"]));
                }

                if (row["id_provinsi"] == DBNull.Value)
                {
                    data_print.setId_ProvPengirim(0);
                }
                else
                {
                    data_print.setId_ProvPengirim(Convert.ToInt32(row["id_provinsi"]));
                }

            }
        }

        // Set All Penerima Datas that has been retrieve to its Entity Set Functions
        void GetPenerimaDetail()
        {
            DataTable dt = intfeditdata.getDataPenerima(data_print.getIdPenerima());

            foreach (DataRow row in dt.Rows)
            {
                data_print.setNamaPenerima(Convert.ToString(row["nama_penerima"]));
                data_print.setJkPenerima(Convert.ToChar(row["jk"]));
                data_print.setNoHubPenerima(Convert.ToString(row["no_hub"]));
                data_print.setKodePosPenerima(Convert.ToString(row["kode_pos"]));
                data_print.setAlamatPenerima(Convert.ToString(row["alamat"]));
                data_print.setRtPenerima(Convert.ToString(row["rt"]));
                data_print.setRwPenerima(Convert.ToString(row["rw"]));
                data_print.setDesaPenerima(Convert.ToString(row["desa"]));
                data_print.setKecPenerima(Convert.ToString(row["kec"]));
                data_print.setId_KabPenerima(Convert.ToInt32(row["id_kabupaten"]));
                data_print.setId_ProvPenerima(intfadddata.getIdComboProv(data_print.getId_KabPenerima()));
            }
        }

        // Set All Tarif Datas that has been retrieve to its Entity Set Functions
        void GetTarifDetail()
        {
            DataTable dt = intfeditdata.getInfoTarif(data_print.getIdTarif());

            foreach (DataRow row in dt.Rows)
            {
                data_print.setLamaHari(Convert.ToInt32(row["lama_hari"]));
                data_print.setKotaPengiriman(Convert.ToString(row["kota_pengiriman"]));
                data_print.setKotaTujuan(Convert.ToString(row["kota_tujuan"]));
                data_print.setTipeBarang(Convert.ToChar(row["tipe_barang"]));
                data_print.setOngkos(Convert.ToInt32(row["ongkos"]));
            }
        }

        // Set data from object data_print to Labels
        void GetChangeLabel()
        {

            // Pengirim Labels
            lbl_nama_pengirim.Text = data_print.getNamaPengirim();
            lbl_nohub_pengirim.Text = data_print.getNoHubPengirim();
            lbl_kota_pengirim.Text = data_print.getKotaPengiriman();
            lbl_alamat_pengirim.Text = data_print.getKotaPengiriman();

            // Penerima Labels
            lbl_nama_penerima.Text = data_print.getNamaPenerima();
            lbl_nohub_penerima.Text = data_print.getNoHubPenerima();
            lbl_kota_penerima.Text = data_print.getKotaTujuan();
            lbl_alamat_penerima.Text = data_print.getAlamatPenerima();
            lbl_kec_penerima.Text = data_print.getKecPenerima();
            lbl_kab_penerima.Text = intfadddata.getNamaComboKab(data_print.getId_KabPengirim());
            lbl_prov_penerima.Text = intfadddata.getNamaCombo4(data_print.getId_ProvPengirim());
            lbl_desa_penerima.Text = data_print.getDesaPenerima();
            lbl_kodepos_penerima.Text = data_print.getKodePosPenerima();
            lbl_rt_penerima.Text = data_print.getRtPenerima();
            lbl_rw_penerima.Text = data_print.getRwPenerima();

            // Data Transaksi Labels
            lbl_kode_kiriman.Text = data_print.getIdTransaksi().ToString();
            lbl_berat.Text = data_print.getBerat().ToString();
            if(data_print.getTipeBarang() == 'P')
            {
                lbl_tipebarang.Text = "Package";
            }
            else
            {
                lbl_tipebarang.Text = "Document";
            }

            
            // Display Total Pembayaran using Rupiah format
            int inttotal = (data_print.getBerat() * data_print.getOngkos());
            CultureInfo culture = new CultureInfo("id-ID");
            lbl_biayapengiriman.Text = inttotal.ToString("C", culture);

            // The other label of FormSlip
            lbl_kota_asal.Text = data_print.getKotaPengiriman();
            lbl_kota_tujuan.Text = data_print.getKotaTujuan();
            lbl_petugas.Text = intfmenuutama.getNamaPegawai(id_petugas);
            lbl_ttd_pengirim.Text = data_print.getNamaPengirim();

            // Display date to normal format
            var dateAndTimeNota = DateTime.Now;
            var datenota = dateAndTimeNota.ToString("dd MMMM yyyy");
            lbl_tglnota.Text = datenota;    
        }


        // LABEL AS BUTTON
        // PRINT in as JPEG to Drive D:\\
        private void linklbl_print_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            bitmap.Save("D:\\NotaTransaksi_"+ data_print.getIdTransaksi() + ".jpeg", ImageFormat.Jpeg);
            MessageBox.Show("Nota Berhasil Dicetak");
            Dispose();
        }

        // Preventing Interface from Flickering too often
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        // Useless Event Function
        private void lineShape3_Click(object sender, EventArgs e) { }



    }
}
