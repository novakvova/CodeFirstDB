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
            Console.WriteLine("Create dB Context "+ DateTime.Now);
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.;Database=hello;Trusted_Connection=True;");
                optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=dbbv012;User Id=bv012user;Password=Wds543iedd*kendhYYJDJDNNnndmd73d@sdf88U^ew!;");

            }
        }
    }
}
