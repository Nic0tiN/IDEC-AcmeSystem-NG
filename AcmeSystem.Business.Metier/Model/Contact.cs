using System.Collections.Generic;

namespace AcmeSystem.Business.Metier.Model
{
    public class Contact : Model
    {
        // public int ContactId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Note { get; set; }
        public Adresse Adresse { get; set; }
        public Compte Compte { get; set; }
        public string Tags { get; set; }
        public List<ContactTag> ContactTags { get; set; }

        public override string ToString()
        {
            return Prenom + " " + Nom + " " + Compte + "\r\n\t" + Adresse;
        }
    }
}
