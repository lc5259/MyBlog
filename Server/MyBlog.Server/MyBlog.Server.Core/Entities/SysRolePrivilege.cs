
using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace MyBlog.Server.Core.Entities
{
   // [Entity("sys_role_privilege", "角色权限")]
    public partial class SysRolePrivilege : EntityBase
    {
       
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [DataMember, Column, Comment("角色id")]
        public string sys_roleid { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [DataMember, Column, Comment("角色名")]
        public string sys_roleid_name { get; set; }

        /// <summary>
        /// 权限值
        /// </summary>
        [DataMember, Column, Comment("权限值")]
        public int? privilege { get; set; }

        /// <summary>
        /// 对象id
        /// </summary>
        [DataMember, Column, Comment("对象id")]
        public string objectid { get; set; }

        /// <summary>
        /// 对象名
        /// </summary>
        [DataMember, Column, Comment("对象名")]
        public string objectid_name { get; set; }

        /// <summary>
        /// 对象类型
        /// </summary>
        [DataMember, Column, Comment("对象类型")]
        public string object_type { get; set; }
    }
}

