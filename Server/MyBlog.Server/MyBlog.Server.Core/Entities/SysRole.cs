
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace MyBlog.Server.Core.Entities
{
 //   [Entity("sys_role", "角色")]
    public partial class SysRole : EntityBase
    {
       

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember, Column, Comment("描述")]
        public string Comment { get; set; }

        /// <summary>
        /// 是否基础角色
        /// </summary>
        [DataMember, Column, Comment("是否基础角色")]
        public bool? is_basic { get; set; }

        /// <summary>
        /// 是否基础角色
        /// </summary>
        [DataMember, Column, Comment("是否基础角色")]
        public string is_basic_name { get; set; }

        /// <summary>
        /// 继承角色
        /// </summary>
        [DataMember, Column, Comment("继承角色")]
        public string parent_roleid { get; set; }

        /// <summary>
        /// 继承角色
        /// </summary>
        [DataMember, Column, Comment("继承角色")]
        public string parent_roleid_name { get; set; }
    }
}

