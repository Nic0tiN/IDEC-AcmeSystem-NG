using AcmeSystem.Business.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcmeSystem.Business.Metier.Services
{
    public interface IContactServices
    {
        ICollection<Contact> GetAll();
    }
}
