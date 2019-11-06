using Controllers;
using Microsoft.AspNetCore.Mvc;
using Controllers.Exceptions;

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
            try
            {

                return View("_View_Home_Home");
            }
            catch (UserNotLoggedException ex)
            {
                return View(ex.Message);
            }
        }

        public IActionResult QuemSomos()
        {
            return View("_View_Home_QuemSomos");
        }
    }
}