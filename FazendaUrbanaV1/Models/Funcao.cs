namespace FazendaUrbanaV1.Models
{
    public class Funcao
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        // Relacionamento: Uma Função pode ter vários Usuários
        public required ICollection<Usuario> Usuarios { get; set; }
    }
}
