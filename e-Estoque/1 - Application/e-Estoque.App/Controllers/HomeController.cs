using Microsoft.AspNetCore.Mvc;

namespace e_Estoque.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
