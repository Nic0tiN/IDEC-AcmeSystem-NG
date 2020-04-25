using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using Microsoft.AspNetCore.Mvc;


namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        IService<Contact> _contactServices;

        public HomeController(IService<Contact> contactServices)
        {
            _contactServices = contactServices;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
