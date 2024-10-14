using System;

namespace FazendaUrbanaV1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }

        // Relacionamento: Um Usuário pode ter uma Função
        public int FuncaoId { get; set; } // Chave estrangeira
        public required Funcao Funcao { get; set; }
    }

}
