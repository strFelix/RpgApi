using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Personagem p = await _context.TB_PERSONAGENS
                    .Include(ar => ar.Arma)//carrega a prop ao objeto
                    .Include(ph => ph.PersonagemHabilidades)
                        .ThenInclude(h => h.Habilidade)//carrega lista de habilidades do objeto
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Personagem> lista = await _context.TB_PERSONAGENS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new Exception("Pontos de vida não pode ser maior que 100");
                }
                await _context.TB_PERSONAGENS.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new System.Exception("Pontos de vida não pode ser maior que 100");
                }
                _context.TB_PERSONAGENS.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Personagem pRemover = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_PERSONAGENS.Remove(pRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}