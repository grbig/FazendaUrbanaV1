namespace FazendaUrbanaV1.Models
{
    public class Parceiros
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public required bool Cliente { get; set; }
        public required bool Fornecedor { get; set; }

    }
}
