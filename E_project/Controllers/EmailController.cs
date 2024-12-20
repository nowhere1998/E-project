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
                var filePath = Path.Combine("wwwroot/images/", fileName);

                System.IO.File.WriteAllBytes(filePath, imageBytes);

                HttpContext.Session.SetString("canvasImage", fileName);

                // Return success response with the file name or path
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            return RedirectToAction("Index", "Home");
        }
    }
    // Model to hold the image data
    public class CanvasImageModel
    {
        public string ImageData { get; set; }
    }

    public class EmailRequest
    {
        public string? ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? ImagePath { get; set; }
    }
}

