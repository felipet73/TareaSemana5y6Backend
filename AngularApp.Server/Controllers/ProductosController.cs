using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApp.Server.Data;
using AngularApp.Server.Model;

namespace AngularApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ServerDbContext _context;

        public ProductosController(ServerDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosModel>>> GetProductosModel()
        {
            return await _context.ProductosModel.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosModel>> GetProductosModel(int id)
        {
            var productosModel = await _context.ProductosModel.FindAsync(id);

            if (productosModel == null)
            {
                return NotFound();
            }

            return productosModel;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductosModel(int id, ProductosModel productosModel)
        {
            if (id != productosModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductosModel>> PostProductosModel(ProductosModel productosModel)
        {
            _context.ProductosModel.Add(productosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductosModel", new { id = productosModel.Id }, productosModel);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductosModel(int id)
        {
            var productosModel = await _context.ProductosModel.FindAsync(id);
            if (productosModel == null)
            {
                return NotFound();
            }

            _context.ProductosModel.Remove(productosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosModelExists(int id)
        {
            return _context.ProductosModel.Any(e => e.Id == id);
        }
    }
}
