using Airbnb_v3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Airbnb_v3.Repositories
{
    public interface IListingRepository
    {
        IEnumerable GetListings(ListingsFilters filters);
        IEnumerable GetNeighbourHoods();

        IEnumerable getReviewsPerYear(int id);
        IEnumerable getAveragePricePerNeighbourhood();
        IEnumerable getAverageRatingPerNeighbourhood();
        Task<Listings> Details(int? id);
    }
}