using GenusEventosApi.DataAccess;
using GenusEventosApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GenusEventosApi.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly DataContext context;

        public ClienteController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Clientes.ToArrayAsync());
        }

        [HttpGet("{id}", Name = nameof(GetClienteById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(202, Type = typeof(Cliente))]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }



        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Cliente))]
        public async Task<IActionResult> Add([FromBody] Cliente newCliente)
        {
            if (newCliente.Id < 0)
            {
                return BadRequest("Id inválido");
            }
            context.Clientes.Add(newCliente);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClienteById), new { id = newCliente.Id }, newCliente);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]    
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Id == id); 
            if (cliente == null) return NotFound();
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return NoContent();
        }




    }
}
