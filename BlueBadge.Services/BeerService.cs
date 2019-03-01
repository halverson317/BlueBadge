using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class BeerService
    {
        private List<MainBeerList> _mainBeerList = new List<MainBeerList>();
        private List<MainBeerList> _queryableList = new List<MainBeerList>();


        public bool CreateBeer(BeerCreate model)
        {
            Beer beer = new Beer()
            {
                BeerName = model.BeerName,
                Style = model.Style,
                Cost = model.Cost,
                ABV = model.ABV,
                Vintage = model.Vintage,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Beers.Add(beer);
                if (ctx.SaveChanges() == 1)
                {
                    AverageRating(beer.BeerName);
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<BeerGetItem> GetBeers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Beers.Select(p => new BeerGetItem
                    {
                        BeerID = p.BeerID,
                        BeerName = p.BeerName,
                        BreweryName = p.BreweryName,
                        Style = p.Style,
                        Cost = p.Cost,
                        ABV = p.ABV,
                        Vintage = p.Vintage,
                        CurrentRating = p.CurrentRating
                    });
                //var noDbls = query.Distinct(BeerName);
                return query.ToArray();
            }
        }
        public IEnumerable<MainBeerList> BeerIndex(string beerName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach (Beer beer in ctx.Beers.AsNoTracking().ToList())
                {
                    var query = ctx.Beers.Where(b => b.BeerName == beerName).Select(b => new MainBeerList
                    {
                        BeerName = beer.BeerName,
                        BreweryName = b.BreweryName,
                        CurrentRating = b.CurrentRating,
                        Style = b.Style,
                    });
                    _queryableList = query.ToList();
                    foreach (MainBeerList item in _queryableList)
                    {
                        _mainBeerList.Add(item);
                    }
                }
                
                return _mainBeerList.ToList();
            }
        }


        public BeerDetail GetBeerByName(int? beerID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Beers.SingleOrDefault(p => p.BeerID == beerID);

                var model = new BeerDetail
                {
                    BeerID = entity.BeerID,
                    BeerName = entity.BeerName,
                    Style = entity.Style,
                    Cost = entity.Cost,
                    ABV = entity.ABV,
                    Vintage = entity.Vintage,
                    CurrentRating = entity.CurrentRating
                };

                return model;
            }
        }

        private bool AverageRating (string beerName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tastings.Where(r => r.BeerName == beerName).ToList();
                float averageRating = 0;
                foreach (var rating in query)
                {
                    averageRating += rating.Rating;
                }
                averageRating /= query.Count;

                var beer = ctx.Beers.Single(b => b.BeerName == beerName);
                beer.CurrentRating = averageRating;

                return ctx.SaveChanges() == 1;
            }
        }


    }

}
