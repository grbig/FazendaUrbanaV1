namespace FazendaUrbanaV1.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? FuncaoId { get; set; }
        public string? NomeFuncao { get; set; } // Apenas para exibir o nome da função
    }
}
