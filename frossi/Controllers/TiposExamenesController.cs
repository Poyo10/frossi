using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frossi.Data;
using frossi.Models;

namespace frossi.Controllers
{
    public class TiposExamenesController : Controller
    {
        private readonly AppDbContext _context;

        public TiposExamenesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TiposExamenes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TiposExamenes.ToListAsync());
        }

        // GET: TiposExamenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposExamenes == null)
            {
                return NotFound();
            }

            var tiposExamenes = await _context.TiposExamenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposExamenes == null)
            {
                return NotFound();
            }

            return View(tiposExamenes);
        }

        // GET: TiposExamenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposExamenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TiposExamenes tiposExamenes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposExamenes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposExamenes);
        }

        // GET: TiposExamenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposExamenes == null)
            {
                return NotFound();
            }

            var tiposExamenes = await _context.TiposExamenes.FindAsync(id);
            if (tiposExamenes == null)
            {
                return NotFound();
            }
            return View(tiposExamenes);
        }

        // POST: TiposExamenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TiposExamenes tiposExamenes)
        {
            if (id != tiposExamenes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposExamenes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposExamenesExists(tiposExamenes.Id))
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
            return View(tiposExamenes);
        }

        // GET: TiposExamenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposExamenes == null)
            {
                return NotFound();
            }

            var tiposExamenes = await _context.TiposExamenes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposExamenes == null)
            {
                return NotFound();
            }

            return View(tiposExamenes);
        }

        // POST: TiposExamenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposExamenes == null)
            {
                return Problem("Entity set 'AppDbContext.TiposExamenes'  is null.");
            }
            var tiposExamenes = await _context.TiposExamenes.FindAsync(id);
            if (tiposExamenes != null)
            {
                _context.TiposExamenes.Remove(tiposExamenes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposExamenesExists(int id)
        {
          return _context.TiposExamenes.Any(e => e.Id == id);
        }
    }
}
