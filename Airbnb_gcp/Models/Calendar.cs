using System;
using System.Collections.Generic;

namespace Airbnb_gcp.Models
{
    public partial class Calendar
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }

        public Listings Listing { get; set; }
    }
}
