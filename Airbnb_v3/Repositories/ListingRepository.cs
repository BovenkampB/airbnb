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
                var result = _context.SummaryListings
                .Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                .Select(i => new SummaryListings
                {
                    Id = i.sl.Id,
                    Name = i.sl.Name,
                    Longitude = i.sl.Longitude,
                    Latitude = i.sl.Latitude,
                    HostName = i.sl.HostName,
                    Neighbourhood = i.sl.Neighbourhood,
                    Price = i.sl.Price,
                    Rating = i.l.ReviewScoresRating

                });

                return result;
            }
            else
            {

                var result = _context.SummaryListings
                .Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                .Select(i => new SummaryListings
                {
                    Id = i.sl.Id,
                    Name = i.sl.Name,
                    Longitude = i.sl.Longitude,
                    Latitude = i.sl.Latitude,
                    HostName = i.sl.HostName,
                    Neighbourhood = i.sl.Neighbourhood,
                    Price = i.sl.Price,
                    Rating = i.l.ReviewScoresRating
                });

                if (filters.Neighbourhood != null)
                {
                    result = result.Where(l => l.Neighbourhood == filters.Neighbourhood);
                }


                if (filters.MinPrice > 0 && filters.MaxPrice > 0)
                {
                    result = result.Where(l => l.Price > filters.MinPrice && l.Price < filters.MaxPrice);
                }
                else if (filters.MinPrice > 0 && filters.MaxPrice == 0)
                {
                    result = result.Where(l => l.Price > filters.MinPrice);
                }
                else if (filters.MinPrice == 0 && filters.MaxPrice > 0)
                {
                    result = result.Where(l => l.Price < filters.MaxPrice);
                }

                if (filters.MinRating > 0)
                {
                    result = result.Where(l => l.Rating > filters.MinRating);
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
