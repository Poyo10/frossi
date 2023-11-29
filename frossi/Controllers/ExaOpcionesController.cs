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
    public class ExaOpcionesController : Controller
    {
        private readonly AppDbContext _context;

        public ExaOpcionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExaOpciones
        public async Task<IActionResult> Index()
        {
              return View(await _context.ExaOpciones.ToListAsync());
        }

        // GET: ExaOpciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExaOpciones == null)
            {
                return NotFound();
            }

            var exaOpciones = await _context.ExaOpciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaOpciones == null)
            {
                return NotFound();
            }

            return View(exaOpciones);
        }

        // GET: ExaOpciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExaOpciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPregunta,Orden,TextoOpcion")] ExaOpciones exaOpciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exaOpciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exaOpciones);
        }

        // GET: ExaOpciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExaOpciones == null)
            {
                return NotFound();
            }

            var exaOpciones = await _context.ExaOpciones.FindAsync(id);
            if (exaOpciones == null)
            {
                return NotFound();
            }
            return View(exaOpciones);
        }

        // POST: ExaOpciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPregunta,Orden,TextoOpcion")] ExaOpciones exaOpciones)
        {
            if (id != exaOpciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exaOpciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaOpcionesExists(exaOpciones.Id))
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
            return View(exaOpciones);
        }

        // GET: ExaOpciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExaOpciones == null)
            {
                return NotFound();
            }

            var exaOpciones = await _context.ExaOpciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaOpciones == null)
            {
                return NotFound();
            }

            return View(exaOpciones);
        }

        // POST: ExaOpciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExaOpciones == null)
            {
                return Problem("Entity set 'AppDbContext.ExaOpciones'  is null.");
            }
            var exaOpciones = await _context.ExaOpciones.FindAsync(id);
            if (exaOpciones != null)
            {
                _context.ExaOpciones.Remove(exaOpciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaOpcionesExists(int id)
        {
          return _context.ExaOpciones.Any(e => e.Id == id);
        }
    }
}
