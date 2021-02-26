using Microsoft.EntityFrameworkCore;
using NovaWeb.Model;

namespace NovaWeb.API.Context
{
    public class NovaWebContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public NovaWebContext(DbContextOptions<NovaWebContext> options) :
            base(options) { }
    }
}
