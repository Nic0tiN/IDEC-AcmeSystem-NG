using System;
using System.Collections.Generic;
using System.Linq;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Business.Metier.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcmeSystem.Presentation.ClientWeb.ViewModels
{
    public class ContactCreateViewModel
    {
        public Contact Contact { get; set; }
        public SelectList Comptes { get; set; }
        public SelectList Tags { get; set; }
    }
}
