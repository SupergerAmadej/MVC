using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSR_N2.Models;
using Microsoft.AspNetCore.Authorization;

namespace DSR_N2.Controllers
{


    public class KletController : Controller
    {
        private readonly DSR_N2Context _context;

        public KletController(DSR_N2Context context)
        {
            _context = context;
        }

        // GET: Klet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klet.ToListAsync());
        }

        // GET: Klet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klet = await _context.Klet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klet == null)
            {
                return NotFound();
            }

            return View(klet);
        }

        // GET: Klet/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Naslov")] Klet klet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klet);
        }

        // GET: Klet/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klet = await _context.Klet.FindAsync(id);
            if (klet == null)
            {
                return NotFound();
            }
            return View(klet);
        }

        // POST: Klet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Naslov")] Klet klet)
        {
            if (id != klet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KletExists(klet.Id))
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
            return View(klet);
        }

        // GET: Klet/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klet = await _context.Klet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klet == null)
            {
                return NotFound();
            }

            return View(klet);
        }

        // POST: Klet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klet = await _context.Klet.FindAsync(id);
            _context.Klet.Remove(klet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KletExists(int id)
        {
            return _context.Klet.Any(e => e.Id == id);
        }
    }
}
