using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class BeerCreate
    {

        [Required]
        public string BeerName { get; set; }
        //[Required]
        //public string Brewery { get; set; }
        [Required]
        public string Style { get; set; }
        public decimal Cost { get; set; }
        public float ABV { get; set; }
        public int Vintage { get; set; }
    }

    public class BeerEdit
    {
        [Key]
        public int BeerID { get; set; }

        //[Required]
        public string BeerName { get; set; }
        
        public string Brewery { get; set; }
        [Required]
        public string Style { get; set; }
        public decimal Cost { get; set; }
        public float ABV { get; set; }
        public int Vintage { get; set; }

    }

    public class BeerDetail
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

    public class BeerGetItem
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

    public class MainBeerList
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

    public class TitleView
    {
        [Key]
        public int BeerID { get; set; }
        public string BeerName { get; set; }
        public IEnumerable<MainBeerList> MainBeerItemList { get; set; }
    }
}
