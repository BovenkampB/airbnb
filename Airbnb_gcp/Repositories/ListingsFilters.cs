﻿namespace Airbnb_gcp.Repositories
{
    public class ListingsFilters
    {
        public int MinRating { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Neighbourhood { get; set; }

        public ListingsFilters()
        {

        }
    }
}