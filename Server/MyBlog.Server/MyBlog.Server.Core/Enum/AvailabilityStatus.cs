using Microsoft.EntityFrameworkCore;

namespace MyBlog.Server.Core.Enum;
/// <summary>
/// 可用状态
/// </summary>
public enum AvailabilityStatus
{
    /// <summary>
    /// 启用
    /// </summary>
    //[Description("启用")]
    [Comment("启用")]
    Enable,

    /// <summary>
    /// 禁用
    /// </summary>
    //[Description("禁用")]
    [Comment("禁用")]
    Disable
}