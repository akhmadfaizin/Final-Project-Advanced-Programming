using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FinalProjectDao.Interface
{
    interface IntfAddData
    {
        DataTable getCombo1();
        DataTable getCombo2(string kota_pengiriman);
        DataTable getCombo4();

        int getIdCombo4(string nama_provinsi);
        string getNamaCombo4(int id_provinsi);
        DataTable getComboKab(int id_provinsi);
        int getIdComboKab(string nama_kabupaten);
        string getNamaComboKab(int id_kabupaten);
        int getIdComboProv(int id_kabupaten);

        DataTable get_dt_cekduplikat_id_pengirim(string id_pengirim);
        DataTable get_dt_cekduplikat_id_penerima(string id_penerima);
        DataTable getDataPengirim(string s);
        DataTable getDataPenerima(string s);
        void getTarif(ref Entity.EntData ead);

        Boolean saveData(Entity.EntData ead);
    }
}

