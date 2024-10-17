namespace FazendaUrbanaV1.Models
{
    public class Fazenda
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        
        public required int AreaX { get; set; }
        public required int AreaY { get; set; }



    }
}
