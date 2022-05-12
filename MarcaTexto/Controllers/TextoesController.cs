#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarcaTexto;

namespace MarcaTexto.Controllers
{
    public class TextoesController : Controller
    {
        private readonly DatabaseContext _context;

        public TextoesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Textoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.xTexto.ToListAsync());
        }

        // GET: Textoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var texto = await _context.xTexto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (texto == null)
            {
                return NotFound();
            }

            return View(texto);
        }

        // GET: Textoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Textoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Texto1,Texto2")] Texto texto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(texto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(texto);
        }

        // GET: Textoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var texto = await _context.xTexto.FindAsync(id);
            if (texto == null)
            {
                return NotFound();
            }
            return View(texto);
        }

        // POST: Textoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Texto1,Texto2")] Texto texto)
        {
            if (id != texto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(texto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextoExists(texto.Id))
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
            return View(texto);
        }

        // GET: Textoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var texto = await _context.xTexto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (texto == null)
            {
                return NotFound();
            }

            return View(texto);
        }

        // POST: Textoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var texto = await _context.xTexto.FindAsync(id);
            _context.xTexto.Remove(texto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextoExists(int id)
        {
            return _context.xTexto.Any(e => e.Id == id);
        }
    }
}
