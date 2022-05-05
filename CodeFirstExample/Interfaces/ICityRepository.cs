using CodeFirstExample.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Interfaces
{
    public interface ICityRepository: IBaseRepository<City, int>
    {
    }
}
