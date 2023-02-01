using Microsoft.AspNetCore.Mvc;
using Moment2.Models;  //Inkludera Models
using System.Diagnostics;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //Index-view
        {
            ViewData["Title"] = "Startsidan"; //Använder ViewData för att returnera titeln från Controllern
            ViewData["Metod"] = "MVC";
            return View();
        }

        public IActionResult MyPhone() {
            CellphoneModel cp = new CellphoneModel(); //Skapa ny instans av model

            //Ange värden på medlemsvariablerna
            cp.Brand = "Xiaomi";
            cp.Colour = "Svart";
            cp.Price = 1595;

            //Returnera instansen av modellen till vyn
            return View(cp);
        }

        public IActionResult Cellphone() //Cellphone view
        {
            return View();
        }

        public IActionResult About() //About View
        {
            ViewBag.AuthorName = "Marcus Andersson"; //Använd Viewbag för att returnera data till View
            ViewBag.CourseName = "DT191G";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}