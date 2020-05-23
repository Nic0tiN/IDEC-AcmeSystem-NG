
namespace AcmeSystem.Business.Metier.Model
{
    public class Adresse : Model
    {
        // public int AdresseId { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string Npa { get; set; }
        public string Localite { get; set; }

        public override string ToString()
        {
            return Rue + " " + Numero + " " + Localite;
        }

    }
}
