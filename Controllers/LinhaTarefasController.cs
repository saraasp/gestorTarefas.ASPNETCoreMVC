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
    public class LinhaTarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinhaTarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LinhaTarefas
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ID = id;
            ViewBag.TAREFA = _context.Ttarefas.Include(l=>l.Cliente).Where(m => m.Id == id).ToList();
            var applicationDbContext = _context.TlinhasTarefa.Include(l => l.Tarefa).Where(m => m.TarefaId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LinhaTarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TlinhasTarefa == null)
            {
                return NotFound();
            }

            var linhaTarefa = await _context.TlinhasTarefa
                .Include(l => l.Tarefa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaTarefa == null)
            {
                return NotFound();
            }

            return View(linhaTarefa);
        }

        // GET: LinhaTarefas/Create
        public IActionResult Create(int id)
        {
            
            ViewData["TarefaId"] = new SelectList(_context.Ttarefas.Where(m=>m.Id==id), "Id", "Descricao");
            return View();
        }

        // POST: LinhaTarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TarefaId,Data,Descricao,NomeFuncionario")] LinhaTarefa linhaTarefa)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(linhaTarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TarefaId"] = new SelectList(_context.Ttarefas, "Id", "Descricao", linhaTarefa.TarefaId);
            return View();
        }

        // GET: LinhaTarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TlinhasTarefa == null)
            {
                return NotFound();
            }

            var linhaTarefa = await _context.TlinhasTarefa.FindAsync(id);
            if (linhaTarefa == null)
            {
                return NotFound();
            }
            ViewData["TarefaId"] = new SelectList(_context.Ttarefas, "Id", "Descricao", linhaTarefa.TarefaId);
            return View(linhaTarefa);
        }

        // POST: LinhaTarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TarefaId,Data,Descricao,NomeFuncionario")] LinhaTarefa linhaTarefa)
        {
            if (id != linhaTarefa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaTarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaTarefaExists(linhaTarefa.Id))
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
            ViewData["TarefaId"] = new SelectList(_context.Ttarefas, "Id", "Descricao", linhaTarefa.TarefaId);
            return View(linhaTarefa);
        }

        // GET: LinhaTarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TlinhasTarefa == null)
            {
                return NotFound();
            }

            var linhaTarefa = await _context.TlinhasTarefa
                .Include(l => l.Tarefa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaTarefa == null)
            {
                return NotFound();
            }

            return View(linhaTarefa);
        }

        // POST: LinhaTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TlinhasTarefa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TlinhasTarefa'  is null.");
            }
            var linhaTarefa = await _context.TlinhasTarefa.FindAsync(id);
            if (linhaTarefa != null)
            {
                _context.TlinhasTarefa.Remove(linhaTarefa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaTarefaExists(int id)
        {
            return (_context.TlinhasTarefa?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //GET
        public async Task<IActionResult> AdicionarLinhaTarefa(int id)
        {
            var linhaTarefa = await _context.TlinhasTarefa.FindAsync(id);

            ViewBag.TAREFA = _context.TlinhasTarefa.Where(m => m.TarefaId == id).ToList();
            return View();

        }

    }
}
