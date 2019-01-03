using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelloAzure.Models;
using Microsoft.Extensions.Configuration;

namespace HelloAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string model = _configuration["Greeting"];
            return View("Index", model);
        }

        /// <exception cref="InvalidOperationException">Sorry, this feature is not supported!</exception>
        public IActionResult TestException()
        {
            throw new InvalidOperationException("Sorry, this feature is not supported!");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
