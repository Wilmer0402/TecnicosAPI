using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Data.Context
{
    public  class TecnicosContext : DbContext
    {
        public TecnicosContext(DbContextOptions<TecnicosContext> options) : base(options) { }

        public DbSet<Models.Tecnico> Tecnico{ get; set; }
    }
}
