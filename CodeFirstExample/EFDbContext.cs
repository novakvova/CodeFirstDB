using CodeFirstExample.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=hello;Trusted_Connection=True;");
            }
        }
    }
}
