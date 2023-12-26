using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace MyBlog.Server.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "MyBlog.Server.Database.Migrations");
    }
}
