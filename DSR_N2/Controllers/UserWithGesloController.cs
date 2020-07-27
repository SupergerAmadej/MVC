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
    public class UserWithGesloController : Controller
    {
        private readonly DSR_N2Context _context;

        public UserWithGesloController(DSR_N2Context context)
        {
            _context = context;
        }

        // GET: UserWithGeslo
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserWithGeslo.ToListAsync());
        }

        // GET: UserWithGeslo/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWithGeslo = await _context.UserWithGeslo
                .FirstOrDefaultAsync(m => m.EMSO == id);
            if (userWithGeslo == null)
            {
                return NotFound();
            }

            return View(userWithGeslo);
        }

        // GET: UserWithGeslo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserWithGeslo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EMSO,Ime,Priimek,Email,Datum_Roj,Kraj_Roj,Starost,Naslov,Postna_Stevilka,Drzava")] UserWithGeslo userWithGeslo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWithGeslo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userWithGeslo);
        }

        // GET: UserWithGeslo/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWithGeslo = await _context.UserWithGeslo.FindAsync(id);
            if (userWithGeslo == null)
            {
                return NotFound();
            }
            return View(userWithGeslo);
        }

        // POST: UserWithGeslo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EMSO,Ime,Priimek,Email,Datum_Roj,Kraj_Roj,Starost,Naslov,Postna_Stevilka,Drzava")] UserWithGeslo userWithGeslo)
        {
            if (id != userWithGeslo.EMSO)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userWithGeslo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserWithGesloExists(userWithGeslo.EMSO))
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
            return View(userWithGeslo);
        }

        // GET: UserWithGeslo/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWithGeslo = await _context.UserWithGeslo
                .FirstOrDefaultAsync(m => m.EMSO == id);
            if (userWithGeslo == null)
            {
                return NotFound();
            }

            return View(userWithGeslo);
        }

        // POST: UserWithGeslo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userWithGeslo = await _context.UserWithGeslo.FindAsync(id);
            _context.UserWithGeslo.Remove(userWithGeslo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserWithGesloExists(long id)
        {
            return _context.UserWithGeslo.Any(e => e.EMSO == id);
        }
    }
}
