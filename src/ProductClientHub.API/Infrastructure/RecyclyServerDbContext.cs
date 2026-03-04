using Microsoft.EntityFrameworkCore;
using RecyclyServer.API.Entities;

namespace RecyclyServer.API.Infrastructure
{
    public class RecyclyServerDbContext : DbContext
    {
        public DbSet<User> Clients { get; set; } //variavel que representa a tabela de clientes no banco de dados

        //conectando com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
             (
               "Server=localhost\\SQLEXPRESS;Database=RecyclyServer;Trusted_Connection=True;TrustServerCertificate=True"
             );
        }
      
    }
}
