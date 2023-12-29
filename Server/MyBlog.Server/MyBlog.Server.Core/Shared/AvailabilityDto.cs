//using Easy.Admin.Core.Enum;
using MyBlog.Server.Core.Enum;

namespace MyBlog.Server.Core.Shared;

public class AvailabilityDto : KeyDto
{
    /// <summary>
    /// 状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }
}