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
            var myCircles = Circle.GetAllCircles().Where(x => x.ApplicationUserId == currentUser.Id);
            ViewBag.CircleId = new SelectList(myCircles, "CircleId", "Name");
            var thisUserprofile = Userprofile.GetThisUserprofile(id);
            return View(thisUserprofile);
        }

        [HttpPost]
        public ActionResult Details(int circleId, int userprofileId)
        {
            Circle.AddUser(circleId, userprofileId);
            return RedirectToAction("Details", "Userprofiles", new { id = userprofileId });
        }

        public async Task<ActionResult> Edit()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var myUserprofile = Userprofile.GetAllUserprofiles().FirstOrDefault(x => x.ApplicationUserId == currentUser.Id);
            if (myUserprofile.ApplicationUserId == currentUser.Id)
            {
                return View(myUserprofile);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public IActionResult Edit(Userprofile userprofile)
        {
            Userprofile.EditUserprofile(userprofile.UserprofileId, userprofile);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
