﻿using Furion.ConfigurableOptions;
using Yitter.IdGenerator;

namespace MyBlog.Server.Core.Options;

/// <summary>
/// 雪花id配置
/// </summary>
public sealed class SnowIdOptions : IdGeneratorOptions, IConfigurableOptions
{

}