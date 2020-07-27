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
    public class DobavaController : Controller
    {
        private readonly DSR_N2Context _context;

        public DobavaController(DSR_N2Context context)
        {
            _context = context;
        }

        // GET: Dobava
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dobava.ToListAsync());
        }

        // GET: Dobava/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobava = await _context.Dobava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dobava == null)
            {
                return NotFound();
            }

            return View(dobava);
        }

        // GET: Dobava/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dobava/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum_Nakupa,Kolicina,Cena")] Dobava dobava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dobava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dobava);
        }

        // GET: Dobava/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobava = await _context.Dobava.FindAsync(id);
            if (dobava == null)
            {
                return NotFound();
            }
            return View(dobava);
        }

        // POST: Dobava/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum_Nakupa,Kolicina,Cena")] Dobava dobava)
        {
            if (id != dobava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dobava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DobavaExists(dobava.Id))
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
            return View(dobava);
        }

        // GET: Dobava/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dobava = await _context.Dobava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dobava == null)
            {
                return NotFound();
            }

            return View(dobava);
        }

        // POST: Dobava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dobava = await _context.Dobava.FindAsync(id);
            _context.Dobava.Remove(dobava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DobavaExists(int id)
        {
            return _context.Dobava.Any(e => e.Id == id);
        }
    }
}
