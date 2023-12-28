using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Application.User.Dto.userInfoDto
{
    public class UpdateUserInfoDto: AddUserInfo
    {
        ///// <summary>
        ///// id索引
        ///// </summary>
        public int Id { get; set; }
    }
}
