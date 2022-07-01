using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AManeira.Data;
using AManeira.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace AManeira.Controllers
{
    [Authorize]
    public class EncomendasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EncomendasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }


        // GET: Encomendas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Encomendas.Include(e => e.Cliente);
            //ir buscar o cliente autenticado
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //procurar na tabela dos clientes pelo utilizador autenticado
            var cliente = await _context.Clientes
               .Where(s => s.UserID == user.Id)
               .FirstOrDefaultAsync();
            if (cliente == null)
            {
                RedirectToAction("Index");
            }

            //enviar o ID do cliente para a view
            ViewBag.Cliente = cliente.ID;
            //return await Task.Run(() => View());
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Encomendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Encomendas == null)
            {
                return RedirectToAction("Index");
            }

            var encomendas = await _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encomendas == null)
            {
                return RedirectToAction("Index");
            }

            return View(encomendas);
        }

        // GET: Encomendas/Create
        public async Task<IActionResult> Create()
        {
            //enviar o preço do prato para a view
            //Preco.Replace(",", ".");
            //decimal PrecoAux;
            //Decimal.TryParse(Preco, out PrecoAux);
            //ViewBag.Preco = PrecoAux;

            //ir buscar o cliente autenticado
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //procurar na tabela dos clientes pelo utilizador autenticado
            var cliente = await _context.Clientes
               .Where(s => s.UserID == user.Id)
               .FirstOrDefaultAsync();
            if (cliente == null)
            {
                RedirectToAction("Index");
            }

            //enviar o ID do cliente para a view
            ViewBag.Cliente = (int)cliente.ID;
            return await Task.Run(() => View());
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecoTotal,DataHoraEntrega,IsActive,ClienteFK")] Encomendas encomendas)
        {
            encomendas.IsActive = true;
            if (ModelState.IsValid)
            {
                _context.Add(encomendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClienteFK"] = new SelectList(_context.Set<Clientes>(), "ID", "ID", encomendas.ClienteFK);
            //encomendas.ClienteFK = cliente.ID;
            return View(encomendas);
        }

        // GET: Encomendas/Edit/
        public async Task<IActionResult> Edit()
        {

            //ir buscar o cliente autenticado
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //ir buscar a encomenda ativa do cliente
            var encomenda = await _context.Encomendas
                                            .Include(e => e.Cliente)
                                            .Include(e => e.ListaEncomendasPratos)
                                            .ThenInclude(e => e.Prato)
                                            .Where(e => e.Cliente.UserID == user.Id && e.IsActive)
                                            .FirstOrDefaultAsync();
                                
            if (encomenda == null)
            {
                return RedirectToAction("Index");
            }

            //calcular o preço total
            var preco = await _context.EncomendasPratos.Include(e => e.Prato).SumAsync(e => e.Prato.Preco*e.Quantidade);
            encomenda.AuxPrecoTotal = preco.ToString("0.00");
            _context.Entry(encomenda).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return View(encomenda);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecoTotal,AuxPrecoTotal,DataHoraEntrega,IsActive,ClienteFK")] Encomendas encomenda)
        {
            encomenda.PrecoTotal = Convert.ToDecimal(encomenda.AuxPrecoTotal.Replace('.', ','));
            encomenda.IsActive = false;
            if (id != encomenda.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendasExists(encomenda.Id))
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
            ViewData["ClienteFK"] = new SelectList(_context.Set<Clientes>(), "ID", "ID", encomenda.ClienteFK);
            return View(encomenda);
        }

        // GET: Encomendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Encomendas == null)
            {
                return RedirectToAction("Index");
            }

            var encomendas = await _context.Encomendas
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encomendas == null)
            {
                return RedirectToAction("Index");
            }

            return View(encomendas);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Encomendas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Encomendas'  is null.");
            }
            var encomendas = await _context.Encomendas.FindAsync(id);
            if (encomendas != null)
            {
                _context.Encomendas.Remove(encomendas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendasExists(int id)
        {
            return _context.Encomendas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> RedirectToEdit()
        {
            var applicationDbContext = _context.Encomendas.Include(e => e.Cliente);
            //ir buscar o cliente autenticado
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //procurar na tabela dos clientes pelo utilizador autenticado
            var cliente = await _context.Clientes
               .Where(s => s.UserID == user.Id)
               .FirstOrDefaultAsync();
            if (cliente == null)
            {
                RedirectToAction("Index");
            }
            // procurar encomenda ativa associada ao cliente
            var encomenda = await _context.Encomendas
               .Where(s => s.ClienteFK == cliente.ID && s.IsActive)
               .FirstOrDefaultAsync();
            if (encomenda == null)
            {
                RedirectToAction("Index");
            }

            // ir para o Edit da encomenda associada ao cliente
            return RedirectToAction("Edit", new { id = encomenda.Id });
        }
    }
}
