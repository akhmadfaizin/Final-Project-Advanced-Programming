using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDao.Entity
{
    class EntPegawai
    {
        private string nikPegawai;
        private string namaPegawai;
        private string passPegawai;

        public void SetNikPegawai(string s)
        {
            nikPegawai = s;
        }

        public string GetNikPegawai()
        {
            return nikPegawai;
        }

        public void SetNamaPegawai(string s)
        {
            namaPegawai = s;
        }

        public string GetNamaPegawai()
        {
            return namaPegawai;
        }

        public void SetPassPegawai(string s)
        {
            passPegawai = s;
        }

        public string GetPassPegawai()
        {
            return passPegawai;
        }

    }
}
