namespace Portifolio.API.Models
{
    public class Aluno
    {
        public int Id { get; set; } 
        public string Nome { get; set; }      
        public string SobreAluno { get; set; }
        public string Atuacao { get; set; } 
        public string Tecnologias { get; set; }
        public string Habilidades { get; set; }
        public string Ferramentas { get; set; }
        public int TurmaId { get; set; }

        

    }
}
