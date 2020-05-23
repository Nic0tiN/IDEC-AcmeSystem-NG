using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AcmeSystem.Business.Metier.DbContext
{
    public class AcmeContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AcmeContext(DbContextOptions options) : base(options) { }
    }
}
