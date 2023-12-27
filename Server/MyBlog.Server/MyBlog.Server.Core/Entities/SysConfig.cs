
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyBlog.Server.Core.Entities
{
   // [Entity("sys_config", "系统配置")]
    public partial class SysConfig : EntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember, Column, Comment("编码")]
        public string code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember, Column, Comment("描述")]
        public string Comment { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DataMember, Column, Comment("值")]
        public string value { get; set; }
    }
}