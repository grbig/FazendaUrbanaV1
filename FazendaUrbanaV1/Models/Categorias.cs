namespace FazendaUrbanaV1.Models
{
    public class Categorias
    {
        public int Id { get; set; }
        public string? Categoria { get; set; }
        
        public ICollection<Produtos>? Produtos { get; set; }
    }
}
