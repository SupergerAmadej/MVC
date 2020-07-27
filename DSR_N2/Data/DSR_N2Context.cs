using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DSR_N2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DSR_N2.Models
{
    public class DSR_N2Context : IdentityDbContext<User>
    {
        public DSR_N2Context (DbContextOptions<DSR_N2Context> options)
            : base(options)
        {
        }


        public DbSet<DSR_N2.Models.Klet> Klet { get; set; }

        public DbSet<DSR_N2.Models.Vino> Vino { get; set; }

        public DbSet<DSR_N2.Models.Dobava> Dobava { get; set; }

        public DbSet<DSR_N2.Models.Proizvajalec> Proizvajalec { get; set; }

        public DbSet<DSR_N2.Models.User> Userri { get; set; }

        public DbSet<DSR_N2.Models.UserWithGeslo> UserWithGeslo { get; set; }
    }
}
