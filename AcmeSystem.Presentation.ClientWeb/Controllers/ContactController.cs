using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;
using AcmeSystem.Presentation.ClientWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class ContactController : Controller
    {
        private IService<Contact> _contactService;
        private IService<Compte> _compteService;
        private IService<Tag> _tagService;
        public int PageSize = 4;

        public ContactController(IService<Contact> contactService, IService<Compte> compteService, IService<Tag> tagService)
        {
            _contactService = contactService;
            _compteService = compteService;
            _tagService = tagService;
        }

        public ViewResult List(int contactPage = 1)
        {
            ViewBag.Query = "";
            if (Request.Query.ContainsKey("nom"))
            {
                ViewBag.Query = Request.Query["nom"];
            }

            return View(new ContactListViewModel
            {
                Contacts = _contactService.GetAll("Adresse,Compte,ContactTags")
                    .Where(c => c.Nom.Contains(ViewBag.Query))
                    .OrderBy(c => c.Nom)
                    .Skip((contactPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = contactPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _contactService.GetAll().Count()
                }
            });
        } 

        [HttpGet]
        public ViewResult Create()
        {
            PopulateComptesDropDownList();
            PopulateTagsDropDownList();
            return View(new ContactCreateViewModel()
            {
                Contact = new Contact()
            });
        }

        [HttpGet]
        public ViewResult View(int id)
        {
            var contact = _contactService.GetId(id, "Adresse,Compte,ContactTags");
            PopulateComptesDropDownList((contact.Compte != null) ? contact.Compte.Id : 0);
            PopulateTagsDropDownList(contact.Tags.Split(","));
            return View(new ContactCreateViewModel()
            {
                Contact = contact 
            });
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            var contact = _contactService.GetId(id, "Adresse,Compte,ContactTags");
            PopulateComptesDropDownList( (contact.Compte != null) ? contact.Compte.Id : 0);
            PopulateTagsDropDownList(contact.Tags.Split(","));
            return View("Create", new ContactCreateViewModel()
            {
                Contact = contact
            });
        }

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            try
            {
                if (contact.Compte.Id != 0)
                {
                    // Contourne un problème d'édition. Lorsque le Contact.Compte.Id est enregistré, la propriété Nom du compte est perdue et
                    // est remplacée par une valeur nulle.
                    contact.Compte = _compteService.GetId(contact.Compte.Id ?? 0);
                }
                else
                {
                    contact.Compte = null;
                }

                contact.Tags = String.Join(",", Request.Form["Contact.Tags"].ToArray());

                _contactService.Save(contact);

                if (Request.Form.ContainsKey("Contact.ContactTags"))
                {
                    foreach(string strValueOrId in Request.Form["Contact.ContactTags"])
                    {
                        int id;
                        if (!Int32.TryParse(strValueOrId, out id))
                        {
                            id = _tagService.Save(new Tag() {Nom = strValueOrId }).Id ?? 0; // Coalesce pour satisfaire `id` de type int pas int?
                        }

                        Tag tag = _tagService.GetId(id);

                        contact.ContactTags.Add(new ContactTag()
                        {
                            Contact =  contact,
                            ContactId = contact.Id,
                            Tag = tag,
                            TagId = tag.Id
                        });
                    }

                }
                _contactService.Save(contact);

                FlashMessage.Success("Contact enregistré avec succès.");

                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                FlashMessage.Error(e.Message);
            }

            PopulateComptesDropDownList(contact);
            PopulateTagsDropDownList(contact.Tags.Split(","));

            return View("Create", new ContactCreateViewModel(){ Contact = contact });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _contactService.Delete(_contactService.GetId(id, "Adresse"));
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

        private void PopulateComptesDropDownList(object selectedCompte = null)
        {
            var comptesQuery = from compte in _compteService.GetAll()
                orderby compte.Nom
                select compte;
            ViewBag.Comptes = new SelectList(comptesQuery.AsQueryable().AsNoTracking(), "Id", "Nom", selectedCompte);
        }

        private void PopulateTagsDropDownList(object[] selectedTags = null)
        {
            var tagsQuery = from contact in _contactService.GetAll()
                orderby contact.Tags
                select contact.Tags;
            List<Tag> tags = new List<Tag>();
            List<Tag> selected = new List<Tag>();
            foreach (string tag in tagsQuery.AsQueryable().AsNoTracking())
            {
                if (tag == null)
                {
                    continue;
                }

                foreach (string _tag in tag.Split(","))
                {
                    tags.Add(new Tag() { Nom = _tag });
                }
            }

            if (selectedTags != null)
            {
                foreach (string selectedTag in selectedTags)
                {
                    selected.Add(new Tag() { Nom = selectedTag });
                }
            }
            
            ViewBag.Tags = new MultiSelectList(tags, "Nom", "Nom", selected);
        }
    }
}