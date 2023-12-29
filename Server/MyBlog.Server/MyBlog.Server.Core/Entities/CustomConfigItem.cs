using MyBlog.Server.Core.Entities.Abstract;
using MyBlog.Server.Core.Entities.Interface;
using MyBlog.Server.Core.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Server.Core.Entities;
/// <summary>
/// 自定义配置子项
/// </summary>
public class CustomConfigItem : DEntityBase<long>, IAvailability, ICreatedUserId, ISoftDelete, ICreatedTime
{
    /// <summary>
    /// 自定义配置Id
    /// </summary>
    public long ConfigId { get; set; }

    /// <summary>
    /// 配置
    /// </summary>
    //[SugarColumn(ColumnDataType = "text")]
    [Column(TypeName = "varchar(2000)")]
    public string Json { get; set; }

    /// <summary>
    /// 可用状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public long CreatedUserId { get; set; }

    /// <summary>
    /// 标记删除
    /// </summary>
    public bool DeleteMark { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
}