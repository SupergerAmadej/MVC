using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    public class Dobava
    {
        public int Id { get; set; }
        //public int Id_Klet { get; set; }
        //public int Id_Vino { get; set; }
        public DateTime Datum_Nakupa { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }

        public virtual Vino Vino { get; set; }
        public virtual Klet Klet { get; set; }


    }
}
