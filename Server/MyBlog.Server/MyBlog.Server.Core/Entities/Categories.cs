using MyBlog.Server.Core.Entities.Abstract;
using MyBlog.Server.Core.Entities.Interface;
using MyBlog.Server.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Server.Core.Entities;

/// <summary>
/// 文章栏目表
/// </summary>
public class Categories : DEntityBase<long>, IAvailability, ISortable, ICreatedUserId, ISoftDelete, ICreatedTime
{
    /// <summary>
    /// 栏目名称
    /// </summary>
    //[SugarColumn(Length = 32)]
    [MaxLength(32)]
    public string Name { get; set; }

    /// <summary>
    /// 父级id
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string Cover { get; set; }

    /// <summary>
    /// 可用状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }

    /// <summary>
    /// 排序值（值越小越靠前）
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string Remark { get; set; }

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

    /// <summary>
    /// 子栏目
    /// </summary>
    //[SugarColumn(IsIgnore = true)]
    [NotMapped]
    public List<Categories> Children { get; set; } = new();
}