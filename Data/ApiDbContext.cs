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

        // Permite que possamos personalizar a forma que as tabelas são criadas ao se basearem nos Models.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a implementação original
            base.OnModelCreating(modelBuilder);

            // "Configurando" a tabela de usuários
            modelBuilder.Entity<Usuario>(entity =>
            {
                // Determina que cada email deve ser único
                entity.HasIndex(u => u.Email).IsUnique();
            });
        }

    }
}