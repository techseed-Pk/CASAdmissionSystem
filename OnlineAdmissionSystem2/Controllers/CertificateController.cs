using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionSystem2.Data;
using OnlineAdmissionSystem2.Data.Entities;

namespace OnlineAdmissionSystem2.Controllers
{
    public class CertificateController : Controller
    {
        private readonly AdmissionDbContext _admissionDbContext;

        public CertificateController(AdmissionDbContext admissionDbContext)
        {
            _admissionDbContext = admissionDbContext;
        }
        public IActionResult Index(int Id) // Example URL: /Certificate/Index/1
        {

            var certificates = _admissionDbContext
                    .Users
                    .Include(x => x.Certificates) // use the Include method to specify related data to be included in query results
                    .FirstOrDefault(x => x.Id == Id)
                    .Certificates
                    .ToList();

            return View(certificates); // using List<Certificate> as a ViewModel for testing instead of creating a seperate view model which we always prefer
        }

        public IActionResult CreateTestCertificate()
        {
            // create a new certificate for first user in database

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
    }
}
