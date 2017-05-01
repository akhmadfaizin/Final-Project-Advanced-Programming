using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDao.Factory
{
    class Factory
    {
        private static Interface.IntfPegawai pegawaiDao;
        private static Interface.IntfAddData tambahdata;
        private static Interface.IntfMenuUtama menu_utama;
        private static Interface.IntfEditData editdata;
        private static Interface.IntfKalDimension hitungberat;

        public static Interface.IntfPegawai getPegawai()
        {
            pegawaiDao = new Implement.ImpPegawai();
            return pegawaiDao;
        }

        public static Interface.IntfAddData getTambahData()
        {
            tambahdata = new Implement.ImpAddData();
            return tambahdata;
        }

        public static Interface.IntfMenuUtama getMenuUtama()
        {
            menu_utama = new Implement.ImpMenuUtama();
            return menu_utama;
        }

        public static Interface.IntfEditData getEditData()
        {
            editdata = new Implement.ImpEditData();
            return editdata;
        }

        public static Interface.IntfKalDimension getBeratDimensi()
        {
            hitungberat = new Implement.ImpKalDimensi();
            return hitungberat;
        }


    }
}
