using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalProjectDao.Implement
{
    class ImpAddData : Interface.IntfAddData
    {
        private SqlConnection koneksi;
        private Boolean status;
        private string s;
        private int n;

        public ImpAddData()
        {
            koneksi = Koneksi.KoneksiDB.getKoneksi();
        }

        // For ComboBox Kota Pengiriman
        public DataTable getCombo1()
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT kota_pengiriman FROM tb_tarif GROUP BY kota_pengiriman ORDER BY kota_pengiriman";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();               
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;          
        }

        // For ComboBox Kota Tujuan
        public DataTable getCombo2(string kota_pengiriman)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT DISTINCT kota_tujuan FROM tb_tarif WHERE kota_pengiriman = '" + kota_pengiriman + "' GROUP BY kota_tujuan ;";

                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);
                
                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // For ComboBox Provinsi
        public DataTable getCombo4()
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT nama_provinsi FROM tb_provinsi;";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method to Get id_provinsi
        public int getIdCombo4(string nama_provinsi)
        {
            try
            {
                string Query = "SELECT id_provinsi FROM tb_provinsi WHERE nama_provinsi = @namaprovinsi;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);
                cmdDataBase.Parameters.AddWithValue("@namaprovinsi", nama_provinsi);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    n = Int32.Parse(value.ToString());
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return n;
        }

        // Method To Get nama_provinsi With id_provinsi As Parameter
        public string getNamaCombo4(int id_provinsi)
        {          
            try
            {
                string Query = "SELECT nama_provinsi FROM tb_provinsi WHERE id_provinsi = @idprovinsi;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);
                cmdDataBase.Parameters.AddWithValue("@idprovinsi", id_provinsi);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    s = value.ToString();
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return s;
        }

        // Method to Get id_provinsi With id_kabupaten As Parameter
        public int getIdComboProv(int id_kabupaten)
        {

            try
            {
                string Query = "SELECT id_provinsi FROM tb_kabupaten WHERE id_kabupaten = @idkabupaten;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);
                cmdDataBase.Parameters.AddWithValue("@idkabupaten", id_kabupaten);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    n = Int32.Parse(value.ToString());
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return n;
        }

        // Method To Populate cmbKabupaten With id_provinsi As Parameter , return Datatable Datatype
        public DataTable getComboKab(int id_provinsi)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT nama_kabupaten FROM tb_kabupaten WHERE id_provinsi = " + id_provinsi + ";";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method To Get id_kabupaten With nama_kabupaten As Parameter
        public int getIdComboKab(string nama_kabupaten)
        {
            try
            {
                string Query = "SELECT id_kabupaten FROM tb_kabupaten WHERE nama_kabupaten = @namakabupaten;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);
                cmdDataBase.Parameters.AddWithValue("@namakabupaten", nama_kabupaten);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    n = Int32.Parse(value.ToString());
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return n;
        }

        // Method To Get nama_kabupaten With id_kabupaten As Parameter
        public string getNamaComboKab(int id_kabupaten)
        {
            try
            {
                string Query = "SELECT nama_kabupaten FROM tb_kabupaten WHERE id_kabupaten = @idkabupaten;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);
                cmdDataBase.Parameters.AddWithValue("@idkabupaten", id_kabupaten);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    s = value.ToString();
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return s;
        }

        // Method to get lama_hari, id_tarif and ongkos
        public void getTarif(ref Entity.EntData ead)
        {
            try
            {
                string Query1 = "SELECT lama_hari FROM tb_tarif WHERE kota_pengiriman= @kotapengiriman AND kota_tujuan = @kotatujuan AND tipe_barang = @tipebarang;";
                SqlCommand cmdDataBase1 = new SqlCommand(Query1, koneksi);
                cmdDataBase1.Parameters.AddWithValue("@kotapengiriman", ead.getKotaPengiriman().ToString());
                cmdDataBase1.Parameters.AddWithValue("@kotatujuan", ead.getKotaTujuan().ToString());
                cmdDataBase1.Parameters.AddWithValue("@tipebarang", ead.getTipeBarang().ToString());

                string Query2 = "SELECT id_tarif FROM tb_tarif WHERE kota_pengiriman= @kotapengiriman AND kota_tujuan = @kotatujuan AND tipe_barang = @tipebarang;";
                SqlCommand cmdDataBase2 = new SqlCommand(Query2, koneksi);
                cmdDataBase2.Parameters.AddWithValue("@kotapengiriman", ead.getKotaPengiriman().ToString());
                cmdDataBase2.Parameters.AddWithValue("@kotatujuan", ead.getKotaTujuan().ToString());
                cmdDataBase2.Parameters.AddWithValue("@tipebarang", ead.getTipeBarang().ToString());

                string Query3 = "SELECT ongkos FROM tb_tarif WHERE kota_pengiriman= @kotapengiriman AND kota_tujuan = @kotatujuan AND tipe_barang = @tipebarang;";
                SqlCommand cmdDataBase3 = new SqlCommand(Query3, koneksi);
                cmdDataBase3.Parameters.AddWithValue("@kotapengiriman", ead.getKotaPengiriman().ToString());
                cmdDataBase3.Parameters.AddWithValue("@kotatujuan", ead.getKotaTujuan().ToString());
                cmdDataBase3.Parameters.AddWithValue("@tipebarang", ead.getTipeBarang().ToString());

                koneksi.Open();

                var value1 = cmdDataBase1.ExecuteScalar();

                if (value1 != null)
                {
                    ead.setLamaHari(Int32.Parse(value1.ToString()));
                }

                var value2 = cmdDataBase2.ExecuteScalar();

                if (value2 != null)
                {
                    ead.setIdTarif(Int32.Parse(value2.ToString()));
                }

                var value3 = cmdDataBase3.ExecuteScalar();

                if (value3 != null)
                {
                    ead.setOngkos(Int32.Parse(value3.ToString()));
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }
        }

        
        // Method To Save Data
        public Boolean saveData(Entity.EntData ead)
        {
            status = false;

            SqlCommand cmdDataBase1, cmdDataBase2, cmdDataBase3;
            String Query1, Query2, Query3;

            try
            {
                // If There is an id_pengirim duplicate 
                if (ead.getStatusDuplikatPengirim() == true)
                {
                    // QUERY UPDATE
                    Query1 = "UPDATE tb_pengirim SET nama_pengirim = @namapengirim, jk = @jkpengirim, kode_pos = @kode_pos, no_hub = @no_hub, alamat = @alamat, rt = @rt, rw = @rw, desa = @desa, kec = @kec, id_kabupaten = @kab, id_provinsi = @prov WHERE id_pengirim = @id_pengirim;";
                    cmdDataBase1 = new SqlCommand(Query1, koneksi);

                    cmdDataBase1.Parameters.AddWithValue("@namapengirim", ead.getNamaPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@jkpengirim", ead.getJkPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@kode_pos", ead.getKodePosPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@no_hub", ead.getNoHubPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@alamat", ead.getAlamatPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@rt", ead.getRtPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@rw", ead.getRwPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@desa", ead.getDesaPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@kec", ead.getKecPengirim());

                    if (ead.getId_KabPengirim() == 0)
                    {
                        cmdDataBase1.Parameters.AddWithValue("@kab", DBNull.Value);
                    }
                    else
                    {
                        cmdDataBase1.Parameters.AddWithValue("@kab", ead.getId_KabPengirim());
                    }

                    if (ead.getId_ProvPengirim() == 0)
                    {
                        cmdDataBase1.Parameters.AddWithValue("@prov", DBNull.Value);
                    }
                    else
                    {
                        cmdDataBase1.Parameters.AddWithValue("@prov", ead.getId_ProvPengirim());
                    }

                    cmdDataBase1.Parameters.AddWithValue("@id_pengirim", ead.getIdPengirim());

                }
                else
                {
                    // QUERY INSERT
                    Query1 = "INSERT INTO tb_pengirim VALUES (@id_pengirim, @namapengirim, @jkpengirim, @kode_pos, @no_hub, @alamat, @rt, @rw, @desa, @kec, @kab, @prov);";
                    cmdDataBase1 = new SqlCommand(Query1, koneksi);

                    cmdDataBase1.Parameters.AddWithValue("@id_pengirim", ead.getIdPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@namapengirim", ead.getNamaPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@jkpengirim", ead.getJkPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@kode_pos", ead.getKodePosPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@no_hub", ead.getNoHubPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@alamat", ead.getAlamatPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@rt", ead.getRtPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@rw", ead.getRwPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@desa", ead.getDesaPengirim());
                    cmdDataBase1.Parameters.AddWithValue("@kec", ead.getKecPengirim());

                    if (ead.getId_KabPengirim() == 0)
                    {
                        cmdDataBase1.Parameters.AddWithValue("@kab", DBNull.Value);
                    }
                    else
                    {
                        cmdDataBase1.Parameters.AddWithValue("@kab", ead.getId_KabPengirim());
                    }

                    if (ead.getId_ProvPengirim() == 0)
                    {
                        cmdDataBase1.Parameters.AddWithValue("@prov", DBNull.Value);
                    }
                    else
                    {
                        cmdDataBase1.Parameters.AddWithValue("@prov", ead.getId_ProvPengirim());
                    }
                    
                }


                // If There is an id_penerima duplicate 
                if (ead.getStatusDuplikatPenerima() == true)
                {
                    // QUERY UPDATE
                    Query2 = "UPDATE tb_penerima SET nama_penerima = @namapenerima, jk = @jkpenerima, kode_pos = @kode_pos, no_hub = @no_hub, alamat = @alamat, rt = @rt, rw = @rw, desa = @desa, kec = @kec, id_kabupaten = @kab WHERE id_penerima = @id_penerima;";
                    cmdDataBase2 = new SqlCommand(Query2, koneksi);

                    cmdDataBase2.Parameters.AddWithValue("@namapenerima", ead.getNamaPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@jkpenerima", ead.getJkPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kode_pos", ead.getKodePosPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@no_hub", ead.getNoHubPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@alamat", ead.getAlamatPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@rt", ead.getRtPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@rw", ead.getRwPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@desa", ead.getDesaPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kec", ead.getKecPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kab", ead.getId_KabPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@id_penerima", ead.getIdPenerima());
                }
                else
                {
                    // QUERY INSERT
                    Query2 = "INSERT INTO tb_penerima VALUES (@id_penerima, @namapenerima, @jkpenerima, @kode_pos, @no_hub, @alamat, @rt, @rw, @desa, @kec, @kab);";
                    cmdDataBase2 = new SqlCommand(Query2, koneksi);

                    cmdDataBase2.Parameters.AddWithValue("@id_penerima", ead.getIdPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@namapenerima", ead.getNamaPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@jkpenerima", ead.getJkPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kode_pos", ead.getKodePosPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@no_hub", ead.getNoHubPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@alamat", ead.getAlamatPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@rt", ead.getRtPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@rw", ead.getRwPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@desa", ead.getDesaPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kec", ead.getKecPenerima());
                    cmdDataBase2.Parameters.AddWithValue("@kab", ead.getId_KabPenerima());
                }

                // Insert A New Transaction Data
                Query3 = "INSERT INTO tb_transaksi (tgl_transaksi, berat, nik, id_pengirim, id_tarif, id_penerima) VALUES (@tgl_transaksi, @berat, @id_pegawai, @id_pengirim, @id_tarif, @id_penerima);";
                cmdDataBase3 = new SqlCommand(Query3, koneksi);

                cmdDataBase3.Parameters.AddWithValue("@tgl_transaksi", ead.getTglTransaksi());
                cmdDataBase3.Parameters.AddWithValue("@berat", ead.getBerat());
                cmdDataBase3.Parameters.AddWithValue("@id_pegawai", ead.getIdPegawai());
                cmdDataBase3.Parameters.AddWithValue("@id_pengirim", ead.getIdPengirim());
                cmdDataBase3.Parameters.AddWithValue("@id_tarif", ead.getIdTarif());
                cmdDataBase3.Parameters.AddWithValue("@id_penerima", ead.getIdPenerima());

                koneksi.Open();
                cmdDataBase1.ExecuteNonQuery();
                cmdDataBase2.ExecuteNonQuery();
                cmdDataBase3.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return status;
        }

        
        // Method To get datatable of the id_pengirim that wanna be checked for duplicate
        public DataTable get_dt_cekduplikat_id_pengirim(string id_pengirim)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT id_pengirim FROM tb_pengirim WHERE id_pengirim = '" + id_pengirim + "'";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method To get datatable of the id_penerima that wanna be checked for duplicate
        public DataTable get_dt_cekduplikat_id_penerima(string id_penerima)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT id_penerima FROM tb_penerima WHERE id_penerima = '" + id_penerima + "'";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method to retrieve pengirim information from database
        public DataTable getDataPengirim(string s)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT * FROM tb_pengirim WHERE id_pengirim = " + s + "  ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method to retrieve penerima information from database
        public DataTable getDataPenerima(string s)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT * FROM tb_penerima WHERE id_penerima = " + s + "  ";
                SqlDataAdapter da = new SqlDataAdapter(strCmd, koneksi);

                da.Fill(dt);
                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }
    }
}
