using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tribo.Models;

namespace Tribo.Data
{
    public class TriboDbContext : IdentityDbContext
    {
        public TriboDbContext(DbContextOptions<TriboDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<TriboParceira> TriboParceira { get; set; }
        public DbSet<Pacote> Pacote { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Contato> Contato { get; set; }

        public DbSet<Admin> Admin { get; set; }
    }
}