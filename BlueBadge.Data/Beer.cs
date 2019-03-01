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
        public int BeerID { get; set; }

        
        public string BeerName { get; set; }
        public string BreweryName { get; set; }
        public string Style { get; set; }
        public decimal Cost { get; set; }
        public float ABV { get; set; }
        public int Vintage { get; set; }
        public float CurrentRating { get; set; }

    }
}
