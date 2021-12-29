using Microsoft.EntityFrameworkCore;

namespace Tribo.Models
{
    public class TriboDbContext : DbContext
    {
        public TriboDbContext(DbContextOptions<TriboDbContext> options) : base(options)
        { }

        public DbSet<Viagem> Viagem { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Contato> Contato { get; set; }
    }


}