using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;
using Microsoft.EntityFrameworkCore;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
         private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if(personagem == null)
                    throw new System.Exception("Personagem não encontrado para o Id informado");
                
                Habilidade habilidade = await _context.TB_HABILIDADES
                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);
                
                if(habilidade == null)
                    throw new System.Exception("Habilidade não encontrada");
                
                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPersonagemHabilidades/{id}")]
        public async Task<IActionResult> GetPersonagemHabilidade(int id)
        {
            try
            {
                PersonagemHabilidade? validarPH = await _context.TB_PERSONAGENS_HABILIDADES
                    .FirstOrDefaultAsync(p => p.PersonagemId == id);

                if(validarPH == null){
                    throw new System.Exception("Personagem não existe");
                }
                else{
                    
                    var busca = 
                        from ph in _context.TB_PERSONAGENS_HABILIDADES
                        join p in _context.TB_PERSONAGENS on ph.PersonagemId equals p.Id
                        join h in _context.TB_HABILIDADES on ph.HabilidadeId equals h.Id
                        where ph.PersonagemId == id
                        select new 
                        {
                            PersonagemId = p.Id, 
                            PersonagemNome = p.Nome,
                            HabilidadeID = h.Id,
                            HabilidadeNome = h.Nome,
                            HabilidadeDano = h.Dano

                        };
                    
                    return Ok(busca.ToList());
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Habilidade> listaHabilidades = await _context.TB_HABILIDADES.ToListAsync();
                return Ok(listaHabilidades);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("DeletePersonagemHabilidade")]
         public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade credenciais){
            try
            {
                PersonagemHabilidade? personagemEncontrado = await _context.TB_PERSONAGENS_HABILIDADES
                    .FirstOrDefaultAsync(pe => 
                        pe.PersonagemId == credenciais.PersonagemId 
                        &&
                        pe.HabilidadeId == credenciais.HabilidadeId);
                
                if(personagemEncontrado == null)
                    throw new System.Exception("Personagem ou habilidade não encontrada");
                else{
                     _context.TB_PERSONAGENS_HABILIDADES.Remove(personagemEncontrado);
                    int linhasAfetadas = await _context.SaveChangesAsync();
                    string message = $"Qauntidade linhas afetada: {linhasAfetadas}";
                    return Ok(message);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}