using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb_v3.Models
{
    public partial class SmallListings
    {
        public SmallListings()
        {
            Calendar = new HashSet<Calendar>();
            Reviews = new HashSet<Reviews>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        //public int HostId { get; set; }
        public string Neighbourhood { get; set; }
        public string Price { get; set; }
        public int? ReviewScoresRating { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<Calendar> Calendar { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
