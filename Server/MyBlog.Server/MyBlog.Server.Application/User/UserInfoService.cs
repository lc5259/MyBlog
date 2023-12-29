using Furion.Schedule;
using Microsoft.AspNetCore.Http;
using MyBlog.Server.Application.User.Dto.userInfoDto;
using MyBlog.Server.Core;
//using MyBlog.Server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.User
{
    //public class UserInfoService : BaseService<UserInfo>
    //{
    //    private readonly IRepository<UserInfo> _repository;

    //    public UserInfoService(IRepository<UserInfo> repository) : base(repository)
    //    {
    //        this._repository = repository;
    //    }

    //    public  async Task<List<UserInfo>>  GetList()
    //    {
    //       var dsg = this._repository.AsEnumerable();
    //        return await this._repository.AsQueryable().ToListAsync<UserInfo>();
    //    }

    //    public async Task AddUser(AddUserInfo addUserInfo)
    //    {
    //        try
    //        {
    //            var userInfo = addUserInfo.Adapt<UserInfo>();
    //            //userInfo.Id = new
    //            //await new apire
    //            await this._repository.InsertAsync(userInfo);
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }
           
    //    }


    //    public async Task<ApiResult<UserInfo>> UpdateUser(UpdateUserInfoDto updateUserInfo)
    //    {
    //        if (await this._repository.FirstOrDefaultAsync(u => u.Id == updateUserInfo.Id) == null)
    //        {
    //            return new ApiResult<UserInfo> { 
    //                IsSuccess= true,
    //                Message = "用户不存在",
    //                Data = null
    //            };
                
    //        }
    //        var user = updateUserInfo.Adapt<UserInfo>();
    //       var result = await this._repository.UpdateNowAsync(user);

    //        return new ApiResult<UserInfo>
    //        {
    //            IsSuccess = true,
    //            //Data= result
    //        };
            
            
    //    }
    //}
}
