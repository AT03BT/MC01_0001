// Controllers/IntroductionController.cs
// Version: 1.0.0
// (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
// https://creativecommons.org/licenses/by/4.0/

using System.Diagnostics;
using System.Text.Encodings.Web;
using MC01_0001.Models;
using Microsoft.AspNetCore.Mvc;

namespace MC01_0001.Controllers
{
    public class IntroductionController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IntroductionController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            return "This is my default action...";
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
