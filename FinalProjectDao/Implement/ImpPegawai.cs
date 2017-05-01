using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FinalProjectDao.Implement
{
    class ImpPegawai : Interface.IntfPegawai
    {
        private string Query;
        private Boolean status;
        private SqlConnection koneksi;

        public ImpPegawai()
        {
            koneksi = Koneksi.KoneksiDB.getKoneksi();
        }

        // Method To Check Login Validation
        public Boolean LoginPegawai(string nikPegawai, string passPegawai)
        {
            Query = "SELECT nik, pass_pegawai FROM tb_pegawai WHERE nik = @nikpeg AND pass_pegawai = @passpeg";
            SqlCommand cmdDataBase = new SqlCommand(Query, koneksi);

            cmdDataBase.Parameters.AddWithValue("@nikpeg", nikPegawai);
            cmdDataBase.Parameters.AddWithValue("@passpeg", passPegawai);

            koneksi.Open();

            SqlDataReader reader = cmdDataBase.ExecuteReader();

            while(reader.Read())
            {
                if ((reader.GetString(0).ToString() == nikPegawai) && (reader.GetString(1).ToString() == passPegawai))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }

            koneksi.Close();

            return status;
        }

    }
}
