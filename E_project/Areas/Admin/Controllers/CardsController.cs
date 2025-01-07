using E_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace E_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CardsController : Controller
    {
        private readonly EProjectContext _context;

        public CardsController(EProjectContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string? search, int? categoryId, int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }
            int pageSize = 8;
            categoryId = categoryId ?? 0;
            var categories = _context.Categories.ToList();
            categories.Insert(0, new Category { CategoryId = 0, CategoryName = "----------Chose Category----------" });
            ViewBag.categoryId = new SelectList(categories, "CategoryId", "CategoryName", categoryId);
            if (categoryId != 0)
            {
                ViewBag.id = categoryId;
                var context = await _context.Cards.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToListAsync();
                if (!string.IsNullOrEmpty(search))
                {
                    context = context.Where(b => b.CardName.ToLower().Contains(search.ToLower())).ToList();
                    ViewBag.search = search;
                }
                var cards = context.ToPagedList(page, pageSize);
                return View(cards);
            }
            else
            {
                var context = await _context.Cards.Include(p => p.Category).ToListAsync();
                if (!string.IsNullOrEmpty(search))
                {
                    context = context.Where(b => b.CardName.ToLower().Contains(search.ToLower())).ToList();
                    ViewBag.search = search;
                }
                var cards = context.ToPagedList(page, pageSize);
                return View(cards);
            }

        }

        // GET: Admin/Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CardId == id);
            card.Image = "/images/card/" + card.Image;
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Admin/Cards/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName");
            ViewBag.status = Status();
            return View();
        }

        // POST: Admin/Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,CardName,Status,Image,CreationDate,Description,CategoryId")] Card card, IFormFile? photo)
        {

            var cards = _context.Cards.ToList();
            if (cards.Any(c => c.CardName.ToLower().Equals(card.CardName.ToLower())))
            {
                ViewBag.errorName = "Card Name is valid";
                ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
                ViewBag.status = Status();
                return View(card);
            }
            if (photo != null && photo.Length >= 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/card/", photo.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                card.Image = photo.FileName;
            }
            else
            {
                ViewBag.errorImage = "Image is required";
                ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
                ViewBag.status = Status();
                return View(card);
            }
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                TempData["message"] = "Card successfully created.";
                TempData["state"] = "Successfully.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
            ViewBag.status = Status();
            return View(card);
        }

        // GET: Admin/Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            ViewBag.status = Status();
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
            return View(card);
        }

        // POST: Admin/Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,CardName,Status,Image,CreationDate,Description,CategoryId")] Card card, IFormFile? photo)
        {
            if (id != card.CardId)
            {
                return NotFound();
            }
            if (_context.Cards.AsNoTracking().FirstOrDefault(c => c.CardName.ToLower().Equals(card.CardName.ToLower()) && c.CardId != card.CardId) != null)
            {
                ViewBag.errorName = "Card Name is valid";
                ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
                ViewBag.status = Status();
                return View(card);
            }
            if (photo != null && photo.Length >= 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/card/", photo.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                card.Image = photo.FileName;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.CardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["message"] = "Card successfully updated.";
                TempData["state"] = "Successfully.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.status = Status();
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.Status == true), "CategoryId", "CategoryName", card.CategoryId);
            return View(card);
        }

        // GET: Admin/Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Admin/Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                card.Status = false;
                _context.Update(card);
            }

            await _context.SaveChangesAsync();
            TempData["message"] = "Card successfully deleted.";
            TempData["state"] = "Successfully.";
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
        private static List<SelectListItem> Status()
        {
            return new List<SelectListItem>
                            {
                            new SelectListItem { Value = "true", Text = "Enable" },
                            new SelectListItem { Value = "false", Text = "Disable"}
                            };
        }
    }
}
