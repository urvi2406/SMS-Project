using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
