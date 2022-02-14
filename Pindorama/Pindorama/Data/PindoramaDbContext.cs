using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pindorama.Models;

namespace Pindorama.Data
{
    public class PindoramaDbContext : IdentityDbContext
    {
        public PindoramaDbContext(DbContextOptions<PindoramaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<AldeiaParceira> AldeiaParceira { get; set; }
        public DbSet<Pacote> Pacote { get; set; }
        public DbSet<Artesanato> Artesanato { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Admin> Admin { get; set; }
       
    }
}