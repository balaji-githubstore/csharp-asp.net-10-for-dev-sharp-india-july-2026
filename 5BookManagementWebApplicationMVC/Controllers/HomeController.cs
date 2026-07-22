using Microsoft.AspNetCore.Mvc;

namespace BookManagementWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //works with model (create object for model class)
            return View();
        }

        public string Error()
        {
            return "Error action from home controller";
        }
    }
}