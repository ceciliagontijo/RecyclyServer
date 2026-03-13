using Microsoft.EntityFrameworkCore;
using RecyclyServer.API.Entities;

namespace RecyclyServer.API.Infrastructure
{
    public class RecyclyServerDbContext : DbContext
    {
        public DbSet<User> Clients { get; set; } 

        public DbSet<CollectionPoint> CollectionPoints { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<CollectionPointMaterial> CollectionPointMaterials { get; set; }

        //conectando com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
             (
               "Server=localhost\\SQLEXPRESS;Database=RecyclyServer;Trusted_Connection=True;TrustServerCertificate=True"
             );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionPointMaterial>()
                .HasKey(cpm => new { cpm.CollectionPointId, cpm.MaterialId });
        }

    }
}
