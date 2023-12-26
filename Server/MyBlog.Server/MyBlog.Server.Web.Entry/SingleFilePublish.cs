using Furion;
using System.Reflection;

namespace MyBlog.Server.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "MyBlog.Server.Application",
            "MyBlog.Server.Core",
            "MyBlog.Server.EntityFramework.Core",
            "MyBlog.Server.Web.Core"
        };
    }
}