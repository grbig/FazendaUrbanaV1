using FazendaUrbanaV1.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaUrbanaV1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação um-para-muitos entre Usuario e Funcao
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Funcao)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(u => u.FuncaoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
