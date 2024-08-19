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

        public IActionResult TestCertificate()
        {
            // add a certificate to a user
            var user = _admissionDbContext
                .Users
                .Include(user => user.Certificates)
                .FirstOrDefault();

            var certificate = new Certificate()
            {
                Name = "C# Course",
                Issuer = "CAS",
            };

            user.Certificates.Add(certificate);

            _admissionDbContext.SaveChanges();

            return Redirect("/Home");

        }

        public IActionResult Profile(int Id, string type = "")
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
                var destinationFolder = Path.Combine(_webHostEnvironment.WebRootPath, "myfiles");

                Directory.CreateDirectory(destinationFolder);

                //save the file to somewhere
                var filePath = Path.Combine(destinationFolder, model.PhotoFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
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
