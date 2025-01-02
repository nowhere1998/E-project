using Azure;
using E_project.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using System.IO;
using X.PagedList.Extensions;

namespace E_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EProjectContext _context;
        private readonly EmailService _emailService;

        public HomeController(ILogger<HomeController> logger, EProjectContext context, EmailService emailService)
        {
            _logger = logger;
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            ViewBag.NewCards = _context.Cards
                .OrderByDescending(c => c.CardId)
                .Skip(0)
                .Take(4)
                .ToList();
            ViewBag.Categories = _context.Categories.OrderByDescending(c=>c.CategoryId).ToList();
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email = "", string password = "")
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            string passmd5 = "";
            passmd5 = Cipher.GenerateMD5(password);
            var acc = _context.Accounts.SingleOrDefault(x => x.Email == email && x.Password == passmd5);
            if (acc != null)
            {
                HttpContext.Session.SetString("accountName", acc.AccountName);
                HttpContext.Session.SetString("accountId", acc.AccountId.ToString());
                return RedirectToAction("Index");
            }
            ViewBag.error = "<p class='alert alert-danger text-center'>Email or password is incorrect!</p>";
            ViewBag.Email = email;
            ViewBag.Password = password;
            return View();
        }

        public bool checkLogin()
        {
            bool check = true;
            if (HttpContext.Session.GetString("accountName") == null)
            {
                check = false;
            }
            return check;
        }

        public IActionResult Register()
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(IFormCollection form, [Bind("AccountName, Email, Password")]Account account, string confirmPassword = "")
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            bool check = true;
            if (_context.Accounts.Any(x => x.Email == account.Email))
            {
                ViewBag.Email = "Email is already exist!";
                check = false;
            }
            if (confirmPassword.Equals(account.Password))
            {
                account.Password = Cipher.GenerateMD5(account.Password);
            }
            else
            {
                ViewBag.ErrorConfirmPassword = "Confirm password does not match!";
                check = false ;
            }
            if(form["terms"] != "on")
            {
                check = false ;
                ViewBag.Terms = "Please accept terms and condition!" ;
            }
            if(!check)
            {
                return View(account);
            }
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return Redirect("/home/login");
            }
            return View(account);
        }

        public IActionResult Terms()
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [Route("/home/cards/{parentCategory}")]
        public IActionResult Cards(int page = 1, int categoryId = 0, string parentCategory = "", string cardName = "")
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).ToList();
            if(_context.Categories != null)
            {
                foreach(var c in _context.Categories)
                {
                    if(c.CategoryId == categoryId)
                    {
                        ViewBag.CategoryName = c.CategoryName;
                        break;
                    }
                    else
                    {
                        ViewBag.CategoryName = parentCategory;
                    }
                }
            }
            else
            {
                ViewBag.CategoryName = "";
            }
            ViewBag.ParentCategory = parentCategory;
            int pagesize = 8;
            page = page < 1 ? 1 : page;
            if (categoryId == 0)
            {
                var cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Category.ParentCategory.ToLower().Equals(parentCategory.ToLower()))
                .Where(c => c.CardName.ToLower().Contains(cardName.ToLower())) 
                .ToPagedList(page, pagesize);
                ViewData["name"] = cardName;
                ViewData["categoryId"] = categoryId;
                return View(cards);
            }
            else
            {
                var cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Category.ParentCategory.ToLower().Equals(parentCategory.ToLower()))
                .Where(c => c.CardName.ToLower().Contains(cardName.ToLower()) && c.CategoryId == categoryId)
                .ToPagedList(page, pagesize);
                ViewData["name"] = cardName;
                ViewData["categoryId"] = categoryId;
                return View(cards);
            }
        }

        [Route("/home/sendcard/{id}")]
        public IActionResult SendCard(int id = 0, string editCard = "")
        {
            if (!checkLogin())
            {
                TempData["LoginRequire"] = "Please login first!";
                return RedirectToAction("Login");
            }
            if (editCard.Equals(""))
            {
                HttpContext.Session.Remove("ImageEditCard");
            }
            var card = _context.Cards.Where(c => c.CardId == id).SingleOrDefault();
            if (card == null)
            {
                return RedirectToAction("Index");
            }
            return View(card);
        }

        [Route("/home/sendcard/{id}")]
        [HttpPost]
        public async Task<IActionResult> SendCard(string email = "", string title = "", string image = "", string message = "", int id = 0)
        {
            var card = _context.Cards.Where(c => c.CardId == id).SingleOrDefault();
            if (card == null)
            {
                return RedirectToAction("Index");
            }
            bool check = true;
            if (email.IsNullOrEmpty())
            {
                ViewBag.ErrorEmail = "Email can not null!";
                check = false;
            }
            if (title.IsNullOrEmpty())
            {
                ViewBag.ErrorTitle = "Title can not null!";
                check = false;
            }
            if (message.IsNullOrEmpty())
            {
                ViewBag.ErrorMessage = "Message can not null!";
                check = false;
            }
            if (image.IsNullOrEmpty())
            {
                ViewBag.ErrorImage = "Image can not null!";
                check = false;
            }
            if (!check)
            {
                return View(card);
            }
            try
            {
                await _emailService.SendEmailWithImageAsync(email, title, message, "wwwroot/images/card/" + image);
                TempData["sendCardSuccess"] = "Send card success!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [Route("/home/edit-card/{id}")]
        public IActionResult EditCard(int id)
        {
            if (!checkLogin())
            {
                TempData["LoginRequire"] = "Please login first!";
                return RedirectToAction("Login");
            }
            var card = _context.Cards.Where(c => c.CardId == id).SingleOrDefault();
            ViewBag.Image = card.Image;
            ViewBag.Id = id;
            return View();
        }

        [HttpPost("UploadCanvasImage")]
        public IActionResult UploadCanvasImage([FromBody] CanvasImageModel model)
        {
            try
            {
                if (model?.ImageData == null)
                {
                    return BadRequest("No image data received.");
                }

                // Remove the Base64 header (e.g., "data:image/png;base64,")
                var base64Data = model.ImageData.Split(',')[1];

                // Convert Base64 to byte array
                var imageBytes = Convert.FromBase64String(base64Data);

                // Save the image to a file (e.g., wwwroot/images folder)
                var fileName = $"canvas_image_{Guid.NewGuid()}.png";
                var filePath = Path.Combine("wwwroot/images/card/", fileName);

                System.IO.File.WriteAllBytes(filePath, imageBytes);

                HttpContext.Session.SetString("ImageEditCard", fileName);
                var result = new { success = true, message = "Request processed successfully" };
                // Return success response with the file name or path
                return Json(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class CanvasImageModel
    {
        public string ImageData { get; set; }
    }
}
