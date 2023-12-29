namespace MyBlog.Server.Core.Entities.Interface;

/// <summary>
/// 软删除
/// </summary>
public interface ISoftDelete
{
    /// <summary>
    /// 标记删除
    /// </summary>
    bool DeleteMark { get; set; }
}