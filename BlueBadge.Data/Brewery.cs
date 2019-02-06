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
        public Guid BreweryID { get; set; }

        [Required]
        public string BreweryName { get; set; }
        [Required]
        public string BrewLocState { get; set; }
        [Required]
        public string BrewLocCity { get; set; }

    }
}
