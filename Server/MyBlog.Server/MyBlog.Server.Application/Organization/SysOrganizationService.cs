using MyBlog.Server.Application.Organization.Dtos;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Organization
{
    /// <summary>
    /// 组织机构管理
    /// </summary>
    public class SysOrganizationService : BaseService<SysOrganization>
    {
        private readonly IRepository<SysOrganization> _repository;

        public SysOrganizationService(IRepository<SysOrganization> repository) : base(repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 组织机构列表查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SysOrgPageOutput>> Page([FromQuery] string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var list = await this._repository.Where(x => x.Name == name).ToListAsync();
                return list.Adapt<List<SysOrgPageOutput>>();
            }

            var data = await this._repository.AsQueryable().OrderBy(x => x.Sort)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return data.Adapt<List<SysOrgPageOutput>>();
        }

        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task addOrg(AddOrgInput dto)
        {
            var org = dto.Adapt<SysOrganization>();
            await this._repository.InsertAsync(org);
        }

        /// <summary>
        /// 更新组织机构代码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task UpdateOrg(UpdateOrgInput dto)
        {
            var org = await this._repository.FindOrDefaultAsync(dto.Id);
            if (org == null)
            {
                throw Oops.Oh("无效参数");
            }
            dto.Adapt(org);
            await this._repository.UpdateAsync(org);

        }

        /// <summary>
        /// 获取机构下拉选项
        /// </summary>
        /// <returns></returns>
        [Description("获取机构下拉选项")]
        [HttpGet]
        public async Task<List<TreeSelectOutput>> TreeSelect()
        {
            var list = await _repository.AsQueryable().ToListAsync();
            return list.Adapt<List<TreeSelectOutput>>();
        }
    }
}
