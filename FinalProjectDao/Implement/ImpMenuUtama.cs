using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalProjectDao.Implement
{
    class ImpMenuUtama : Interface.IntfMenuUtama
    {
        private SqlConnection koneksi;
        private Boolean status;

        public ImpMenuUtama()
        {
            koneksi = Koneksi.KoneksiDB.getKoneksi();
        }

        // Method To get Nama Pegawai by passing the id_pegawai
        public string getNamaPegawai(string id_pegawai)
        {
            try
            {
                string Query = "SELECT nama_pegawai FROM tb_pegawai WHERE nik = @idpeg;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);

                cmdDataBase.Parameters.AddWithValue("@idpeg", id_pegawai);

                koneksi.Open();

                var value = cmdDataBase.ExecuteScalar();

                if (value != null)
                {
                    id_pegawai = value.ToString();
                }

                koneksi.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return id_pegawai;
        }

        // Method To Populate Datagridview
        public DataTable load_table()
        {
            DataTable dt = new DataTable();

            try
            {
                string Query = "SELECT t.id_transaksi AS [Kode Kiriman], t.tgl_transaksi AS [Tanggal Pengiriman], m.nama_pengirim AS [Nama Pengirim], n.nama_penerima AS [Nama Penerima], f.kota_tujuan AS [Kota Penerima], t.berat AS [Berat], f.lama_hari AS [Lama Pengiriman], (t.berat * f.ongkos) AS [Biaya Pengiriman] FROM tb_transaksi t INNER JOIN tb_pengirim m ON m.id_pengirim = t.id_pengirim INNER JOIN tb_penerima n ON n.id_penerima = t.id_penerima INNER JOIN tb_tarif f ON f.id_tarif = t.id_tarif ORDER BY t.id_transaksi DESC;";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);

                SqlDataAdapter sda = new SqlDataAdapter(cmdDataBase);

                sda.Fill(dt);          
            }
            catch (SqlException se)
            {
                Console.WriteLine("ERROR " + se);
            }

            return dt;
        }

        // Method To Delete Data with no_transaksi as Parameter
        public Boolean deletedata(int no_transaksi)
        {
            status = false;

            try
            {
                string Query = "DELETE FROM tb_transaksi WHERE id_transaksi = @notrans";
                SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);

                cmdDataBase.Parameters.AddWithValue("@notrans", no_transaksi);

                koneksi.Open();
                cmdDataBase.ExecuteNonQuery();
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
