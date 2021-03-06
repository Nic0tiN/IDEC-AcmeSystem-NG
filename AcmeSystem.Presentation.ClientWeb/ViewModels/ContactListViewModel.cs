﻿using AcmeSystem.Business.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;

namespace AcmeSystem.Presentation.ClientWeb.ViewModels
{
    public class ContactListViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
