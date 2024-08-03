using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionSystem2.Models;
using System.Diagnostics.Eventing.Reader;

namespace OnlineAdmissionSystem2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup() {
            NewUserViewModel model = new NewUserViewModel();
            return View(model); 
        }

        [HttpPost]
        public IActionResult Signup(NewUserViewModel newUserViewModel)
        {
            ModelState.AddModelError(nameof(newUserViewModel.Email), "Email is already taken.");

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(newUserViewModel);
        }
    }
}
