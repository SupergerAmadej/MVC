using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    public class Klet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Naslov { get; set; }

        //public virtual ICollection<Vino> Vina { get; set; }
        public virtual ICollection<Dobava> Dobave { get; set; }
    }
}
