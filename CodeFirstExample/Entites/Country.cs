using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entites
{
    [Table("tblCountries")]
    public class Country : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        public virtual IList<City> Cities { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
