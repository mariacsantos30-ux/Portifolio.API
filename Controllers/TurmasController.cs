using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.API.Data;
using Portifolio.API.Models;

namespace Portifolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>>
           GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return Ok("Turma cadastrada com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarDados(int id, Turma turma)
        {
            var turmaAtual = await _context.Turmas.FindAsync(id);
            if (turmaAtual == null)
            {
                return NotFound();
            }

            turmaAtual.Nome = turma.Nome;
            turmaAtual.Periodo = turma.Periodo;
            turmaAtual.Professor = turma.Professor;

            await _context.SaveChangesAsync();

            return Ok("Turma alterada com sucesso");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTurmas(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}

