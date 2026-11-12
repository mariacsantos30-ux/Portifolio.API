using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.API.Data;
using Portifolio.API.Models;

namespace Portifolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>>
           GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok("Alunos cadastrados com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarDados(int id, Aluno aluno)
        {
            var alunoAtual = await _context.Alunos.FindAsync(id);
            if (alunoAtual == null)
            {
                return NotFound();
            }

            alunoAtual.Nome = aluno.Nome;
            alunoAtual.SobreAluno = aluno.SobreAluno;
            alunoAtual.Atuacao = aluno.Atuacao;
            alunoAtual.Tecnologias = aluno.Tecnologias;
            alunoAtual.Habilidades = aluno.Habilidades;
            alunoAtual.Ferramentas = aluno.Ferramentas;
            alunoAtual.TurmaId = aluno.TurmaId;

            await _context.SaveChangesAsync();

            return Ok("Alunos alterados com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePr(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}



    

