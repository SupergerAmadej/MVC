using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    public class Vino
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Alkohol { get; set; }

        public virtual ICollection<Dobava> Dobave { get; set; }
        public virtual Proizvajalec Proizvajalec { get; set; }
    }
}
