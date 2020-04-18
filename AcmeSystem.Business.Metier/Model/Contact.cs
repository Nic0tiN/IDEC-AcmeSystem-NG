using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Model
{
    public class Contact
    {
        public Contact() { }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Adresse Adresse { get; set; }

        public override string ToString()
        {
            return Prenom + " " + Nom;
        }
    }
}
