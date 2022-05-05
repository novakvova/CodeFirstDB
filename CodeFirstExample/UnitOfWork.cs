using CodeFirstExample.Interfaces;
using CodeFirstExample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    public class UnitOfWork : IDisposable
    {
        private EFDbContext _context = new EFDbContext();
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;

        public ICountryRepository CountryRepository
        {
            get
            {
                _countryRepository = _countryRepository ?? new CountryRepository(_context);
                return _countryRepository;
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                _cityRepository = _cityRepository ?? new CityRepository(_context);
                return _cityRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
