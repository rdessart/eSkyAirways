using eSkyAirlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AirlineData.Repository;
using AirlineData.Models;

namespace eSkyAirlines.Controllers
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
            return View();
        }
        [Route("/Fleet/{id?}")]
        [Route("Home/Fleet/{id?}")]
        public IActionResult Fleet(string id = null)
        {
            AircraftRepository acRep = new AircraftRepository();
            if (id is null)
            {
                return View(model:acRep.GetAll());
            }
            Aircraft ac = acRep.GetOneByRegistration(id);
            if(ac is null)
            {
                throw new Exception("No aircrafts matched registrations");
            }
            return View("AircraftDetails", model: ac);
        }
        public IActionResult Route()
        {
            return View();
        }
        public IActionResult Statistics()
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
