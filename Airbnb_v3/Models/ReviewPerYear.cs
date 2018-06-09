using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb_v3.Models
{
    public class ReviewPerYear
    {
        public int? Id { get; set; }
        public int? Year { get; set; }
        public int? NumberOfReviews { get; set; }
    }
}
