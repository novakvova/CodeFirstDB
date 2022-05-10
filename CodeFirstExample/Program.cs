using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CodeFirstExample.Entites;
using CodeFirstExample.Interfaces;
using CodeFirstExample.Models;
using CodeFirstExample.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            //using (UnitOfWork uw = new UnitOfWork())
            //{
            //    var list = uw.CityRepository.GetAll()
            //        .Include(x => x.Country);
            //    Console.WriteLine("Show list cities:");
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    Console.WriteLine("Show list countries: ");
            //    foreach (var item in uw.CountryRepository.GetAll())
            //    {
            //        Console.WriteLine(item);
            //    };
            //}

            // The Microsoft.Extensions.DependencyInjection.ServiceCollection
            // has extension methods provided by other .NET Core libraries to
            // register services with DI.
            var serviceCollection = new ServiceCollection();

            // The Microsoft.Extensions.Logging package provides this one-liner
            // to add logging services.
            serviceCollection.AddLogging();

            var containerBuilder = new ContainerBuilder();

            // Once you've registered everything in the ServiceCollection, call
            // Populate to bring those registrations into Autofac. This is
            // just like a foreach over the list of things in the collection
            // to add them to Autofac.
            containerBuilder.Populate(serviceCollection);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.




            //containerBuilder.RegisterType<MessageHandler>().As<IHandler>();

            containerBuilder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityItemModel>()
                    .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name));
                //etc...
            })).AsSelf().SingleInstance();

            containerBuilder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            containerBuilder.RegisterType<EFDbContext>().SingleInstance();
            containerBuilder.RegisterType<CityRepository>().As<ICityRepository>();
            containerBuilder.RegisterType<CountryRepository>().As<ICountryRepository>();
            containerBuilder.RegisterType<LocalManager>();

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            //var context = serviceProvider.GetRequiredService<EFDbContext>();
            //var cityRepository = serviceProvider.GetRequiredService<ICityRepository>();
            //var list = cityRepository.GetAll()
            //    .Include(x => x.Country);
            //Console.WriteLine("Show list cities:");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //var countryRepository = serviceProvider.GetRequiredService<ICountryRepository>();
            //Console.WriteLine("Show list countries: ");
            //foreach (var item in countryRepository.GetAll())
            //{
            //    Console.WriteLine(item);
            //};

            var localManager = serviceProvider.GetRequiredService<LocalManager>();
            localManager.ShowCityAndCountry();



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
