

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=101, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=102, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=103, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=104, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=105, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=106, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        
        //a)
        [HttpGet("GetbyNome/{nome}")]
        public IActionResult GetbyNome(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome.Equals(nome));
                
                if(listaBusca.Count != 0 ){
                    return Ok(listaBusca);
                }else {
                    return NotFound("Personagem Não Encontrado!!! ;(");
                }                  
        }

        //b)
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem NovoPersonagem){

            if(NovoPersonagem.Defesa < 10 || NovoPersonagem.Inteligencia > 30){
                return BadRequest("Personagem não Permitido!!\n Defesa < 10 ou Inteligência > 30.");
            }else{
                personagens.Add(NovoPersonagem);
                return Ok(personagens);
            }
        }

        //c)
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem NovoPersonagem){

            if(NovoPersonagem.Classe == ClasseEnum.Mago && NovoPersonagem.Defesa < 35){
                return BadRequest("Personagens Mago, não são permitidos com Defesa < 35");
            }else{
                personagens.Add(NovoPersonagem);
                return Ok(personagens);
            }
        }

        //d)
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            List<Personagem> RemoveCavaleiro = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);

            List<Personagem> OrdenadoPontosVida = RemoveCavaleiro.OrderByDescending(x => x.PontosVida).ToList();

            return Ok(OrdenadoPontosVida);            
        }

        //e)
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            string mensagem = $"Temos {personagens.Count} personagens, e a soma da Inteligência é {personagens.Sum(i => i.Inteligencia)}";
            return Ok(mensagem);
        }


        //f)
        [HttpGet("GetbyClasse/{classeId}")]
        public IActionResult GetbyClasse(int classeId)
        {
            ClasseEnum tipoEnum = (ClasseEnum)classeId;

            //List<Personagem> listaClasse = personagens.FindAll(p => p.Classe.Equals(tipoEnum));
            List<Personagem> listaClasse = personagens.FindAll(p => p.Classe == tipoEnum);
            return Ok(listaClasse);
        }

 

    }
}




