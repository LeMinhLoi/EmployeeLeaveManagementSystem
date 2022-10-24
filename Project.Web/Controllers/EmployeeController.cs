using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
