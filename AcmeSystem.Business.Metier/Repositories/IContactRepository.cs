﻿using AcmeSystem.Business.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Business.Metier.Repositories
{
    public interface IContactRepository
    {
        Contact GetById(int id);
        ICollection<Contact> GetAll();
    }
}