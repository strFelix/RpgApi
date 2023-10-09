namespace RpgApi.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Dano { get; set; }

        public Personagem Personagem { get; set; }
        public int PersonagemId{ get; set; }

        
        
    }
}