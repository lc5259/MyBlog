using EasyCaching.Core;
using Furion.DatabaseAccessor;
using MyBlog.Server.Application.Role.Dtos;
using MyBlog.Server.Core.Const;
using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.Role
{
    public class SysRoleService : BaseService<SysRole>
    {
        private readonly IRepository<SysRole> _sysRoleRepository;
        private readonly IRepository<SysRoleMenu> _sysRoleMenuRepository;
        private readonly IRepository<SysMenu> _sysMenuRepository;
        private readonly IEasyCachingProvider _easyCachingProvider;
        private readonly IIdGenerator _idGenerator;


        public SysRoleService(IRepository<SysRole> sysRoleRepository,
        IRepository<SysRoleMenu> sysRoleMenuRepository,
        IRepository<SysMenu> sysMenuRepository,
        IEasyCachingProvider easyCachingProvider,
        IIdGenerator idGenerator) : base(sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
            _sysRoleMenuRepository = sysRoleMenuRepository;
            this._sysMenuRepository = sysMenuRepository;
            _easyCachingProvider = easyCachingProvider;
            _idGenerator = idGenerator;
        }

        /// <summary>
        /// 角色分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedList<SysRolePageOutput>> Page([FromQuery] SysRoleQueryInput dto)
        {
            return await this._sysRoleRepository
                .Where(!string.IsNullOrEmpty(dto.Name), x => x.Name.Contains(dto.Name))
                .OrderBy(x => x.Sort)
                .Select(x => new SysRolePageOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedTime = x.CreatedTime,
                    Status = x.Status,
                    Code = x.Code,
                    Sort = x.Sort,
                    Remark = x.Remark
                }).ToPagedListAsync();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [UnitOfWork]
        public async Task addRole(AddSysRoleInput dto)
        {
            if (await this._sysRoleRepository.AnyAsync(s => s.Code == dto.Code))
            {
                throw Oops.Oh("角色已存在！");
            }

            var role = dto.Adapt<SysRole>();
            var roleMenus = dto.Menus.Select(x => new SysRoleMenu()
            {
                MenuId = x,
                RoleId = role.Id,
            });

            await this._sysRoleRepository.InsertAsync(role);
            await this._sysRoleMenuRepository.InsertAsync(roleMenus);

        }
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [UnitOfWork]
        public async Task UpdateRole(UpdateSysRoleInput dto)
        {
            var role = await this._sysRoleRepository.FindOrDefaultAsync(dto.Id);
            if (role == null)
            {
                throw Oops.Oh("无效参数");
            }
            if (await this._sysRoleRepository.AnyAsync(x => x.Id == dto.Id && x.Code == dto.Code))
            {
                throw Oops.Oh("角色已存在");
            }
            dto.Adapt(role);

            var roleMenu = dto.Menus.Select(x => new SysRoleMenu()
            {
                MenuId = x,
                RoleId = role.Id,
            });
            await this._sysRoleRepository.UpdateAsync(role);
            await this._sysRoleMenuRepository.UpdateAsync(roleMenu);
            await this._easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
        }

        /// <summary>
        /// 获取角色可访问的菜单和按钮id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<long>> GetRoleMenu([FromQuery] long id)
        {
            var date = from p in _sysRoleRepository.AsQueryable()
                   join d in _sysRoleMenuRepository.AsQueryable() on p.Id equals d.RoleId
                   join f in _sysMenuRepository.AsQueryable() on d.MenuId equals f.Id
                   where (p.Id == id && f.Status == AvailabilityStatus.Enable)
                   select   d.MenuId;
            return date.ToList();

        }

        /// <summary>
        /// 修改角色状态
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task SetStatus(AvailabilityDto dto)
        {
            var role = await this._sysRoleRepository.FindOrDefaultAsync(dto.Id);
            role.Status = dto.Status;
            await this._sysRoleRepository.UpdateIncludeAsync(role, new[]{ nameof(role.Status)});
            await _easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(KeyDto dto)
        {
           await  this._sysRoleRepository.DeleteAsync(dto.Id);
            await _easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
        }

        /// <summary>
        /// 角色下拉选项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SelectOutput>> RoleSelect()
        {
           return  await this._sysRoleRepository.AsQueryable().Where(x => x.Status == AvailabilityStatus.Enable)
                        .OrderBy(x => x.Sort)
                        .OrderBy(x => x.Id)
                        .Select(x => new SelectOutput()
                        {
                            Value = x.Id,
                            Label = x.Name
                        }).ToListAsync();
           
        }

    }
}
