using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Web.Core
{
    public class testComponent : IApplicationComponent
    {
        public void Load(IApplicationBuilder app, IWebHostEnvironment env, ComponentContext componentContext)
        {
            app.UseInject(string.Empty);
        }
    }
}
