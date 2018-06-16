using Airbnb_gcp.Models;
using System;
using System.Collections;

namespace Airbnb_gcp.Repositories
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