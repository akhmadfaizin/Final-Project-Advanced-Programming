using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FinalProjectDao.Koneksi
{
    class KoneksiDB
    {
        private static SqlConnection koneksi;

        public static SqlConnection getKoneksi()
        {
            koneksi = new SqlConnection();
            koneksi.ConnectionString = "Data Source=AF-PC\\SQLEXPRESS;Initial Catalog=db_jasakurir_v2;Integrated Security=True";

            return koneksi;
        }
    }
}
