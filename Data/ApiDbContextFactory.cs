using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InteraFacil.API.Data
{
    // Esta classe SÓ é usada pela ferramenta de terminal 'dotnet ef'
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            //  Cria um "construtor de opções" em branco
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            var connectionString = "Data Source=finfacil.db";
            optionsBuilder.UseSqlite(connectionString);

            // 3. Retorna o novo ApiDbContext usando essas opções
            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}