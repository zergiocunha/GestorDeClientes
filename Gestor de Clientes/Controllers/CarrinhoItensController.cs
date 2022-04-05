#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeClientes.Models.Carrinho;
using GestorDeClientes.Models.Context;

namespace GestorDeClientes.Controllers
{
    public class CarrinhoItensController : Controller
    {
        private readonly GCContext _context;

        public CarrinhoItensController(GCContext context)
        {
            _context = context;
        }

        // GET: CarrinhoItens
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarrinhoItens.ToListAsync());
        }

        // GET: CarrinhoItens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinhoItens = await _context.CarrinhoItens
                .FirstOrDefaultAsync(m => m.IdItens == id);
            if (clsCarrinhoItens == null)
            {
                return NotFound();
            }

            return View(clsCarrinhoItens);
        }

        // GET: CarrinhoItens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarrinhoItens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItens,Produto,Quantidade,SubTotal")] ClsCarrinhoItens clsCarrinhoItens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsCarrinhoItens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsCarrinhoItens);
        }

        // GET: CarrinhoItens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinhoItens = await _context.CarrinhoItens.FindAsync(id);
            if (clsCarrinhoItens == null)
            {
                return NotFound();
            }
            return View(clsCarrinhoItens);
        }

        // POST: CarrinhoItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItens,Produto,Quantidade,SubTotal")] ClsCarrinhoItens clsCarrinhoItens)
        {
            if (id != clsCarrinhoItens.IdItens)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsCarrinhoItens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsCarrinhoItensExists(clsCarrinhoItens.IdItens))
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
            return View(clsCarrinhoItens);
        }

        // GET: CarrinhoItens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinhoItens = await _context.CarrinhoItens
                .FirstOrDefaultAsync(m => m.IdItens == id);
            if (clsCarrinhoItens == null)
            {
                return NotFound();
            }

            return View(clsCarrinhoItens);
        }

        // POST: CarrinhoItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsCarrinhoItens = await _context.CarrinhoItens.FindAsync(id);
            _context.CarrinhoItens.Remove(clsCarrinhoItens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsCarrinhoItensExists(int id)
        {
            return _context.CarrinhoItens.Any(e => e.IdItens == id);
        }
    }
}
