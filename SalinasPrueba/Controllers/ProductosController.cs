using Microsoft.AspNetCore.Mvc;
using SalinasPrueba.Models;
using System.Data.Entity;

namespace SalinasPrueba.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ProductosController : Controller
    {
        private readonly InventarioContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> getProductos()
        {
            return await _context.Productos.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Producto>>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(getProducto, producto: GetProducto()), new { id = producto.Id }, producto);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Producto>>> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DelateProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);


            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
