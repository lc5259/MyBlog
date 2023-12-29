using MyBlog.Server.Core.Entities.Abstract;
using MyBlog.Server.Core.Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Server.Core.Entities;

/// <summary>
/// 相册图片表
/// </summary>
public class Pictures : DEntityBase<long>, ICreatedTime
{
    /// <summary>
    /// 相册Id
    /// </summary>
    public long AlbumId { get; set; }

    /// <summary>
    /// 图片地址
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string Url { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string Remark { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
}