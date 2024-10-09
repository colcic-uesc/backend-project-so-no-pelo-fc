using BackEndAPI.Service.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BackEndAPI.Service.DataBase;
public class ApiDBContextFactory : IDesignTimeDbContextFactory<ApiDBContext>
{
    public ApiDBContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory().Split('.')[0])
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                
        var optionsBuilder = new DbContextOptionsBuilder<ApiDBContext>();
        var conn = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlite(conn);
        return new ApiDBContext(optionsBuilder.Options);
    }
}
