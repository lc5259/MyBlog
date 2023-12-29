using Microsoft.Extensions.Logging;
using MyBlog.Server.Core.Entities.Abstract;
using MyBlog.Server.Core.Entities.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Server.Core.Entities;

/// <summary>
/// 操作日志
/// </summary>
public class SysOperationLog : Entity<long>, ICreatedTime
{
    /// <summary>
    /// 操作用户ID
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 日志级别
    /// </summary>
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// 接口描述
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string Description { get; set; }

    /// <summary>
    /// 控制器名称
    /// </summary>
    //[SugarColumn(Length = 128)]
    [MaxLength(128)]
    public string ControllerName { get; set; }

    /// <summary>
    /// 路由名称
    /// </summary>
    //[SugarColumn(Length = 128)]
    [MaxLength(128)]
    public string ActionName { get; set; }

    /// <summary>
    /// 请求方式
    /// </summary>
    //[SugarColumn(Length = 16)]
    [MaxLength(16)]
    public string HttpMethod { get; set; }

    /// <summary>
    /// 请求跟踪唯一ID （同一次请求ID相同）
    /// </summary>
    //[SugarColumn(Length = 64)]
    [MaxLength(64)]
    public string TraceId { get; set; }

    /// <summary>
    /// 线程ID
    /// </summary>
    public int ThreadId { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string UserAgent { get; set; }

    /// <summary>
    /// 请求地址
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string RequestUrl { get; set; }

    /// <summary>
    /// ip地址
    /// </summary>
    //[SugarColumn(Length = 64)]
    [MaxLength(64)]
    public string RemoteIp { get; set; }

    /// <summary>
    /// 用户系统信息
    /// </summary>
    //[SugarColumn(Length = 256)]
    [MaxLength(256)]
    public string OsDescription { get; set; }

    /// <summary>
    /// 耗时（毫秒）
    /// </summary>
    public int Elapsed { get; set; }

    /// <summary>
    /// Ip归属地
    /// </summary>
    //[SugarColumn(Length = 128)]
    [MaxLength(128)]
    public string Location { get; set; }

    /// <summary>
    /// http状态码
    /// </summary>
    public int HttpStatusCode { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    //[SugarColumn(ColumnDataType = "text")]
    [Column(TypeName ="varchar(200)")]
    public string Parameter { get; set; }

    /// <summary>
    /// 响应结果
    /// </summary>
    //[Column(TypeName = "varchar(200)")]
    [Column(TypeName = "varchar(200)")]
    public string Response { get; set; }

    /// <summary>
    /// 详细信息
    /// </summary>
    [Column(TypeName = "varchar(200)")]
    public string Message { get; set; }

    /// <summary>
    /// 异常信息
    /// </summary>
    [Column(TypeName = "varchar(200)")]
    public string Exception { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
}