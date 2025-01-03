using E_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_project.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("send-email")]
        public async Task<IActionResult> SendEmailWithImage()
        {
            return View();
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmailWithImage(EmailRequest request)
        {
            var path = "";
            if (!HttpContext.Session.GetString("canvasImage").IsNullOrEmpty())
            {
                path = HttpContext.Session.GetString("canvasImage");
            }
            try
            {
                await _emailService.SendEmailWithImageAsync(request.ToEmail, request.Subject, request.Body, "wwwroot/images/"+path);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("edit-card")]
        public IActionResult UploadCanvasImage()
        {
            return View();
        }

        
    }
    // Model to hold the image data
    

    public class EmailRequest
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? ImagePath { get; set; }
    }
}

