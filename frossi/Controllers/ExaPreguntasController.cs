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
    public class ExaPreguntasController : Controller
    {
        private readonly AppDbContext _context;

        public ExaPreguntasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExaPreguntas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ExaPreguntas.Include(e => e.TiposExamenes);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ExaPreguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExaPreguntas == null)
            {
                return NotFound();
            }

            var exaPreguntas = await _context.ExaPreguntas
                .Include(e => e.TiposExamenes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaPreguntas == null)
            {
                return NotFound();
            }

            return View(exaPreguntas);
        }

        // GET: ExaPreguntas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre");
            return View();
        }

        // POST: ExaPreguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoExamen,Texto,PathImagen,RtaCorrecta")] ExaPreguntas exaPreguntas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exaPreguntas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaPreguntas.IdTipoExamen);
            return View(exaPreguntas);
        }

        // GET: ExaPreguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExaPreguntas == null)
            {
                return NotFound();
            }

            var exaPreguntas = await _context.ExaPreguntas.FindAsync(id);
            if (exaPreguntas == null)
            {
                return NotFound();
            }
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaPreguntas.IdTipoExamen);
            return View(exaPreguntas);
        }

        // POST: ExaPreguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoExamen,Texto,PathImagen,RtaCorrecta")] ExaPreguntas exaPreguntas)
        {
            if (id != exaPreguntas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exaPreguntas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaPreguntasExists(exaPreguntas.Id))
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
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaPreguntas.IdTipoExamen);
            return View(exaPreguntas);
        }

        // GET: ExaPreguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExaPreguntas == null)
            {
                return NotFound();
            }

            var exaPreguntas = await _context.ExaPreguntas
                .Include(e => e.TiposExamenes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaPreguntas == null)
            {
                return NotFound();
            }

            return View(exaPreguntas);
        }

        // POST: ExaPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExaPreguntas == null)
            {
                return Problem("Entity set 'AppDbContext.ExaPreguntas'  is null.");
            }
            var exaPreguntas = await _context.ExaPreguntas.FindAsync(id);
            if (exaPreguntas != null)
            {
                _context.ExaPreguntas.Remove(exaPreguntas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaPreguntasExists(int id)
        {
          return _context.ExaPreguntas.Any(e => e.Id == id);
        }
    }
}
