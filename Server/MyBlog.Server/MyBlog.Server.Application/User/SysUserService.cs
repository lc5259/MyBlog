using EasyCaching.Core;
using Furion.Schedule;
using Microsoft.AspNetCore.Http;
using MyBlog.Server.Application.Auth;
using MyBlog.Server.Application.Config;
using MyBlog.Server.Application.Menu;
using MyBlog.Server.Application.User.Dto;
using MyBlog.Server.Core;
using MyBlog.Server.Core.Config;
using MyBlog.Server.Core.Entities;
using MyBlog.Server.Core.Extensions;

//using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace MyBlog.Server.Application.User
{
    public class SysUserService : BaseService<SysUser>
    {
        

        private readonly IRepository<SysUser> _repository;
        private readonly IRepository<SysUserRole> _userRoleRepository;
        private readonly IRepository<SysOrganization> _orgRepository;
        private readonly SysMenuService _sysMenuService;
        private readonly CustomConfigService _customConfigService;
        private readonly AuthManager _authManager;
        private readonly IEasyCachingProvider _easyCachingProvider;
        private readonly IIdGenerator _idGenerator;

        public SysUserService(IRepository<SysUser> repository,
            IRepository<SysUserRole> userRoleRepository,
            IRepository<SysOrganization> orgRepository,
            SysMenuService sysMenuService,
            CustomConfigService customConfigService,
            AuthManager authManager,
            IEasyCachingProvider easyCachingProvider,
            IIdGenerator idGenerator) : base(repository)
        {
            _repository = repository;
            _userRoleRepository = userRoleRepository;
            _orgRepository = orgRepository;
            _sysMenuService = sysMenuService;
            _customConfigService = customConfigService;
            _authManager = authManager;
            _easyCachingProvider = easyCachingProvider;
            _idGenerator = idGenerator;
        }

        /// <summary>
        /// 系统用户分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("系统用户分页查询")]
        [HttpGet]
        public async Task<PagedList<SysUserPageOutput>> Page([FromQuery] QuerySysUserInput dto)
        {
            List<long> orgIdList = new List<long>();
            if (dto.OrgId.HasValue)
            {
                orgIdList.Add(dto.OrgId.Value);

                var list = await _orgRepository.AsQueryable()
                             .Include(u => u.Children)
                             .Where(u => u.Id == dto.OrgId)
                             .ToListAsync();

                //var list = await _orgRepository.AsQueryable().ToChildListAsync(x => x.ParentId, dto.OrgId);

                orgIdList.AddRange(list.Select(x => x.Id));
            }
            return await _repository.AsQueryable()
                .Where(x => x.Id > 1)
                .Where(!string.IsNullOrWhiteSpace(dto.Name), x => x.Name.Contains(dto.Name))
                .Where(!string.IsNullOrWhiteSpace(dto.Account), x => x.Account.Contains(dto.Account))
                .Where(!string.IsNullOrWhiteSpace(dto.Mobile), x => x.Mobile.Contains(dto.Mobile))
                .Where(orgIdList.Any(), x => orgIdList.Contains(x.OrgId))
                .Select(x => new SysUserPageOutput
                {
                    Name = x.Name,
                    Status = x.Status,
                    Account = x.Account,
                    Birthday = x.Birthday,
                    Mobile = x.Mobile,
                    Gender = x.Gender,
                    NickName = x.NickName,
                    CreatedTime = x.CreatedTime,
                    Email = x.Email,
                    Id = x.Id
                })
                .ToPagedListAsync();
            //这里先不做映射mapper ，感觉用映射会麻烦
        }

        /// <summary>
        /// 添加系统用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [UnitOfWork, HttpPost("add")]
        [DisplayName("添加系统用户")]
        public async Task AddUser(AddSysUserInput dto) 
        {
            var user = dto.Adapt<SysUser>();
            user.Id = _idGenerator.NextId();
            string encode = _idGenerator.Encode(user.Id);
            var setting =await this._customConfigService.Get<SysSecuritySetting>();
            user.Password = MD5Encryption.Encrypt(encode+ "123456");

            var roles = dto.Roles.Select(x => new SysUserRole
            { 
                RoleId = x,
                UserId = user.Id
            }).ToList();

          
            await this._repository.InsertAsync(user);
            await this._userRoleRepository.InsertAsync(roles);

        }

        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("更新系统用户信息")]
        [UnitOfWork, HttpPut("edit")]
        public async Task UpdateUser(UpdateSysUserInput dto) { }

        /// <summary>
        /// 系统用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UpdateSysUserInput> Detail([FromQuery] long id) 
        {
            return null;
        }

        /// <summary>
        /// 重置系统用户密码
        /// </summary>
        /// <returns></returns>
        [DisplayName("重置系统用户密码")]
        [HttpPatch]
        public async Task Reset(ResetPasswordInput dto) { }

        /// <summary>
        /// 获取当前登录用户的信息
        /// </summary>
        /// <returns></returns>
        [DisplayName("获取登录用户的信息")]
        [HttpGet]
        public async Task<SysUserInfoOutput> CurrentUserInfo() { return null; }

        /// <summary>
        /// 用户修改账户密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("用户修改账户密码")]
        [HttpPatch]
        public async Task ChangePassword(ChangePasswordOutput dto) { }

        /// <summary>
        /// 用户修改头像
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [DisplayName("用户修改头像")]
        [HttpPatch]
        public async Task UploadAvatar([FromBody] string url) { }

        /// <summary>
        /// 系统用户修改自己的信息
        /// </summary>
        /// <returns></returns>
        [DisplayName("系统用户修改个人信息")]
        [HttpPatch("updateCurrentUser")]
        public async Task UpdateCurrentUser(UpdateCurrentUserInput dto) { }
    }
}
