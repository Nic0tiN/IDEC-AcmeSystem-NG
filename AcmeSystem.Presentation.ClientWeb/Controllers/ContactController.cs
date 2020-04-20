using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using AcmeSystem.Presentation.ClientWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AcmeSystem.Presentation.ClientWeb.Controllers
{
    public class ContactController : Controller
    {
        IContactServices _contactServices;
        public int PageSize = 4;

        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
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
                Contact = new Contact()
            });

        [HttpPost]
        public ViewResult Create(Contact contact)
            => View(new ContactCreateViewModel
            {
                Contact = _contactServices.Create(contact)
            });
    }
}