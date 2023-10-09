using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models
{
    public class Habilidade
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public int Dano { get; set; }
        public List<PersonagemHabilidade> PersonagemHabilidades { get; set; }
         
    }
}