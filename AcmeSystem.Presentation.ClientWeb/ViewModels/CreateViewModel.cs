using AcmeSystem.Business.Metier.Model;

namespace AcmeSystem.Presentation.ClientWeb.ViewModels
{
    public class CreateViewModel<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }
    }
}
