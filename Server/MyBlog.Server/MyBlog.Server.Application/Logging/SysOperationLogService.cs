using BaiduBce.Services.Bos.Model;
using Furion.Logging;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyBlog.Server.Application.Logging.Dtos;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Logging
{
    /// <summary>
/// 操作日志
/// </summary>
    public class SysOperationLogService : IDynamicApiController
    {
        private readonly IRepository<SysOperationLog> _repository;
        private readonly IRepository<SysUser> _sysUserrepository;

        public SysOperationLogService(IRepository<SysOperationLog> repository, IRepository<SysUser> SysUserrepository)
        {
            this._repository = repository;
            _sysUserrepository = SysUserrepository;
        }

        /// <summary>
        /// 操作日志分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<OperationLogPageOutput>> list([FromQuery] LogPageQueryInput dto)
        {
            var data = from p in this._repository.AsQueryable()
                       join d in this._sysUserrepository.AsQueryable() on p.UserId equals d.Id
                       where (!string.IsNullOrWhiteSpace(dto.Keyword)) && (p.Description.Contains(dto.Keyword) || p.Message.Contains(dto.Keyword))
                              && p.LogLevel == dto.LogLevel && (!string.IsNullOrWhiteSpace(dto.Account) && d.Account.Contains(dto.Account))
                       orderby p.Id
                       select new OperationLogPageOutput
                       {
                           Id = p.Id,
                           Description = p.Description,
                           LogLevel = p.LogLevel,
                           Message = p.Message,
                           ActionName = p.ActionName,
                           ControllerName = p.ControllerName,
                           HttpMethod = p.HttpMethod,
                           HttpStatusCode = p.HttpStatusCode,
                           Elapsed = p.Elapsed,
                           Exception = p.Exception,
                           Location = p.Location,
                           RemoteIp = p.RemoteIp,
                           OsDescription = p.OsDescription,
                           UserAgent = p.UserAgent,
                           //Parameter = p.Parameter,
                           //Response = p.Response,
                           RequestUrl = p.RequestUrl,
                           Account = d.Account,
                           CreatedTime = p.CreatedTime
                       };

            return await data.ToPagedListAsync();
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <returns></returns>
        [DisplayName("清除操作日志")]
        [HttpDelete("clear")]
        public async Task Clear()
        {
            await _repository.DeleteAsync(x => x.Id > 0);
        }
    }
}
