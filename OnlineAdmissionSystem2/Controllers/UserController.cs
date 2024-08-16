using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionSystem2.Data;
using OnlineAdmissionSystem2.Data.Entities;
using OnlineAdmissionSystem2.Models;
using System.Diagnostics.Eventing.Reader;

namespace OnlineAdmissionSystem2.Controllers
{
    public class UserController : Controller
    {
        private readonly AdmissionDbContext _admissionDbContext;

        public UserController(AdmissionDbContext admissionDbContext)
        {
            _admissionDbContext = admissionDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup() {
            SignupViewModel model = new SignupViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user;

                user = _admissionDbContext.Users.FirstOrDefault(x => x.Email == model.Email);

                if (user == null)
                {
                    user = new User();
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.Password = model.Password;

                    _admissionDbContext.Add(user);
                    _admissionDbContext.SaveChanges();
                }

                return Content("Your data is valid");
            }

            return View(model);
        }
    }
}
