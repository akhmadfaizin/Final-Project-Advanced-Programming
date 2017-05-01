using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDao.Entity
{
    class EntKalDimensi
    {
        private double panjang;
        private double lebar;
        private double tinggi;
        
        public double getPanjang()
        {
            return panjang;
        }

        public void setPanjang(double a)
        {
            panjang = a;
        }

        public double getLebar()
        {
            return lebar;
        }

        public void setLebar(double a)
        {
            lebar = a;
        }

        public double getTinggi()
        {
            return tinggi;
        }

        public void setTinggi(double a)
        {
            tinggi = a;
        }

    }
}
