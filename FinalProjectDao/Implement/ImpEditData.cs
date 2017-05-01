using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalProjectDao.Implement
{
    class ImpEditData : Interface.IntfEditData
    {
        private SqlConnection koneksi;
        private Boolean status;

        public ImpEditData()
        {
            koneksi = Koneksi.KoneksiDB.getKoneksi();
        }

        // Method To Retrieve A Transaction Information
        public DataTable getTransaksi(int a)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT * FROM tb_transaksi WHERE id_transaksi = "+ a +"  ";
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

        // Method To Retrieve A Pengirim Information
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

        // Method To Retrieve A Penerima Information
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

        // Method To Retrieve A Tarif Information
        public DataTable getInfoTarif(int a)
        {
            DataTable dt = new DataTable();

            try
            {
                koneksi.Open();
                string strCmd = "SELECT * FROM tb_tarif WHERE id_tarif = " + a + "  ";
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

        // Method To Update Data
        public Boolean updatedata(Entity.EntData ead)
        {
            status = false;

            try
            {
                // Query Update Table tb_pengirim
                string Query1 = "UPDATE tb_pengirim SET nama_pengirim = @namapengirim, jk = @jkpengirim, kode_pos = @kode_pos, no_hub = @no_hub, alamat = @alamat, rt = @rt, rw = @rw, desa = @desa, kec = @kec, id_kabupaten = @kab, id_provinsi = @prov WHERE id_pengirim = @id_pengirim;";
                SqlCommand cmdDataBase1 = new SqlCommand(Query1, koneksi);

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


                // Query Update Table tb_penerima
                string Query2 = "UPDATE tb_penerima SET nama_penerima = @namapenerima, jk = @jkpenerima, kode_pos = @kode_pos, no_hub = @no_hub, alamat = @alamat, rt = @rt, rw = @rw, desa = @desa, kec = @kec, id_kabupaten = @kab WHERE id_penerima = @id_penerima;";
                SqlCommand cmdDataBase2 = new SqlCommand(Query2, koneksi);

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


                // Query Update Table tb_transaksi
                string Query3 = "UPDATE tb_transaksi SET tgl_transaksi = @tgl_transaksi, berat = @berat, nik = @id_pegawai, id_pengirim = @id_pengirim, id_tarif = @id_tarif, id_penerima = @id_penerima WHERE id_transaksi = @id_transaksi";
                SqlCommand cmdDataBase3 = new SqlCommand(Query3, koneksi);

                cmdDataBase3.Parameters.AddWithValue("@tgl_transaksi", ead.getTglTransaksi());
                cmdDataBase3.Parameters.AddWithValue("@berat", ead.getBerat());
                cmdDataBase3.Parameters.AddWithValue("@id_pegawai", ead.getIdPegawai());
                cmdDataBase3.Parameters.AddWithValue("@id_pengirim", ead.getIdPengirim());
                cmdDataBase3.Parameters.AddWithValue("@id_tarif", ead.getIdTarif());
                cmdDataBase3.Parameters.AddWithValue("@id_penerima", ead.getIdPenerima());
                cmdDataBase3.Parameters.AddWithValue("@id_transaksi", ead.getIdTransaksi());

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
    }
}
