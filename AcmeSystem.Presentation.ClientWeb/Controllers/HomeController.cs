using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using Microsoft.AspNetCore.Mvc;


namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()
        {
            return View();
        }

    }
}
