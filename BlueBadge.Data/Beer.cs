using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Beer
    {
        [Key]
        public Guid BeerID { get; set; }

        [Required]
        public string BeerName { get; set; }
        public string Brewery { get; set; }
        public string Style { get; set; }
        public decimal Cost { get; set; }
        public float ABV { get; set; }
        public int Vintage { get; set; }

    }
}
