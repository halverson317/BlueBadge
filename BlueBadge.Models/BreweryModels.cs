using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class BreweryModels
    {
        public class BreweryCreate
        {

            
            public string BreweryName { get; set; }
            
            public string BrewLocState { get; set; }
            
            public string BrewLocCity { get; set; }

            public float CurrentRating { get; set; }
        }

        public class BreweryEdit
        {
            [Key]
            public int BreweryID { get; set; }

            
            public string BreweryName { get; set; }
            
            public string BrewLocState { get; set; }
           
            public string BrewLocCity { get; set; }
            public float CurrentRating { get; set; }
        }

        public class BreweryDetail
        {
            [Key]
            public int BreweryID { get; set; }

            
            public string BreweryName { get; set; }
          
            public string BrewLocState { get; set; }
           
            public string BrewLocCity { get; set; }

            public float CurrentRating { get; set; }

        }

        public class BreweryListItem
        {
            [Key]
            public int BreweryID { get; set; }

           
            public string BreweryName { get; set; }
          
            public string BrewLocState { get; set; }
            
            public string BrewLocCity { get; set; }

            public float CurrentRating { get; set; }

        }
    }
}
