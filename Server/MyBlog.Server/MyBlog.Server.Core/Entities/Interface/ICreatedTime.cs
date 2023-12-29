namespace MyBlog.Server.Core.Entities.Interface;

/// <summary>
/// 创建日期
/// </summary>
public interface ICreatedTime
{
    /// <summary>
    /// 创建时间
    /// </summary>
    DateTime CreatedTime { get; set; }
}