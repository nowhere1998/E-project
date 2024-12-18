using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_project.Models;

namespace E_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionDetailsController : Controller
    {
        private readonly EProjectContext _context;

        public TransactionDetailsController(EProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/TransactionDetails
        public async Task<IActionResult> Index()
        {
            var eProjectContext = _context.TransactionDetails.Include(t => t.Transaction);
            return View(await eProjectContext.ToListAsync());
        }

        // GET: Admin/TransactionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionDetailId == id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // GET: Admin/TransactionDetails/Create
        public IActionResult Create()
        {
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId");
            return View();
        }

        // POST: Admin/TransactionDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionDetailId,DestinationEmail,TransactionId,Status")] TransactionDetail transactionDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionDetail.TransactionId);
            return View(transactionDetail);
        }

        // GET: Admin/TransactionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionDetail.TransactionId);
            return View(transactionDetail);
        }

        // POST: Admin/TransactionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionDetailId,DestinationEmail,TransactionId,Status")] TransactionDetail transactionDetail)
        {
            if (id != transactionDetail.TransactionDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionDetailExists(transactionDetail.TransactionDetailId))
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
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionDetail.TransactionId);
            return View(transactionDetail);
        }

        // GET: Admin/TransactionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionDetail = await _context.TransactionDetails
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionDetailId == id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            return View(transactionDetail);
        }

        // POST: Admin/TransactionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail != null)
            {
                _context.TransactionDetails.Remove(transactionDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionDetailExists(int id)
        {
            return _context.TransactionDetails.Any(e => e.TransactionDetailId == id);
        }
    }
}
