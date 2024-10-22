namespace FazendaUrbanaV1.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int? ProducaoEmSegundos { get; set; }
        public int? ValidadeEmSegundos { get; set; }
        public int? Estoque {  get; set; } 
        public float? VlrVenda { get; set; }
        public float? VlrCusto { get; set; }

        public bool Producao {  get; set; }
        public bool Venda { get; set; }

        public Categorias? Categoria { get; set; }
        public int? CategoriaId { get; set; }


    }
}
