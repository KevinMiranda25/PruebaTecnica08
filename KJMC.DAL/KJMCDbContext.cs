using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.EN;
using Microsoft.EntityFrameworkCore;

namespace KJMC.DAL
{
    public class KJMCDbContext : DbContext
    {
        public KJMCDbContext(DbContextOptions<KJMCDbContext> options) : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
