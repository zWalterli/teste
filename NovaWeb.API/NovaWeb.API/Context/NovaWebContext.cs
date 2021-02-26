using Microsoft.EntityFrameworkCore;
using NovaWeb.API.Model;

namespace NovaWeb.API.Context
{
    public class NovaWebContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public NovaWebContext(DbContextOptions<NovaWebContext> options) :
            base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>()
                .HasOne(c => c.contato)
                .WithMany(a => a.telefones)
                .HasForeignKey("fk_telefone_contato");

            /*
            modelBuilder.Entity<Contato>()
                .HasOne(fa => fa.Categorias)
                .WithMany(a => (IEnumerable<FilmeCategoria>)a.Filmes)
                .HasForeignKey("category_id");
            */
        }
    }
}
