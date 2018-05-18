using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airbnb_v3.Models;

namespace Airbnb_v3.Controllers
{
    public class SummaryListingsController : Controller
    {
        private readonly AirBNBContext _context;

        public SummaryListingsController(AirBNBContext context)
        {
            _context = context;
        }

        // GET: SummaryListings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SummaryListings.ToListAsync());
        }

        // GET: SummaryListings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryListings = await _context.SummaryListings
                .SingleOrDefaultAsync(m => m.Id == id);
            if (summaryListings == null)
            {
                return NotFound();
            }

            return View(summaryListings);
        }

        // GET: SummaryListings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SummaryListings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HostId,HostName,NeighbourhoodGroup,Neighbourhood,Latitude,Longitude,RoomType,Price,MinimumNights,NumberOfReviews,LastReview,ReviewsPerMonth,CalculatedHostListingsCount,Availability365")] SummaryListings summaryListings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summaryListings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summaryListings);
        }

        // GET: SummaryListings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryListings = await _context.SummaryListings.SingleOrDefaultAsync(m => m.Id == id);
            if (summaryListings == null)
            {
                return NotFound();
            }
            return View(summaryListings);
        }

        // POST: SummaryListings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HostId,HostName,NeighbourhoodGroup,Neighbourhood,Latitude,Longitude,RoomType,Price,MinimumNights,NumberOfReviews,LastReview,ReviewsPerMonth,CalculatedHostListingsCount,Availability365")] SummaryListings summaryListings)
        {
            if (id != summaryListings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summaryListings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummaryListingsExists(summaryListings.Id))
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
            return View(summaryListings);
        }

        // GET: SummaryListings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summaryListings = await _context.SummaryListings
                .SingleOrDefaultAsync(m => m.Id == id);
            if (summaryListings == null)
            {
                return NotFound();
            }

            return View(summaryListings);
        }

        // POST: SummaryListings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var summaryListings = await _context.SummaryListings.SingleOrDefaultAsync(m => m.Id == id);
            _context.SummaryListings.Remove(summaryListings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummaryListingsExists(int id)
        {
            return _context.SummaryListings.Any(e => e.Id == id);
        }
    }
}
