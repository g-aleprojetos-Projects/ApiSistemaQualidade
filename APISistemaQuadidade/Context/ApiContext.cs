using APISistemaQuadidade.Models;
using Microsoft.EntityFrameworkCore;

namespace APISistemaQuadidade.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<MockSearch> Searchs { get; set; }

        public DbSet<MockTable> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .Property(p => p.Titulo)
                .HasMaxLength(15);
            modelBuilder.Entity<Card>()
                .Property(p => p.Subtitulo)
                .HasMaxLength(50);
        }
    }
}
