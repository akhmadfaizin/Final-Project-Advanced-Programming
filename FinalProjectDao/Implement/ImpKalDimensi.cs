using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProjectDao.Implement
{
    class ImpKalDimensi : Interface.IntfKalDimension
    {
        private int berat;
        private double hasil;

        // Method to calculate Berat
        public int hitungberat(Entity.EntKalDimensi ek)
        {

            // Calculate The Volume then Divide by 6000
            hasil = (ek.getPanjang() * ek.getLebar() * ek.getTinggi()) / 6000;

            // Round the double number and Convert it to Integer
            berat = (int)Math.Round(hasil);

            return berat;
        }

    }
}
