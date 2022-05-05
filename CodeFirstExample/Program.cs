using CodeFirstExample.Entites;
using CodeFirstExample.Interfaces;
using CodeFirstExample.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //EFDbContext context = new EFDbContext();

            //ICityRepository cityRepository = new CityRepository(context);
            using (UnitOfWork uw = new UnitOfWork())
            {
                var list = uw.CityRepository.GetAll()
                    .Include(x => x.Country);
                Console.WriteLine("Show list cities:");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Show list countries: ");
                foreach (var item in uw.CountryRepository.GetAll())
                {
                    Console.WriteLine(item);
                };
            }
            //var list = cityRepository.GetAll()
            //    .Include(x=>x.Country);
            //Console.WriteLine("Show list cities:");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Show list countries: ");
            ////ICountryRepository countryRepository = new CountryRepository(context);
            //foreach (var item in countryRepository.GetAll())
            //{
            //    Console.WriteLine(item);
            //};

            //EFDbContext context = new EFDbContext();
            ////Country country = new Country();
            ////country.Name = "Польща";
            ////context.Countries.Add(country);
            ////context.SaveChanges();
            //Console.WriteLine("Оберіть країну:");
            //foreach (var country in context.Countries.ToList())
            //{
            //    Console.WriteLine(country);
            //}
            //Console.Write("->_");
            //int idCountry = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter city name: ");
            //string cityName = Console.ReadLine();
            //City city = new City();
            //city.Name = cityName;
            //city.CountryId = idCountry;
            //context.Cities.Add(city);
            //context.SaveChanges();

            //Console.WriteLine("Create database");
        }
    }
}
