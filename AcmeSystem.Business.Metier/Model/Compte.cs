
namespace AcmeSystem.Business.Metier.Model
{
    public class Compte : Model
    {
        // public int CompteId { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}
