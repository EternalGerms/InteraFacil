using Microsoft.EntityFrameworkCore;
using InteraFacil.API.Models;

namespace InteraFacil.API.Data
{
    public class ApiDbContext : DbContext
    {
        // Configuração do banco de dados no ASP.NET
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        
        // Faz o EF Core criar uma tabela Usuários baseando-se na classe Usuario.
        public DbSet<Usuario> Usuarios { get; set; }
    }
}