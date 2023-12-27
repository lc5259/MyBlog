using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Server.EntityFramework.Core.DbContexts;

namespace MyBlog.Server.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>(DbProvider.SqlServer);
        }, "MyBlog.Server.Database.Migrations");    
    }

    
}
