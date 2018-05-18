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
    public class NeighbourhoodsController : Controller
    {
        private readonly AirBNBContext _context;

        public NeighbourhoodsController(AirBNBContext context)
        {
            _context = context;
        }

        // GET: Neighbourhoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Neighbourhoods.ToListAsync());
        }

        // GET: Neighbourhoods/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighbourhoods = await _context.Neighbourhoods
                .SingleOrDefaultAsync(m => m.Neighbourhood == id);
            if (neighbourhoods == null)
            {
                return NotFound();
            }

            return View(neighbourhoods);
        }

        // GET: Neighbourhoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Neighbourhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NeighbourhoodGroup,Neighbourhood")] Neighbourhoods neighbourhoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighbourhoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neighbourhoods);
        }

        // GET: Neighbourhoods/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighbourhoods = await _context.Neighbourhoods.SingleOrDefaultAsync(m => m.Neighbourhood == id);
            if (neighbourhoods == null)
            {
                return NotFound();
            }
            return View(neighbourhoods);
        }

        // POST: Neighbourhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NeighbourhoodGroup,Neighbourhood")] Neighbourhoods neighbourhoods)
        {
            if (id != neighbourhoods.Neighbourhood)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighbourhoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighbourhoodsExists(neighbourhoods.Neighbourhood))
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
            return View(neighbourhoods);
        }

        // GET: Neighbourhoods/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighbourhoods = await _context.Neighbourhoods
                .SingleOrDefaultAsync(m => m.Neighbourhood == id);
            if (neighbourhoods == null)
            {
                return NotFound();
            }

            return View(neighbourhoods);
        }

        // POST: Neighbourhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var neighbourhoods = await _context.Neighbourhoods.SingleOrDefaultAsync(m => m.Neighbourhood == id);
            _context.Neighbourhoods.Remove(neighbourhoods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighbourhoodsExists(string id)
        {
            return _context.Neighbourhoods.Any(e => e.Neighbourhood == id);
        }
    }
}
