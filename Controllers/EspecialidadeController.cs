using GenusEventosApi.DataAccess;
using GenusEventosApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenusEventosApi.Controllers
{
    [Route("api/Especialidade")]
    [ApiController]
    public class EspecialidadeController : Controller
    {
        private readonly DataContext context;

        public EspecialidadeController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Especialidade>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Especialidades.Include(e => e.Profissionais).ToArrayAsync());
        }

        [HttpGet("{id}", Name = nameof(GetEspecialidadeById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Especialidade))]
        public async Task<IActionResult> GetEspecialidadeById(int id)
        {
            var especialidade = await context.Especialidades.FirstOrDefaultAsync(p => p.Id == id);
            if (especialidade == null) return NotFound();
            return Ok(especialidade);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Especialidade))]
        public async Task<IActionResult> Add([FromBody] Especialidade newEspecialidade)
        {
            if (newEspecialidade.Id < 0) return BadRequest();

            context.Especialidades.Add(new Especialidade() { Nome = newEspecialidade.Nome, Profissionais = new()});
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEspecialidadeById), new { id = newEspecialidade.Id }, newEspecialidade);
        }

        

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidade = await context.Especialidades.FirstOrDefaultAsync(p => p.Id == id);
            if (especialidade == null) return NotFound();
            context.Especialidades.Remove(especialidade);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
