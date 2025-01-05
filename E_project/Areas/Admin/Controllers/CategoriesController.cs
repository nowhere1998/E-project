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
    public class CategoriesController : Controller
    {
        private readonly EProjectContext _context;

        public CategoriesController(EProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index(string? search, int page = 1)
        {
            int pageSize = 10;
            var results = await _context.Categories.ToListAsync();
            if (page < 1)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(search))
            {
                results = results.Where(c => c.CategoryName.ToLower().Contains(search.ToLower())).ToList();
            }
            var categories = results.ToPagedList(page, pageSize);
            ViewBag.search = search;
            return View(categories);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            ViewBag.parentCategories = ParentCategories();
            ViewBag.status = Status();
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Status,ParentCategory")] Category category)
        {
            ViewBag.parentCategories = ParentCategories();
            ViewBag.status = Status();
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.parentCategories = ParentCategories();
            ViewBag.status = Status();
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CreationDate,Status,ParentCategory")] Category category)
        {
            ViewBag.parentCategories = ParentCategories();
            ViewBag.status = Status();
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.Include(c => c.Cards)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            if (category.Cards.Any())
            {
                ViewBag.error = "This category has cards, you cannot delete it.";
                return View(category);
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

        private static List<SelectListItem> ParentCategories()
        {
            return new List<SelectListItem>
                            {
                            new SelectListItem { Value = "Celebration", Text = "Celebration" },
                            new SelectListItem { Value = "Festivals", Text = "Festivals"},
                            new SelectListItem { Value = "Glimpses of VietName", Text = "Glimpses of VietName"},
                            new SelectListItem { Value = "Heritage", Text = "Heritage"},
                            new SelectListItem { Value = "Ministry", Text = "Ministry"},
                            new SelectListItem { Value = "MISCELLANEOUS", Text = "MISCELLANEOUS"}
                            };
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
