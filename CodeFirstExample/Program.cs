using CodeFirstExample.Entites;
using System;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDbContext context = new EFDbContext();
            Country country = new Country();
            country.Name = "Україна";
            context.Countries.Add(country);
            context.SaveChanges();

            //int idCountry = 1;
            //City city = new City();
            //city.Name = "Тернопіль";
            //city.CountryId = idCountry;
            //context.Cities.Add(city);
            //context.SaveChanges();  

            Console.WriteLine("Create database");
        }
    }
}
