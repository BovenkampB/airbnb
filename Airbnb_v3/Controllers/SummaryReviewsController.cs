using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airbnb_v3.Models;
using Airbnb_v3.Repositories;
using System.Collections;

namespace Airbnb_v3.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class SummaryReviewsController : Controller
    {
        private readonly IListingRepository _listingsRepository;

        public SummaryReviewsController(AirBNBContext context, IListingRepository listingRepository)
        {
            _listingsRepository = listingRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable getReviewsPerYear(int id)
        {
            var result = _listingsRepository.getReviewsPerYear(id);

            return result;
        }
    }
}
