﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entites
{
    [Table("tblCities")]
    public class City : BaseEntity<int>
    {
        [Required, StringLength(200)]
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\t Name:{Name}\t County: {Country.Name}";
        }
    }
}
