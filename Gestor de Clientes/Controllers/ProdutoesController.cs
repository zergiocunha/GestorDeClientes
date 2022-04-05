#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeClientes.Models.Context;
using GestorDeClientes.Models.Produto;

namespace GestorDeClientes.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly GCContext _context;

        public ProdutoesController(GCContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsProduto = await _context.Produto
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (clsProduto == null)
            {
                return NotFound();
            }

            return View(clsProduto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduto,Descricao,Foto,Preco")] ClsProduto clsProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsProduto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsProduto = await _context.Produto.FindAsync(id);
            if (clsProduto == null)
            {
                return NotFound();
            }
            return View(clsProduto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto,Descricao,Foto,Preco")] ClsProduto clsProduto)
        {
            if (id != clsProduto.IdProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsProdutoExists(clsProduto.IdProduto))
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
            return View(clsProduto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsProduto = await _context.Produto
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (clsProduto == null)
            {
                return NotFound();
            }

            return View(clsProduto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsProduto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(clsProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.IdProduto == id);
        }
    }
}
