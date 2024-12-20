using E_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly EProjectContext _context;

        public AccountsController(EProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: Admin/Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Accounts/Create
        public IActionResult Create()
        {
            ViewBag.role = Role();
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,AccountName,Email,Password,Balance,RenewalDate,Role")] Account account)
        {
            if (_context.Accounts.AsNoTracking().FirstOrDefault(a => a.Email.Equals(account.Email)) != null)
            {
                ViewBag.errorEmail = "This email is valid";
                ViewBag.role = Role();
                return View(account);
            }
            if (ModelState.IsValid)
            {
                account.Password = Cipher.GenerateMD5(account.Password);
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.role = Role();
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            var allowEdit = 0;
            if (account.Email.Equals(User.Claims.Skip(1).FirstOrDefault().Value))
            {
                allowEdit = 1;
            }
            ViewBag.allowEdit = allowEdit;
            ViewBag.role = Role();
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,AccountName,Email,Password,Balance,RenewalDate,Role")] Account account, byte? allowEdit)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }
            if (_context.Accounts.AsNoTracking().FirstOrDefault(a => a.Email.Equals(account.Email) && a.AccountId != account.AccountId) != null)
            {
                ViewBag.errorEmail = "This email is valid";
                ViewBag.allowEdit = allowEdit;
                ViewBag.role = Role();
                return View(account);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (allowEdit == 1)
                    {
                        account.Password = Cipher.GenerateMD5(account.Password);
                    }
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
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
            ViewBag.allowEdit = allowEdit;
            ViewBag.role = Role();
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
        private static List<SelectListItem> Role()
        {
            return new List<SelectListItem>
                            {
                            new SelectListItem { Value = "Admin", Text = "Admin" },
                            new SelectListItem { Value = "User", Text = "User"}
                            };
        }
    }
}
