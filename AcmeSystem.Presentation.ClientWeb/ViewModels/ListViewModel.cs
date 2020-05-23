using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeSystem.Business.Metier.Model;

namespace AcmeSystem.Presentation.ClientWeb.ViewModels
{
    public class ListViewModel<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
