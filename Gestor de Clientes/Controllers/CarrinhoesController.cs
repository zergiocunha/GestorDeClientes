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
    public class CarrinhoesController : Controller
    {
        private readonly GCContext _context;

        public CarrinhoesController(GCContext context)
        {
            _context = context;
        }

        // GET: Carrinhoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrinho.ToListAsync());
        }

        // GET: Carrinhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinho = await _context.Carrinho
                .FirstOrDefaultAsync(m => m.IdCarrinho == id);
            if (clsCarrinho == null)
            {
                return NotFound();
            }

            return View(clsCarrinho);
        }

        // GET: Carrinhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrinhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrinho,Cliente,TotalGeral")] ClsCarrinho clsCarrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsCarrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsCarrinho);
        }

        // GET: Carrinhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinho = await _context.Carrinho.FindAsync(id);
            if (clsCarrinho == null)
            {
                return NotFound();
            }
            return View(clsCarrinho);
        }

        // POST: Carrinhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarrinho,Cliente,TotalGeral")] ClsCarrinho clsCarrinho)
        {
            if (id != clsCarrinho.IdCarrinho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsCarrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsCarrinhoExists(clsCarrinho.IdCarrinho))
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
            return View(clsCarrinho);
        }

        // GET: Carrinhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsCarrinho = await _context.Carrinho
                .FirstOrDefaultAsync(m => m.IdCarrinho == id);
            if (clsCarrinho == null)
            {
                return NotFound();
            }

            return View(clsCarrinho);
        }

        // POST: Carrinhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsCarrinho = await _context.Carrinho.FindAsync(id);
            _context.Carrinho.Remove(clsCarrinho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsCarrinhoExists(int id)
        {
            return _context.Carrinho.Any(e => e.IdCarrinho == id);
        }
    }
}
