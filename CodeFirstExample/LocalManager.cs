using AutoMapper;
using CodeFirstExample.Interfaces;
using CodeFirstExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    public class LocalManager
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public LocalManager(ICityRepository cityRepository,
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public void ShowCityAndCountry()
        {
            List<CityItemModel> cities = _cityRepository.GetAll()
                .Include(x => x.Country)
                .Select(x=>_mapper.Map<CityItemModel>(x)).ToList();

            //var list = _cityRepository.GetAll()
            //    .Include(x => x.Country);

            Console.WriteLine("Show list cities:");
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Show list countries: ");
            foreach (var item in _countryRepository.GetAll())
            {
                Console.WriteLine(item);
            };
        }
    }
}
