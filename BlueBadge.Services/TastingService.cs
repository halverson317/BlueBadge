using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class TastingService
    {

        public bool CreateTasting(TastingCreate model)
        {


            var beer = new Beer()
            {
                BeerName = model.BeerName,
                Style = model.Style,
                Cost = model.Cost,
                ABV = model.ABV,
                Vintage = model.Vintage,
            };

            var brewery = new Brewery()
            {
                BreweryName = model.BreweryName,
                BrewLocCity = model.BrewLocCity,
                BrewLocState = model.BrewLocState,
            };

            var ctx = new ApplicationDbContext();


            ctx.Beers.Add(beer);
            ctx.Breweries.Add(brewery);


            ctx.SaveChanges();




            var beerID = ctx.Beers.OrderByDescending(p => p.BeerID).FirstOrDefault().BeerID;
            var breweryID = ctx.Breweries.OrderByDescending(p => p.BreweryID).FirstOrDefault().BreweryID;

            var tasting = new Tasting()
            {
                BeerID = beerID,
                BeerName = model.BeerName,
                BreweryName = model.BreweryName,
                BreweryID = breweryID,
                DateOfTasting = model.DateOfTasting,
                DateAdded = DateTime.Now,
                Rating = model.Rating,
                Comment = model.Comment,

            };


            {
                ctx.Tastings.Add(tasting);
                if (ctx.SaveChanges() == 1)
                {
                    AverageRating(beer.BeerName);
                    AverageBreweryRating(brewery.BreweryName);
                    return true;
                }
                return false;
            }


        }


        public IEnumerable<TastingGetListItem> GetTastings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tastings.Select(p => new TastingGetListItem
                {
                    TastingID = p.TastingID,
                    BeerName = p.BeerName,
                    BeerID = p.BeerID,
                    BreweryID = p.BreweryID,
                    BreweryName = p.BreweryName,
                    //DrinkerID = p.DrinkerID,
                    DateOfTasting = p.DateOfTasting,
                    DateAdded = p.DateAdded,
                    Rating = p.Rating,
                    Comment = p.Comment,
                });

                return query.ToArray();
            }
        }

        public TastingDetail GetTastingByID(int? tastingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Tasting entity = ctx.Tastings.SingleOrDefault(p => p.TastingID ==tastingID);
                 
                

                return new TastingDetail
                {

                    BeerName = entity.Beer.BeerName,
                    BreweryName = entity.Brewery.BreweryName,
                    Style = entity.Beer.Style,
                    Cost = entity.Beer.Cost,
                    ABV = entity.Beer.ABV,
                    Vintage = entity.Beer.Vintage,
                    Rating = entity.Rating,
                    Comment = entity.Comment,
                };
            }
        }

            public bool EditTasting(TastingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tastings.FirstOrDefault(p => p.TastingID == model.TastingID);

                entity.Rating = model.Rating;
                entity.Comment = model.Comment;
                entity.DateOfTasting = model.DateOfTasting;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTasting(int id)
        {
            var beer = new Beer();
            var brewery = new Brewery();

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tastings.Single(p => p.TastingID == id);
                var entityTwo = ctx.Beers.Single(b => b.BeerID == id);
                var entityThree = ctx.Breweries.Single(w => w.BreweryID == id);
                ctx.Tastings.Remove(entity);
                if (ctx.SaveChanges() == 1)
                {
                    AverageRating(beer.BeerName);
                    AverageBreweryRating(brewery.BreweryName);
                    return true;
                }
                return false;
            }
        }

        private bool AverageRating(string beerName)
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

                var beerList = ctx.Beers.Where(b => b.BeerName == beerName).ToList();
                foreach (var beer in beerList)
                {
                    beer.CurrentRating = averageRating;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        private bool AverageBreweryRating(string breweryName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tastings.Where(r => r.BreweryName == breweryName).ToList();
                float averageRating = 0;
                foreach (var rating in query)
                {
                    averageRating += rating.Rating;
                }
                averageRating /= query.Count;

                var breweryList = ctx.Breweries.Where(b => b.BreweryName == breweryName).ToList();
                foreach (var B in breweryList)
                {
                    B.CurrentRating = averageRating;
                }

                return ctx.SaveChanges() == 1;
            }


        }
    }
}
