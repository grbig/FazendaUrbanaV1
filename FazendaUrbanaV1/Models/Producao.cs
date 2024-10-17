namespace FazendaUrbanaV1.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public int IdSemente {  get; set; }
        public int IdProduto {  get; set; }
        public DateTime DataPlantacao { get; set; }
        public DateTime DataColheita { get; set; }
        public int LocalFazenda {  get; set; }

    }
}
