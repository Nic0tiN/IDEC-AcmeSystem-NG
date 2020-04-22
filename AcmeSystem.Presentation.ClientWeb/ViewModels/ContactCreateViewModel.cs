using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeSystem.Business.Metier.Model;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;

namespace AcmeSystem.Presentation.ClientWeb.ViewModels
{
    public class ContactCreateViewModel
    {
        public Contact Contact { get; set; }
        public IEnumerable<Compte> Comptes { get; set; }
    }
}
