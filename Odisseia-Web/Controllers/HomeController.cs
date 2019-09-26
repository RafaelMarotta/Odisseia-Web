using Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("_View_Home_Index");
        }

        public IActionResult Home()
        {
            if (UserSessionController.GetUser(HttpContext) == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View("_View_Home_Home");
        }

        public IActionResult QuemSomos()
        {
            return View("_View_Home_QuemSomos");
        }
    }
}