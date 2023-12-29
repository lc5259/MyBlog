using MyBlog.Server.Core.Enum;

namespace MyBlog.Server.Core.Entities.Interface;
/// <summary>
/// 可用状态
/// </summary>
public interface IAvailability
{
    /// <summary>
    /// 可用状态
    /// </summary>
    AvailabilityStatus Status { get; set; }
}