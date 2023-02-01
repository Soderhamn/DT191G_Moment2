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

            if(HttpContext.Request.Cookies.ContainsKey("PhoneName")) //Om kakan PhoneName finns
            {
                string? pn = HttpContext.Request.Cookies["PhoneName"]; //Läs in namnet från Cookie
                ViewData["SavedPhone"] = pn; //Lagra i ViewData["SavedPhone"]
            }

            ViewData["Title"] = "Startsidan"; //Använder ViewData för att returnera titeln från Controllern
            ViewData["Metod"] = "MVC";
            return View();
        }

        public IActionResult MyPhone() {

            if(HttpContext.Request.Cookies.ContainsKey("PhoneName")) //Om kakan PhoneName finns
            {
                string? pn = HttpContext.Request.Cookies["PhoneName"]; //Läs in namnet från Cookie
                ViewData["SavedPhone"] = pn; //Lagra i ViewData["SavedPhone"]
            }

            CellphoneModel cp = new CellphoneModel(); //Skapa ny instans av model

            //Ange värden på medlemsvariablerna
            cp.Brand = "Xiaomi";
            cp.Colour = "Svart";
            cp.Price = 1595;

            //Returnera instansen av modellen till vyn
            return View(cp);
        }
        [HttpPost] //Vid postning
        public IActionResult Cellphone(CellphoneModel cp) {


            ViewBag.CellphoneInfo = cp.Brand + " " + cp.Colour + " " + cp.Price + ":-";

            //Spara telefonens namn i en Cookie
            HttpContext.Response.Cookies.Append("PhoneName", cp.Brand + "");

            ViewData["SavedPhone"] = cp.Brand; //Lagra i ViewData["SavedPhone"]
            

            return View();
        }

        [HttpGet] //Visa 
        public IActionResult Cellphone() //Cellphone view
        {
            
            if(HttpContext.Request.Cookies.ContainsKey("PhoneName")) //Om kakan PhoneName finns
            {
                string? pn = HttpContext.Request.Cookies["PhoneName"]; //Läs in namnet från Cookie
                ViewData["SavedPhone"] = pn; //Lagra i ViewData["SavedPhone"]
            }

            return View();
        }

        public IActionResult About() //About View
        {
            if(HttpContext.Request.Cookies.ContainsKey("PhoneName")) //Om kakan PhoneName finns
            {
                string? pn = HttpContext.Request.Cookies["PhoneName"]; //Läs in namnet från Cookie
                ViewData["SavedPhone"] = pn; //Lagra i ViewData["SavedPhone"]
            }

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