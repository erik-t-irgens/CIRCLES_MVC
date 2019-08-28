using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Circles_MVC.Models;

namespace Circles_MVC.Controllers
{
    public class CirclesController : Controller
    {

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            var allCircles = Circle.GetAllCircles();
            return View(allCircles);
        }

        // public IActionResult IndexNext()
        // {
        //     var nextDestinations = Destination.GetNextDestinations();
        //     return View("Index", nextDestinations);
        // }

        // public IActionResult IndexPrev()
        // {
        //     var prevDestinations = Destination.GetPrevDestinations();
        //     return View("Index", prevDestinations);
        // }

        public IActionResult Details(int id)
        {
            var thisCircle = Circle.GetThisCircle(id);
            return View(thisCircle);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Circle circle)
        {
            Circle.CreateCircle(circle);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Circle.DeleteCircle(id);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var particularCircle = Circle.GetThisCircle(id);
            return View(particularCircle);
        }

        [HttpPost]
        public IActionResult Edit(int id, Circle circle)
        {
            Circle.EditCircle(id, circle);
            return RedirectToAction("Index");
        }
    }
}
