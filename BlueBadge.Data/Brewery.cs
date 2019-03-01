using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Brewery
    {
        [Key]
        public int BreweryID { get; set; }

        [Required]
        public string BreweryName { get; set; }
        [MaxLength(2, ErrorMessage ="Please use the State Initials")]
        [Display(Name = "State")]
        public string BrewLocState { get; set; }
        [Required]
        [Display(Name = "City")]
        public string BrewLocCity { get; set; }
        public float CurrentRating  { get; set; }

    }
}
