using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapNhatTT_Demo.Data;
using CapNhatTT_Demo.Models;

namespace CapNhatTT_Demo.Controllers
{
    public class ThongTinSVController : Controller
    {
        private readonly CapNhatTT_DemoContext _context;

        public ThongTinSVController(CapNhatTT_DemoContext context)
        {
            _context = context;
        }

        // GET: ThongTinSV
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThongTinSVModel.ToListAsync());
        }

        // GET: ThongTinSV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSVModel = await _context.ThongTinSVModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thongTinSVModel == null)
            {
                return NotFound();
            }

            return View(thongTinSVModel);
        }

        // GET: ThongTinSV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThongTinSV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Address,CMND")] ThongTinSVModel thongTinSVModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongTinSVModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thongTinSVModel);
        }

        // GET: ThongTinSV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSVModel = await _context.ThongTinSVModel.FindAsync(id);
            if (thongTinSVModel == null)
            {
                return NotFound();
            }
            return View(thongTinSVModel);
        }

        // POST: ThongTinSV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Address,CMND")] ThongTinSVModel thongTinSVModel)
        {
            if (id != thongTinSVModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongTinSVModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongTinSVModelExists(thongTinSVModel.Id))
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
            return View(thongTinSVModel);
        }

        // GET: ThongTinSV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSVModel = await _context.ThongTinSVModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thongTinSVModel == null)
            {
                return NotFound();
            }

            return View(thongTinSVModel);
        }

        // POST: ThongTinSV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thongTinSVModel = await _context.ThongTinSVModel.FindAsync(id);
            if (thongTinSVModel != null)
            {
                _context.ThongTinSVModel.Remove(thongTinSVModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongTinSVModelExists(int id)
        {
            return _context.ThongTinSVModel.Any(e => e.Id == id);
        }
    }
}
