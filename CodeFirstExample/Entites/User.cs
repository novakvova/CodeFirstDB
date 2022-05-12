using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entites
{
    [Table("tblUsers")]
    public class User : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IList<Basket> Baskets { get; set; }
    }
}
