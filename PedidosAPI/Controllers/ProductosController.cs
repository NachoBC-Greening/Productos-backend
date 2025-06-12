using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosAPI.Data;
using PedidosAPI.Models;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductosController(ProductContext context)
        {
            _context = context;
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.productoId == id);
        }

        // GET: api/Product
        [HttpGet]
        public async Task<List<Producto>> GetAllProducts()
        {
            return await _context.Producto.ToListAsync();
        }

        //GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProduct(int id)
        {
            var producto = await _context.Producto
                                .FirstOrDefaultAsync(p => p.productoId == id);

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProduct(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = producto.productoId }, producto);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Producto producto)
        {
            Console.WriteLine($"Updating product with ID: {id}");
            if (id != producto.productoId)
            {
                return BadRequest();
            } else
            {
                var productoInDB = await _context.Producto
                                .FirstOrDefaultAsync(p => p.productoId == id);

                productoInDB.nombre = producto.nombre;
                productoInDB.precio = producto.precio;
                productoInDB.tax = producto.tax;

                _context.Entry(productoInDB).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
                
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
