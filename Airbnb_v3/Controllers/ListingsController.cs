using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airbnb_v3.Models;
using Airbnb_v3.Repositories;
using Airbnb_v3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace Airbnb_v3.Controllers
{

    public class ListingsController : Controller
    {
        private readonly IListingRepository _repo;
        private static ListingsFilters listingFilters;

        public ListingsController(IListingRepository repo, AirBNBContext context)
        {
            _repo = repo;
        }

        [Authorize]
        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var result = await _repo.Details(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return View(result);

        }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [HttpGet]
        public IEnumerable GetListings()
        {
            var result = _repo.GetListings(listingFilters);

            return result;
        }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Neighbourhoods> neighbourhoods = (IEnumerable<Neighbourhoods>)_repo.GetNeighbourHoods();

            return View(new ListingsViewModel(listingFilters, neighbourhoods));
        }

        [HttpPost]
        public IActionResult Filter(ListingsFilters filters)
        {
            listingFilters = filters;
            return Redirect("../Listings");
        }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public IActionResult ClearFilter()
        {
            listingFilters = null;
            return Redirect("../Listings");
        }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [HttpGet]
        public IEnumerable getAveragePricePerNeighbourhood()
        {
            var result = _repo.getAveragePricePerNeighbourhood();

            return result;
        }

        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [HttpGet]
        public IEnumerable getAverageRatingPerNeighbourhood()
        {
            var result = _repo.getAverageRatingPerNeighbourhood();

            return result;
        }
    }
}
