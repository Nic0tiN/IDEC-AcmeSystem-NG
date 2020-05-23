using System;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;
using AcmeSystem.Presentation.ClientWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class CompteController : Controller
    {
        private IService<Compte> _compteService;
        public int PageSize = 4;

        public CompteController(IService<Compte> compteService)
        {
            _compteService = compteService;
        }

        public ViewResult Index(int page = 1) => View(new ListViewModel<Compte>
        {
            Items = _compteService.GetAll()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = _compteService.GetAll().Count
            }
        });

        [HttpGet]
        public ViewResult Create()
            => View(new CreateViewModel<Compte>
            {
                Entity = new Compte()
            });
        [HttpGet]
        public ViewResult View(int id)
            => View(new CreateViewModel<Compte>()
            {
                Entity = _compteService.GetId(id)
            });

        [HttpGet]
        public ViewResult Update(int id)
        => View("Create", new CreateViewModel<Compte>()
            {
                Entity = _compteService.GetId(id)
            });
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Compte compte)
        {
            try
            {
                _compteService.Save(compte);
                FlashMessage.Success("Compte enregistré avec succès.");

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                FlashMessage.Error(e.Message);
            }
            
            return View("Create", new CreateViewModel<Compte>() { Entity = compte });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _compteService.Delete(_compteService.GetId(id));
                FlashMessage.Success("Contact supprimé avec succès.");
            }
            catch (Exception e)
            {
                FlashMessage.Error(e.Message);
            }

            return RedirectToAction("Index");
        }
    }
}