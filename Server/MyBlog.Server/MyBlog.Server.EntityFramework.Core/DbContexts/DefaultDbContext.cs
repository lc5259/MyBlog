using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Server.EntityFramework.Core;

[AppDbContext("MyBlog.Server", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
