using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using MyBlog.Server.Core.Entities.Interface;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Server.Core.Entities.Abstract;

/// <summary>
/// 表实体继承
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
public abstract class Entity<TKey> : DEntityBase<TKey>
{
    /// <summary>
    /// 主键
    /// </summary>
    //[SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键")]

    //[Key]
    //[Comment("Id主键")]
    //public virtual TKey Id { get; set; }
}