using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Model
{
    public partial class Model
    {
        public int? Id { get; set; }

        public bool IsNew => Id == null;
    }
}
