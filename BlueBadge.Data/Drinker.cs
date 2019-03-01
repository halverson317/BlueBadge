using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Drinker
    {   [Key]
        public int DrinkerID { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }

       
        public string UserName { get; set; }
        [Display(Name = "State")]
        public string LocationState { get; set; }
        [Display(Name = "City")]
        public string LocationCity { get; set; }
        [Display(Name = "Favorite Beer")]
        public string FavoriteBeer { get; set; }
        [Display(Name = "Favorite Brewery")]
        public string FavoriteBrewery { get; set; }

        public int Age { get; set; }
        [Display(Name = "# of Reviews")]
        public int NoOfTastings { get; set; }

        [Required]
        public DateTimeOffset ProfileCreated { get; set; }


    }
}
