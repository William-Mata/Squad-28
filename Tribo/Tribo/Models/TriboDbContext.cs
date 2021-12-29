using Microsoft.EntityFrameworkCore;

namespace Tribo.Models
{
    public class TriboDbContext : DbContext
    {
        public TriboDbContext(DbContextOptions<TriboDbContext> options) : base(options)
        { }

        public DbSet<Viagem> Viagens { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<TriboParceira> Tribos { get; set; }

        public DbSet<Pacote> Pacotes { get; set; }


    }


}