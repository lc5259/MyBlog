using EasyCaching.Core;
using Microsoft.OpenApi.Extensions;
using MyBlog.Server.Application.Auth;
using MyBlog.Server.Core.Entities;

namespace MyBlog.Server.Application.Menu;
/// <summary>
/// 系统菜单管理
/// </summary>
public class SysMenuService : BaseService<SysMenu>, ITransient
{
    private readonly IRepository<SysMenu> _repository;
    private readonly IEasyCachingProvider _easyCachingProvider;
    private readonly AuthManager _authManager;

    public SysMenuService(IRepository<SysMenu> repository,
        IEasyCachingProvider easyCachingProvider,
        AuthManager authManager) : base(repository)
    {
        this._repository = repository;
        this._easyCachingProvider = easyCachingProvider;
        this._authManager = authManager;
    }
}