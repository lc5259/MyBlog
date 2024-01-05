using EasyCaching.Core;
using Furion.Schedule;
using Microsoft.AspNetCore.Http;
using MyBlog.Server.Application.Auth;
using MyBlog.Server.Application.Config;
using MyBlog.Server.Application.Menu;
using MyBlog.Server.Application.User.Dto;
using MyBlog.Server.Core;
using MyBlog.Server.Core.Config;
using MyBlog.Server.Core.Const;
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
        //private readonly SysMenuService _sysMenuService;
        private readonly CustomConfigService _customConfigService;
        private readonly AuthManager _authManager;
        private readonly IEasyCachingProvider _easyCachingProvider;
        private readonly IIdGenerator _idGenerator;

        public SysUserService(IRepository<SysUser> repository,
            IRepository<SysUserRole> userRoleRepository,
            IRepository<SysOrganization> orgRepository,
            //SysMenuService sysMenuService,
            CustomConfigService customConfigService,
            AuthManager authManager,
            IEasyCachingProvider easyCachingProvider,
            IIdGenerator idGenerator) : base(repository)
        {
            _repository = repository;
            _userRoleRepository = userRoleRepository;
            _orgRepository = orgRepository;
            //_sysMenuService = sysMenuService;
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
            try
            {
                var user = dto.Adapt<SysUser>();
                //user.Id = _idGenerator.NextId(); --sqlserver数据库不允许为自增字段赋值。
                string encode = _idGenerator.Encode(user.Id);
                var setting = await this._customConfigService.Get<SysSecuritySetting>();
                user.Password = MD5Encryption.Encrypt(encode + "123456");

                var roles = dto.Roles.Select(x => new SysUserRole
                {
                    RoleId = x,
                    UserId = user.Id
                }).ToList();


                await this._repository.InsertAsync(user);
                await this._userRoleRepository.InsertAsync(roles);
            }
            catch (Exception e)
            {

                throw;
            }
            

        }

        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("更新系统用户信息")]
        [UnitOfWork, HttpPut("edit")]
        public async Task UpdateUser(UpdateSysUserInput dto) 
        {
            var user = await this._repository.FindAsync(dto.Id);
            if (user == null) 
            {
                throw new ArgumentException("无效参数");
            }
            dto.Adapt(user);
            //user = dto.Adapt<SysUser>();
            var roles = dto.Roles.Select(x => new SysUserRole()
            { 
                RoleId = x,
                UserId = user.Id
            });

            await this._repository.UpdateAsync(user);
            await this._userRoleRepository.DeleteAsync( user.Id);
            await this._userRoleRepository.InsertAsync(roles );
            await this._easyCachingProvider.RemoveByPrefixAsync(CacheConst.PermissionKey);
        }

        /// <summary>
        /// 系统用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UpdateSysUserInput> Detail([FromQuery] long id) 
        {
            var roles =  this._userRoleRepository.Where(r => r.UserId == id)
                                .Select(x => x.RoleId).ToList();

            return await this._repository.Where(x => x.Id == id)
                .Select(x => new UpdateSysUserInput() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    OrgId = x.OrgId,
                    Account = x.Account,
                    Mobile = x.Mobile,
                    Remark = x.Remark,
                    Birthday = x.Birthday,
                    Email = x.Email,
                    Gender = x.Gender,
                    NickName = x.NickName,
                    Roles = roles
                }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 重置系统用户密码
        /// </summary>
        /// <returns></returns>
        [DisplayName("重置系统用户密码")]
        [HttpPatch]
        public async Task Reset(ResetPasswordInput dto) 
        {
            var user = await this._repository.FindAsync(dto.Id);
            string password = MD5Encryption.Encrypt(_idGenerator.Encode(dto.Id) + dto.Password);
            user.Password= password;
            await this._repository.UpdateIncludeAsync(user, new[]{nameof(user.Password)});
           
        }

        /// <summary>
        /// 获取当前登录用户的信息
        /// </summary>
        /// <returns></returns>
        [DisplayName("获取登录用户的信息")]
        [HttpGet]
        public async Task<SysUserInfoOutput> CurrentUserInfo() 
        {
            var userId = _authManager.UserId;
            var user = await this._repository.FindAsync(userId);
            if (user == null) { throw new Exception("用户为空"); };
            var sysuserInfoOut = user.Adapt<SysUserInfoOutput>();
            sysuserInfoOut.OrgName = this._orgRepository.Where(o => o.Id == user.OrgId)
                    .Select(o => o.Name).ToString();

            return sysuserInfoOut;
        }

        /// <summary>
        /// 用户修改账户密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [DisplayName("用户修改账户密码")]
        [HttpPatch]
        public async Task ChangePassword(ChangePasswordOutput dto) 
        {
            var userId = _authManager.UserId;
            var encode = _idGenerator.Encode(userId);
            string pwd = MD5Encryption.Encrypt($"{encode}{dto.OriginalPwd}");

            if (!await this._repository.AnyAsync(x => x.Id == userId  && x.Password == pwd))
            {
                throw Oops.Bah("原密码错误！");
            }
            pwd = MD5Encryption.Encrypt($"{encode}{dto.Password}");

            SysUser user = await this._repository.FindAsync(userId);
            user.Password = pwd;
            await this._repository.UpdateIncludeAsync(user, new[] { nameof(user.Password)});

        }

        /// <summary>
        /// 用户修改头像
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [DisplayName("用户修改头像")]
        [HttpPatch]
        public async Task UploadAvatar([FromBody] string url)
        { 
            long userId = _authManager.UserId;
            var user = await this._repository.FindAsync(userId);
            await this._repository.UpdateIncludeAsync(user, new[] { nameof(user.Avatar)});
        }

        /// <summary>
        /// 系统用户修改自己的信息
        /// </summary>
        /// <returns></returns>
        [DisplayName("系统用户修改个人信息")]
        [HttpPatch("updateCurrentUser")]
        public async Task UpdateCurrentUser(UpdateCurrentUserInput dto)
        {
            long userId = _authManager.UserId;
            var user = await this._repository.FindAsync(userId);
            dto.Adapt(user);
            await this._repository.UpdateAsync(user);
        }
    }
}
