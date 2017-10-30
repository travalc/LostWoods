using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostWoods.Models;
using LostWoods.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LostWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(TrailFactory connectTrail) {
            trailFactory = connectTrail;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.GetAllTrails();
            return View();
        }

        [HttpGet]
        [Route("NewTrail")]

        public IActionResult NewTrail()
        {
            Trail trail = new Trail();
            ViewBag.trail = trail;
            return View();
        }

        [HttpGet]
        [Route("Trails/{id}")]

        public IActionResult Trails(int id)
        {
            Trail trail = trailFactory.FindById(id);
            ViewBag.trail = trail;
            return View();
        }

        [HttpPost]
        [Route("Trail")]

        public IActionResult Trail(Trail model)
        {
            if (ModelState.IsValid)
            {
                trailFactory.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

    }
}
