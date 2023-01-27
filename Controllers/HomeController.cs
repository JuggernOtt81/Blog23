using Blog23.Models;
using Blog23.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Blog23.Services.Interfaces;
using Blog23.Services;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace Blog23.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactAsync(ContactMe model)
        {
            if (ModelState.IsValid)
            {
                model.Message = $"{model.Message} <hr/> Phone: {model.Phone}";
                await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
                
            }
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
