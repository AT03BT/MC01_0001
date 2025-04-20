/*
    Controllers/HomeController.cs
    Version: 1.0.0
    Edited: 2025-04-01
    (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
    https://creativecommons.org/licenses/by/4.0/

    If you like my work, please consider supporting me by checking out my music on YouTube:
    https://youtube.com/shorts/Q921NmrtY9c
    Please leave a good comment and like.
*/

using System.Diagnostics;
using MC01_0001.Models;
using Microsoft.AspNetCore.Mvc;

namespace MC01_0001.Controllers
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
            ViewData["Title"] = "Move Catalogue";
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
