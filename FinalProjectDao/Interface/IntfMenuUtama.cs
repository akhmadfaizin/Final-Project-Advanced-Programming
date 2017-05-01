using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FinalProjectDao.Interface
{
    interface IntfMenuUtama
    {
        DataTable load_table();
        string getNamaPegawai(string id_pegawai);
        Boolean deletedata(int no_transaksi);
    }
}
