using CodeFirstExample.Entites;
using System;
using System.Linq;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDbContext context = new EFDbContext();
            //Country country = new Country();
            //country.Name = "Польща";
            //context.Countries.Add(country);
            //context.SaveChanges();
            Console.WriteLine("Оберіть країну:");
            foreach (var country in context.Countries.ToList())
            {
                Console.WriteLine(country);
            }
            Console.Write("->_");
            int idCountry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city name: ");
            string cityName = Console.ReadLine();
            City city = new City();
            city.Name = cityName;
            city.CountryId = idCountry;
            context.Cities.Add(city);
            context.SaveChanges();

            Console.WriteLine("Create database");
        }
    }
}
