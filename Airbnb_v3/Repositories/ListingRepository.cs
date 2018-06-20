using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnb_v3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Airbnb_v3.Repositories
{
    public class ListingRepository : IListingRepository
    {
        //private IMemoryCache ;

        private AirBNBContext _context;

        public ListingRepository(AirBNBContext context, IMemoryCache memoryCache)
        {
            _context = context;
            //_cache = memoryCache;
        }

        public async Task<IEnumerable> GetListings(ListingsFilters filters)
        {
            if (filters == null)
            {
                return await _context.SummaryListings.Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                    .Select(i => new SummaryListings
                    {
                        Id = i.sl.Id,
                        Name = i.sl.Name,
                        Longitude = i.sl.Longitude,
                        Latitude = i.sl.Latitude,
                        HostName = i.sl.HostName,
                        Neighbourhood = i.sl.Neighbourhood,
                        Price = i.sl.Price,
                        Rating = i.l.ReviewScoresRating,
                        Availability365 = i.l.Availability365
                    }).ToListAsync();
            }
            else
            {
                var result = _context.SummaryListings.Join(_context.Listings, sL => sL.Id, l => l.Id, (sl, l) => new { sl, l })
                    .Select(i => new SummaryListings
                    {
                        Id = i.sl.Id,
                        Name = i.sl.Name,
                        Longitude = i.sl.Longitude,
                        Latitude = i.sl.Latitude,
                        HostName = i.sl.HostName,
                        Neighbourhood = i.sl.Neighbourhood,
                        Price = i.sl.Price,
                        Rating = i.l.ReviewScoresRating,
                        Availability365 = i.l.Availability365
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
                return await result.ToListAsync();
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

        public IEnumerable getReviewsPerYear(int id)
        {
            var result = _context.ReviewPerYear
                .Where(l => l.Id == id)
                .Select(i => new ReviewPerYear
                {
                    Id = i.Id,
                    Year = i.Year,
                    NumberOfReviews = i.NumberOfReviews
                });

            return result;
        }

        public IEnumerable getAveragePricePerNeighbourhood()
        {
            var result = _context.AveragePricePerNeighbourhood
                .Select(i => new AveragePricePerNeighbourhood
                {
                    Neighbourhood = i.Neighbourhood,
                    Price = i.Price
                });

            return result;
        }

        public IEnumerable getAverageRatingPerNeighbourhood()
        {
            var result = _context.AverageRatingPerNeighbourhood
               .Select(i => new AverageRatingPerNeighbourhood
               {
                   Neighbourhood = i.Neighbourhood,
                   Rating = i.Rating
               });

            return result;
        }

        public async Task<Listings> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var listings = await _context.Listings
                .Include(l => l.IdNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return null;
            }

            return listings;
        }
    }
}
