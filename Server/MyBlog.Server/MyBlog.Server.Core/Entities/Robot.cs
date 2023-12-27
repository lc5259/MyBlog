
using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace MyBlog.Server.Core.Entities
{
    //[ "机器人")]
    public partial class Robot : EntityBase
    {
       
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 钩子地址
        /// </summary>
        [DataMember, Column, Comment("钩子地址")]
        public string hook { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [DataMember, Column, Comment("说明")]
        public string Comment { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember, Column, Comment("类型")]
        public string robot_type { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [DataMember, Column, Comment("类型名称")]
        public string robot_type_name { get; set; }
    }
}

