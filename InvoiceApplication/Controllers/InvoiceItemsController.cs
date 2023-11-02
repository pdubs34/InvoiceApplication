using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.Data;
using InvoiceApplication.Models;

namespace InvoiceApplication.Controllers
{
    public class InvoiceItemsController : Controller
    {
        private readonly InvoiceApplicationContext _context;

        public InvoiceItemsController(InvoiceApplicationContext context)
        {
            _context = context;
        }

        // GET: InvoiceItems
        public async Task<IActionResult> Index()
        {
            var invoiceApplicationContext = _context.InvoiceItem.Include(i => i.Item);
            return View(await invoiceApplicationContext.ToListAsync());
        }

        // GET: InvoiceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvoiceItem == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItem
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // GET: InvoiceItems/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id");
            return View();
        }

        // POST: InvoiceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemId,Quantity,Type")] InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceItem.ItemId);
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvoiceItem == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItem.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceItem.ItemId);
            return View(invoiceItem);
        }

        // POST: InvoiceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemId,Quantity,Type")] InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceItemExists(invoiceItem.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", invoiceItem.ItemId);
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvoiceItem == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItem
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // POST: InvoiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvoiceItem == null)
            {
                return Problem("Entity set 'InvoiceApplicationContext.InvoiceItem'  is null.");
            }
            var invoiceItem = await _context.InvoiceItem.FindAsync(id);
            if (invoiceItem != null)
            {
                _context.InvoiceItem.Remove(invoiceItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceItemExists(int id)
        {
          return (_context.InvoiceItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
