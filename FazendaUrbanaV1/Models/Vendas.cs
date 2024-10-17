namespace FazendaUrbanaV1.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime DataFaturamento { get; set; }
        public int IdUsuario { get; set; }
        public int IdParceiro { get; set; }

        public ICollection<VendasIte>? vendasIte { get; set; }
    }
}
