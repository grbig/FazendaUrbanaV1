﻿namespace FazendaUrbanaV1.Models
{
    public class Parceiros
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public required Boolean Cliente { get; set; }
        public required Boolean Fornecedor { get; set; }

    }
}
