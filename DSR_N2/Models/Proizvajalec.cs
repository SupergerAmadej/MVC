using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    public class Proizvajalec
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual ICollection<Vino> Vina { get; set; }
    }
}
