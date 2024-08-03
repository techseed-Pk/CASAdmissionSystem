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
            return View(); 
        }
    }
}
