﻿namespace FazendaUrbanaV1.Models
{
  
    public class VendasIte
    {
       
        public Vendas? Vendas { get; set; }
        public int VendaId { get; set; }

        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produtos? Produto { get; set; }

        public int Quantidade { get; set; }
        public float? VlrUnit {  get; set; }
        public float? PercDesc {  get; set; }
        public float? VlrTotal { get; set; }

       
    }
}
