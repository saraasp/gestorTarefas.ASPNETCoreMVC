using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestorTarefas.Data;
using gestorTarefas.Models;

namespace gestorTarefas.Controllers
{
    public class ImportanciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportanciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Importancias
        public async Task<IActionResult> Index()
        {
              return _context.Timportancias != null ? 
                          View(await _context.Timportancias.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Timportancias'  is null.");
        }

        // GET: Importancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timportancias == null)
            {
                return NotFound();
            }

            var importancia = await _context.Timportancias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importancia == null)
            {
                return NotFound();
            }

            return View(importancia);
        }

        // GET: Importancias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Importancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designacao")] Importancia importancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importancia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importancia);
        }

        // GET: Importancias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timportancias == null)
            {
                return NotFound();
            }

            var importancia = await _context.Timportancias.FindAsync(id);
            if (importancia == null)
            {
                return NotFound();
            }
            return View(importancia);
        }

        // POST: Importancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designacao")] Importancia importancia)
        {
            if (id != importancia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importancia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportanciaExists(importancia.Id))
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
            return View(importancia);
        }

        // GET: Importancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timportancias == null)
            {
                return NotFound();
            }

            var importancia = await _context.Timportancias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importancia == null)
            {
                return NotFound();
            }

            return View(importancia);
        }

        // POST: Importancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timportancias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Timportancias'  is null.");
            }
            var importancia = await _context.Timportancias.FindAsync(id);
            if (importancia != null)
            {
                _context.Timportancias.Remove(importancia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportanciaExists(int id)
        {
          return (_context.Timportancias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
