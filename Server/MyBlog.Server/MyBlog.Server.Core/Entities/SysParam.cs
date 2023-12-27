
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyBlog.Server.Core.Entities
{
 //   [Entity("sys_param", "选项")]
    public partial class SysParam : EntityBase
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
        /// 选项集
        /// </summary>
        [DataMember, Column, Comment("选项集")]
        public string sys_paramGroupId { get; set; }

        /// <summary>
        /// 选项集名
        /// </summary>
        [DataMember, Column, Comment("选项集名")]
        public string sys_paramgroupid_name { get; set; }
    }
}