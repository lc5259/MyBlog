﻿using MyBlog.Server.Core.Options;

namespace MyBlog.Server.Core.Extensions;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// 添加自定义选项
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomOptions(this IServiceCollection service)
    {
        service.AddConfigurableOptions<DbConnectionOptions>();
        service.AddConfigurableOptions<OssConnectionOptions>();
        service.AddConfigurableOptions<SnowIdOptions>();
        return service;
    }
}