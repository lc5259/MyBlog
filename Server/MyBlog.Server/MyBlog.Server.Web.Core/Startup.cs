using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using Furion.Logging;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyBlog.Server.Web.Core.Handlers;
using MyBlog.Server.Core.Extensions;
using MyBlog.Server.Core.Options;

namespace MyBlog.Server.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {

        //解决Encoding无法使用gb2312编码问题
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //添加自定义选项
        services.AddCustomOptions();


        services.AddConsoleFormatter();
        services.AddJwt<JwtHandler>();


       

        services.AddCorsAccessor();

        services.AddControllers()
           .AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 首字母小写（驼峰样式）
               options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 时间格式化
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
               options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;//忽略空值
           })
               .AddInjectWithUnifyResult();

        //配置缓存 文档：https://easycaching.readthedocs.io/en/latest/
        services.AddEasyCaching(options =>
        {
            string type = App.Configuration["easycaching:type"];
            switch (type)
            {
                case "csredis":
                    options.UseCSRedis(App.Configuration);
                    options.WithJson("DefaultCSRedis");
                    break;
                default:
                    options.UseInMemory(App.Configuration);
                    options.WithJson("DefaultInMemory");
                    break;
            }
        });

        //雪花id 文档：https://github.com/yitter/IdGenerator
        services.AddIdGenerator(App.GetConfig<SnowIdOptions>("SnowId"));

        //模板引擎 文档：https://furion.baiqian.ltd/docs/view-engine
        services.AddViewEngine();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // 添加状态码拦截中间件
        app.UseUnifyResultStatusCodes();


        app.UseHttpsRedirection();
        app.UseStaticFiles();
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
