using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } //variavel que representa a tabela de clientes no banco de dados
        public DbSet<Product> Products { get; set; }

        //conectando com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=F:\\Workspace\\ProductClientHubDB.octet-stream");
        }
      
    }
}
