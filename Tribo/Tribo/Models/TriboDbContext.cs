using Microsoft.EntityFrameworkCore;

namespace Tribo.Models
{
    public class TriboDbContext : DbContext
    {
        public TriboDbContext(DbContextOptions<TriboDbContext> options) : base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Viagem> Viagem { get; set; }
        public DbSet<Tribo> Tribo { get; set; }
        public DbSet<Pacote> Pacote { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Contato> Contato { get; set; }

    }


}