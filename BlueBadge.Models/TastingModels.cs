using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class TastingCreate
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
    }

    public class TastingEdit
    {
        [Key]
        public int TastingID { get; set; }
        

        public int DrinkerID { get; set; }
        
        public int BeerID { get; set; }
        
       
        public int BreweryID { get; set; }
     

        public DateTime DateOfTasting { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }

        [Required]
        public float Rating { get; set; }

        public string Comment { get; set; }

    }

    public class TastingDetail
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

    } 

    public class TastingGetListItem
    {
        [Key]
        public int TastingID { get; set; }
        public int DrinkerID { get; set; }

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
    }

    public class TastingDelete
    {
        [Key]
        public int TastingID { get; set; }

        public int DrinkerID { get; set; }

        public int BeerID { get; set; }

        public int BreweryID { get; set; }


        public DateTime DateOfTasting { get; set; }

        
        public DateTimeOffset DateAdded { get; set; }

        
        public float Rating { get; set; }

        public string Comment { get; set; }

    }
}
    

