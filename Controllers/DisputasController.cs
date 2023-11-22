using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using System.Linq;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context){
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));

                dano -= new Random().Next(oponente.Defesa);

                if(dano > 0)
                    oponente.PontosVida -= (int)dano;

                if(oponente.PontosVida <= 0){
                    d.Narracao = $"{oponente.Nome} foi derrotado!";
                    atacante.Vitorias = atacante.Vitorias + 1;
                    oponente.Derrotas = oponente.Derrotas + 1;
                }

                oponente.Disputas = oponente.Disputas + 1;
                atacante.Disputas = atacante.Disputas + 1;

                _context.TB_PERSONAGENS.Update(oponente);
                _context.TB_PERSONAGENS.Update(atacante);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante: {0} ", atacante.Nome);
                dados.AppendFormat(" Oponente: {0} ", oponente.Nome);
                dados.AppendFormat(" Pontos de vida do atacante {0} ", atacante.PontosVida);
                dados.AppendFormat(" Pontos de vida do oponente {0} ", oponente.PontosVida);
                dados.AppendFormat(" Arma utilizada: {0} ", atacante.Arma.Nome);
                dados.AppendFormat(" Dano: {0} ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.TB_DISPUTAS.Add(d);
                _context.SaveChanges();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.PersonagemHabilidades)
                        .ThenInclude(ph => ph.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                PersonagemHabilidade ph = await _context.TB_PERSONAGENS_HABILIDADES
                    .Include(p => p.Habilidade)
                    .FirstOrDefaultAsync(phBusca =>
                        phBusca.HabilidadeId == d.HabilidadeId &&
                        phBusca.PersonagemId == d.AtacanteId
                    );
                
                if(ph == null)
                    d.Narracao = $"{atacante.Nome} não possui esta habilidade";
                else
                {
                    int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));
                    dano -= new Random().Next(oponente.Defesa);

                    if(dano > 0)
                        oponente.PontosVida -= (int)dano;

                    if(oponente.PontosVida <= 0){
                        d.Narracao = $"{oponente.Nome} foi derrotado!";
                        atacante.Vitorias = atacante.Vitorias + 1;
                        oponente.Derrotas = oponente.Derrotas + 1;
                    }
                        

                    oponente.Disputas = oponente.Disputas + 1;
                    atacante.Disputas = atacante.Disputas + 1;

                    _context.TB_PERSONAGENS.Update(oponente);
                    _context.TB_PERSONAGENS.Update(atacante);
                    await _context.SaveChangesAsync();

                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat(" Atacante: {0} ", atacante.Nome);
                    dados.AppendFormat(" Oponente: {0} ", oponente.Nome);
                    dados.AppendFormat(" Pontos de vida do atacante {0} ", atacante.PontosVida);
                    dados.AppendFormat(" Pontos de vida do oponente {0} ", oponente.PontosVida);
                    dados.AppendFormat(" Habilidade utilizada: {0} ", ph.Habilidade.Nome);
                    dados.AppendFormat(" Dano: {0} ", dano);

                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.TB_DISPUTAS.Add(d);
                    _context.SaveChanges();
                }

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }    
        }

        [HttpPost("DisputaEmGrupo")]
        public async Task<IActionResult> DisputaEmGrupoAsync(Disputa d)
        {
            try
            {
                d.Resultados = new List<string>();

                List<Personagem> personagens = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                    .Where(p => d.ListaIdPersonagem.Contains(p.Id)).ToListAsync();
                
                int qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                while(qtdPersonagensVivos > 1)
                {
                    List<Personagem> atacantes  = personagens.Where(p => p.PontosVida > 0).ToList();
                    Personagem atacante = atacantes[new Random().Next(atacantes.Count)];
                    d.AtacanteId = atacante.Id;

                    List<Personagem> oponentes = personagens.Where(p => p.Id != atacante.Id && p.PontosVida > 0).ToList();
                    Personagem oponente = oponentes[new Random().Next(oponentes.Count)];
                    d.OponenteId = oponente.Id;

                    int dano = 0;
                    string ataqueUsado = string.Empty;
                    string resultado = string.Empty;
                
                    bool ataqueUsaArma = new Random().Next(1) == 0;

                    if (ataqueUsaArma && atacante.Arma != null)
                    {
                        dano = atacante.Arma.Dano + new Random().Next(atacante.Forca);
                        dano -= new Random().Next(oponente.Defesa);
                        ataqueUsado = atacante.Arma.Nome;

                        if(dano > 0)
                            oponente.PontosVida = oponente.PontosVida - (int)dano;

                        resultado =
                            string.Format($"{atacante.Nome} atacou {oponente.Nome} usando {ataqueUsado} com um dano de {dano}. ");
                        d.Narracao += resultado;
                        d.Resultados.Add(resultado);

                    }
                    else if (atacante.PersonagemHabilidades.Count != 0){
                        int sorteioHabilidadeId = new Random().Next(atacante.PersonagemHabilidades.Count);
                        Habilidade habilidadeEscolhida = atacante.PersonagemHabilidades[sorteioHabilidadeId].Habilidade;
                        ataqueUsado = habilidadeEscolhida.Nome;

                        dano = habilidadeEscolhida.Dano + new Random().Next(atacante.Inteligencia);
                        dano -= new Random().Next(oponente.Defesa);

                        if(dano > 0)
                            oponente.PontosVida -=  (int)dano;

                        resultado =
                            string.Format($"{atacante.Nome} atacou {oponente.Nome} usando {ataqueUsado} com um dano de {dano}. ");
                        d.Narracao += resultado;
                        d.Resultados.Add(resultado);
                    }

                    if(!string.IsNullOrEmpty(ataqueUsado))
                    {
                        atacante.Vitorias ++;
                        atacante.Disputas ++;
                        oponente.Derrotas ++;
                        oponente.Disputas ++;

                        d.Id = 0;
                        d.DataDisputa = DateTime.Now;
                        _context.TB_DISPUTAS.Add(d);
                        await _context.SaveChangesAsync();
                    }

                    qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                    if(qtdPersonagensVivos == 1)
                    {
                        string resultadoFinal =
                            $"{atacante.Nome.ToUpper()} é CAMPEÃO com {atacante.PontosVida} pontos de vida restantes";
                        
                        d.Narracao += resultadoFinal;
                        d.Resultados.Add(resultadoFinal);
                        break;
                    }
                }

                _context.TB_PERSONAGENS.UpdateRange(personagens);
                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ApagarDisputas")]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();  _context.TB_DISPUTAS.RemoveRange(disputas);
                await _context.SaveChangesAsync();
                return Ok("Disputas apagadas");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [HttpGet("Listar")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();
                return Ok(disputas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}