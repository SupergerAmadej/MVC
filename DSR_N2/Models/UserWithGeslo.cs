using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    [NotMapped]
    public class UserWithGeslo : User
    {
        [MinLength(8, ErrorMessage = "Geslo mora biti 8 znakov dolgo")]
        [RegularExpression(@"^([a-zA-Z+]+[0-9+]+[&@!#+]+)$", ErrorMessage = "Geslo mora vsebovati vsaj 1 stevilo in 1 poseben znak")]
        [Required(ErrorMessage = "Geslo je nujno")]
        public string Geslo { get; set; }

        public UserWithGeslo()
        {

        }

        public UserWithGeslo(UserWithGeslo userWithGeslo) : base()
        {
            Geslo = userWithGeslo.Geslo;
        }
    }
}
