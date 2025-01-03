﻿using E_project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly EProjectContext _context;

        public HomeController(EProjectContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("search")]
        public IActionResult Search(string search, string path)
        {
            /* if (path.ToLower().Contains("order/details"))
             {
                 return Redirect("/admin/orders" + "?name=" + search);
             }*/
            return Redirect(path + "?search=" + search);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.error = "<div class='alert alert-danger'>Email or password is blank</div>";
                return View();
            }
            string passmd5 = Cipher.GenerateMD5(password);
            var acc = _context.Accounts.SingleOrDefault(x => x.Email == email && x.Password == passmd5);
            if (acc == null)
            {
                ViewBag.error = "<div class='alert alert-danger'>Wrong</div>";
                ViewBag.Email = email;
                return View();
            }
            else if (!acc.Role.Equals("Admin"))
            {
                ViewBag.error = "<div class='alert alert-danger'>Not admin</div>";
                ViewBag.Email = email;
                return View();
            }
            else
            {
                var identity = new ClaimsIdentity(
                    new[] {
                        new Claim("AccountId", acc.AccountId.ToString()),
                        new Claim("AccountName", acc.AccountName),
                        new Claim("Email", acc.Email?.ToString() ?? ""),
                        new Claim("Image", acc.Image ?? "Image"),
                    }, "EProjectSecurityScheme");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync("EProjectSecurityScheme", principal);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("EProjectSecurityScheme");
            return RedirectToAction("Index");
        }
    }
}
