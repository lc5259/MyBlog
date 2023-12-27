using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Server.Web.Core.Handlers;

namespace MyBlog.Server.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>();


       

        services.AddCorsAccessor();

        services.AddControllers()
                .AddInjectWithUnifyResult();

        var sgg3333 = App.Configuration["SpecificationDocumentSettings:DocumentTitle"];
        var sgg = App.Configuration["ConnectionStrings:DbConnectionString"];

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        //可以将多个配置或服务放在一个 Icomponent 派生类中
        //app.UseComponent<testComponent>( env);

        app.UseInject(string.Empty);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
