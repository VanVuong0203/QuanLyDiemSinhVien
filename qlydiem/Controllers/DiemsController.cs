using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qlydiem.Data;
using qlydiem.Models;

namespace qlydiem.Controllers
{
    public class DiemsController : Controller
    {
        private readonly qlydiemContext _context;

        public DiemsController(qlydiemContext context)
        {
            _context = context;
        }

        // GET: Diems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diem.ToListAsync());
        }

        // GET: Diems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // GET: Diems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MSSV,MaHP,SoTinChi,DiemQuaTrinh,DiemCuoiKy,HocKy,NamHoc")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diem);
        }

        // GET: Diems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }
            return View(diem);
        }

        // POST: Diems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MSSV,MaHP,SoTinChi,DiemQuaTrinh,DiemCuoiKy,HocKy,NamHoc")] Diem diem)
        {
            if (id != diem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Không cần phải gán lại các cột tính toán, EF sẽ tự tính lại các cột đó.
                    _context.Update(diem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemExists(diem.Id))
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
            return View(diem);
        }

        // GET: Diems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diem = await _context.Diem.FindAsync(id);
            if (diem != null)
            {
                _context.Diem.Remove(diem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemExists(int id)
        {
            return _context.Diem.Any(e => e.Id == id);
        }
    }
}
