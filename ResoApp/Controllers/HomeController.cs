using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResoApp.Models;
using System.Diagnostics;

namespace ResoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DbResturantContext context;
        public HomeController(ILogger<HomeController> logger,DbResturantContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public IActionResult Index()
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
}