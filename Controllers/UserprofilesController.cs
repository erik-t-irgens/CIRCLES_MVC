using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Circles_MVC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Circles_MVC.Controllers
{
    [Authorize]
    public class UserprofilesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserprofilesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var allUserprofiles = Userprofile.GetAllUserprofilesFirst();
            var otherUserprofiles = allUserprofiles.Where(x => x.ApplicationUserId != currentUser.Id);
            return View(otherUserprofiles);
        }

        public async Task<ActionResult> Next()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var allUserprofiles = Userprofile.GetAllUserprofilesNext();
            var otherUserprofiles = allUserprofiles.Where(x => x.ApplicationUserId != currentUser.Id);
            return View("Index", otherUserprofiles);
        }

        public async Task<ActionResult> Prev()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var allUserprofiles = Userprofile.GetAllUserprofilesPrev();
            var otherUserprofiles = allUserprofiles.Where(x => x.ApplicationUserId != currentUser.Id);
            return View("Index", otherUserprofiles);
        }

        public async Task<ActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var allCircles = Circle.GetAllCircles();
            // ViewBag.MyCircles = new SelectList((allCircles.Where(x => x.ApplicationUserId == currentUser.Id)), "CircleId", "Name");
            var thisUserprofile = Userprofile.GetThisUserprofile(id);
            return View(thisUserprofile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var particularUserprofile = Userprofile.GetThisUserprofile(id);
            if (particularUserprofile.ApplicationUserId == currentUser.Id)
            {
                return View(particularUserprofile);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public IActionResult Edit(int id, Userprofile userprofile)
        {
            Userprofile.EditUserprofile(id, userprofile);
            return RedirectToAction("Index");
        }
    }
}
