using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.API.Data;
using Portifolio.API.Models;

namespace Portifolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
       
            private readonly AppDbContext _context;

            public ProjetosController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Projeto>>>
               GetProjetos()
            {
                return await _context.Projetos.ToListAsync();
            }

            [HttpPost]
            public async Task<IActionResult> CadastrarProjeto(Projeto projeto)
            {
                _context.Projetos.Add(projeto);
                await _context.SaveChangesAsync();

                return Ok("Projeto cadastrado com sucesso!");
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> AlterarDados(int id, Projeto projeto)
            {
                var projetoAtual = await _context.Projetos.FindAsync(id);
                if (projetoAtual == null)
                {
                    return NotFound();
                }

                projetoAtual.Titulo = projeto.Titulo;
                projetoAtual.Descricao = projeto.Descricao;
                projetoAtual.Link = projeto.Link;

                await _context.SaveChangesAsync();

                return Ok("Projeto alterado com sucesso");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProjeto(int id)
            {
                var projeto = await _context.Projetos.FindAsync(id);

                if (projeto == null)
                {
                    return NotFound();
                }

                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();

                return NoContent();


            }
        }
    }


