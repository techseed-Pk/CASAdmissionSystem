using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionSystem2.Data;
using OnlineAdmissionSystem2.Data.Entities;
using OnlineAdmissionSystem2.Models;
using System.Diagnostics.Eventing.Reader;

namespace OnlineAdmissionSystem2.Controllers
{
    public class UserController : Controller
    {
        private readonly AdmissionDbContext _admissionDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(AdmissionDbContext admissionDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _admissionDbContext = admissionDbContext;
            _webHostEnvironment = webHostEnvironment;
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
                //save the file to a destination

                var destinationFolder = Path.Combine(_webHostEnvironment.WebRootPath, "myfiles");

                // make sure directory exists or otherwise create it
                Directory.CreateDirectory(destinationFolder);

                var newFilePath = Path.Combine(destinationFolder, model.PhotoFile.FileName);

                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    model.PhotoFile.CopyTo(stream);
                }

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

                return RedirectToAction("Profile", new { Id = user.Id });
            }

            return View(model);
        }
    }
}
