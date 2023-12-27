
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyBlog.Server.Core.Entities
{
  //  [Entity("sys_paramgroup", "选项集")]
    public partial class SysParamGroup : EntityBase
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