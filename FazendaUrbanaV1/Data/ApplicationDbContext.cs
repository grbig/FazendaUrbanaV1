using FazendaUrbanaV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FazendaUrbanaV1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Parceiros> Parceiros { get; set; }

        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<VendasIte> VendasIte { get; set; }
        
        public DbSet<Producao> Producaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação um-para-muitos entre Usuario e Funcao

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Funcao)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(u => u.FuncaoId);
            
            modelBuilder.Entity<Produtos>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<VendasIte>()
                .HasOne(v => v.Vendas)
                .WithMany(i => i.vendasIte)
                .HasForeignKey(f => f.VendaId);

            modelBuilder.Entity<VendasIte>()
                .HasOne(v => v.Produto)
                .WithMany()
                .HasForeignKey(f => f.IdProduto);

            modelBuilder.Entity<Vendas>()
                .HasOne(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.IdUsuario);

            modelBuilder.Entity<Vendas>()
                .HasOne(u => u.Parceiro)
                .WithMany()
                .HasForeignKey(u => u.IdParceiro);

            modelBuilder.Entity<Producao>()
                .HasOne(u => u.Produto)
                .WithMany()
                .HasForeignKey(u => u.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producao>()
               .HasOne(u => u.Semente)
               .WithMany()
               .HasForeignKey(u => u.IdSemente)
               .OnDelete(DeleteBehavior.Restrict); 




            base.OnModelCreating(modelBuilder);
        }
    }
}
