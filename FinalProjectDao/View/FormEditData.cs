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
    public partial class FormEditData : Form
    {

        private View.FormMenuUtama fmu2;
        private string id_pegawaiedit;
        private Boolean status;
        private char jk_pengirim, jk_penerima;

        private Interface.IntfEditData intfeditdata;
        private Interface.IntfAddData intfadddata;
        private Interface.IntfMenuUtama intfmenuutama;

        // Instantiation an object from EntData class
        private Entity.EntData data_edit = new Entity.EntData();

        // Class Constructor
        public FormEditData(View.FormMenuUtama fmu1)
        {
            intfeditdata = Factory.Factory.getEditData();
            intfadddata = Factory.Factory.getTambahData();
            intfmenuutama = Factory.Factory.getMenuUtama();

            InitializeComponent();

            fmu2 = fmu1;

            // SET id pegawai
            id_pegawaiedit = fmu2.getIdPegawai();

            // Display Nama Pegawai on Top Left
            lbl_nama_pegawai.Text = intfmenuutama.getNamaPegawai(id_pegawaiedit);

            // Retrieve id_transaksi by calling other class function
            data_edit.setIdTransaksi(fmu2.getNoTransaksi());

            // GET DATA TRANSAKSI
            GetTransaksiDetail();

            // GET DATA PENGIRIM based on id_transaksi
            GetPengirimDetail();

            // GET DATA PENERIMA based on id_transaksi
            GetPenerimaDetail();

            // GET DATA TARIF based on id_transaksi
            GetTarifDetail();

            // FILL IN ALL TEXTBOX
            FillTextBox();

            // POSITIONING RADIOBUTTON AND COMBOBOX on Pengirim Tab and Penerima Tab
            PositPengirimPenerima();

        }

        // Set All Transaksi Datas that has been retrieve to its Entity Set Functions
        void GetTransaksiDetail()
        {
            DataTable dt = intfeditdata.getTransaksi(data_edit.getIdTransaksi());

            foreach (DataRow row in dt.Rows)
            {
                data_edit.setTglTransaksi(Convert.ToString(row["tgl_transaksi"]));
                data_edit.setBerat(Convert.ToInt32(row["berat"]));
                data_edit.setIdPengirim(Convert.ToString(row["id_pengirim"]));
                data_edit.setIdTarif(Convert.ToInt32(row["id_tarif"]));
                data_edit.setIdPenerima(Convert.ToString(row["id_penerima"]));
            }
        }

        // Set All Pengirim Datas that has been retrieve to its Entity Set Functions
        void GetPengirimDetail()
        {
            DataTable dt = intfeditdata.getDataPengirim(data_edit.getIdPengirim());

            foreach (DataRow row in dt.Rows)
            {
                data_edit.setNamaPengirim(Convert.ToString(row["nama_pengirim"]));
                data_edit.setJkPengirim(Convert.ToChar(row["jk"]));
                data_edit.setNoHubPengirim(Convert.ToString(row["no_hub"]));
                data_edit.setKodePosPengirim(Convert.ToString(row["kode_pos"]));
                data_edit.setAlamatPengirim(Convert.ToString(row["alamat"]));
                data_edit.setRtPengirim(Convert.ToString(row["rt"]));
                data_edit.setRwPengirim(Convert.ToString(row["rw"]));
                data_edit.setDesaPengirim(Convert.ToString(row["desa"]));
                data_edit.setKecPengirim(Convert.ToString(row["kec"]));

                if(row["id_kabupaten"] == DBNull.Value)
                {
                    data_edit.setId_KabPengirim(0);
                }
                else
                {
                    data_edit.setId_KabPengirim(Convert.ToInt32(row["id_kabupaten"]));
                }

                if (row["id_provinsi"] == DBNull.Value)
                {
                    data_edit.setId_ProvPengirim(0);
                }
                else
                {
                    data_edit.setId_ProvPengirim(Convert.ToInt32(row["id_provinsi"]));
                }

            }
        }

        // Set All Penerima Datas that has been retrieve to its Entity Set Functions
        void GetPenerimaDetail()
        {
            DataTable dt = intfeditdata.getDataPenerima(data_edit.getIdPenerima());

            foreach (DataRow row in dt.Rows)
            {
                data_edit.setNamaPenerima(Convert.ToString(row["nama_penerima"]));
                data_edit.setJkPenerima(Convert.ToChar(row["jk"]));
                data_edit.setNoHubPenerima(Convert.ToString(row["no_hub"]));
                data_edit.setKodePosPenerima(Convert.ToString(row["kode_pos"]));
                data_edit.setAlamatPenerima(Convert.ToString(row["alamat"]));
                data_edit.setRtPenerima(Convert.ToString(row["rt"]));
                data_edit.setRwPenerima(Convert.ToString(row["rw"]));
                data_edit.setDesaPenerima(Convert.ToString(row["desa"]));
                data_edit.setKecPenerima(Convert.ToString(row["kec"]));
                data_edit.setId_KabPenerima(Convert.ToInt32(row["id_kabupaten"]));
                data_edit.setId_ProvPenerima(intfadddata.getIdComboProv(data_edit.getId_KabPenerima()));
            }
        }

        // Set All Tarif Datas that has been retrieve to its Entity Set Functions
        void GetTarifDetail()
        {
            DataTable dt = intfeditdata.getInfoTarif(data_edit.getIdTarif());

            foreach (DataRow row in dt.Rows)
            {
                data_edit.setLamaHari(Convert.ToInt32(row["lama_hari"]));
                data_edit.setKotaPengiriman(Convert.ToString(row["kota_pengiriman"]));
                data_edit.setKotaTujuan(Convert.ToString(row["kota_tujuan"]));
                data_edit.setTipeBarang(Convert.ToChar(row["tipe_barang"]));
                data_edit.setOngkos(Convert.ToInt32(row["ongkos"]));
            }
        }

        // Method To Fill textboxes
        void FillTextBox()
        {
            // TEXTBOX PENGIRIM
            txt_id_pengirim.Text = data_edit.getIdPengirim();
            txt_nama_pengirim.Text = data_edit.getNamaPengirim();
            txt_nohub_pengirim.Text = data_edit.getNoHubPengirim();
            txt_alamat_pengirim.Text = data_edit.getAlamatPengirim();
            txt_kodepos_pengirim.Text = data_edit.getKodePosPengirim();
            txt_rt_pengirim.Text = data_edit.getRtPengirim();
            txt_rw_pengirim.Text = data_edit.getRwPengirim();
            txt_desa_pengirim.Text = data_edit.getDesaPengirim();
            txt_kec_pengirim.Text = data_edit.getKecPengirim();

            // TEXTBOX PENERIMA
            txt_id_penerima.Text = data_edit.getIdPenerima();
            txt_nama_penerima.Text = data_edit.getNamaPenerima();
            txt_nohub_penerima.Text = data_edit.getNoHubPenerima();
            txt_alamat_penerima.Text = data_edit.getAlamatPenerima();
            txt_kodepos_penerima.Text = data_edit.getKodePosPenerima();
            txt_rt_penerima.Text = data_edit.getRtPenerima();
            txt_rw_penerima.Text = data_edit.getRwPenerima();
            txt_desa_penerima.Text = data_edit.getDesaPenerima();
            txt_kec_penerima.Text = data_edit.getKecPenerima();
        }

        // Method To Get Combobox, RadioButton, and Datetimepicker to its position
        void PositPengirimPenerima()
        {
            // Set Radio Button Position base on data it's retrieve
            if(data_edit.getJkPengirim() == 'L')
            {
                rb_L_pengirim.Checked = true;
                jk_pengirim = 'L';
            }
            else
            {
                rb_P_pengirim.Checked = true;
                jk_pengirim = 'P';
            }

            if (data_edit.getJkPenerima() == 'L')
            {
                rb_L_penerima.Checked = true;
                jk_penerima = 'L';
            }
            else
            {
                rb_P_penerima.Checked = true;
                jk_penerima = 'P';
            }

            // Fill combobox provinsi & kabupaten of Pengirim
            cmbProvPengirim.Items.Clear();
            cmbProvPengirim.DataSource = null;    // Because the combobox is bound to datatable
            cmbProvPengirim.ResetText();          // Make the combobox text empty
            cmbKabPengirim.Items.Clear();
            cmbKabPengirim.DataSource = null;    // Because the combobox is bound to datatable
            cmbKabPengirim.ResetText();          // Make the combobox text empty
            fillcombo4();
            if (data_edit.getId_ProvPengirim() != 0)
            {
                cmbProvPengirim.SelectedItem = intfadddata.getNamaCombo4(data_edit.getId_ProvPengirim());
            }

            if (data_edit.getId_KabPengirim() != 0)
            {
                cmbKabPengirim.SelectedItem = intfadddata.getNamaComboKab(data_edit.getId_KabPengirim());
            }

            // Fill combobox provinsi & kabupaten of Penerima
            cmbProvPenerima.Items.Clear();
            cmbProvPenerima.DataSource = null;    // Because the combobox is bound to datatable
            cmbProvPenerima.ResetText();          // Make the combobox text empty
            cmbKabPenerima.Items.Clear();
            cmbKabPenerima.DataSource = null;    // Because the combobox is bound to datatable
            cmbKabPenerima.ResetText();          // Make the combobox text empty
            fillcombo5();
            if (data_edit.getId_ProvPenerima() != 0)
            {
                cmbProvPenerima.SelectedItem = intfadddata.getNamaCombo4(data_edit.getId_ProvPenerima());
            }

            if (data_edit.getId_KabPenerima() != 0)
            {
                cmbKabPenerima.SelectedItem = intfadddata.getNamaComboKab(data_edit.getId_KabPenerima());
            }

            // Convert datetimepicker String values to DateTime value
            dateTimePicker1.Value = DateTime.Parse(data_edit.getTglTransaksi());

            // Load Combobox Kota Pengiriman
            cmbKotaPengiriman.Items.Clear();
            cmbKotaPengiriman.DataSource = null;    // Because the combobox is bound to datatable
            cmbKotaPengiriman.ResetText();          // Make the combobox text empty
            fillcombo1();
            cmbKotaPengiriman.SelectedItem = data_edit.getKotaPengiriman();

            // Load Combobox Kota Tujuan
            cmbKotaTujuan.Items.Clear();
            cmbKotaTujuan.DataSource = null;    // Because the combobox is bound to datatable
            cmbKotaTujuan.ResetText();          // Make the combobox text empty
            fillcombo2();
            cmbKotaTujuan.SelectedItem = data_edit.getKotaTujuan();

            // Load Combobox Tipe Barang
            cmbTipeBarang.Items.Clear();
            cmbTipeBarang.DataSource = null;    // Because the combobox is bound to datatable
            cmbTipeBarang.ResetText();          // Make the combobox text empty
            fillcombo3();

            if(data_edit.getTipeBarang() == 'P')
            {
                cmbTipeBarang.SelectedItem = "Package";
            }
            else
            {
                cmbTipeBarang.SelectedItem = "Document";
            }

            // Set Textboxes to It's position and the value
            txt_lama_pengiriman.Text = data_edit.getLamaHari().ToString();
            txt_tarif.Text = data_edit.getOngkos().ToString();
            txt_berat.Text = data_edit.getBerat().ToString();
            txt_total_biaya.Text = (data_edit.getBerat() * data_edit.getOngkos()).ToString();

        }

        // Fill ComboBox Kota Pengiriman
        void fillcombo1()
        {
            DataTable dCb1 = intfadddata.getCombo1();

            for (int i = 0; i < dCb1.Rows.Count; i++)
            {
                cmbKotaPengiriman.Items.Add(dCb1.Rows[i]["kota_pengiriman"]);
            }
        }

        // Fill ComboBox Kota Tujuan
        void fillcombo2()
        {       
            DataTable dCb2 = intfadddata.getCombo2(cmbKotaPengiriman.SelectedItem.ToString());

            for (int i = 0; i < dCb2.Rows.Count; i++)
            {
                cmbKotaTujuan.Items.Add(dCb2.Rows[i]["kota_tujuan"]);
            }
        }

        // Fill ComboBox Tipe Barang
        void fillcombo3()
        {
            cmbTipeBarang.Items.Add("Package");
            cmbTipeBarang.Items.Add("Document");
        }

        // Fill ComboBox Provinsi Pengirim
        void fillcombo4()
        {
            DataTable dCb4 = intfadddata.getCombo4();

            for (int i = 0; i < dCb4.Rows.Count; i++)
            {
                cmbProvPengirim.Items.Add(dCb4.Rows[i]["nama_provinsi"]);
            }
        }

        // Trigger event when cmbProvPengirim selected
        private void cmbProvPengirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear it so it wouldn't get display twice or more
            cmbKabPengirim.Items.Clear();
            cmbKabPengirim.DataSource = null;    // Because the combobox is bound to datatable
            cmbKabPengirim.ResetText();          // Make the combobox text empty     

            data_edit.setId_ProvPengirim(intfadddata.getIdCombo4(cmbProvPengirim.SelectedItem.ToString()));

            DataTable dCb5 = intfadddata.getComboKab(data_edit.getId_ProvPengirim());

            for (int i = 0; i < dCb5.Rows.Count; i++)
            {
                cmbKabPengirim.Items.Add(dCb5.Rows[i]["nama_kabupaten"]);
            }
        }

        // Trigger event when cmbKabPengirim selected
        private void cmbKabPengirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKabPengirim.SelectedItem != null)
            {
                data_edit.setId_KabPengirim(intfadddata.getIdComboKab(cmbKabPengirim.SelectedItem.ToString()));
            }   
        }

        
        // Fill ComboBox Provinsi Penerima
        void fillcombo5()
        {
            DataTable dCb5 = intfadddata.getCombo4();

            for (int i = 0; i < dCb5.Rows.Count; i++)
            {
                cmbProvPenerima.Items.Add(dCb5.Rows[i]["nama_provinsi"]);
            }
        }

        // Trigger event when cmbProvPenerima selected
        private void cmbProvPenerima_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear it so it wouldn't get display twice or more
            cmbKabPenerima.Items.Clear();
            cmbKabPenerima.DataSource = null;    // Because the combobox is bound to datatable
            cmbKabPenerima.ResetText();          // Make the combobox text empty     

            // Even though it wouldn't be saved
            data_edit.setId_ProvPenerima(intfadddata.getIdCombo4(cmbProvPenerima.SelectedItem.ToString()));

            DataTable dCb5 = intfadddata.getComboKab(data_edit.getId_ProvPenerima());

            for (int i = 0; i < dCb5.Rows.Count; i++)
            {
                cmbKabPenerima.Items.Add(dCb5.Rows[i]["nama_kabupaten"]);
            }
        }

        // Trigger event when cmbKabPenerima selected
        private void cmbKabPenerima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbKabPenerima.SelectedItem != null)
            {
                data_edit.setId_KabPenerima(intfadddata.getIdComboKab(cmbKabPenerima.SelectedItem.ToString()));
            }         
        }

        // When One of ComboBox Kota Pengiriman Items get Selected
        private void cmbKotaPengiriman_SelectedIndexChanged(object sender, EventArgs e)
        {

            data_edit.setKotaPengiriman(cmbKotaPengiriman.SelectedItem.ToString());

            // Clear it so it wouldn't get display twice or more
            cmbTipeBarang.Items.Clear();
            cmbTipeBarang.DataSource = null;    // Because the combobox is bound to datatable
            cmbTipeBarang.ResetText();          // Make the combobox text empty
            cmbKotaTujuan.Items.Clear();
            cmbKotaTujuan.DataSource = null;    // Because the combobox is bound to datatable
            cmbKotaTujuan.ResetText();          // Make the combobox text empty

            txt_lama_pengiriman.Text = "";
            txt_tarif.Text = "";

            if (cmbKotaTujuan.SelectedItem == null)
            {
                DataTable dCb2 = intfadddata.getCombo2(cmbKotaPengiriman.SelectedItem.ToString());

                for (int i = 0; i < dCb2.Rows.Count; i++)
                {
                    cmbKotaTujuan.Items.Add(dCb2.Rows[i]["kota_tujuan"]);
                }
            }
            else
            {
                // Clear it so it wouldn't get display twice or more
                cmbKotaTujuan.Items.Clear();
                cmbKotaTujuan.DataSource = null;    // Because the combobox is bound to datatable
                cmbKotaTujuan.ResetText();          // Make the combobox text empty

                DataTable dCb2 = intfadddata.getCombo2(cmbKotaPengiriman.SelectedItem.ToString());

                for (int i = 0; i < dCb2.Rows.Count; i++)
                {
                    cmbKotaTujuan.Items.Add(dCb2.Rows[i]["kota_tujuan"]);
                }
            }
        }

        // When One of ComboBox Kota Tujuan get Selected
        private void cmbKotaTujuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipeBarang.Items.Clear();
            cmbTipeBarang.DataSource = null;    // Just To Be Safe
            cmbTipeBarang.ResetText();          // Make the combobox text empty    

            txt_lama_pengiriman.Text = "";
            txt_tarif.Text = "";

            fillcombo3();
        }

        // When One of ComboBox Tipe Barang Items get Selected
        private void cmbTipeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbKotaTujuan.SelectedItem != null)
            {
                data_edit.setKotaTujuan(cmbKotaTujuan.SelectedItem.ToString());
            }

            // Set cmbTipeBarang item value to object data_edit
            if (cmbTipeBarang.SelectedItem.ToString() == "Package")
            {
                data_edit.setTipeBarang('P');
            }
            else
            {
                data_edit.setTipeBarang('D');
            }

            if (cmbKotaPengiriman.SelectedItem != null && cmbKotaTujuan.SelectedItem != null)
            {
                intfadddata.getTarif(ref data_edit);

                txt_lama_pengiriman.Text = data_edit.getLamaHari().ToString();
                txt_tarif.Text = data_edit.getOngkos().ToString();
            }
        }

        // Trigger event when txt_tarif text changed
        private void txt_tarif_TextChanged(object sender, EventArgs e)
        {
            txt_berat.Text = "";
            txt_total_biaya.Text = "";
        }

        // What would happened if Berat Barang Text Box is filled or empty
        private void txt_berat_TextChanged(object sender, EventArgs e)
        {
            // If the box is Empty
            if (txt_berat.Text == "")
            {
                txt_total_biaya.Text = "";
            }
            // If the box Not Empty
            else
            {
                // Checking whether the data input is Integer or not
                int i;
                bool sukses = int.TryParse(txt_berat.Text, out i);
                if (sukses && txt_tarif.Text != "")
                {
                    // If it's an integer
                    data_edit.setBerat(Convert.ToInt32(txt_berat.Text));
                    txt_total_biaya.Text = (data_edit.getBerat() * data_edit.getOngkos()).ToString();
                }
                else
                {
                    // If it's not integer
                    txt_total_biaya.Text = "";
                }
            }
        }

        // RADIO BUTTON JENIS KELAMIN
        private void rb_L_pengirim_CheckedChanged(object sender, EventArgs e)
        {
            jk_pengirim = 'L';
        }

        private void rb_P_pengirim_CheckedChanged(object sender, EventArgs e)
        {
            jk_pengirim = 'P';
        }

        private void rb_L_penerima_CheckedChanged(object sender, EventArgs e)
        {
            jk_penerima = 'L';
        }

        private void rb_P_penerima_CheckedChanged(object sender, EventArgs e)
        {
            jk_penerima = 'P';
        }
        // END OF RADIO BUTTON CODE


        //////// Button Code on Tab Data Pengirim      
        bool checkCancel = true;    // Boolean to help prevent moving to next tab NOT BY BUTTON

        // Button Next
        private void btn_next1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id_pengirim.Text) || txt_id_pengirim.Text.Length != 16 || string.IsNullOrEmpty(txt_nama_pengirim.Text) || txt_nama_pengirim.Text.Length > 30 || string.IsNullOrEmpty(txt_nohub_pengirim.Text) || txt_nohub_pengirim.Text.Length > 15)
            {
                MessageBox.Show("Silahkan Isi yang Wajib Di Isikan dengan benar.");
            }
            else
            {
                checkCancel = false;
                customTabControl1.SelectedTab = DataPenerima;
            }
        }

        private void customTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = checkCancel;
            checkCancel = true;
        }

        // Button Cancel
        private void btn_cancel1_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        //////// Button Code on Tab Data Penerima
        // Button Next
        private void btn_next2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id_penerima.Text) || txt_id_penerima.Text.Length != 16 || string.IsNullOrEmpty(txt_nama_penerima.Text) || txt_nama_penerima.Text.Length > 30 || string.IsNullOrEmpty(txt_kodepos_penerima.Text) || txt_kodepos_penerima.Text.Length != 5 || string.IsNullOrEmpty(txt_nohub_penerima.Text) || txt_nohub_penerima.Text.Length > 15 || string.IsNullOrEmpty(txt_alamat_penerima.Text) || txt_alamat_penerima.Text.Length > 30 || string.IsNullOrEmpty(txt_kec_penerima.Text) || txt_kec_penerima.Text.Length > 25 || cmbKabPenerima.SelectedItem == null || cmbProvPenerima.SelectedItem == null)
            {
                MessageBox.Show("Silahkan Isi yang Wajib Di Isikan dengan benar.");
            }
            else
            {
                checkCancel = false;
                customTabControl1.SelectedTab = DataKiriman;
            }
        }

        // Button Back
        private void btn_back1_Click(object sender, EventArgs e)
        {
            checkCancel = false;
            customTabControl1.SelectedTab = DataPengirim;
        }

        // Button Cancel
        private void btn_cancel2_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        //////// Button Code on Tab Data Kiriman
        // Button Back
        private void btn_back2_Click(object sender, EventArgs e)
        {
            checkCancel = false;
            customTabControl1.SelectedTab = DataPenerima;
        }

        // Button Update (even though the button name is "save")
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePicker1.Value.ToString()) || txt_total_biaya.Text == "")
            {
                MessageBox.Show("Pastikan Semuanya sudah terisi / dipilih dengan benar.");
            }
            else
            {
                // Set Value Textbox And Else to Entity Pengirim
                data_edit.setIdPengirim(txt_id_pengirim.Text);
                data_edit.setNamaPengirim(txt_nama_pengirim.Text);
                data_edit.setJkPengirim(jk_pengirim);
                data_edit.setKodePosPengirim(txt_kodepos_pengirim.Text);
                data_edit.setNoHubPengirim(txt_nohub_pengirim.Text);
                data_edit.setAlamatPengirim(txt_alamat_pengirim.Text);
                data_edit.setRtPengirim(txt_rt_pengirim.Text);
                data_edit.setRwPengirim(txt_rw_pengirim.Text);
                data_edit.setDesaPengirim(txt_desa_pengirim.Text);
                data_edit.setKecPengirim(txt_kec_pengirim.Text);

                if (cmbProvPengirim.SelectedItem != null)
                {
                    data_edit.setId_ProvPengirim(intfadddata.getIdCombo4(cmbProvPengirim.SelectedItem.ToString()));
                }

                if (cmbKabPengirim.SelectedItem != null)
                {
                    data_edit.setId_KabPengirim(intfadddata.getIdComboKab(cmbKabPengirim.SelectedItem.ToString()));
                }


                // Set Value Textbox And Else to Entity Penerima
                data_edit.setIdPenerima(txt_id_penerima.Text);
                data_edit.setNamaPenerima(txt_nama_penerima.Text);
                data_edit.setJkPenerima(jk_penerima);
                data_edit.setKodePosPenerima(txt_kodepos_penerima.Text);
                data_edit.setNoHubPenerima(txt_nohub_penerima.Text);
                data_edit.setAlamatPenerima(txt_alamat_penerima.Text);
                data_edit.setRtPenerima(txt_rt_penerima.Text);
                data_edit.setRwPenerima(txt_rw_penerima.Text);
                data_edit.setDesaPenerima(txt_desa_penerima.Text);
                data_edit.setKecPenerima(txt_kec_penerima.Text);
                data_edit.setId_KabPenerima(intfadddata.getIdComboKab(cmbKabPenerima.SelectedItem.ToString()));
                // No need to save the Id Prov Penerima  

                // Set Value Textbox And Else to Entity Transaksi
                data_edit.setTglTransaksi(dateTimePicker1.Value.ToString());
                data_edit.setBerat(Convert.ToInt32(txt_berat.Text));
                data_edit.setIdPegawai(id_pegawaiedit);

                status = intfeditdata.updatedata(data_edit);

                if(status == true)
                {
                    MessageBox.Show("Data Telah DiUpdate");
                    fmu2.load_table();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Data GAGAL DiUpdate");
                    Dispose();
                }               
            }
        }

        // Button Cancel
        private void btn_cancel3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // Button Summoning Dimension Calculator
        private void btn_kalkulator_Click(object sender, EventArgs e)
        {
            FormKalDimensi kd = new FormKalDimensi();
            kd.ShowDialog();
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
