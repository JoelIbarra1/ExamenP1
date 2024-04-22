using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenP1.Data;
using ExamenP1.Models;

namespace ExamenP1.Controllers
{
    public class JIbarrasController : Controller
    {
        private readonly ExamenP1Context _context;

        public JIbarrasController(ExamenP1Context context)
        {
            _context = context;
        }

        // GET: JIbarras
        public async Task<IActionResult> Index()
        {
            return View(await _context.JIbarra.ToListAsync());
        }

        // GET: JIbarras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jIbarra = await _context.JIbarra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jIbarra == null)
            {
                return NotFound();
            }

            return View(jIbarra);
        }

        // GET: JIbarras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JIbarras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Peso,Madrilista,FechaNacimiento")] JIbarra jIbarra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jIbarra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jIbarra);
        }

        // GET: JIbarras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jIbarra = await _context.JIbarra.FindAsync(id);
            if (jIbarra == null)
            {
                return NotFound();
            }
            return View(jIbarra);
        }

        // POST: JIbarras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Peso,Madrilista,FechaNacimiento")] JIbarra jIbarra)
        {
            if (id != jIbarra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jIbarra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JIbarraExists(jIbarra.Id))
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
            return View(jIbarra);
        }

        // GET: JIbarras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jIbarra = await _context.JIbarra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jIbarra == null)
            {
                return NotFound();
            }

            return View(jIbarra);
        }

        // POST: JIbarras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jIbarra = await _context.JIbarra.FindAsync(id);
            if (jIbarra != null)
            {
                _context.JIbarra.Remove(jIbarra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JIbarraExists(int id)
        {
            return _context.JIbarra.Any(e => e.Id == id);
        }
    }
}
