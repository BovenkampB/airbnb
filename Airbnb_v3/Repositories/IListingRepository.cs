using Airbnb_v3.Models;
using System;
using System.Collections;

namespace Airbnb_v3.Repositories
{
    public interface IListingRepository
    {
        IEnumerable GetListings(ListingsFilters filters);
        IEnumerable GetNeighbourHoods();

        IEnumerable getReviewsPerYear(int id);
        IEnumerable getAveragePricePerNeighbourhood();
        IEnumerable getAverageRatingPerNeighbourhood();
    }

}