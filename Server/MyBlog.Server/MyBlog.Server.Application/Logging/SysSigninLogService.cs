using BaiduBce.Services.Bos.Model;
using Furion.Logging;
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
    /// 登录日志
    /// </summary>
    public class SysSigninLogService : IDynamicApiController
    {
        private readonly IRepository<SysSigninLog> _repository;
        private readonly IRepository<SysUser> _sysUserrepository;

        public SysSigninLogService(IRepository<SysSigninLog> repository, IRepository<SysUser> SysUserrepository)
        {
            _repository = repository;
            _sysUserrepository = SysUserrepository;
        }

        /// <summary>
        /// 登录日志分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("登录日志列表")]
        [HttpGet]
        public async Task<PagedList<SigninLogPageOutput>> List([FromQuery] LogPageQueryInput dto)
        {
            var data = from p in this._repository.AsQueryable()
                       join d in this._sysUserrepository.AsQueryable() on p.UserId equals d.Id
                       where (!string.IsNullOrWhiteSpace(dto.Keyword)) &&   p.Message.Contains(dto.Keyword)
                              && (!string.IsNullOrWhiteSpace(dto.Account) && d.Account.Contains(dto.Account))
                       orderby p.Id
                         select new SigninLogPageOutput
                         {
                            Id = p.Id,
                            Message = p.Message,
                           RemoteIp = p.RemoteIp,
                           Location = p.Location,
                           OsDescription = p.OsDescription,
                           UserAgent = p.UserAgent,
                           CreatedTime = p.CreatedTime,
                           Account =   d .Account
                         };
            return await data.ToPagedListAsync();
        }
    }
}
