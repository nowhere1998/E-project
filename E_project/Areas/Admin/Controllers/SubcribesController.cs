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
    public class SubcribesController : Controller
    {
        private readonly EProjectContext _context;

        public SubcribesController(EProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Subcribes
        public async Task<IActionResult> Index()
        {
            var eProjectContext = _context.Subcribes.Include(s => s.Account);
            return View(await eProjectContext.ToListAsync());
        }

        // GET: Admin/Subcribes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcribe = await _context.Subcribes
                .Include(s => s.Account)
                .FirstOrDefaultAsync(m => m.SubcribeId == id);
            if (subcribe == null)
            {
                return NotFound();
            }

            return View(subcribe);
        }

        // GET: Admin/Subcribes/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountName");
            return View();
        }

        // POST: Admin/Subcribes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcribeId,Email,Content,AccountId")] Subcribe subcribe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcribe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountName", subcribe.AccountId);
            return View(subcribe);
        }

        // GET: Admin/Subcribes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcribe = await _context.Subcribes.FindAsync(id);
            if (subcribe == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountName", subcribe.AccountId);
            return View(subcribe);
        }

        // POST: Admin/Subcribes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcribeId,Email,Content,AccountId")] Subcribe subcribe)
        {
            if (id != subcribe.SubcribeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcribe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcribeExists(subcribe.SubcribeId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountName", subcribe.AccountId);
            return View(subcribe);
        }

        // GET: Admin/Subcribes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcribe = await _context.Subcribes
                .Include(s => s.Account)
                .FirstOrDefaultAsync(m => m.SubcribeId == id);
            if (subcribe == null)
            {
                return NotFound();
            }

            return View(subcribe);
        }

        // POST: Admin/Subcribes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcribe = await _context.Subcribes.FindAsync(id);
            if (subcribe != null)
            {
                _context.Subcribes.Remove(subcribe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcribeExists(int id)
        {
            return _context.Subcribes.Any(e => e.SubcribeId == id);
        }
    }
}
