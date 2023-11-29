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
    public class TiposDocsController : Controller
    {
        private readonly AppDbContext _context;

        public TiposDocsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TiposDocs
        public async Task<IActionResult> Index()
        {
              return View(await _context.TiposDoc.ToListAsync());
        }

        // GET: TiposDocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposDoc == null)
            {
                return NotFound();
            }

            var tiposDoc = await _context.TiposDoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDoc == null)
            {
                return NotFound();
            }

            return View(tiposDoc);
        }

        // GET: TiposDocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descri")] TiposDoc tiposDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDoc);
        }

        // GET: TiposDocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposDoc == null)
            {
                return NotFound();
            }

            var tiposDoc = await _context.TiposDoc.FindAsync(id);
            if (tiposDoc == null)
            {
                return NotFound();
            }
            return View(tiposDoc);
        }

        // POST: TiposDocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descri")] TiposDoc tiposDoc)
        {
            if (id != tiposDoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposDocExists(tiposDoc.Id))
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
            return View(tiposDoc);
        }

        // GET: TiposDocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposDoc == null)
            {
                return NotFound();
            }

            var tiposDoc = await _context.TiposDoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDoc == null)
            {
                return NotFound();
            }

            return View(tiposDoc);
        }

        // POST: TiposDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposDoc == null)
            {
                return Problem("Entity set 'AppDbContext.TiposDoc'  is null.");
            }
            var tiposDoc = await _context.TiposDoc.FindAsync(id);
            if (tiposDoc != null)
            {
                _context.TiposDoc.Remove(tiposDoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDocExists(int id)
        {
          return _context.TiposDoc.Any(e => e.Id == id);
        }
    }
}
