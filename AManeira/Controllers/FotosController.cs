using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AManeira.Data;
using AManeira.Models;

namespace AManeira.Controllers
{
    public class FotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fotos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fotos.Include(f => f.Prato);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return RedirectToAction("Index");
            }

            var fotos = await _context.Fotos
                .Include(f => f.Prato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotos == null)
            {
                return RedirectToAction("Index");
            }

            return View(fotos);
        }

        // GET: Fotos/Create
        public IActionResult Create()
        {
            ViewData["PratoFK"] = new SelectList(_context.Pratos, "Id", "Id");
            return View();
        }

        // POST: Fotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PratoFK")] Fotos fotos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PratoFK"] = new SelectList(_context.Pratos, "Id", "Id", fotos.PratoFK);
            return View(fotos);
        }

        // GET: Fotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return RedirectToAction("Index");
            }

            var fotos = await _context.Fotos.FindAsync(id);
            if (fotos == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["PratoFK"] = new SelectList(_context.Pratos, "Id", "Id", fotos.PratoFK);
            return View(fotos);
        }

        // POST: Fotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PratoFK")] Fotos fotos)
        {
            if (id != fotos.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotosExists(fotos.Id))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PratoFK"] = new SelectList(_context.Pratos, "Id", "Id", fotos.PratoFK);
            return View(fotos);
        }

        // GET: Fotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fotos == null)
            {
                return RedirectToAction("Index");
            }

            var fotos = await _context.Fotos
                .Include(f => f.Prato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotos == null)
            {
                return RedirectToAction("Index");
            }

            return View(fotos);
        }

        // POST: Fotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fotos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fotos'  is null.");
            }
            var fotos = await _context.Fotos.FindAsync(id);
            if (fotos != null)
            {
                _context.Fotos.Remove(fotos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotosExists(int id)
        {
          return _context.Fotos.Any(e => e.Id == id);
        }
    }
}
