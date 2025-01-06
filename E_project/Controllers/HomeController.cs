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
                .Where(c => c.Status == true)
                .Skip(0)
                .Take(4)
                .ToList();
            ViewBag.Categories = _context.Categories.OrderByDescending(c=>c.CategoryId).Where(c => c.Status == true).ToList();
            return View();
        }

        public IActionResult Login()
        {
            if (TempData["Path"] != null)
            {
                ViewBag.Path = TempData["Path"];
            }
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email = "", string password = "", string path = "")
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            string passmd5 = "";
            passmd5 = Cipher.GenerateMD5(password);
            var acc = _context.Accounts.SingleOrDefault(x => x.Email == email && x.Password == passmd5 && x.Role != "Disable");
            if (acc != null)
            {
                HttpContext.Session.SetString("accountName", acc.AccountName);
                HttpContext.Session.SetString("accountId", acc.AccountId.ToString());
                if (!path.IsNullOrEmpty())
                {
                    return Redirect(path);
                }
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
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(IFormCollection form, [Bind("AccountName, Email, Password")]Account account, string confirmPassword = "")
        {
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
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
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
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
            if(_context.Categories != null)
            {
                foreach(var c in _context.Categories.Where(c => c.Status == true))
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
                ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            }
            else
            {
                ViewBag.CategoryName = "";
                ViewBag.Categories = new List<Category>();
            }
            ViewBag.ParentCategory = parentCategory;
            int pagesize = 8;
            page = page < 1 ? 1 : page;
            if (categoryId == 0)
            {
                var cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Status == true)
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
                .Where(c => c.Status == true)
                .Where(c => c.Category.ParentCategory.ToLower().Equals(parentCategory.ToLower()))
                .Where(c => c.CardName.ToLower().Contains(cardName.ToLower()) && c.CategoryId == categoryId)
                .ToPagedList(page, pagesize);
                ViewData["name"] = cardName;
                ViewData["categoryId"] = categoryId;
                return View(cards);
            }
        }

        public IActionResult Search(int page = 1, string parentCategory = "", string cardName = "")
        { 
            if(_context.Categories != null)
            {
                ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            }
            else
            {
                ViewBag.CategoryName = "";
                ViewBag.Categories = new List<Category>();
            }
            ViewBag.ParentCategory = parentCategory;
            int pagesize = 8;
            page = page < 1 ? 1 : page;
            var cards = _context.Cards.Include(c => c.Category)
                .ToPagedList(page, pagesize);
            ViewData["cardName"] = cardName;
            ViewData["parentCategory"] = parentCategory;

            if (parentCategory.Equals("") && !cardName.Equals(""))
            {
                cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Status == true)
                .Where(c => c.CardName.ToLower().Contains(cardName.ToLower()))
                .ToPagedList(page, pagesize);
            }

            if (parentCategory.Equals("") && cardName.Equals(""))
            {
                cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Status == true)
                .ToPagedList(page, pagesize);
            }

            if (!parentCategory.Equals("") && !cardName.Equals(""))
            {
                cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Status == true)
                .Where(c => c.Category.ParentCategory.ToLower().Contains(parentCategory.ToLower()))
                .Where(c => c.CardName.ToLower().Contains(cardName.ToLower()))
                .ToPagedList(page, pagesize);
            }

            if (!parentCategory.Equals("") && cardName.Equals(""))
            {
                cards = _context.Cards.Include(c => c.Category)
                .OrderByDescending(c => c.CardId)
                .Where(c => c.Status == true)
                .Where(c => c.Category.ParentCategory.ToLower().Contains(parentCategory.ToLower()))
                .ToPagedList(page, pagesize);
            }
            return View(cards);
        }

        [Route("/home/sendcard/{id}")]
        public IActionResult SendCard(int id = 0, string editCard = "", string path = "")
        {
            if (!checkLogin())
            {
                TempData["LoginRequire"] = "Please login first!";
                TempData["Path"] = path;
                return RedirectToAction("Login");
            }
            if (editCard.Equals(""))
            {
                HttpContext.Session.Remove("ImageEditCard");
            }
            ViewBag.Categories = _context.Categories.OrderByDescending(c => c.CategoryId).Where(c => c.Status == true).ToList();
            var card = _context.Cards.Where(c => c.CardId == id).SingleOrDefault();
            if (card == null)
            {
                return RedirectToAction("Index");
            }
            return View(card);
        }

        [Route("/home/sendcard/{id}")]
        [HttpPost]
        public async Task<IActionResult> SendCard(string[] email, string title = "", string image = "", string message = "", int id = 0)
        {
            var card = _context.Cards.Where(c => c.CardId == id).Where(c => c.Status == true).SingleOrDefault();
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
                Transaction transaction = new Transaction();
                transaction.Image = image;
                transaction.Success = 1;
                transaction.CardId = id;
                transaction.AccountId = int.Parse(HttpContext.Session.GetString("accountId")); 
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                Transaction newTransaction = _context.Transactions.OrderByDescending(t=>t.TransactionId).FirstOrDefault();
                foreach(var e in email)
                {
                    await _emailService.SendEmailWithImageAsync(e, title, message, "wwwroot/images/card/" + image);
                    TransactionDetail transactionDetail = new TransactionDetail();
                    transactionDetail.DestinationEmail = e;
                    transactionDetail.Status = true;
                    transactionDetail.TransactionId = newTransaction.TransactionId;
                    _context.Add(transactionDetail);
                    await _context.SaveChangesAsync();
                }
                TempData["Success"] = "Send card success!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [Route("/home/edit-card/{id}")]
        public IActionResult EditCard(int id = 0, string path = "")
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            if (!checkLogin())
            {
                TempData["LoginRequire"] = "Please login first!";
                TempData["Path"] = path;
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

        public IActionResult Contact(string path = "")
        {
            if (!checkLogin())
            {
                TempData["LoginRequire"] = "Please login first!";
                TempData["Path"] = path;
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContact(string content = "")
        {
            if (content.Equals(""))
            {
                return RedirectToAction("Contact");
            }
            Feedback feedback = new Feedback();
            feedback.Content = content;
            feedback.AccountId = int.Parse(HttpContext.Session.GetString("accountId"));
            _context.Add(feedback);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Send feedback success!";
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
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
