using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Niculae_Ana_Maria_Pagina_Web.Models;

namespace Niculae_Ana_Maria_Pagina_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Niculae_Ana_Maria_Pagina_Web.Models.Shop> Shop { get; set; }
        public DbSet<Niculae_Ana_Maria_Pagina_Web.Models.Angajat> Angajat { get; set; }
    }


}
