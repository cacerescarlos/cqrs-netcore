using TiendaCQRS.Commands;
using TiendaCQRS.Data;
using TiendaCQRS.Models;

namespace TiendaCQRS.Hadlers
{
    public class CrearProductoCommandHandler
    {
        private readonly TiendaContext _context;
        public CrearProductoCommandHandler(TiendaContext context)
        {
            _context = context;
            
        }
        public async Task Handle(CrearProductoCommand command)
        {
            var producto = new Product
            {
                Nombre = command.Nombre,
                Precio = command.Precio
            };
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }
    }
}
