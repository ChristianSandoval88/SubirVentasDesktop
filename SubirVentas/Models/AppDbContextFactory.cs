using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SubirVentas.Models
{
    public class AppDbContextFactory:IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var connectionString = args[0]; 
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(serverVersion));
            var context = new AppContext(optionsBuilder.Options);
            return context;
        }
    }
}
