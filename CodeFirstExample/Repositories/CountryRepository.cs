using CodeFirstExample.Entites;
using CodeFirstExample.Interfaces;
using Overby.Extensions.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Repositories
{
    public  class CountryRepository : BaseRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(EFDbContext context) : base(context)
        {
            Console.WriteLine("Context memory ref: " + context.GetReferenceId());
        }
    }
}
