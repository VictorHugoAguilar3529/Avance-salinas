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
        public async Task<ActionResult<Factura>> GetFacturaNum(string NumeroFactura)
        {
            var factura = await _context.Facturas
                                        .Include(f => f.NumeroFactura)
                                        .FirstOrDefaultAsync(f => f.NumeroFactura == NumeroFactura);
            if (factura == null)
            {
                return NotFound();
            }
            return factura;
        }




        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacturaNum), new { NumeroFactura = factura.NumeroFactura }, factura);
        }


        [HttpPut]
        public async Task<ActionResult<IEnumerable<Producto>>> PutFactura(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
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
