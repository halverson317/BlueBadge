using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class DrinkerCreate
    {
        public string FName { get; set; }
        public string LName { get; set; }

        
        public string UserName { get; set; }
        public string LocationState { get; set; }
        public string LocationCity { get; set; }
        public string FavoriteBeer { get; set; }
        public string FavoriteBrewery { get; set; }

        public int Age { get; set; }
        public int NoOfTastings { get; set; }

    }

    public class DrinkerEdit
    {
        [Key]
        public int DrinkerID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        
        public string UserName { get; set; }
        public string LocationState { get; set; }
        public string LocationCity { get; set; }
        public string FavoriteBeer { get; set; }
        public string FavoriteBrewery { get; set; }

        public int Age { get; set; }
        public int NoOfTastings { get; set; }

    }

    public class DrinkerDetail
    {
        [Key]
        public int DrinkerID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        
        public string UserName { get; set; }
        public string LocationState { get; set; }
        public string LocationCity { get; set; }
        public string FavoriteBeer { get; set; }
        public string FavoriteBrewery { get; set; }

        public int Age { get; set; }
        public int NoOfTastings { get; set; }

        public DateTimeOffset ProfileCreated { get; set; }
    }

    public class DrinkerListItem
    {
        [Key]
        public int DrinkerID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

       
        public string UserName { get; set; }
        public string LocationState { get; set; }
        public string LocationCity { get; set; }
        public string FavoriteBeer { get; set; }
        public string FavoriteBrewery { get; set; }

        public int Age { get; set; }
        public int NoOfTastings { get; set; }

        public DateTimeOffset ProfileCreated { get; set; }
    }
}
