
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Sixpence.Web.Entity
{
  //  [Entity("sys_file", "系统文件")]
    public partial class SysFile : EntityBase
    {
       

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 文件对象
        /// </summary>
        [DataMember, Column, Comment("文件对象")]
        public string objectId { get; set; }

        /// <summary>
        /// 真实文件名
        /// </summary>
        [DataMember, Column, Comment("真实文件名")]
        public string real_name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [DataMember, Column, Comment("文件路径")]
        public string file_path { get; set; }

        /// <summary>
        /// 哈希值
        /// </summary>
        [DataMember, Column, Comment("哈希值")]
        public string hash_code { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember, Column, Comment("文件类型")]
        public string file_type { get; set; }

        /// <summary>
        /// 内容类型
        /// </summary>
        [DataMember, Column, Comment("内容类型")]
        public string content_type { get; set; }
    }
}