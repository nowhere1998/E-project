using Microsoft.AspNetCore.Mvc;

namespace E_project.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
