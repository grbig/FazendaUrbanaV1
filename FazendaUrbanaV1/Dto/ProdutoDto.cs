using FazendaUrbanaV1.Models;

namespace FazendaUrbanaV1.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int? ProducaoEmSegundos { get; set; }
        public int? ValidadeEmSegundos { get; set; }
        public int? Estoque { get; set; }
        public float? VlrVenda { get; set; }
        public float? VlrCusto { get; set; }

        public Boolean? Producao { get; set; }
        public Boolean? Venda { get; set; }
        public int? CategoriaId { get; set; }
        public string? NomeCategoria { get; set; }

    }
}
