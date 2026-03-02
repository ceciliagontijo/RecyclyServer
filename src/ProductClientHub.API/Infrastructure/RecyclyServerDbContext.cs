using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infrastructure
{
    public class RecyclyServerDbContext : DbContext
    {
        public DbSet<User> Clients { get; set; } //variavel que representa a tabela de clientes no banco de dados

        //conectando com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=F:\\Workspace\\ProductClientHubDB.octet-stream");
        }
      
    }
}
