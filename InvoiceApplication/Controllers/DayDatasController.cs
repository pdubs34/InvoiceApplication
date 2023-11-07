using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.Data;
using InvoiceApplication.Models.DataModels;

namespace InvoiceApplication.Controllers
{
    public class DayDatasController : Controller
    {
        private readonly InvoiceApplicationContext _context;

        public DayDatasController(InvoiceApplicationContext context)
        {
            _context = context;
        }

        // GET: DayDatas
        public async Task<IActionResult> Index()
        {
              return _context.DayData != null ? 
                          View(await _context.DayData.ToListAsync()) :
                          Problem("Entity set 'InvoiceApplicationContext.DayData'  is null.");
        }

        // GET: DayDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DayData == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayData == null)
            {
                return NotFound();
            }

            return View(dayData);
        }

        // GET: DayDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DayDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Precipitation,Temp,Retail")] DayData dayData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dayData);
        }

        // GET: DayDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DayData == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayData.FindAsync(id);
            if (dayData == null)
            {
                return NotFound();
            }
            return View(dayData);
        }

        // POST: DayDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Precipitation,Temp,Retail")] DayData dayData)
        {
            if (id != dayData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayDataExists(dayData.Id))
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
            return View(dayData);
        }

        // GET: DayDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DayData == null)
            {
                return NotFound();
            }

            var dayData = await _context.DayData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayData == null)
            {
                return NotFound();
            }

            return View(dayData);
        }

        // POST: DayDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DayData == null)
            {
                return Problem("Entity set 'InvoiceApplicationContext.DayData'  is null.");
            }
            var dayData = await _context.DayData.FindAsync(id);
            if (dayData != null)
            {
                _context.DayData.Remove(dayData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayDataExists(int id)
        {
          return (_context.DayData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
