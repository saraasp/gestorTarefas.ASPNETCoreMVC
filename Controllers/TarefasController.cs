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
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index(int? dropClientes, int? dropFuncionarios, int? dropImportancias, string? rdb, bool coima)
        {
            

            ViewBag.CLIENTES = new SelectList(_context.Tclientes.ToList(), "Id", "Nome");
            ViewBag.FUNCIONARIOS = new SelectList(_context.Tfuncionarios.ToList(), "Id", "Nome");
            ViewBag.IMPORTANCIAS = new SelectList(_context.Timportancias.ToList(), "Id", "Designacao");

            List<Tarefa> listaTarefas = new List<Tarefa>();

            if (coima == true && rdb == "pendentes" && dropClientes==null && dropFuncionarios==null && dropImportancias==null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == false).ToList();
            }
            else if (coima == true && rdb == "resolvidas" && dropClientes == null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == true).ToList();
            }
            else if (coima == false && rdb == "resolvidas" && dropClientes == null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m=>m.Estado == true).ToList();
            }
            else if (coima == false && rdb == "pendentes" && dropClientes == null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Estado == false).ToList();
            }
            else if (coima == true && rdb == "pendentes" && dropClientes != null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == false && m.ClienteId == dropClientes).ToList();
            }
            else if (coima == true && rdb == "resolvidas" && dropClientes != null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == true && m.ClienteId == dropClientes).ToList();
            }
            else if (coima == false && rdb == "resolvidas" && dropClientes != null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == false && m.Estado == true && m.ClienteId == dropClientes).ToList();
            }
            else if (coima == false && rdb == "pendentes" && dropClientes != null && dropFuncionarios == null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Estado == false && m.ClienteId == dropClientes).ToList();
            }//dropCliente e dropFuncionario != null
            else if (coima == true && rdb == "pendentes" && dropClientes != null && dropFuncionarios != null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == false && m.ClienteId == dropClientes && m.FuncionarioId==dropFuncionarios).ToList();
            }
            else if (coima == true && rdb == "resolvidas" && dropClientes != null && dropFuncionarios != null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == true && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios).ToList();
            }
            else if (coima == false && rdb == "resolvidas" && dropClientes != null && dropFuncionarios != null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == false && m.Estado == true && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios).ToList();
            }
            else if (coima == false && rdb == "pendentes" && dropClientes != null && dropFuncionarios != null && dropImportancias == null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Estado == false && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios).ToList();
            }//dropImportancias != null
            else if (coima == true && rdb == "pendentes" && dropClientes != null && dropFuncionarios != null && dropImportancias != null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == false && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios && m.ImportanciaId == dropImportancias).ToList();
            }
            else if (coima == true && rdb == "resolvidas" && dropClientes != null && dropFuncionarios != null && dropImportancias != null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == true && m.Estado == true && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios && m.ImportanciaId == dropImportancias).ToList();
            }
            else if (coima == false && rdb == "resolvidas" && dropClientes != null && dropFuncionarios != null && dropImportancias != null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Coima == false && m.Estado == true && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios && m.ImportanciaId == dropImportancias).ToList();
            }
            else if (coima == false && rdb == "pendentes" && dropClientes != null && dropFuncionarios != null && dropImportancias != null)
            {
                listaTarefas = _context.Ttarefas.Where(m => m.Estado == false && m.ClienteId == dropClientes && m.FuncionarioId == dropFuncionarios && m.ImportanciaId == dropImportancias).ToList();
            } //-----
            else
            {
                listaTarefas = _context.Ttarefas.OrderBy(m => m.DataLimite).Where(m => m.Estado == false).ToList();
            }





           


            return View(listaTarefas);
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ttarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Ttarefas
                .Include(t => t.Categoria)
                .Include(t => t.Cliente)
                .Include(t => t.Funcionario)
                .Include(t => t.Importancia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Tcategorias, "Id", "Designacao");
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome");
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome");
            ViewData["ImportanciaId"] = new SelectList(_context.Timportancias, "Id", "Designacao");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataCriacao,Descricao,DataLimite,DataResolucao,ClienteId,FuncionarioId,CategoriaId,ImportanciaId,Coima,Estado")] Tarefa tarefa)
        {
            tarefa.DataCriacao = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));

            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Tcategorias, "Id", "Id", tarefa.CategoriaId);
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id", tarefa.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id", tarefa.FuncionarioId);
            ViewData["ImportanciaId"] = new SelectList(_context.Timportancias, "Id", "Id", tarefa.ImportanciaId);
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ttarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Ttarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Tcategorias, "Id", "Designacao", tarefa.CategoriaId);
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Nome", tarefa.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Nome", tarefa.FuncionarioId);
            ViewData["ImportanciaId"] = new SelectList(_context.Timportancias, "Id", "Designacao", tarefa.ImportanciaId);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataCriacao,Descricao,DataLimite,DataResolucao,ClienteId,FuncionarioId,CategoriaId,ImportanciaId,Coima,Estado")] Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Tcategorias, "Id", "Id", tarefa.CategoriaId);
            ViewData["ClienteId"] = new SelectList(_context.Tclientes, "Id", "Id", tarefa.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Tfuncionarios, "Id", "Id", tarefa.FuncionarioId);
            ViewData["ImportanciaId"] = new SelectList(_context.Timportancias, "Id", "Id", tarefa.ImportanciaId);
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ttarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Ttarefas
                .Include(t => t.Categoria)
                .Include(t => t.Cliente)
                .Include(t => t.Funcionario)
                .Include(t => t.Importancia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ttarefas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ttarefas'  is null.");
            }
            var tarefa = await _context.Ttarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Ttarefas.Remove(tarefa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(int id)
        {
          return (_context.Ttarefas?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> ResolverTarefa(int id)
        {
            var tarefa = await _context.Ttarefas.FindAsync(id);

            tarefa.DataResolucao = DateTime.Now.ToString("dd/MM/yyyy");
            tarefa.Estado = true;

            try
            {
                _context.Update(tarefa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
