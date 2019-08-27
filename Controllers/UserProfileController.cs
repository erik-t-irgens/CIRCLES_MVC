using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Circles_MVC.Models;

namespace Circles_MVC.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            var allUserprofiles = Userprofile.GetAllUserprofiles();
            return View(allUserprofiles);
        }

        public IActionResult Details(int id)
        {
            var thisUserprofile = Userprofile.GetThisUserprofile(id);
            return View(thisUserprofile);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Edit(int id)
        {
            var thisUserprofile = Userprofile.GetThisUserprofile(id);
            return View(thisUserprofile);
        }

        [HttpPost]
        public IActionResult Edit(int id, Userprofile userprofile)
        {
            Userprofile.EditUserprofile(id, userprofile);
            return RedirectToAction("Index");
        }
    }
}
