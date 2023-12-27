
using Furion.DatabaseAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace MyBlog.Server.Core.Entities
{
  //  [Entity("version_script_execution_log", "版本脚本执行日志")]
    public class VersionScriptExecutionLog : EntityBase
    {
        

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember, Column, Comment("名称")]
        public string name { get; set; }

        /// <summary>
        /// 是否执行成功
        /// </summary>
        [DataMember, Column, Comment("是否执行成功")]
        public bool? is_success { get; set; }
    }
}
