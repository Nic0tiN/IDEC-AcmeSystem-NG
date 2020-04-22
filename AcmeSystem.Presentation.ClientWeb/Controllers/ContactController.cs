using System;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;
using AcmeSystem.Presentation.ClientWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class ContactController : Controller
    {
        private IAdresseServices _adresseServices;
        private IContactServices _contactServices;
        private ICompteServices _compteServices;
        public int PageSize = 4;

        public ContactController(IAdresseServices addresseServices, IContactServices contactServices, ICompteServices compteServices)
        {
            _adresseServices = addresseServices;
            _contactServices = contactServices;
            _compteServices = compteServices;
        }

        public ViewResult List(int contactPage = 1)
            => View(new ContactListViewModel
            {
                Contacts = _contactServices.GetAll()
                    .OrderBy(c => c.Nom)
                    .Skip((contactPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = contactPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _contactServices.GetAll().Count()
                }
            });

        [HttpGet]
        public ViewResult Create()
            => View(new ContactCreateViewModel
            {
                Contact = new Contact(),
                Comptes = _compteServices.GetAll().ToList()
            });

        [HttpGet]
        public ViewResult Update(Contact contact)
            => View("Create", new ContactCreateViewModel
            {
                Contact = contact
            });

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            try
            {
                contact = _contactServices.Save(contact);
                FlashMessage.Success("Contact enregistré avec succès.");

                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                FlashMessage.Error(e.Message);
            }

            return View("Create", new ContactCreateViewModel(){ Contact = contact });
        }

        [HttpPost]
        public ActionResult Delete(Contact contact)
        {
            try
            {
                _contactServices.Delete(contact);
                FlashMessage.Success("Contact supprimé avec succès.");
            }
            catch (Exception e)
            {
                FlashMessage.Error(e.Message);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ViewResult Synchronize()
        {
            return View(new SynchronizeViewModel() { });
        }
    }
}