namespace FazendaUrbanaV1.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public int IdSemente { get; set; }
        public Produtos? Semente { get; set; }  // Propriedade de navegação para Produto (semente)

        public int IdProduto { get; set; }
        public Produtos? Produto { get; set; }

        public DateTime DataPlantacao { get; set; }
        public DateTime DataColheita { get; set; }

        public bool IsSementeValida()
        {
            return Semente != null && Semente.Producao;
        }

        public bool IsProdutoValida()
        {
            return Produto != null && Produto.Venda;
        }

    }
}
