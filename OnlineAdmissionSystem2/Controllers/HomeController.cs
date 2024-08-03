using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineAdmissionSystem2.Data;
using OnlineAdmissionSystem2.Mappings;
using OnlineAdmissionSystem2.Models;
using System.Diagnostics;

namespace OnlineAdmissionSystem2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly AdmissionDbContext _admissionDbContext;

        public HomeController(ILogger<HomeController> logger, IMapper mapper,
            AdmissionDbContext admissionDbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _admissionDbContext = admissionDbContext;
        }

        public IActionResult Index()
        {
            // create a new student
            UserDataModel student = new UserDataModel();
            student.Name = "test";
            student.Email = "test@test.com";

            _admissionDbContext.Users.Add(student);
            _admissionDbContext.SaveChanges();

            

            var theStudent = _admissionDbContext.Users.FirstOrDefault();

            var a = _mapper.Map<NewUserViewModel>(theStudent);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
