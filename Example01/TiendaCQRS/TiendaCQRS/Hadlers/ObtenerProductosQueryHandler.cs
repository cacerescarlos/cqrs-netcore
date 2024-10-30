using TiendaCQRS.Data;
using TiendaCQRS.Models;
using Microsoft.EntityFrameworkCore;
using TiendaCQRS.Queries;

namespace TiendaCQRS.Handlers
{
    public class ObtenerProductosQueryHandler
    {
        private readonly TiendaContext _context;

        public ObtenerProductosQueryHandler(TiendaContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(ObtenerProductosQuery query)
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
