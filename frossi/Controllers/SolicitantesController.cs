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
    public class SolicitantesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitantes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Solicitantes.Include(s => s.TiposDoc);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Solicitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitantes = await _context.Solicitantes
                .Include(s => s.TiposDoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitantes == null)
            {
                return NotFound();
            }

            return View(solicitantes);
        }

        // GET: Solicitantes/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDoc"] = new SelectList(_context.TiposDoc, "Id", "Nombre");
            return View();
        }

        // POST: Solicitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoDoc,NroDoc,Nombres,Apellido,Email")] Solicitantes solicitantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDoc"] = new SelectList(_context.TiposDoc, "Id", "Nombre", solicitantes.IdTipoDoc);
            return View(solicitantes);
        }

        // GET: Solicitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitantes = await _context.Solicitantes.FindAsync(id);
            if (solicitantes == null)
            {
                return NotFound();
            }
            ViewData["IdTipoDoc"] = new SelectList(_context.TiposDoc, "Id", "Nombre", solicitantes.IdTipoDoc);
            return View(solicitantes);
        }

        // POST: Solicitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoDoc,NroDoc,Nombres,Apellido,Email")] Solicitantes solicitantes)
        {
            if (id != solicitantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitantesExists(solicitantes.Id))
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
            ViewData["IdTipoDoc"] = new SelectList(_context.TiposDoc, "Id", "Nombre", solicitantes.IdTipoDoc);
            return View(solicitantes);
        }

        // GET: Solicitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitantes == null)
            {
                return NotFound();
            }

            var solicitantes = await _context.Solicitantes
                .Include(s => s.TiposDoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitantes == null)
            {
                return NotFound();
            }

            return View(solicitantes);
        }

        // POST: Solicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitantes == null)
            {
                return Problem("Entity set 'AppDbContext.Solicitantes'  is null.");
            }
            var solicitantes = await _context.Solicitantes.FindAsync(id);
            if (solicitantes != null)
            {
                _context.Solicitantes.Remove(solicitantes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitantesExists(int id)
        {
          return _context.Solicitantes.Any(e => e.Id == id);
        }
    }
}
