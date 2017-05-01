using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FinalProjectDao.Interface
{
    interface IntfEditData
    {
        DataTable getTransaksi(int a);
        DataTable getDataPengirim(string s);
        DataTable getDataPenerima(string s);
        DataTable getInfoTarif(int a);
        Boolean updatedata(Entity.EntData ead);
    }
}
