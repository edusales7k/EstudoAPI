using EstudoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EstudoAPI.Infra
{
    public class DBConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=Employers;" +
                "User Id=postgres;" +
                "Password=tuta7k;");
    }
}
