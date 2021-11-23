using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Penggajian_Karyawan.Models;

namespace Penggajian_Karyawan.Controllers
{
    public class GajisController : Controller
    {
        private readonly PenggajianKaryawanContext _context;

        public GajisController(PenggajianKaryawanContext context)
        {
            _context = context;
        }

        // GET: Gajis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gajis.ToListAsync());
        }

        // GET: Gajis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis
                .FirstOrDefaultAsync(m => m.IdGaji == id);
            if (gaji == null)
            {
                return NotFound();
            }

            return View(gaji);
        }

        // GET: Gajis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gajis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGaji,Nama,IdPegawai,IdGolongan,Tunjangan,Potongan,Total")] Gaji gaji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gaji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gaji);
        }

        // GET: Gajis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis.FindAsync(id);
            if (gaji == null)
            {
                return NotFound();
            }
            return View(gaji);
        }

        // POST: Gajis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGaji,Nama,IdPegawai,IdGolongan,Tunjangan,Potongan,Total")] Gaji gaji)
        {
            if (id != gaji.IdGaji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gaji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GajiExists(gaji.IdGaji))
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
            return View(gaji);
        }

        // GET: Gajis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gaji = await _context.Gajis
                .FirstOrDefaultAsync(m => m.IdGaji == id);
            if (gaji == null)
            {
                return NotFound();
            }

            return View(gaji);
        }

        // POST: Gajis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gaji = await _context.Gajis.FindAsync(id);
            _context.Gajis.Remove(gaji);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GajiExists(int id)
        {
            return _context.Gajis.Any(e => e.IdGaji == id);
        }
    }
}
