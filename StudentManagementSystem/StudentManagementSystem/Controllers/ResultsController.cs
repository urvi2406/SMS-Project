using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
