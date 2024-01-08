using EasyCaching.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using MyBlog.Server.Application.Auth;
using MyBlog.Server.Application.Menu.Dtos;
using MyBlog.Server.Core.Const;
using MyBlog.Server.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyBlog.Server.Application.Menu;
/// <summary>
/// 系统菜单管理
/// </summary>
public class SysMenuService : BaseService<SysMenu>, ITransient
{
    private readonly IRepository<SysMenu> _repository;
    private readonly IRepository<SysRoleMenu> _sysRoleMenuRepository;
    private readonly IRepository<SysRole> _sysRoleRepository;
    private readonly IRepository<SysUserRole> _sysUserRoleRepository;
    private readonly IEasyCachingProvider _easyCachingProvider;
    private readonly AuthManager _authManager;

    public SysMenuService(IRepository<SysMenu> repository,
        IRepository<SysRoleMenu> sysRoleMenuRepository,
        IRepository<SysRole> sysRoleRepository,
        IRepository<SysUserRole> sysUserRoleRepository,
        IEasyCachingProvider easyCachingProvider,
        AuthManager authManager) : base(repository)
    {
        this._repository = repository;
        this._sysRoleMenuRepository = sysRoleMenuRepository;
        this._sysRoleRepository = sysRoleRepository;
        this._sysUserRoleRepository = sysUserRoleRepository;
        this._easyCachingProvider = easyCachingProvider;
        this._authManager = authManager;
    }

    /// <summary>
    /// 菜单列表查询
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<SysMenuPageOutput>> Page([FromQuery] string name)
    {
        if (this._authManager.IsSuperAdmin)
        {
            var data = this._repository.AsQueryable()
                .OrderBy(x => x.Name)
                .OrderBy(x => x.Id);

            if (!string.IsNullOrWhiteSpace(name))
            {
                var list = await data.Where(x => x.Name.Contains(name)).ToListAsync();
                return list.Adapt<List<SysMenuPageOutput>>();
            }
            return data.ToList().Adapt<List<SysMenuPageOutput>>();
        }
        else
        {
            long userId = this._authManager.UserId;
            var data = from m in this._repository.AsQueryable()
                       join rm in this._sysRoleMenuRepository.AsQueryable() on m.Id equals rm.MenuId
                       join sr in this._sysRoleRepository.AsQueryable() on rm.RoleId equals sr.Id
                       join ur in this._sysUserRoleRepository.AsQueryable() on sr.Id equals ur.RoleId
                       where sr.Status == AvailabilityStatus.Enable && ur.UserId == userId
                       select m;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var list = await data.Where(x => x.Name.Contains(name)).Distinct().OrderBy(x => x.Sort).OrderBy(x => x.Id).ToListAsync();
                return list.Adapt<List<SysMenuPageOutput>>();
            }
            return  data.Where(x => x.Status == AvailabilityStatus.Enable).OrderBy(x => x.Sort).OrderBy(x => x.Id).ToListAsync().Adapt<List<SysMenuPageOutput>>();

        }
    }

    /// <summary>
    /// 添加菜单/按钮
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task AddMeun(AddSysMenuInput dto)
    {
        SysMenu sysMenu = dto.Adapt<SysMenu>();
        if (sysMenu.Type == MenuType.Button)
        {
            sysMenu.Link = sysMenu.Icon = sysMenu.Component = sysMenu.Path = sysMenu.Redirect = sysMenu.RouteName = null;
        }
        else
        {
            if (await this._repository.AnyAsync(x => x.RouteName.ToLower() == dto.RouteName.ToLower()))
            {
                throw Oops.Bah("路由名称已存在");
            }
            sysMenu.Code = null;
        }
        await this._repository.InsertAsync(sysMenu);
        await this._easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
    }

    /// <summary>
    /// 更新菜单/按钮
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task UpdateMenu(UpdateSysMenuInput dto)
    {
        SysMenu sysMenu = await this._repository.FindOrDefaultAsync(dto.Id);
        if (sysMenu != null) { throw Oops.Oh(" 无效参数！"); }
        if (sysMenu.Type != MenuType.Button  && await this._repository.AnyAsync(x => x.RouteName.ToLower() == dto.RouteName.ToLower() && x.Id != dto.Id))
        {
            throw Oops.Bah("路由名称已存在");
        }
        //检查菜单父子关系受否存在循环引用
        if (dto.ParentId.HasValue && dto.ParentId != sysMenu.ParentId)
        {
            List<SysMenu> list = await this._repository.Include(u => u.Children).Select(x => x.Children).FirstOrDefaultAsync();
            if (list.Any(x => x.Id == dto.ParentId))
            {
                throw Oops.Oh($"请勿将当前 {dto.Type.GetDisplayName()} 的父级菜单设置为它的子集。");
            }
        }
        dto.Adapt(sysMenu);
        if (sysMenu.Type == MenuType.Button)
        {
            sysMenu.Link = sysMenu.Icon = sysMenu.Component = sysMenu.Path = sysMenu.Redirect = sysMenu.RouteName = null;
        }
        else
        {
            
            sysMenu.Code = null;
        }
        await this._repository.UpdateAsync(sysMenu);
        await this._easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
    }

    /// <summary>
    /// 根据菜单id 获取系统菜单详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SysMenuDetailOutput> Detail([FromQuery] long id)
    {
        return await this._repository.AsQueryable().Where(x => x.Id == id)
                        .Select(x => new SysMenuDetailOutput
                        {
                            Id = x.Id,
                            Name = x.Name,
                            ParentId = x.ParentId,
                            Status = x.Status,
                            Code = x.Code,
                            Sort = x.Sort,
                            Component = x.Component,
                            Icon = x.Icon,
                            IsFixed = x.IsFixed,
                            IsIframe = x.IsIframe,
                            IsKeepAlive = x.IsKeepAlive,
                            IsVisible = x.IsVisible,
                            Link = x.Link,
                            Remark = x.Remark,
                            Path = x.Path,
                            Redirect = x.Redirect,
                            RouteName = x.RouteName,
                            Type = x.Type
                        }).FirstAsync();
            
    }
    /// <summary>
    /// 菜单下拉树
    /// </summary>
    /// <returns></returns>
    [DisplayName("菜单下拉树")]
    [HttpGet]
    public async Task<List<TreeSelectOutput>> TreeSelect()
    {
        var list = await this._repository.AsQueryable()
            .OrderBy(x => x.Sort)
            .OrderBy(x => x.Id)
            .Include(x => x.Children)
            .ToListAsync();
        return list.Adapt<List<TreeSelectOutput>>();
    }

    /// <summary>
    /// 删除菜单/按钮
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [DisplayName("删除菜单/按钮"), HttpDelete("delete")]
    public override async Task Delete(KeyDto dto)
    {
        await this._repository.DeleteAsync(dto);
        await _easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
    }

    /// <summary>
    /// 修改菜单/按钮状态
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [DisplayName("修改菜单/按钮状态"), HttpPut("setStatus")]
    public override async Task SetStatus(AvailabilityDto dto)
    {
        var data =await this._repository.FindAsync(dto.Id);
        data.Status = dto.Status;
        await this._repository.UpdateIncludeAsync(data, new[] { nameof(data.Status) });
        await _easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
    }

    /// <summary>
    /// 获取当前登录用户可用菜单
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<RouterOutput>> PermissionMenus()
    {
        long userId = this._authManager.UserId;
        var value = await _easyCachingProvider.GetAsync($"{CacheConst.PermissionMenuKey}{userId}", async () =>
        {
            var queryable = this._repository.AsQueryable()
                .Where(x => x.Status == AvailabilityStatus.Enable)
                .OrderBy(x => x.Sort)
                .OrderBy(x => x.Id);
            List<SysMenu> list = null;
            if (_authManager.IsSuperAdmin)
            {
                list = await queryable
                    .Where(x => x.Type != MenuType.Button).Include(x => x.Children).ToListAsync();
                    
            }
            else
            {
                var data = from sr in this._sysRoleRepository.AsQueryable()
                                  join ur in this._sysUserRoleRepository.AsQueryable()  on sr.Id equals ur.RoleId
                                  join sru in this._sysRoleMenuRepository.AsQueryable() on sr.Id equals sru.RoleId
                                  join sm in this._repository.AsQueryable() on sru.MenuId equals sm.Id
                                  where sr.Status == AvailabilityStatus.Enable && ur.UserId == userId && sm.Status == AvailabilityStatus.Enable
                                  select sru.MenuId;
                List<long> menuIdList = data.ToList();

               


                var array = menuIdList.Select(x => x as object).ToArray();
                foreach (var item in array)
                {
                    list = await queryable.Include(x => x.Children).Where(x => x.ParentId == x.Id).ToListAsync();
                }
               
                RemoveButton(list);
            }
            return list.Adapt<List<RouterOutput>>();
        }, TimeSpan.FromDays(1));
        return value.Value ?? new List<RouterOutput>();
    }

    /// <summary>
    /// 移除菜单中的按钮
    /// </summary>
    /// <param name="menus"></param>
    void RemoveButton(List<SysMenu> menus)
    {
        for (int i = menus.Count - 1; i >= 0; i--)
        {
            if (menus[i].Type == MenuType.Button)
            {
                menus.Remove(menus[i]);
                continue;
            }
            if (menus[i].Children.Any())
            {
                RemoveButton(menus[i].Children);
            }
        }
    }

    /// <summary>
    /// 菜单按钮树
    /// </summary>
    /// <returns></returns>
    [DisplayName("菜单按钮树")]
    [HttpGet]
    public async Task<List<TreeSelectOutput>> TreeMenuButton()
    {
        long userId = _authManager.UserId;
        List<SysMenu> menus;
        if (_authManager.IsSuperAdmin)//超级管理员
        {
            menus = await this._repository.AsQueryable().Include(x => x.Children).Where(c => c.ParentId == null).ToListAsync();// 根节点条件
              
        }
        else
        {
            var data = from m in this._repository.AsQueryable()
                    join srm in this._sysRoleMenuRepository.AsQueryable() on m.Id equals srm.MenuId
                    join sr in this._sysRoleRepository.AsQueryable() on srm.RoleId equals sr.Id
                    join sur in this._sysUserRoleRepository.AsQueryable() on sr.Id equals sur.Id
                    where m.Status == AvailabilityStatus.Enable && sr.Status == AvailabilityStatus.Disable && sur.UserId == userId
                    select m;
            menus = await data.AsQueryable().Include(x => x.Children).Where(c => c.ParentId == null).ToListAsync();
           
        }

        return menus.Adapt<List<TreeSelectOutput>>();
    }

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <returns></returns>
    [NonAction]
    public async Task<bool> CheckPermission(string code)
    {
        if (_authManager.IsSuperAdmin) return true;
        var cache = await GetAuthButtonCodeList(_authManager.UserId);
        var output = cache.FirstOrDefault(x => x.Code.Contains(code, StringComparison.CurrentCultureIgnoreCase));
        return output?.Access ?? true;
    }

    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    [NonAction]
    public async Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId)
    {
        var cache = await _easyCachingProvider.GetAsync($"{CacheConst.PermissionButtonCodeKey}{userId}", async () =>
        {
            var data = from sr in this._sysRoleRepository.AsQueryable()
                       join sur in this._sysUserRoleRepository.AsQueryable() on  sr.Id equals sur.RoleId
                       join srm in this._sysRoleMenuRepository.AsQueryable() on sr.Id equals srm.RoleId
                       where sr.Status == AvailabilityStatus.Enable
                       select srm ;
            var queryable = data.ToList();



            //以下左连接代码有问题，注释掉，不想写了，后面前后的链条时候再写
            List<CheckPermissionOutput> list = null;
            //var list = await _sysMenuRepository.AsQueryable().LeftJoin(queryable, (menu, roleMenu) => menu.Id == roleMenu.MenuId)
            //       .Where(menu => menu.Type == MenuType.Button)
            //       .Select((menu, roleMenu) => new CheckPermissionOutput
            //       {
            //           Code = menu.Code,
            //           Access = SqlFunc.IIF(SqlFunc.IsNull(roleMenu.Id, 0) > 0 || menu.Status == AvailabilityStatus.Disable, true, false)
            //       }).ToListAsync();
            return list.Distinct().ToList();
        }, TimeSpan.FromDays(1));
        return cache.Value;
    }
}
