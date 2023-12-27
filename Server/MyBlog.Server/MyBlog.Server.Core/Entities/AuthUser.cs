using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Server.Core.Entities
{
    //Entity 默认包括 id，CreatedTime，UpdatedTime 字段
    public class AuthUser: Entity
    {
        [Column,  Comment("名称")]
        public string name { get; set; }

        [Column,  Comment("编码")]
        public string code { get; set; }

        [Column,  Comment("密码")]
        public string password { get; set; }

        [Column, Comment("角色权限id")]
        public string roleid { get; set; }

        [Column,  Comment("角色权限名")]
        public string roleid_name { get; set; }

        [Column,  Comment("用户id")]
        public string user_infoid { get; set; }

        [Column,  Comment("锁定")]
        public bool? is_lock { get; set; }

        [Column,  Comment("锁定")]
        public string is_lock_name { get; set; }

        [Column,  Comment("上次登录时间")]
        public DateTime? last_login_time { get; set; }

        [Column,  Comment("尝试登录次数")]
        public int? try_times { get; set; }
    }
}
 