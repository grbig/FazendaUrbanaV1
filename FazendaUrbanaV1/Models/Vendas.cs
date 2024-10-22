namespace FazendaUrbanaV1.Models
{
    public enum TipoVenda
    {
        Compra = 'C',
        Venda = 'V',
        Devolucao = 'D',
        Ajuste = 'A',
        Implantação = 'I'
    }
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime DataFaturamento { get; set; }
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public int IdParceiro { get; set; }
        public Parceiros? Parceiro { get; set; }

        public TipoVenda TipoVenda { get; set; }
        public ICollection<VendasIte>? vendasIte { get; set; }
    }
}
