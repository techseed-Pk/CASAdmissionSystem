using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAdmissionSystem2.Data;

namespace OnlineAdmissionSystem2.Controllers
{
    public class CertificateController : Controller
    {
        private readonly AdmissionDbContext _admissionDbContext;

        public CertificateController(AdmissionDbContext admissionDbContext)
        {
            _admissionDbContext = admissionDbContext;
        }
        public IActionResult Index(int Id)
        {

            var certificates = _admissionDbContext
                    .Users
                    .Include(x => x.Certificates)
                    .FirstOrDefault(x => x.Id == Id)
                    .Certificates
                    .ToList();

            return View(certificates);
        }
    }
}
