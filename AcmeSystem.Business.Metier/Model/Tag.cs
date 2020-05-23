using System.Collections.Generic;


namespace AcmeSystem.Business.Metier.Model
{
    public class Tag : Model
    {
        // public int TagId { get; set; }
        public List<ContactTag> ContactTags { get; set; }
        public string Nom { get; set; }
        public override string ToString()
        {
            return Nom;
        }
    }
}
