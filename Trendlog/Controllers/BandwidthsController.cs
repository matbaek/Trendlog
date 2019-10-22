using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trendlog.Models;

namespace Trendlog.Controllers
{
    public class BandwidthsController : Controller
    {
        private readonly TrendlogContext _context;

        public BandwidthsController(TrendlogContext context)
        {
            _context = context;
        }

        // GET: Bandwidths
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bandwidth.ToListAsync());
        }

        // GET: Bandwidths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandwidth = await _context.Bandwidth
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bandwidth == null)
            {
                return NotFound();
            }

            return View(bandwidth);
        }

        // GET: Bandwidths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bandwidths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Value")] Bandwidth bandwidth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bandwidth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bandwidth);
        }

        // GET: Bandwidths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandwidth = await _context.Bandwidth.FindAsync(id);
            if (bandwidth == null)
            {
                return NotFound();
            }
            return View(bandwidth);
        }

        // POST: Bandwidths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Value")] Bandwidth bandwidth)
        {
            if (id != bandwidth.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandwidth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandwidthExists(bandwidth.ID))
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
            return View(bandwidth);
        }

        // GET: Bandwidths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandwidth = await _context.Bandwidth
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bandwidth == null)
            {
                return NotFound();
            }

            return View(bandwidth);
        }

        // POST: Bandwidths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandwidth = await _context.Bandwidth.FindAsync(id);
            _context.Bandwidth.Remove(bandwidth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandwidthExists(int id)
        {
            return _context.Bandwidth.Any(e => e.ID == id);
        }
    }
}
