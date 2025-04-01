namespace ApiPiaget.Models
{
    public class Escola
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? RGM { get; set; }
        public string? CPF { get; set; }
        public Aluno? Aluno { get; set; }
        public Professor? Professor { get; set; }

    }
}
