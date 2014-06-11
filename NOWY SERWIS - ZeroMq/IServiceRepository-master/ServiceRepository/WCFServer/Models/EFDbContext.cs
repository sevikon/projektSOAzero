using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NServiceRepository;

namespace WCFServer.Models
{
    /**
    * Skorzystanie z dobrodziejstw Entity Framework
    * */
    public class EFDbContext : DbContext
    {
        public DbSet<Service> Servs { get; set; }
    }
}
