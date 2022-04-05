#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorDeClientes.Models.Cliente;
using GestorDeClientes.Models.Context;

namespace GestorDeClientes.Controllers
{
    public class ClienteEnderecoesController : Controller
    {
        private readonly GCContext _context;

        public ClienteEnderecoesController(GCContext context)
        {
            _context = context;
        }

        // GET: ClienteEnderecoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteEndereco.ToListAsync());
        }

        // GET: ClienteEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsClienteEndereco = await _context.ClienteEndereco
                .FirstOrDefaultAsync(m => m.IdClienteEndereco == id);
            if (clsClienteEndereco == null)
            {
                return NotFound();
            }

            return View(clsClienteEndereco);
        }

        // GET: ClienteEnderecoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteEndereco,Logradouro,Numero,Complemento,Bairro,CEP,UF")] ClsClienteEndereco clsClienteEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsClienteEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsClienteEndereco);
        }

        // GET: ClienteEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsClienteEndereco = await _context.ClienteEndereco.FindAsync(id);
            if (clsClienteEndereco == null)
            {
                return NotFound();
            }
            return View(clsClienteEndereco);
        }

        // POST: ClienteEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteEndereco,Logradouro,Numero,Complemento,Bairro,CEP,UF")] ClsClienteEndereco clsClienteEndereco)
        {
            if (id != clsClienteEndereco.IdClienteEndereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsClienteEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsClienteEnderecoExists(clsClienteEndereco.IdClienteEndereco))
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
            return View(clsClienteEndereco);
        }

        // GET: ClienteEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsClienteEndereco = await _context.ClienteEndereco
                .FirstOrDefaultAsync(m => m.IdClienteEndereco == id);
            if (clsClienteEndereco == null)
            {
                return NotFound();
            }

            return View(clsClienteEndereco);
        }

        // POST: ClienteEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsClienteEndereco = await _context.ClienteEndereco.FindAsync(id);
            _context.ClienteEndereco.Remove(clsClienteEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsClienteEnderecoExists(int id)
        {
            return _context.ClienteEndereco.Any(e => e.IdClienteEndereco == id);
        }
    }
}
