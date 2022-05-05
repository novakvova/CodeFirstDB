using CodeFirstExample.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country,int>
    {
    }
}
