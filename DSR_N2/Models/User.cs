using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSR_N2.Models
{
    public class ValidateDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            if ((DateTime)value >= Convert.ToDateTime("01/01/1900") && (DateTime)value <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not in given range.");
            }
        }
    }
    public class User : IdentityUser
    {
        //[Key]
        //public int id { get; set; }
        [Required(ErrorMessage = "Emso je nujen")]
        [Range(1000000000000, 9999999999999, ErrorMessage ="EMSO mora biti dolg 13 znakov")]
        public long EMSO { get; set; }
        [Required(ErrorMessage = "Ime je nujno")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Dovoljene so samo črke")]
        [MaxLength(50)]
        public string Ime { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Dovoljene so samo črke")]
        [Required(ErrorMessage = "Priimek je nujen")]
        [MaxLength(50)]
        public string Priimek { get; set; }
        [Required(ErrorMessage = "Email je nujen")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Nepravilen fromat za Email")]
        public override string Email { get; set; }
        [Required(ErrorMessage = "Datum rojstva je nujen")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [ValidateDateRange]
        [UIHint("DateTime")]
        public DateTime Datum_Roj { get; set; }

        [Required(ErrorMessage ="Kraj rojstva")]
        public string Kraj_Roj { get; set; }

        [Range(0, int.MaxValue)]
        public int Starost { get; set; }
        [Required(ErrorMessage = "Naslov je nujen")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Posta stevilka je nujna")]
        [Range(0, int.MaxValue)]
        public int Postna_Stevilka { get; set; }
        [Required(ErrorMessage = "Drzava je nujna")]
        public string Drzava { get; set; }

        public User()
        {

        }

        public User(User user)
        {
            EMSO = user.EMSO;
            Ime = user.Ime;
            Priimek = user.Priimek;
            Email = user.Email;
            Datum_Roj = user.Datum_Roj;
            Starost = user.Starost;
            Naslov = user.Naslov;
            Postna_Stevilka = user.Postna_Stevilka;
            Drzava = user.Drzava;
        }

        public static IEnumerable<SelectListItem> KrajiRojstva()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Celje", Value = "Celje",Selected=true});
            list.Add(new SelectListItem { Text = "Maribor", Value = "Maribor" });
            list.Add(new SelectListItem { Text = "Ljubljana", Value = "Ljubljana" });

            foreach (var i in list)
            {
                yield return i;
            }
        }
    }
}
