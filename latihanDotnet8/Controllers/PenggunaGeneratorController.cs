using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using latihanDotnet8.Context;
using latihanDotnet8.Models.Entities;

namespace latihanDotnet8.Controllers
{
    public class PenggunaGeneratorController : Controller
    {
        private readonly dbAplicationContext _context;

        public PenggunaGeneratorController(dbAplicationContext context)
        {
            _context = context;
        }

        // GET: PenggunaGenerator
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pengguna.ToListAsync());
        }

        // GET: PenggunaGenerator/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengguna = await _context.Pengguna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pengguna == null)
            {
                return NotFound();
            }

            return View(pengguna);
        }

        // GET: PenggunaGenerator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PenggunaGenerator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,NoHp,Password,PasswordSalah,isActive")] Pengguna pengguna)
        {
            if (ModelState.IsValid)
            {
                pengguna.Id = Guid.NewGuid();
                _context.Add(pengguna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pengguna);
        }

        // GET: PenggunaGenerator/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengguna = await _context.Pengguna.FindAsync(id);
            if (pengguna == null)
            {
                return NotFound();
            }
            return View(pengguna);
        }

        // POST: PenggunaGenerator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,NoHp,Password,PasswordSalah,isActive")] Pengguna pengguna)
        {
            if (id != pengguna.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pengguna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenggunaExists(pengguna.Id))
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
            return View(pengguna);
        }

        // GET: PenggunaGenerator/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengguna = await _context.Pengguna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pengguna == null)
            {
                return NotFound();
            }

            return View(pengguna);
        }

        // POST: PenggunaGenerator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pengguna = await _context.Pengguna.FindAsync(id);
            if (pengguna != null)
            {
                _context.Pengguna.Remove(pengguna);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenggunaExists(Guid id)
        {
            return _context.Pengguna.Any(e => e.Id == id);
        }
    }
}
