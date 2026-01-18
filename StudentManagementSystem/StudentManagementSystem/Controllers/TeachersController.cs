using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
