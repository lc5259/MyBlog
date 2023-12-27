
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace MyBlog.Server.Core.Entities
{
    public partial class MailVertification : EntityBase
    {    
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [DataMember, Column, Comment("邮箱地址")]
        public string mail_address { get; set; }

        /// <summary>
        /// 登录请求信息
        /// </summary>
        [DataMember, Column, Comment("登录请求信息")]
        public string login_request { get; set; }
        //public JToken login_request { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [DataMember, Column, Comment("过期时间")]
        public DateTime? expire_time { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember, Column, Comment("消息内容")]
        public string content { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        [DataMember, Column, Comment("是否激活")]
        public bool? is_active { get; set; }

        /// <summary>
        /// 激活类型
        /// </summary>
        [DataMember, Column, Comment("激活类型")]
        public string mail_type { get; set; }
    }

    public enum MailType
    {
        Activation,
        ResetPassword
    }
}
