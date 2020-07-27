using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSR_N2.Models;

namespace DSR_N2.Controllers
{
    public class VinoController : Controller
    {
        private readonly DSR_N2Context _context;

        public VinoController(DSR_N2Context context)
        {
            _context = context;
        }

        // GET: Vino
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vino.ToListAsync());
        }

        // GET: Vino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vino == null)
            {
                return NotFound();
            }

            return View(vino);
        }

        // GET: Vino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Alkohol")] Vino vino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vino);
        }

        // GET: Vino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino.FindAsync(id);
            if (vino == null)
            {
                return NotFound();
            }
            return View(vino);
        }

        // POST: Vino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Alkohol")] Vino vino)
        {
            if (id != vino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinoExists(vino.Id))
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
            return View(vino);
        }

        // GET: Vino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vino = await _context.Vino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vino == null)
            {
                return NotFound();
            }

            return View(vino);
        }

        // POST: Vino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vino = await _context.Vino.FindAsync(id);
            _context.Vino.Remove(vino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinoExists(int id)
        {
            return _context.Vino.Any(e => e.Id == id);
        }
    }
}
