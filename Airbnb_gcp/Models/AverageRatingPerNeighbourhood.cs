using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb_gcp.Models
{
    public class AverageRatingPerNeighbourhood
    {
        public int? Id { get; set; }
        public string Neighbourhood { get; set; }
        public int Rating { get; set; }
    }
}
