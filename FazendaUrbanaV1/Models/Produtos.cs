namespace FazendaUrbanaV1.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public int CategoriaId { get; set; }
        public required Categorias Categoria { get; set; }

    }
}
