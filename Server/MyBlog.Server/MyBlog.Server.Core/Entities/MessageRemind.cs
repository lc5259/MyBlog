
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyBlog.Server.Core.Entities
{
    // "消息提醒")]
    public partial class MessageRemind : EntityBase
    {
       
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 接收人id
        /// </summary>
        [DataMember, Column, Comment("接收人id")]
        public string receiverId { get; set; }

        /// <summary>
        /// 接收人名称
        /// </summary>
        [DataMember, Column, Comment("接收人名称")]
        public string receiverId_name { get; set; }

        /// <summary>
        /// 是否阅读
        /// </summary>
        [DataMember, Column, Comment("是否阅读")]
        public bool? is_read { get; set; }

        /// <summary>
        /// 是否阅读
        /// </summary>
        [DataMember, Column, Comment("是否阅读")]
        public string is_read_name { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember, Column, Comment("消息内容")]
        public string content { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember, Column, Comment("消息类型")]
        public string message_type { get; set; }
    }
}

