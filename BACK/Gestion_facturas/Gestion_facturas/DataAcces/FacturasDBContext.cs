using Microsoft.EntityFrameworkCore;
using Gestion_facturas.Models.DataModels;

namespace Gestion_facturas.DataAcces
{
    public class FacturasDBContext : DbContext
    {
        public FacturasDBContext(DbContextOptions<FacturasDBContext> options) : base(options)
        {
            
        
        }

        //TODO: add Dbset (tables)

        public DbSet<Users> Users { get; set; }

        //TODO: add Dbset (tables)

        public DbSet<Gestion_facturas.Models.DataModels.Enterprise> Enterprise { get; set; } = default!;

        //TODO: add Dbset (tables)

        public DbSet<Gestion_facturas.Models.DataModels.Invoice> Invoice { get; set; } = default!;

        //TODO: add Dbset (tables)

        public DbSet<Gestion_facturas.Models.DataModels.InvoiceLine> InvoiceLine { get; set; } = default!;
    }
}
