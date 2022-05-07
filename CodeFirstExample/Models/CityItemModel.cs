using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Models
{
    public class CityItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Назва країни
        /// </summary>
        public string CountryName { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\t Name:{Name}\t County: {CountryName}";
        }
    }
}
