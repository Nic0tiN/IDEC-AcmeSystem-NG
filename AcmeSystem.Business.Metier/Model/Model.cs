using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Model
{
    public abstract class Model
    {
        public int? Id;
        public abstract override string ToString();
    }
}
