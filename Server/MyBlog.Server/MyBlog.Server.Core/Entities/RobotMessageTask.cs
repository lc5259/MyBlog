
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyBlog.Server.Core.Entities
{
   // [Entity("robot_message_task", "机器人消息任务")]
    public partial class RobotMessageTask : EntityBase
    {     

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember, Column, Comment("消息内容")]
        public string content { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        [DataMember, Column, Comment("执行时间")]
        public string runtime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember, Column, Comment("消息类型")]
        public string message_type { get; set; }

        /// <summary>
        /// 消息类型名称
        /// </summary>
        [DataMember, Column, Comment("消息类型名称")]
        public string message_type_name { get; set; }

        /// <summary>
        /// 机器人
        /// </summary>
        [DataMember, Column, Comment("机器人")]
        public string robotid { get; set; }

        /// <summary>
        /// 机器人名称
        /// </summary>
        [DataMember, Column, Comment("机器人名称")]
        public string robotid_name { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        [DataMember, Column, Comment("任务状态")]
        public string job_state { get; set; }

        /// <summary>
        /// 任务状态名称
        /// </summary>
        [DataMember, Column, Comment("任务状态名称")]
        public string job_state_name { get; set; }
    }
}

