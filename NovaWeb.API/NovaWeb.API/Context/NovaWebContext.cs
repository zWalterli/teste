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
                .HasOne<Contato>()
                .WithMany(a => a.telefones)
                .HasForeignKey("id_contato");
        }
    }
}
