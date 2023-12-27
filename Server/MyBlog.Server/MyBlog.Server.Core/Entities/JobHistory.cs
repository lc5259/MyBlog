
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace MyBlog.Server.Core.Entities
{
    public class JobHistory : EntityBase
    {
       
        /// <summary>
        /// 作业名
        /// </summary>
        [DataMember, Column, Comment("作业名")]
        public string job_name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember, Column, Comment("开始时间")]
        public DateTime? start_time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember, Column, Comment("结束时间")]
        public DateTime? end_time { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember, Column, Comment("状态")]
        public string status { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        [DataMember, Column, Comment("错误原因")]
        public string error_msg { get; set; }
    }
}
