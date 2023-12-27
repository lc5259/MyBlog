
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyBlog.Server.Core.Entities
{
   // [Entity("sys_entity", "实体")]
  //  [KeyAttributes("实体不能重复创建", "code")]
    public partial class SysEntity : EntityBase
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
    }
}