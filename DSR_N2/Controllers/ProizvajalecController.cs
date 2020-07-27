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
    public class ProizvajalecController : Controller
    {
        private readonly DSR_N2Context _context;

        public ProizvajalecController(DSR_N2Context context)
        {
            _context = context;
        }

        // GET: Proizvajalec
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvajalec.ToListAsync());
        }

        // GET: Proizvajalec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvajalec == null)
            {
                return NotFound();
            }

            return View(proizvajalec);
        }

        // GET: Proizvajalec/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvajalec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Proizvajalec proizvajalec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvajalec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvajalec);
        }

        // GET: Proizvajalec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalec.FindAsync(id);
            if (proizvajalec == null)
            {
                return NotFound();
            }
            return View(proizvajalec);
        }

        // POST: Proizvajalec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Proizvajalec proizvajalec)
        {
            if (id != proizvajalec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvajalec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvajalecExists(proizvajalec.Id))
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
            return View(proizvajalec);
        }

        // GET: Proizvajalec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvajalec == null)
            {
                return NotFound();
            }

            return View(proizvajalec);
        }

        // POST: Proizvajalec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvajalec = await _context.Proizvajalec.FindAsync(id);
            _context.Proizvajalec.Remove(proizvajalec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvajalecExists(int id)
        {
            return _context.Proizvajalec.Any(e => e.Id == id);
        }
    }
}
