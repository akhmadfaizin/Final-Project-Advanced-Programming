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
    public partial class FormTambahData : Form
    {
        private string v3id_pegawai;
        private Boolean status;
        // Set the jk as 'L' as it's radio button default checked is on Laki-Laki
        private char jk_pengirim = 'L', jk_penerima = 'L';

        private View.FormMenuUtama fmu2;

        private Interface.IntfAddData intfadddata;
        private Interface.IntfMenuUtama intfmenuutama;

        // Instantiation an object from EntData class
        private Entity.EntData data_add = new Entity.EntData();

        // Class Constructor
        public FormTambahData(View.FormMenuUtama fmu1)
        {
            intfadddata = Factory.Factory.getTambahData();
            intfmenuutama = Factory.Factory.getMenuUtama();

            InitializeComponent();        
                                
            fillcombo1();           // cmbKotaPengiriman
            fillcombo4();           // cmbProvPengirim
            fillcombo5();           // cmbProvPenerima
            fmu2 = fmu1;

            // Retrieve id_pegawai value from function of other class
            v3id_pegawai = fmu2.getIdPegawai();

            // Display Nama Pegawai on Top Left
            lbl_pegawaiheader.Text = intfmenuutama.getNamaPegawai(v3id_pegawai);

            // Set id_pegawai to data_add object
            data_add.setIdPegawai(v3id_pegawai);

        }

        // Fill ComboBox Kota Pengiriman
        void fillcombo1()
        {
            DataTable dCb1 = intfadddata.getCombo1();
            
            for(int i = 0; i < dCb1.Rows.Count; i++)
            {
                cmbKotaPengiriman.Items.Add(dCb1.Rows[i]["kota_pengiriman"]);
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
            cmbKabPengirim.DataSource = null;    // Because the combobox might be bound to datatable
            cmbKabPengirim.ResetText();          // Make the combobox text empty     

            data_add.setId_ProvPengirim(intfadddata.getIdCombo4(cmbProvPengirim.SelectedItem.ToString()));
    
            DataTable dCb5 = intfadddata.getComboKab(data_add.getId_ProvPengirim());

            for (int i = 0; i < dCb5.Rows.Count; i++)
            {
                cmbKabPengirim.Items.Add(dCb5.Rows[i]["nama_kabupaten"]);
            }
            
        }

        // Trigger event when cmbKabPengirim selected
        private void cmbKabPengirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbKabPengirim.SelectedItem != null)
            {
                data_add.setId_KabPengirim(intfadddata.getIdComboKab(cmbKabPengirim.SelectedItem.ToString()));
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
            cmbKabPenerima.DataSource = null;    // Because the combobox might be bound to datatable
            cmbKabPenerima.ResetText();          // Make the combobox text empty     

            // Even though it wouldn't be saved
            data_add.setId_ProvPenerima(intfadddata.getIdCombo4(cmbProvPenerima.SelectedItem.ToString()));

            DataTable dCb5 = intfadddata.getComboKab(data_add.getId_ProvPenerima());

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
                data_add.setId_KabPenerima(intfadddata.getIdComboKab(cmbKabPenerima.SelectedItem.ToString()));
            }          
        }

        // When One of ComboBox Kota Pengiriman Items get Selected
        private void cmbKotaPengiriman_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set cmbKotaPengiriman item value to object data_add
            data_add.setKotaPengiriman(cmbKotaPengiriman.SelectedItem.ToString());

            // Clear it so it wouldn't get display twice or more
            cmbTipeBarang.Items.Clear();
            cmbTipeBarang.DataSource = null;    // Just To Be Safe
            cmbTipeBarang.ResetText();          // Make the combobox text empty           
            cmbKotaTujuan.Items.Clear();
            cmbKotaTujuan.DataSource = null;    // Because the combobox might be bound to datatable
            cmbKotaTujuan.ResetText();          // Make the combobox text empty

            txt_lama_pengiriman.Text = "";
            txt_tarif.Text = "";

            if (cmbKotaTujuan.SelectedItem == null)
            {
                // Retrieve list of cmbKotaTujuan base on it's kota pengiriman
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
                cmbKotaTujuan.DataSource = null;    // Because the combobox might be bound to datatable
                cmbKotaTujuan.ResetText();          // Make the combobox text empty

                // Retrieve list of cmbKotaTujuan base on it's kota pengiriman
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
                // Set cmbKotaTujuan item value to object data_add
                data_add.setKotaTujuan(cmbKotaTujuan.SelectedItem.ToString());
            }

            // Set cmbTipeBarang item value to object data_add
            if(cmbTipeBarang.SelectedItem.ToString() == "Package")
            {
                data_add.setTipeBarang('P');
            }
            else
            {
                data_add.setTipeBarang('D');
            }


            if(cmbKotaPengiriman.SelectedItem != null && cmbKotaTujuan.SelectedItem != null)
            {
                intfadddata.getTarif(ref data_add);

                txt_lama_pengiriman.Text = data_add.getLamaHari().ToString();
                txt_tarif.Text = data_add.getOngkos().ToString();     
            }
        }

        // What would happened if Berat Barang Textbox is filled or empty
        private void txt_berat_TextChanged(object sender, EventArgs e)
        {
            // If the box is empty
            if (txt_berat.Text == "")
            {
                txt_total_biaya.Text = "";
            }
            // If Not Empty
            else
            {
                // Checking whether the data input is Integer or not
                int i;
                bool sukses = int.TryParse(txt_berat.Text, out i);
                if (sukses && txt_tarif.Text!= "")
                {
                    // If it's an integer
                    txt_total_biaya.Text = (Convert.ToInt32(txt_tarif.Text) * Convert.ToInt32(txt_berat.Text)).ToString();
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

        // Control the ControlTab
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
            if(string.IsNullOrEmpty(txt_id_penerima.Text) || txt_id_penerima.Text.Length != 16 || string.IsNullOrEmpty(txt_nama_penerima.Text) || txt_nama_penerima.Text.Length > 30 || string.IsNullOrEmpty(txt_kodepos_penerima.Text) || txt_kodepos_penerima.Text.Length != 5 || string.IsNullOrEmpty(txt_nohub_penerima.Text) || txt_nohub_penerima.Text.Length > 15 || string.IsNullOrEmpty(txt_alamat_penerima.Text) || txt_alamat_penerima.Text.Length > 30 || string.IsNullOrEmpty(txt_kec_penerima.Text) || txt_kec_penerima.Text.Length > 25 || cmbKabPenerima.SelectedItem == null || cmbProvPenerima.SelectedItem == null)
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

        // Button Save
        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(dateTimePicker1.Value.ToString()) || txt_total_biaya.Text == "")
            {
                MessageBox.Show("Pastikan Semuanya sudah terisi / dipilih dengan benar.");
            }
            else
            {
                // Set Value Textbox And Else to Entity Pengirim
                data_add.setIdPengirim(txt_id_pengirim.Text);
                data_add.setNamaPengirim(txt_nama_pengirim.Text);
                data_add.setJkPengirim(jk_pengirim);
                data_add.setKodePosPengirim(txt_kodepos_pengirim.Text);
                data_add.setNoHubPengirim(txt_nohub_pengirim.Text);
                data_add.setAlamatPengirim(txt_alamat_pengirim.Text);
                data_add.setRtPengirim(txt_rt_pengirim.Text);
                data_add.setRwPengirim(txt_rw_pengirim.Text);
                data_add.setDesaPengirim(txt_desa_pengirim.Text);
                data_add.setKecPengirim(txt_kec_pengirim.Text);

                if (cmbProvPengirim.SelectedItem != null)
                {
                    data_add.setId_ProvPengirim(intfadddata.getIdCombo4(cmbProvPengirim.SelectedItem.ToString()));
                }

                if (cmbKabPengirim.SelectedItem != null)
                {
                    data_add.setId_KabPengirim(intfadddata.getIdComboKab(cmbKabPengirim.SelectedItem.ToString()));
                }


                // Set Value Textbox And Else to Entity Penerima
                data_add.setIdPenerima(txt_id_penerima.Text);
                data_add.setNamaPenerima(txt_nama_penerima.Text);
                data_add.setJkPenerima(jk_penerima);
                data_add.setKodePosPenerima(txt_kodepos_penerima.Text);
                data_add.setNoHubPenerima(txt_nohub_penerima.Text);
                data_add.setAlamatPenerima(txt_alamat_penerima.Text);
                data_add.setRtPenerima(txt_rt_penerima.Text);
                data_add.setRwPenerima(txt_rw_penerima.Text);
                data_add.setDesaPenerima(txt_desa_penerima.Text);
                data_add.setKecPenerima(txt_kec_penerima.Text);
                data_add.setId_KabPenerima(intfadddata.getIdComboKab(cmbKabPenerima.SelectedItem.ToString()));
                // No need to save the Id Prov Penerima  

                // Set Value Textbox And Else to Entity Transaksi
                data_add.setTglTransaksi(dateTimePicker1.Value.ToString());
                data_add.setBerat(Convert.ToInt32(txt_berat.Text));
                data_add.setIdPegawai(v3id_pegawai);

                status = intfadddata.saveData(data_add);

                if(status == true)
                {
                    MessageBox.Show("Data Telah Disimpan");
                    fmu2.load_table();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Data Gagal Disimpan");
                    Dispose();
                }
            }
                        
        }

        // Button Cancel
        private void btn_cancel3_Click(object sender, EventArgs e)
        {
            Dispose();       
        }

        // Trigger Event To Check Whether There is a Pengirim Duplicate on Database
        private void txt_id_pengirim_TextChanged(object sender, EventArgs e)
        {

            if (txt_id_pengirim.TextLength == 16)
            {
                // Get DataTable with 1 column and 1 row, to check for duplicate
                DataTable dtcd = intfadddata.get_dt_cekduplikat_id_pengirim(txt_id_pengirim.Text);

                foreach (DataRow rowx in dtcd.Rows)
                {
                    if (txt_id_pengirim.Text == Convert.ToString(rowx["id_pengirim"]))
                    {
                        data_add.setStatusDuplikatPengirim(true);
                        data_add.setIdPengirim(txt_id_pengirim.Text);
                        // Get DataTabe of 1 record with all columns include
                        DataTable dt = intfadddata.getDataPengirim(data_add.getIdPengirim());

                        foreach (DataRow row in dt.Rows)
                        {
                            // Retrieve Data Pengirim
                            data_add.setNamaPengirim(Convert.ToString(row["nama_pengirim"]));
                            data_add.setJkPengirim(Convert.ToChar(row["jk"]));
                            data_add.setNoHubPengirim(Convert.ToString(row["no_hub"]));
                            data_add.setKodePosPengirim(Convert.ToString(row["kode_pos"]));
                            data_add.setAlamatPengirim(Convert.ToString(row["alamat"]));
                            data_add.setRtPengirim(Convert.ToString(row["rt"]));
                            data_add.setRwPengirim(Convert.ToString(row["rw"]));
                            data_add.setDesaPengirim(Convert.ToString(row["desa"]));
                            data_add.setKecPengirim(Convert.ToString(row["kec"]));

                            if (row["id_kabupaten"] == DBNull.Value)
                            {
                                data_add.setId_KabPengirim(0);
                            }
                            else
                            {
                                data_add.setId_KabPengirim(Convert.ToInt32(row["id_kabupaten"]));
                            }

                            if (row["id_provinsi"] == DBNull.Value)
                            {
                                data_add.setId_ProvPengirim(0);
                            }
                            else
                            {
                                data_add.setId_ProvPengirim(Convert.ToInt32(row["id_provinsi"]));
                            }
                        }

                        // Diplay the data on Textboxes and else
                        txt_nama_pengirim.Text = data_add.getNamaPengirim();
                        txt_nohub_pengirim.Text = data_add.getNoHubPengirim();
                        txt_alamat_pengirim.Text = data_add.getAlamatPengirim();
                        txt_kodepos_pengirim.Text = data_add.getKodePosPengirim();
                        txt_rt_pengirim.Text = data_add.getRtPengirim();
                        txt_rw_pengirim.Text = data_add.getRwPengirim();
                        txt_desa_pengirim.Text = data_add.getDesaPengirim();
                        txt_kec_pengirim.Text = data_add.getKecPengirim();

                        if (data_add.getJkPengirim() == 'L')
                        {
                            rb_L_pengirim.Checked = true;
                        }
                        else
                        {
                            rb_P_pengirim.Checked = true;
                        }

                        cmbProvPengirim.Items.Clear();
                        cmbProvPengirim.DataSource = null;    // Because the combobox might be bound to datatable
                        cmbProvPengirim.ResetText();          // Make the combobox text empty
                        cmbKabPengirim.Items.Clear();
                        cmbKabPengirim.DataSource = null;    // Because the combobox might be bound to datatable
                        cmbKabPengirim.ResetText();          // Make the combobox text empty
                        fillcombo4();

                        if (data_add.getId_ProvPengirim() != 0)
                        {
                            cmbProvPengirim.SelectedItem = intfadddata.getNamaCombo4(data_add.getId_ProvPengirim());
                        }

                        if (data_add.getId_KabPengirim() != 0)
                        {
                            cmbKabPengirim.SelectedItem = intfadddata.getNamaComboKab(data_add.getId_KabPengirim());
                        }
                    }
                    else
                    {
                        data_add.setStatusDuplikatPengirim(false);
                    }
                }
            }
            else
            {
                data_add.setStatusDuplikatPengirim(false);

                // Set The Data Becoming Null
                data_add.setNamaPengirim("");
                data_add.setJkPengirim('\0');
                data_add.setNoHubPengirim("");
                data_add.setKodePosPengirim("");
                data_add.setAlamatPengirim("");
                data_add.setRtPengirim("");
                data_add.setRwPengirim("");
                data_add.setDesaPengirim("");
                data_add.setKecPengirim("");
                data_add.setId_KabPengirim(0);
                data_add.setId_ProvPenerima(0);

                // Empty The Textboxes and else
                txt_nama_pengirim.Text = "";
                txt_nohub_pengirim.Text = "";
                txt_alamat_pengirim.Text = "";
                txt_kodepos_pengirim.Text = "";
                txt_rt_pengirim.Text = "";
                txt_rw_pengirim.Text = "";
                txt_desa_pengirim.Text = "";
                txt_kec_pengirim.Text = "";

                rb_L_pengirim.Checked = true;

                cmbProvPengirim.Items.Clear();
                cmbProvPengirim.DataSource = null;    // Because the combobox might be bound to datatable
                cmbProvPengirim.ResetText();          // Make the combobox text empty
                cmbKabPengirim.Items.Clear();
                cmbKabPengirim.DataSource = null;    // Because the combobox might be bound to datatable
                cmbKabPengirim.ResetText();          // Make the combobox text empty
                fillcombo4();
                cmbProvPengirim.SelectedItem = null;
                cmbKabPengirim.SelectedItem = null;
            }
        }

        // Trigger Event To Check Whether There is a Penerima Duplicate on Database
        private void txt_id_penerima_TextChanged(object sender, EventArgs e)
        {
            if (txt_id_penerima.TextLength == 16)
            {
                // Get DataTable with 1 column and 1 row, to check for duplicate
                DataTable dtcd = intfadddata.get_dt_cekduplikat_id_penerima(txt_id_penerima.Text);

                foreach (DataRow rowx in dtcd.Rows)
                {
                    if (txt_id_penerima.Text == Convert.ToString(rowx["id_penerima"]))
                    {
                        data_add.setStatusDuplikatPenerima(true);
                        data_add.setIdPenerima(txt_id_penerima.Text);
                        // Get DataTabe of 1 record with all columns include
                        DataTable dt = intfadddata.getDataPenerima(data_add.getIdPenerima());

                        foreach (DataRow row in dt.Rows)
                        {
                            // Retrieve Data Penerima
                            data_add.setNamaPenerima(Convert.ToString(row["nama_penerima"]));
                            data_add.setJkPenerima(Convert.ToChar(row["jk"]));
                            data_add.setNoHubPenerima(Convert.ToString(row["no_hub"]));
                            data_add.setKodePosPenerima(Convert.ToString(row["kode_pos"]));
                            data_add.setAlamatPenerima(Convert.ToString(row["alamat"]));
                            data_add.setRtPenerima(Convert.ToString(row["rt"]));
                            data_add.setRwPenerima(Convert.ToString(row["rw"]));
                            data_add.setDesaPenerima(Convert.ToString(row["desa"]));
                            data_add.setKecPenerima(Convert.ToString(row["kec"]));
                            data_add.setId_KabPenerima(Convert.ToInt32(row["id_kabupaten"]));
                            data_add.setId_ProvPenerima(intfadddata.getIdComboProv(data_add.getId_KabPenerima()));
                        }

                        // Diplay the data on Textboxes and else
                        txt_nama_penerima.Text = data_add.getNamaPenerima();
                        txt_nohub_penerima.Text = data_add.getNoHubPenerima();
                        txt_alamat_penerima.Text = data_add.getAlamatPenerima();
                        txt_kodepos_penerima.Text = data_add.getKodePosPenerima();
                        txt_rt_penerima.Text = data_add.getRtPenerima();
                        txt_rw_penerima.Text = data_add.getRwPenerima();
                        txt_desa_penerima.Text = data_add.getDesaPenerima();
                        txt_kec_penerima.Text = data_add.getKecPenerima();

                        if (data_add.getJkPenerima() == 'L')
                        {
                            rb_L_penerima.Checked = true;
                        }
                        else
                        {
                            rb_P_penerima.Checked = true;

                        }

                        cmbProvPenerima.Items.Clear();
                        cmbProvPenerima.DataSource = null;    // Because the combobox might be bound to datatable
                        cmbProvPenerima.ResetText();          // Make the combobox text empty
                        cmbKabPenerima.Items.Clear();
                        cmbKabPenerima.DataSource = null;    // Because the combobox might be bound to datatable
                        cmbKabPenerima.ResetText();          // Make the combobox text empty
                        fillcombo5();

                        if (data_add.getId_ProvPenerima() != 0)
                        {
                            cmbProvPenerima.SelectedItem = intfadddata.getNamaCombo4(data_add.getId_ProvPenerima());
                        }

                        if (data_add.getId_KabPenerima() != 0)
                        {
                            cmbKabPenerima.SelectedItem = intfadddata.getNamaComboKab(data_add.getId_KabPenerima());
                        }
                    }
                    else
                    {
                        data_add.setStatusDuplikatPenerima(false);
                    }
                }
            }
            else
            {
                data_add.setStatusDuplikatPenerima(false);

                // Set The Data Becoming Null
                data_add.setNamaPenerima("");
                data_add.setJkPenerima('\0');
                data_add.setNoHubPenerima("");
                data_add.setKodePosPenerima("");
                data_add.setAlamatPenerima("");
                data_add.setRtPenerima("");
                data_add.setRwPenerima("");
                data_add.setDesaPenerima("");
                data_add.setKecPenerima("");
                data_add.setId_KabPenerima(0);
                data_add.setId_ProvPenerima(0);

                // Empty The Textboxes and else
                txt_nama_penerima.Text = "";
                txt_nohub_penerima.Text = "";
                txt_alamat_penerima.Text = "";
                txt_kodepos_penerima.Text = "";
                txt_rt_penerima.Text = "";
                txt_rw_penerima.Text = "";
                txt_desa_penerima.Text = "";
                txt_kec_penerima.Text = "";

                rb_L_penerima.Checked = true;

                cmbProvPenerima.Items.Clear();
                cmbProvPenerima.DataSource = null;    // Because the combobox might be bound to datatable
                cmbProvPenerima.ResetText();          // Make the combobox text empty
                cmbKabPenerima.Items.Clear();
                cmbKabPenerima.DataSource = null;    // Because the combobox might be bound to datatable
                cmbKabPenerima.ResetText();          // Make the combobox text empty
                fillcombo5();
                cmbProvPenerima.SelectedItem = null;
                cmbKabPenerima.SelectedItem = null;
            }
        }

        // Button Summoning Dimension Calculator
        private void btn_kalkulator_Click(object sender, EventArgs e)
        {
            FormKalDimensi kd = new FormKalDimensi();
            kd.ShowDialog();
        }

        // Prevent Highlighting when Inputing ID
        private void txt_id_pengirim_Click(object sender, EventArgs e)
        {
            txt_id_pengirim.DeselectAll();
        }

        // Prevent Highlighting when Inputing ID
        private void txt_id_pengirim_DoubleClick(object sender, EventArgs e)
        {
            txt_id_pengirim.DeselectAll();
        }

        // Prevent Highlighting when Inputing ID
        private void txt_id_penerima_Click(object sender, EventArgs e)
        {
            txt_id_penerima.DeselectAll();
        }

        // Prevent Highlighting when Inputing ID
        private void txt_id_penerima_DoubleClick(object sender, EventArgs e)
        {
            txt_id_penerima.DeselectAll();
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
