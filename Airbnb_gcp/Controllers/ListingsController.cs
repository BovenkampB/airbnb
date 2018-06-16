using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airbnb_gcp.Models;
using Airbnb_gcp.Repositories;
using Airbnb_gcp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace Airbnb_gcp.Controllers
{

    public class ListingsController : Controller
    {
        private readonly IListingRepository _repo;
        private static ListingsFilters listingFilters;
        //context moet er nog uitgesloopt worden( zit namelijk al in repository)
        private readonly AirBNBContext _context;

        public ListingsController(IListingRepository repo, AirBNBContext context)
        {
            _repo = repo;
            _context = context;
        }

        //standaard index
        //// GET: Listings
        //public async Task<IActionResult> Index()
        //{
        //    var airBNBContext = _context.Listings.Include(l => l.IdNavigation);
        //    return View(await airBNBContext.ToListAsync());
        //}

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings
                .Include(l => l.IdNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Listings, "Id", "Access");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListingUrl,ScrapeId,LastScraped,Name,Summary,Space,Description,ExperiencesOffered,NeighborhoodOverview,Notes,Transit,Access,Interaction,HouseRules,ThumbnailUrl,MediumUrl,PictureUrl,XlPictureUrl,HostId,HostUrl,HostName,HostSince,HostLocation,HostAbout,HostResponseTime,HostResponseRate,HostAcceptanceRate,HostIsSuperhost,HostThumbnailUrl,HostPictureUrl,HostNeighbourhood,HostListingsCount,HostTotalListingsCount,HostVerifications,HostHasProfilePic,HostIdentityVerified,Street,Neighbourhood,NeighbourhoodCleansed,NeighbourhoodGroupCleansed,City,State,Zipcode,Market,SmartLocation,CountryCode,Country,Latitude,Longitude,IsLocationExact,PropertyType,RoomType,Accommodates,Bathrooms,Bedrooms,Beds,BedType,Amenities,SquareFeet,Price,WeeklyPrice,MonthlyPrice,SecurityDeposit,CleaningFee,GuestsIncluded,ExtraPeople,MinimumNights,MaximumNights,CalendarUpdated,HasAvailability,Availability30,Availability60,Availability90,Availability365,CalendarLastScraped,NumberOfReviews,FirstReview,LastReview,ReviewScoresRating,ReviewScoresAccuracy,ReviewScoresCleanliness,ReviewScoresCheckin,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresValue,RequiresLicense,License,JurisdictionNames,InstantBookable,IsBusinessTravelReady,CancellationPolicy,RequireGuestProfilePicture,RequireGuestPhoneVerification,CalculatedHostListingsCount,ReviewsPerMonth")] Listings listings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Listings, "Id", "Access", listings.Id);
            return View(listings);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings.SingleOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Listings, "Id", "Access", listings.Id);
            return View(listings);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListingUrl,ScrapeId,LastScraped,Name,Summary,Space,Description,ExperiencesOffered,NeighborhoodOverview,Notes,Transit,Access,Interaction,HouseRules,ThumbnailUrl,MediumUrl,PictureUrl,XlPictureUrl,HostId,HostUrl,HostName,HostSince,HostLocation,HostAbout,HostResponseTime,HostResponseRate,HostAcceptanceRate,HostIsSuperhost,HostThumbnailUrl,HostPictureUrl,HostNeighbourhood,HostListingsCount,HostTotalListingsCount,HostVerifications,HostHasProfilePic,HostIdentityVerified,Street,Neighbourhood,NeighbourhoodCleansed,NeighbourhoodGroupCleansed,City,State,Zipcode,Market,SmartLocation,CountryCode,Country,Latitude,Longitude,IsLocationExact,PropertyType,RoomType,Accommodates,Bathrooms,Bedrooms,Beds,BedType,Amenities,SquareFeet,Price,WeeklyPrice,MonthlyPrice,SecurityDeposit,CleaningFee,GuestsIncluded,ExtraPeople,MinimumNights,MaximumNights,CalendarUpdated,HasAvailability,Availability30,Availability60,Availability90,Availability365,CalendarLastScraped,NumberOfReviews,FirstReview,LastReview,ReviewScoresRating,ReviewScoresAccuracy,ReviewScoresCleanliness,ReviewScoresCheckin,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresValue,RequiresLicense,License,JurisdictionNames,InstantBookable,IsBusinessTravelReady,CancellationPolicy,RequireGuestProfilePicture,RequireGuestPhoneVerification,CalculatedHostListingsCount,ReviewsPerMonth")] Listings listings)
        {
            if (id != listings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingsExists(listings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Listings, "Id", "Access", listings.Id);
            return View(listings);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = await _context.Listings
                .Include(l => l.IdNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listings = await _context.Listings.SingleOrDefaultAsync(m => m.Id == id);
            _context.Listings.Remove(listings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingsExists(int id)
        {
            return _context.Listings.Any(e => e.Id == id);
        }

        //private IQueryable<SmallListings> totalQueryResult;
        //[HttpGet]
        //public IQueryable GetListings()
        //{
        //    totalQueryResult = _context.SmallListings.Select(i => new SmallListings
        //    {
        //        Id = i.Id,
        //        Name = i.Name,
        //        Longitude = i.Longitude,
        //        Latitude = i.Latitude,
        //        Price = i.Price,
        //        ThumbnailUrl = i.ThumbnailUrl,
        //        Description = i.Description,
        //        Neighbourhood = i.Neighbourhood,
        //        ReviewScoresRating = i.ReviewScoresRating
        //    });

        //    return totalQueryResult;
        //}


        private IQueryable<Listings> filteredQueryResult;
        [HttpGet]
        public IQueryable GetListingsWithFilter(String filter)
        {
            filteredQueryResult = _context.Listings.Select(i => new Listings
            {
                Id = i.Id,
                Name = i.Name,
                Longitude = i.Longitude,
                Latitude = i.Latitude,
                Price = i.Price,
                ThumbnailUrl = i.ThumbnailUrl,
                Neighbourhood = i.Neighbourhood,
                Description = i.Description,
                ReviewScoresRating = i.ReviewScoresRating,

            }).Where(m => m.Neighbourhood.Contains(filter));

            return filteredQueryResult;
        }


        [HttpGet]
        public IEnumerable GetListings()
        {
            var result = _repo.GetListings(listingFilters);

            return result;
        }

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

        public IActionResult ClearFilter()
        {
            listingFilters = null;
            return Redirect("../Listings");
        }

        [HttpGet]
        public IEnumerable getAveragePricePerNeighbourhood()
        {
            var result = _repo.getAveragePricePerNeighbourhood();

            return result;
        }

        [HttpGet]
        public IEnumerable getAverageRatingPerNeighbourhood()
        {
            var result = _repo.getAverageRatingPerNeighbourhood();

            return result;
        }
    }
}
