using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Model
{
    public class Compte : Model
    {
        public int? Id { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}
