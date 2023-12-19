using latihanDotnet8.Context;
using latihanDotnet8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace latihanDotnet8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private dbAplicationContext _dbContext;
        public HomeController(ILogger<HomeController> logger, dbAplicationContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var dtPengguna = _dbContext.Pengguna.Count();
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
