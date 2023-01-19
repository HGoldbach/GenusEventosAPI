using GenusEventosApi.DataAccess;
using GenusEventosApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenusEventosApi.Controllers
{
    [Route("api/Profissional")]
    [ApiController]

    public class ProfissionalController : Controller
    {
        private readonly DataContext _context;

        public ProfissionalController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Profissional>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Profissionais.Include(p => p.Especialidade).ToArrayAsync());
        }

        [HttpGet("{id}", Name = nameof(GetProfissionalById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Profissional))]
        public async Task<IActionResult> GetProfissionalById(int id)
        {
            var profissional = await _context.Profissionais.Where(p => p.Id == id).Include(e => e.Especialidade).FirstOrDefaultAsync();
            if (profissional == null) return NotFound();
            return Ok(profissional);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(201, Type = typeof(Profissional))]
        public async Task<IActionResult> Add(CreateProfissionalDto request)
        {
            var especialidade = await _context.Especialidades.FindAsync(request.EspecialidadeId);
            if (especialidade == null) return NotFound();

            var newProfissional = new Profissional
            {
                Cpf = request.Cpf,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                ValorHora = request.ValorHora,
                Endereco = request.Endereco,
                Especialidade = especialidade
            };

            _context.Profissionais.Add(newProfissional);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProfissionalById), new { id = newProfissional.Id }, newProfissional);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            var profissional = await _context.Profissionais.FirstOrDefaultAsync(p => p.Id == id);
            if (profissional == null) return NotFound();
            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();   
            return NoContent();
        }


    }
}
