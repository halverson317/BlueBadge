using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBadge.Data;
using BlueBadge.Models;
using static BlueBadge.Models.BreweryModels;

namespace BlueBadge.Services
{
    public class BreweryService
    {
        public IEnumerable<BreweryListItem> GetBreweries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Breweries.Select(p => new BreweryListItem
                    {
                        BreweryID = p.BreweryID,
                        BreweryName = p.BreweryName,
                        BrewLocState = p.BrewLocState,
                        BrewLocCity = p.BrewLocCity,
                        CurrentRating = p.CurrentRating,

                    });
                return query.ToArray();
            }
        }
    }
}

