using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Circles_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Circles_MVC.Controllers
{
    [Authorize]
    public class CirclesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CirclesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var allCircles = Circle.GetAllCircles();
            var yourCircles = allCircles.Where(x => x.ApplicationUserId == currentUser.Id);
            return View(yourCircles);
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

        public async Task<ActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var particularCircle = Circle.GetThisCircle(id);
            if (particularCircle.ApplicationUserId == currentUser.Id)
            {
                return View(particularCircle);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Circle circle)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            circle.ApplicationUserId = currentUser.Id;
            Circle.CreateCircle(circle);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Circle.DeleteCircle(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var particularCircle = Circle.GetThisCircle(id);
            if (particularCircle.ApplicationUserId == currentUser.Id)
            {
                return View(particularCircle);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult RemoveUser(int joinId, int circleId)
        {
            Console.WriteLine("REMOVE USER: " + joinId + " is id and cI: " + circleId);
            Circle.RemoveUser(joinId);
            return RedirectToAction("Details", "Circles", new { id = circleId });
        }

        [HttpPost]
        public IActionResult Edit(int id, Circle circle)
        {
            Circle.EditCircle(id, circle);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
