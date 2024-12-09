using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiplicationApp.Models;

namespace MultiplicationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new MultiplicationModel());
        }
        [HttpPost]
        public ActionResult Index(MultiplicationModel model)
        {
            if (model.Number > 0)
            {
                // Generate multiplication table for the chosen number
                model.Results = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    model.Results.Add(model.Number * i);
                }
            }
            return View(model);
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


