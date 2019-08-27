// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Circles_MVC.Models;
// using System.Threading.Tasks;
// using Circles_MVC.ViewModels;
// using System.Collections.Generic;
// using System.Linq;

// namespace Circles_API.Controllers
// {
//     public class ApplicationUserController : Controller
//     {
//         public ActionResult Login()
//         {
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Register(ApplicationUser applicationuser)
//         {
//             ApplicationUser.Register(applicationuser);
//             return RedirectToAction("Index", "Home");
//         }

//         [HttpPost]
//         public async Task<ActionResult> Register(RegisterViewModel model)
//         {
//             var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
//             if (model.Password == model.ConfirmPassword)
//             {
//                 IdentityResult result = await _userManager.CreateAsync(user, model.Password);
//                 if (result.Succeeded)
//                 {
//                     return RedirectToAction("Index");
//                 }
//                 else
//                 {
//                     return View();
//                 }
//             }
//             else
//             {
//                 ViewBag.PasswordNotMatch = "Your passwords didn't match! Try again!";
//                 return View();
//             }
//         }

//         public ActionResult Login()
//         {
//             return View();
//         }
//         [HttpPost]
//         public async Task<ActionResult> Login(LoginViewModel model)
//         {
//             Microsoft.AspNetCore.Identity.SignInResult result = await
//             _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
//             if (result.Succeeded)
//             {
//                 return RedirectToAction("Index");
//             }
//             else
//             {
//                 return View();
//             }
//         }

//         [HttpPost]
//         public async Task<ActionResult> LogOff()
//         {
//             await _signInManager.SignOutAsync();
//             return RedirectToAction("Index");
//         }
//     }
// }