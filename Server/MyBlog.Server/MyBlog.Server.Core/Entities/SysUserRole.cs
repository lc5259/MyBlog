using MyBlog.Server.Core.Entities.Abstract;

namespace MyBlog.Server.Core.Entities;

public class SysUserRole : Entity<long>
{
    /// <summary>
    /// 用户id
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 角色id
    /// </summary>
    public long RoleId { get; set; }
}