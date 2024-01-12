using Microsoft.AspNetCore.Mvc;

namespace e_Estoque.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            if (currentUser != null)
            {
                var identity = currentUser.Identities.FirstOrDefault();

                if (identity != null && identity.IsAuthenticated)
                {
                    return View();
                }
            }

            return Redirect("Identity/Account/Login");
        }
    }
}