using RegressivaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RegressivaAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        // Configurar nomes das tabelas em minúsculas
            modelBuilder.Entity<Usuario>().ToTable("usuarios", "${DB_SCHEMA}");
            modelBuilder.Entity<Evento>().ToTable("eventos", "${DB_SCHEMA}");
            base.OnModelCreating(modelBuilder);
        }
    }
}
