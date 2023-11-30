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
    public class ExaHechosController : Controller
    {
        private readonly AppDbContext _context;

        public ExaHechosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExaHechos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ExaHechos.Include(e => e.Solicitantes).Include(e => e.TiposExamenes);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ExaHechos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExaHechos == null)
            {
                return NotFound();
            }

            var exaHechos = await _context.ExaHechos
                .Include(e => e.Solicitantes)
                .Include(e => e.TiposExamenes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaHechos == null)
            {
                return NotFound();
            }

            return View(exaHechos);
        }

        // GET: ExaHechos/Create
        public IActionResult Create()
        {
            ViewData["IdSolicitante"] = new SelectList(_context.Solicitantes, "Id", "Apellido");
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre");
            ViewData["IdTipoDoc"] = new SelectList(_context.TiposDoc, "Id", "Descri");
            return View();
        }

        // POST: ExaHechos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,IdTipoExamen,IdSolicitante,Correctas,Incorrectas,FechaInicio,FechaFin")] ExaHechos exaHechos)
        public async Task<IActionResult> Create([Bind("IdTipoExamen, IdTipoDoc, NroDoc")] ExaHechos exaHechos)
        {
            if (ModelState.IsValid)
            {

                var nroDocValue = exaHechos.Solicitantes.NroDoc;
                var idTipoDocValue = exaHechos.Solicitantes.IdTipoDoc;






                _context.Add(exaHechos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSolicitante"] = new SelectList(_context.Solicitantes, "Id", "Apellido", exaHechos.IdSolicitante);
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaHechos.IdTipoExamen);
            return View(exaHechos);
        }

        // GET: ExaHechos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExaHechos == null)
            {
                return NotFound();
            }

            var exaHechos = await _context.ExaHechos.FindAsync(id);
            if (exaHechos == null)
            {
                return NotFound();
            }
            ViewData["IdSolicitante"] = new SelectList(_context.Solicitantes, "Id", "Apellido", exaHechos.IdSolicitante);
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaHechos.IdTipoExamen);
            return View(exaHechos);
        }

        // POST: ExaHechos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoExamen,IdSolicitante,Correctas,Incorrectas,FechaInicio,FechaFin")] ExaHechos exaHechos)
        {
            if (id != exaHechos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exaHechos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaHechosExists(exaHechos.Id))
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
            ViewData["IdSolicitante"] = new SelectList(_context.Solicitantes, "Id", "Apellido", exaHechos.IdSolicitante);
            ViewData["IdTipoExamen"] = new SelectList(_context.TiposExamenes, "Id", "Nombre", exaHechos.IdTipoExamen);
            return View(exaHechos);
        }

        // GET: ExaHechos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExaHechos == null)
            {
                return NotFound();
            }

            var exaHechos = await _context.ExaHechos
                .Include(e => e.Solicitantes)
                .Include(e => e.TiposExamenes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exaHechos == null)
            {
                return NotFound();
            }

            return View(exaHechos);
        }

        // POST: ExaHechos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExaHechos == null)
            {
                return Problem("Entity set 'AppDbContext.ExaHechos'  is null.");
            }
            var exaHechos = await _context.ExaHechos.FindAsync(id);
            if (exaHechos != null)
            {
                _context.ExaHechos.Remove(exaHechos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaHechosExists(int id)
        {
          return _context.ExaHechos.Any(e => e.Id == id);
        }


        public IActionResult BuscarSolicitante(int idTipoDoc, string nroDoc)
        {
            var solicitante = _context.Solicitantes
                .FirstOrDefault(s => s.IdTipoDoc == idTipoDoc && s.NroDoc == nroDoc);

            if (solicitante != null)
            {
                // Aquí tienes el IdSolicitante encontrado
                int idSolicitanteEncontrado = solicitante.Id;

                // Realiza las acciones necesarias con el IdSolicitante encontrado
                // Por ejemplo, podrías asignarlo a una propiedad y usarlo en otro método o realizar alguna otra acción.

                //return View();
                return RedirectToAction("OtraAccion", "Controlador");
            }
            else
            {
                // El solicitante no fue encontrado
                // Maneja la lógica en caso de que no se encuentre el solicitante con los valores proporcionados

                return View("SolicitanteNoEncontrado");
            }

            // Resto del código del método...
        }

    }
}
