
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sixpence.Web.Module.SysAttrs
{
  //  [KeyAttributes("该实体字段已存在", "entityid", "code")]
   // [Entity("sys_attrs", "实体字段")]
    public partial class SysAttrs : EntityBase
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
        /// 实体id
        /// </summary>
        [DataMember, Column, Comment("实体id")]
        public string entityid { get; set; }

        /// <summary>
        /// 实体名
        /// </summary>
        [DataMember, Column, Comment("实体名")]
        public string entityid_name { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        [DataMember, Column, Comment("字段类型")]
        public string attr_type { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        [DataMember, Column, Comment("字段长度")]
        public int? attr_length { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        [DataMember, Column, Comment("是否必填")]
        public bool? isrequire { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        [DataMember, Column, Comment("默认值")]
        public string default_value { get; set; }
    }
}