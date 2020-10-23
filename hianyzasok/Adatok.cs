using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hianyzasok
{
    class Adatok
    {
        public int Honap { get; set; }
        public int Nap { get; set; }
        public string Nev { get; set; }
        public string Hianyzasok { get; set; }


        public int HianyzasDarab()
        {
            int db = 0;
            foreach (var i in Hianyzasok)
            {
                if (i == 'I' || i == 'X')
                {
                    db++;
                }
            }

            return db;
        }
    }
}
