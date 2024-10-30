using Microsoft.EntityFrameworkCore;
using TiendaCQRS.Models;

namespace TiendaCQRS.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options ): base(options) { }
            public DbSet<Product> Productos { get; set; }
            

    }
}
