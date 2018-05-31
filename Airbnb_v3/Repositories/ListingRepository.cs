using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb_v3.Models;

namespace Airbnb_v3.Repositories
{
    public class ListingRepository : IListingRepository
    {

        private AirBNBContext _context;

        public ListingRepository(AirBNBContext context)
        {
            _context = context;
        }
        public IEnumerable GetListings(ListingsFilters filters)
        {



            if (filters == null)
            {
                var result = _context.SmallListings
                //.Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                .Select(i => new SmallListings
                {
                    Id = i.Id,
                    Name = i.Name,
                    Longitude = i.Longitude,
                    Latitude = i.Latitude,
                    Price = i.Price,
                    ThumbnailUrl = i.ThumbnailUrl,
                    Description = i.Description,
                    Neighbourhood = i.Neighbourhood,
                    ReviewScoresRating = i.ReviewScoresRating

                });

                return result;
            }
            else
            {

                var result = _context.SmallListings
                //.Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                .Select(i => new SmallListings
                {
                    Id = i.Id,
                    Name = i.Name,
                    Longitude = i.Longitude,
                    Latitude = i.Latitude,
                    Price = i.Price.Substring(1, i.Price.Length - 3),
                    ThumbnailUrl = i.ThumbnailUrl,
                    Description = i.Description,
                    Neighbourhood = i.Neighbourhood,
                    ReviewScoresRating = i.ReviewScoresRating
                });

                if (filters.Neighbourhood != null)
                {
                    result = result.Where(l => l.Neighbourhood == filters.Neighbourhood);
                }


                if (filters.MinPrice > 0 && filters.MaxPrice > 0)
                {
                    result = result.Where(l => Int32.Parse(l.Price) > filters.MinPrice && Int32.Parse(l.Price) < filters.MaxPrice);
                }
                else if (filters.MinPrice > 0 && filters.MaxPrice == 0)
                {
                    result = result.Where(l => Int32.Parse(l.Price) > filters.MinPrice);
                }
                else if (filters.MinPrice == 0 && filters.MaxPrice > 0)
                {
                    result = result.Where(l => Int32.Parse(l.Price) < filters.MaxPrice);
                }

                if (filters.MinRating > 0)
                {
                    result = result.Where(l => l.ReviewScoresRating > filters.MinRating);
                }
                return result;

            }
        }

        public IEnumerable GetNeighbourHoods()
        {
            var result = _context.Neighbourhoods.Select(i => new Neighbourhoods
            {
                Neighbourhood = i.Neighbourhood
            });

            return result;
        }
    }
}
