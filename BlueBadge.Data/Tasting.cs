using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Tasting
    {
        [Key]
        public int TastingID { get; set; }
        //public int DrinkerID { get; set; }

        /// Beer Attributes ///

        public int BeerID { get; set; }
        public string BeerName { get; set; }
        public string Style { get; set; }
        public decimal Cost { get; set; }
        public float ABV { get; set; }
        public int Vintage { get; set; }


        /// Brewery Attribs ///


        public int BreweryID { get; set; }
        
        public string BreweryName { get; set; }
        public string BrewLocState { get; set; }
        public string BrewLocCity { get; set; }


        public DateTime DateOfTasting { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        public float Rating { get; set; }

        public string Comment { get; set; }





       // public virtual Drinker Drinker { get; set; }
        public virtual Beer Beer { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
