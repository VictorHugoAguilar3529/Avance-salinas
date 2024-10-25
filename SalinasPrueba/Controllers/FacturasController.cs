using Microsoft.AspNetCore.Mvc;
using SalinasPrueba.Models;
using System.Data.Entity;

namespace SalinasPrueba.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class FacturasController : Controller
    {
        private readonly InventarioContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> getFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }



        [HttpGet("{NumeroFactura}")]
        public async Task<ActionResult<IEnumerable<Factura>>> getFacturaNum(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return factura;
        }

        [HttpGet("{NumeroFactura}")]
        public async Task<ActionResult<IEnumerable<Factura>>> getFacturaNum(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return factura;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Factura>>> PostProducto(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(getFactura, producto: GetFactura()), new { id = factura.Id }, factura);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Producto>>> PutFactura(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delatefactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);


            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
