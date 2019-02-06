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
        public Guid TastingID { get; set; }

        [ForeignKey("Drinker")]
        public Guid DrinkerID { get; set; }
        [ForeignKey("Beer")]
        public Guid BeerID { get; set; }
        [ForeignKey("Brewery")]
        public Guid BreweryID { get; set; }

        public DateTimeOffset DateOfTasting { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }





        public virtual Drinker Drinker { get; set; }
        public virtual Beer Beer { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
