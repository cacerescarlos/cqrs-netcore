using Microsoft.AspNetCore.Mvc;
using TiendaCQRS.Commands;
using TiendaCQRS.Hadlers;
using TiendaCQRS.Handlers;
using TiendaCQRS.Queries;

namespace TiendaCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly CrearProductoCommandHandler _crearProductoHandler;
        private readonly ObtenerProductosQueryHandler _obtenerProductosHandler;

        public ProductosController(CrearProductoCommandHandler crearProductoHandler, ObtenerProductosQueryHandler obtenerProductosHandler)
        {
            _crearProductoHandler = crearProductoHandler;
            _obtenerProductosHandler = obtenerProductosHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto(CrearProductoCommand command)
        {
            await _crearProductoHandler.Handle(command);
            return Ok("Producto creado exitosamente");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _obtenerProductosHandler.Handle(new ObtenerProductosQuery());
            return Ok(productos);
        }
    }
}
